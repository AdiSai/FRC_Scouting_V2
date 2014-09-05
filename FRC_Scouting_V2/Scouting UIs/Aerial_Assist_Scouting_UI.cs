﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class Aerial_Assist_Scouting_UI : UserControl
    {
        private int autoHighTally;
        private int autoLowTally;
        private int autoPickupTally;
        private int controlledHighTally;
        private int controlledLowTally;
        private int controlledPickupTally;
        private int hotGoalTally;
        private int matchNumber = 1;
        private int missedPickupsTally;
        private int teamColour;

        private int xStarting = 0;
        private int yStarting = 0;

        public Aerial_Assist_Scouting_UI()
        {
            InitializeComponent();
        }

        public void UpdateLabels()
        {
            autoHighTallyDisplay.Text = Convert.ToString(autoHighTally);
            autoLowTallyDisplay.Text = Convert.ToString(autoLowTally);
            controlledHighTallyDisplay.Text = Convert.ToString(controlledHighTally);
            controlledLowTallyDisplay.Text = Convert.ToString(controlledLowTally);
            hotGoalTallyDisplay.Text = Convert.ToString(hotGoalTally);
            autoPickupTallyDisplay.Text = Convert.ToString(autoPickupTally);
            controlledPickupTallyDisplay.Text = Convert.ToString(controlledPickupTally);
            missedPickupsTallyDisplay.Text = Convert.ToString(missedPickupsTally);
        }

        public void PlotInitialLines()
        {
            Pen blackpen = new Pen(Color.Black, 4);
            Pen fineBlackPen = new Pen(Color.Black, 2);
            var initGraphics = startingLocationPanel.CreateGraphics();

            //Drawing square around the outside edge
            initGraphics.DrawRectangle(blackpen, 0, 0, 258, 191);

            //Drawing field lines
            initGraphics.DrawLine(fineBlackPen, 86, 0, 86, 191);
            initGraphics.DrawLine(fineBlackPen, 172, 0, 172, 191);
            initGraphics.Dispose();
        }

        public void BlankPanel()
        {
            var initGraphics = startingLocationPanel.CreateGraphics();
            initGraphics.FillRectangle(Brushes.White, 0, 0, 258, 191);
            initGraphics.Dispose();
            PlotInitialLines();
        }

        private void autoHighMinusButton_Click(object sender, EventArgs e)
        {
            autoHighTally = autoHighTally - 1;
            UpdateLabels();
        }

        private void autoHighPlusButton_Click(object sender, EventArgs e)
        {
            autoHighTally = autoHighTally + 1;
            UpdateLabels();
        }

        private void autoLowMinusButton_Click(object sender, EventArgs e)
        {
            autoLowTally = autoLowTally - 1;
            UpdateLabels();
        }

        private void autoLowPlusButton_Click(object sender, EventArgs e)
        {
            autoLowTally = autoLowTally + 1;
            UpdateLabels();
        }

        private void autoPickupMinusButton_Click(object sender, EventArgs e)
        {
            autoPickupTally = autoPickupTally - 1;
            UpdateLabels();
        }

        private void autoPickupPlusButton_Click(object sender, EventArgs e)
        {
            autoPickupTally = autoPickupTally + 1;
            UpdateLabels();
        }

        private void controlledHighMinusButton_Click(object sender, EventArgs e)
        {
            controlledHighTally = controlledHighTally - 1;
            UpdateLabels();
        }

        private void controlledHighPlusButton_Click(object sender, EventArgs e)
        {
            controlledHighTally = controlledHighTally + 1;
            UpdateLabels();
        }

        private void controlledLowMinusButton_Click(object sender, EventArgs e)
        {
            controlledLowTally = controlledLowTally - 1;
            UpdateLabels();
        }

        private void controlledLowPlusButton_Click(object sender, EventArgs e)
        {
            controlledLowTally = controlledLowTally + 1;
            UpdateLabels();
        }

        private void controllPickupMinusButton_Click(object sender, EventArgs e)
        {
            controlledPickupTally = controlledPickupTally - 1;
            UpdateLabels();
        }

        private void controllPickupPlusButton_Click(object sender, EventArgs e)
        {
            controlledPickupTally = controlledPickupTally + 1;
            UpdateLabels();
        }

        private void hotGoalMinusButton_Click(object sender, EventArgs e)
        {
            hotGoalTally = hotGoalTally - 1;
            UpdateLabels();
        }

        private void hotGoalPlusButton_Click(object sender, EventArgs e)
        {
            hotGoalTally = hotGoalTally + 1;
            UpdateLabels();
        }

        private void matchNumberNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            matchNumber = Convert.ToInt32(matchNumberNumericUpDown.Value);
        }

        private void missedPickupsMinusButton_Click(object sender, EventArgs e)
        {
            missedPickupsTally = missedPickupsTally - 1;
            UpdateLabels();
        }

        private void missedPickupsPlusButton_Click(object sender, EventArgs e)
        {
            missedPickupsTally = missedPickupsTally + 1;
            UpdateLabels();
        }

        private void teamColourComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (teamColourComboBox.SelectedIndex)
            {
                case 0:
                    teamColour = 0;
                    break;
                case 1:
                    teamColour = 1;
                    break;
            }
        }

        private void submitDataButton_Click(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void startingLocationPanel_MouseClick(object sender, MouseEventArgs e)
        {
            startingLocationPanel.Refresh();
            BlankPanel();
            var g = startingLocationPanel.CreateGraphics();
            xStarting = Convert.ToInt32(e.X) - 3;
            yStarting = Convert.ToInt32(e.Y) - 3;
            g.DrawRectangle(new Pen(Brushes.Black, 3),new Rectangle(new Point(xStarting, yStarting), new Size(5, 5)));
        }

        private void startingLocationPanel_Paint(object sender, PaintEventArgs e)
        {
            PlotInitialLines();
        }

        private void Aerial_Assist_UI_Layout_Load(object sender, EventArgs e)
        {
            //Set team colour items
            teamColourComboBox.Items.Add("Blue");
            teamColourComboBox.Items.Add("Red");
        }
    }
}