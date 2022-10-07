using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vsite.Battleship.Model;

namespace MainForm
{
    enum Player
    {
        Human,
        Computer
    }
    public partial class BattleshipForm : Form
    {
        private const int gridSize = 10;
        public readonly List<int> shipLengths = new List<int>() { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
        private const int gridButtonStartBattlePositionX = 20;  
        private const int gridButtonStartBattlePositionY = 30;    
        private List<GridButton> myFleetGridButtons;    
        private List<GridButton> computerGridButtons;
        private int myFleetShipsLeft;
        private int computerShipsLeft;
        private List<Label> gridLabelsMyFleet = new List<Label>();
        private List<Label> gridLabelsComputerFleet = new List<Label>();
        private Game game;
        private int buttonPlaceMyFleetCounter;

        public BattleshipForm()
        {
            InitializeComponent();
            buttonStartBattle.Enabled = false;
            computerGridButtons = DisplayButtonsGrid(Player.Computer, gridSize, gridSize);
        }
        private List<GridButton> DisplayButtonsGrid(Player player, int rows, int cols)
        {
            if (player == Player.Computer)
            {
                return DisplayComputer(rows, cols, gridButtonStartBattlePositionX + 10, gridButtonStartBattlePositionY);
            }

            var shipSquares = game.CreateMyFleet();
            return DisplayMyFleet(rows, cols, gridButtonStartBattlePositionX + 10, gridButtonStartBattlePositionY, shipSquares);
        }
        private List<GridButton> DisplayMyFleet(int rows, int cols, int positionX, int positionY, IEnumerable<Square> shipSquares)
        {
            var gridButtons = new List<GridButton>();

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (row == 0)
                    {
                        DisplayNumberingLabelMyFleet(positionX + 15 + 40 * col + col, positionY - 15, true, col);
                    }
                    if (col == 0)
                    {
                        DisplayNumberingLabelMyFleet(positionX - 20, positionY + 15 + row * 40 + row, false, row);
                    }

                    var gridButton = new GridButton(row, col, Player.Human, shipSquares.Any(s => s.Row == row && s.Column == col) ? GridButtonState.Ship : GridButtonState.Initial);
                    gridButton.Location = new System.Drawing.Point(positionX + col * 40 + col, positionY + row * 40 + row);
                    gridButton.Name = "buttonHuman_" + row + "_" + col;
                    gridButton.Size = new System.Drawing.Size(40, 40);
                    gridButton.Text = "";
                    gridButton.Click += ProcessButtonHit;

                    gridButtons.Add(gridButton);
                    groupBoxMyFleet.Controls.Add(gridButton);
                }
            }
            return gridButtons;
        }
        private List<GridButton> DisplayComputer(int rows, int cols, int positionX, int positionY)
        {
            var gridButtons = new List<GridButton>();
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    if (row == 0)
                    {
                        DisplayNumberingLabelComputer(positionX + 15 + 40 * col + col, positionY - 15, true, col);
                    }
                    if (col == 0)
                    {
                        DisplayNumberingLabelComputer(positionX - 20, positionY + 15 + row * 40 + row, false, row);
                    }

                    var gridButton = new GridButton(row, col, Player.Computer, GridButtonState.Initial);
                    gridButton.Location = new System.Drawing.Point(positionX + col * 40 + col, positionY + row * 40 + row);
                    gridButton.Name = "buttonComputer_" + row + "_" + col;
                    gridButton.Size = new System.Drawing.Size(40, 40);
                    gridButton.Text = "";
                    gridButton.Click += ProcessButtonHit;
                    gridButton.Enabled = false;

                    gridButtons.Add(gridButton);
                    groupBoxComputerFleet.Controls.Add(gridButton);
                }
            }
            return gridButtons;
        }
        private void DisplayNumberingLabelComputer(int posX, int posY, bool isChar, int num)
        {
            var label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(posX, posY);
            label.Size = new System.Drawing.Size(57, 13);
            if (isChar)
            {
                label.Text = Convert.ToChar('A' + num).ToString();
            }
            else
            {
                label.Text = (num + 1).ToString();
            }

            gridLabelsComputerFleet.Add(label);
            groupBoxComputerFleet.Controls.Add(label);
        }
        private void DisplayNumberingLabelMyFleet(int posX, int posY, bool isChar, int num)
        {
            var label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(posX, posY);
            label.Size = new System.Drawing.Size(57, 13);
            if (isChar)
            {
                label.Text = Convert.ToChar('A' + num).ToString();
            }
            else
            {
                label.Text = (num + 1).ToString();
            }

            gridLabelsMyFleet.Add(label);
            groupBoxMyFleet.Controls.Add(label);
        }
        private void ProcessButtonHit(object sender, EventArgs e)
        {
            var gridButton = sender as GridButton;

            Debug.WriteLine($"Button clicked---{gridButton.Name}");

            var hitResult = game.PlayerShoot(gridButton.Row, gridButton.Column);
            var computerGridButton = computerGridButtons.First(c => c.Row == gridButton.Row && c.Column == gridButton.Column);
            switch (hitResult)
            {
                case HitResult.Missed:
                    computerGridButton.GridButtonState = GridButtonState.Missed;
                    break;
                case HitResult.Hit:
                    computerGridButton.GridButtonState = GridButtonState.Hit;
                    break;
                case HitResult.Sunken:
                    UpdateSunkenComputerShip(game.GetComputerShipSquaresFromSquare(gridButton.Row, gridButton.Column));
                    computerShipsLeft -= 1;

                    textBoxComputerShipCount.Text = computerShipsLeft.ToString();
                    break;
            }

            textBoxComputerLastTarget.Text = Convert.ToChar('A' + gridButton.Column).ToString() + (gridButton.Row + 1);

            if (computerShipsLeft < 1)
            {
                MessageBox.Show("You WIN!", ">> Game Battleship <<");
                GameRestart();
                return;
            }

            ComputerPlays();
        }
        private void buttonPlaceMyFleet_Click(object sender, EventArgs e)
        {
            buttonStartBattle.Enabled = true;

            buttonPlaceMyFleetCounter += 1;
            if (buttonPlaceMyFleetCounter > 1)
            {
                ResetMyFleet();
            }
            else
            {
                game = new Game(gridSize, gridSize, shipLengths);
                myFleetGridButtons = DisplayButtonsGrid(Player.Human, gridSize, gridSize);
            }

        }
        private Player GameStart()
        {
            var random = new Random();
            if (random.Next(2) == 0)
            {
                MessageBox.Show("You play first!", ">> Game Battleship <<");
                return Player.Human;
            }
            MessageBox.Show("Computer plays first!", ">> Game Battleship <<");
            return Player.Computer;
        }
        private void GameRestart()
        {
            foreach (var gridButton in myFleetGridButtons)
            {
                groupBoxMyFleet.Controls.Remove(gridButton);
            }

            foreach (var gridButton in computerGridButtons)
            {
                groupBoxComputerFleet.Controls.Remove(gridButton);
            }

            foreach (var label in gridLabelsComputerFleet)
            {
                groupBoxComputerFleet.Controls.Remove(label);
            }

            foreach (var label in gridLabelsMyFleet)
            {
                groupBoxMyFleet.Controls.Remove(label);
            }

            buttonStartBattle.Enabled = false;
            buttonPlaceMyFleet.Enabled = true;
            buttonPlaceMyFleetCounter = 0;
            computerGridButtons = DisplayButtonsGrid(Player.Computer, gridSize, gridSize);
        }
        private void buttonStartBattle_Click(object sender, EventArgs e)
        {
            buttonPlaceMyFleet.Enabled = false;
            buttonStartBattle.Enabled = false;

            myFleetShipsLeft = shipLengths.Count();
            computerShipsLeft = shipLengths.Count();

            textBoxMyShipCount.Text = myFleetShipsLeft.ToString();

            textBoxComputerShipCount.Text = computerShipsLeft.ToString();

            foreach (var gridbutton in computerGridButtons)
            {
                gridbutton.Enabled = true;
            }

            var playerStarting = GameStart();
            if (playerStarting == Player.Computer)
            {
                ComputerPlays();
            }
        }
        private void ResetMyFleet()
        {
            foreach (var squareButton in myFleetGridButtons)
            {
                groupBoxMyFleet.Controls.Remove(squareButton);
            }
            myFleetGridButtons = DisplayButtonsGrid(Player.Human, gridSize, gridSize);
        }
        private void ComputerPlays()
        {
            var target = game.GetComputerTarget();
            var hitResult = game.ComputerShoot(target);
            var humanSquare = myFleetGridButtons.First(s => s.Row == target.Row && s.Column == target.Column);
            switch (hitResult)
            {
                case HitResult.Missed:
                    humanSquare.GridButtonState = GridButtonState.Missed;
                    break;
                case HitResult.Hit:
                    humanSquare.GridButtonState = GridButtonState.Hit;
                    break;
                case HitResult.Sunken:
                    UpdateHumanSunkenShip(game.GetPlayerShipSquaresFromSquare(target.Row, target.Column));
                    myFleetShipsLeft -= 1;

                    textBoxMyShipCount.Text = myFleetShipsLeft.ToString();
                    break;
            }

            textBoxMyLastTarget.Text = Convert.ToChar('A' + target.Column).ToString() + (target.Row + 1);

            if (myFleetShipsLeft < 1)
            {
                MessageBox.Show("Computer WINS! Better luck next time!", ">> Game BattleShip <<");
                GameRestart();
            }
        }
        private void UpdateHumanSunkenShip(IEnumerable<Square> shipSquares)
        {
            foreach (var sunkenSquare in shipSquares)
            {
                var humanSquare = myFleetGridButtons.First(s => s.Row == sunkenSquare.Row && s.Column == sunkenSquare.Column);
                humanSquare.GridButtonState = GridButtonState.Sunken;
                foreach (var eliminatedSquare in GetAdjacentEliminatedSquares(humanSquare))
                {
                    eliminatedSquare.GridButtonState = GridButtonState.Eliminated;
                }
            }
        }
        private IEnumerable<GridButton> GetAdjacentEliminatedSquares(GridButton gridButton)
        {
            if (myFleetGridButtons.Contains(gridButton))
            {
                return myFleetGridButtons.Where(
                    s => (s.GridButtonState == GridButtonState.Initial || s.GridButtonState == GridButtonState.Ship) &&
                    (s.Row == gridButton.Row || s.Row + 1 == gridButton.Row || s.Row - 1 == gridButton.Row) &&
                    (s.Column == gridButton.Column || s.Column + 1 == gridButton.Column || s.Column - 1 == gridButton.Column)
                    );
            }
            else
            {
                return computerGridButtons.Where(
                    s => (s.GridButtonState == GridButtonState.Initial || s.GridButtonState == GridButtonState.Ship) &&
                    (s.Row == gridButton.Row || s.Row + 1 == gridButton.Row || s.Row - 1 == gridButton.Row) &&
                    (s.Column == gridButton.Column || s.Column + 1 == gridButton.Column || s.Column - 1 == gridButton.Column)
                    );
            }
        }
        private void UpdateSunkenComputerShip(IEnumerable<Square> shipSquares)
        {
            foreach (var sunkenSquare in shipSquares)
            {
                var computerSquare = computerGridButtons.First(s => s.Row == sunkenSquare.Row && s.Column == sunkenSquare.Column);
                computerSquare.GridButtonState = GridButtonState.Sunken;
                foreach (var eliminatedSquare in GetAdjacentEliminatedSquares(computerSquare))
                {
                    eliminatedSquare.GridButtonState = GridButtonState.Eliminated;
                }
            }
        }
    }
}

