
namespace MainForm
{
    partial class BattleshipForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonPlaceMyFleet = new System.Windows.Forms.Button();
            this.buttonStartBattle = new System.Windows.Forms.Button();
            this.groupBoxMyFleet = new System.Windows.Forms.GroupBox();
            this.groupBoxComputerFleet = new System.Windows.Forms.GroupBox();
            this.labelMyShipCount = new System.Windows.Forms.Label();
            this.labelMyLastTarget = new System.Windows.Forms.Label();
            this.textBoxMyShipCount = new System.Windows.Forms.TextBox();
            this.textBoxMyLastTarget = new System.Windows.Forms.TextBox();
            this.textBoxComputerLastTarget = new System.Windows.Forms.TextBox();
            this.textBoxComputerShipCount = new System.Windows.Forms.TextBox();
            this.labelCompLastTarget = new System.Windows.Forms.Label();
            this.labelComputerShipCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonPlaceMyFleet
            // 
            this.buttonPlaceMyFleet.Location = new System.Drawing.Point(6, 463);
            this.buttonPlaceMyFleet.Name = "buttonPlaceMyFleet";
            this.buttonPlaceMyFleet.Size = new System.Drawing.Size(450, 23);
            this.buttonPlaceMyFleet.TabIndex = 0;
            this.buttonPlaceMyFleet.Text = "Place My Fleet";
            this.buttonPlaceMyFleet.UseVisualStyleBackColor = true;
            this.buttonPlaceMyFleet.Click += new System.EventHandler(this.buttonPlaceMyFleet_Click);
            // 
            // buttonStartBattle
            // 
            this.buttonStartBattle.Location = new System.Drawing.Point(463, 463);
            this.buttonStartBattle.Name = "buttonStartBattle";
            this.buttonStartBattle.Size = new System.Drawing.Size(450, 23);
            this.buttonStartBattle.TabIndex = 1;
            this.buttonStartBattle.Text = "Start Battle";
            this.buttonStartBattle.UseVisualStyleBackColor = true;
            this.buttonStartBattle.Click += new System.EventHandler(this.buttonStartBattle_Click);
            // 
            // groupBoxMyFleet
            // 
            this.groupBoxMyFleet.Location = new System.Drawing.Point(6, 7);
            this.groupBoxMyFleet.Name = "groupBoxMyFleet";
            this.groupBoxMyFleet.Size = new System.Drawing.Size(450, 447);
            this.groupBoxMyFleet.TabIndex = 3;
            this.groupBoxMyFleet.TabStop = false;
            this.groupBoxMyFleet.Text = "My Fleet";
            // 
            // groupBoxComputerFleet
            // 
            this.groupBoxComputerFleet.Location = new System.Drawing.Point(463, 7);
            this.groupBoxComputerFleet.Name = "groupBoxComputerFleet";
            this.groupBoxComputerFleet.Size = new System.Drawing.Size(450, 447);
            this.groupBoxComputerFleet.TabIndex = 4;
            this.groupBoxComputerFleet.TabStop = false;
            this.groupBoxComputerFleet.Text = "Computer Fleet";
            // 
            // labelMyShipCount
            // 
            this.labelMyShipCount.AutoSize = true;
            this.labelMyShipCount.Location = new System.Drawing.Point(12, 496);
            this.labelMyShipCount.Name = "labelMyShipCount";
            this.labelMyShipCount.Size = new System.Drawing.Size(79, 13);
            this.labelMyShipCount.TabIndex = 5;
            this.labelMyShipCount.Text = "My Ship Count:";
            // 
            // labelMyLastTarget
            // 
            this.labelMyLastTarget.AutoSize = true;
            this.labelMyLastTarget.Location = new System.Drawing.Point(12, 521);
            this.labelMyLastTarget.Name = "labelMyLastTarget";
            this.labelMyLastTarget.Size = new System.Drawing.Size(81, 13);
            this.labelMyLastTarget.TabIndex = 6;
            this.labelMyLastTarget.Text = "My Last Target:";
            // 
            // textBoxMyShipCount
            // 
            this.textBoxMyShipCount.Location = new System.Drawing.Point(97, 492);
            this.textBoxMyShipCount.Name = "textBoxMyShipCount";
            this.textBoxMyShipCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxMyShipCount.TabIndex = 7;
            // 
            // textBoxMyLastTarget
            // 
            this.textBoxMyLastTarget.Location = new System.Drawing.Point(97, 518);
            this.textBoxMyLastTarget.Name = "textBoxMyLastTarget";
            this.textBoxMyLastTarget.Size = new System.Drawing.Size(100, 20);
            this.textBoxMyLastTarget.TabIndex = 8;
            // 
            // textBoxComputerLastTarget
            // 
            this.textBoxComputerLastTarget.Location = new System.Drawing.Point(585, 518);
            this.textBoxComputerLastTarget.Name = "textBoxComputerLastTarget";
            this.textBoxComputerLastTarget.Size = new System.Drawing.Size(100, 20);
            this.textBoxComputerLastTarget.TabIndex = 12;
            // 
            // textBoxComputerShipCount
            // 
            this.textBoxComputerShipCount.Location = new System.Drawing.Point(585, 492);
            this.textBoxComputerShipCount.Name = "textBoxComputerShipCount";
            this.textBoxComputerShipCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxComputerShipCount.TabIndex = 11;
            // 
            // labelCompLastTarget
            // 
            this.labelCompLastTarget.AutoSize = true;
            this.labelCompLastTarget.Location = new System.Drawing.Point(468, 521);
            this.labelCompLastTarget.Name = "labelCompLastTarget";
            this.labelCompLastTarget.Size = new System.Drawing.Size(112, 13);
            this.labelCompLastTarget.TabIndex = 10;
            this.labelCompLastTarget.Text = "Computer Last Target:";
            // 
            // labelComputerShipCount
            // 
            this.labelComputerShipCount.AutoSize = true;
            this.labelComputerShipCount.Location = new System.Drawing.Point(468, 496);
            this.labelComputerShipCount.Name = "labelComputerShipCount";
            this.labelComputerShipCount.Size = new System.Drawing.Size(110, 13);
            this.labelComputerShipCount.TabIndex = 9;
            this.labelComputerShipCount.Text = "Computer Ship Count:";
            // 
            // BattleshipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 561);
            this.Controls.Add(this.textBoxComputerLastTarget);
            this.Controls.Add(this.textBoxComputerShipCount);
            this.Controls.Add(this.labelCompLastTarget);
            this.Controls.Add(this.labelComputerShipCount);
            this.Controls.Add(this.textBoxMyLastTarget);
            this.Controls.Add(this.textBoxMyShipCount);
            this.Controls.Add(this.labelMyLastTarget);
            this.Controls.Add(this.labelMyShipCount);
            this.Controls.Add(this.buttonStartBattle);
            this.Controls.Add(this.buttonPlaceMyFleet);
            this.Controls.Add(this.groupBoxComputerFleet);
            this.Controls.Add(this.groupBoxMyFleet);
            this.Name = "BattleshipForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Battleship";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlaceMyFleet;
        private System.Windows.Forms.Button buttonStartBattle;
        private System.Windows.Forms.GroupBox groupBoxMyFleet;
        private System.Windows.Forms.GroupBox groupBoxComputerFleet;
        private System.Windows.Forms.Label labelMyShipCount;
        private System.Windows.Forms.Label labelMyLastTarget;
        private System.Windows.Forms.TextBox textBoxMyShipCount;
        private System.Windows.Forms.TextBox textBoxMyLastTarget;
        private System.Windows.Forms.TextBox textBoxComputerLastTarget;
        private System.Windows.Forms.TextBox textBoxComputerShipCount;
        private System.Windows.Forms.Label labelCompLastTarget;
        private System.Windows.Forms.Label labelComputerShipCount;
    }
}

