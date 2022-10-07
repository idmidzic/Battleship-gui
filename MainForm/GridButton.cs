using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsite.Battleship.Model;


namespace MainForm
{
    enum GridButtonState
    {
        Initial,
        Ship,
        Eliminated,
        Missed,
        Hit,
        Sunken
    }
    class GridButton : System.Windows.Forms.Button
    {
        private readonly int row;
        private readonly int column;
        private readonly Player player;
        private GridButtonState state;

        public GridButton(int row, int column, Player player, GridButtonState state) : base()
        {
            this.row = row;
            this.column = column;
            this.player = player;
            if (player == Player.Human)
            {
                DisableButtonClick();
            }
            this.state = state;
            UpdateButtonColor();
        }

        public void UpdateButtonColor()
        {
            switch (state)
            {
                case GridButtonState.Initial:
                    BackColor = Color.LightGray;
                    if (player == Player.Computer)
                    {
                        EnableButtonClick();
                    }
                    return;
                case GridButtonState.Ship:
                    BackColor = Color.DarkOliveGreen;
                    return;
                case GridButtonState.Missed:
                    BackColor = Color.DarkGray;
                    break;
                case GridButtonState.Eliminated:
                    BackColor = Color.White;
                    break;
                case GridButtonState.Hit:
                    BackColor = Color.Red;
                    break;
                case GridButtonState.Sunken:
                    BackColor = Color.Black;
                    break;
                default:
                    BackColor = Color.LightGray;
                    return;
            }
            if (player == Player.Computer)
            {
                DisableButtonClick();
            }
        }
        private void DisableButtonClick()
        {
            Enabled = false;
        }

        private void EnableButtonClick()
        {
            Enabled = true;
        }

        public int Row => row;
        public int Column => column;
        public GridButtonState GridButtonState
        {
            get => state;
            set
            {
                state = value;
                UpdateButtonColor();
            }
        }
    }
}

