﻿//*********************************License***************************************
//===============================================================================
//The MIT License (MIT)

//Copyright (c) 2014 FRC_Scouting_V2

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
//===============================================================================

using System;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class MainSettings : Form
    {
        //Variables
        private readonly UsefulSnippets us = new UsefulSnippets();

        public MainSettings()
        {
            InitializeComponent();
        }

        private void clickEmptyTextBoxChecker_CheckedChanged(object sender, EventArgs e)
        {
            if (clickEmptyTextBoxChecker.Checked)
            {
                Settings.Default.clickToEmptyTextBoxes = true;
                Settings.Default.Save();
            }
            else
            {
                if (clickEmptyTextBoxChecker.Checked == false)
                {
                    Settings.Default.clickToEmptyTextBoxes = false;
                    Settings.Default.Save();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void howDoISaveMySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Your settings save automatically, every time you change a setting it will immediately save the change.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainSettings_Load(object sender, EventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                clickEmptyTextBoxChecker.Checked = true;
            }
            else
            {
                if (Settings.Default.clickToEmptyTextBoxes == false)
                {
                    clickEmptyTextBoxChecker.Checked = false;
                }
            }

            if (Settings.Default.minimizeHomeWentEventLoads)
            {
                minimizeHomeCheckbox.Checked = true;
            }
            else
            {
                if (Settings.Default.minimizeHomeWentEventLoads == false)
                {
                    minimizeHomeCheckbox.Checked = false;
                }
            }

            usernameTextBox.Text = Settings.Default.username;
            databaseIPTextBox.Text = Settings.Default.databaseIP;
            databasePortTextBox.Text = Settings.Default.databasePort;
            databaseUsernameTextBox.Text = Settings.Default.databaseUsername;
            databasePasswordTextBox.Text = Settings.Default.databasePassword;
            databaseNameTextBox.Text = Settings.Default.databaseName;
        }

        private void minimizeHomeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (minimizeHomeCheckbox.Checked)
            {
                Settings.Default.minimizeHomeWentEventLoads = true;
                Settings.Default.Save();
            }
            else
            {
                if (minimizeHomeCheckbox.Checked == false)
                {
                    Settings.Default.minimizeHomeWentEventLoads = false;
                    Settings.Default.Save();
                }
            }
        }

        private void resetAllSettingsButton_Click(object sender, EventArgs e)
        {
            us.ClearSettings();
        }

        private void usernameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                usernameTextBox.Text = ("");
            }
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (usernameTextBox.Text != (""))
            {
                Settings.Default.username = usernameTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void whatIsTheUsernameFieldUsedForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "The Username field is used to keep track of who makes changes to any data. This prevents any mischievous changes to data.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void databaseIPTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databaseIPTextBox.Text != (""))
            {
                Settings.Default.databaseIP = databaseIPTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void databasePortTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databasePortTextBox.Text != (""))
            {
                Settings.Default.databasePort = databasePortTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void databaseUsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databaseUsernameTextBox.Text != (""))
            {
                Settings.Default.databaseUsername = databaseUsernameTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void databasePasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databasePasswordTextBox.Text != (""))
            {
                Settings.Default.databasePassword = databasePasswordTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void databaseNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (databaseNameTextBox.Text != (""))
            {
                Settings.Default.databaseName = databaseNameTextBox.Text;
                Settings.Default.Save();
            }
        }

        private void databaseIPTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databaseIPTextBox.Text = ("");
            }
        }

        private void databasePortTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databasePortTextBox.Text = ("");
            }
        }

        private void databaseNameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databaseNameTextBox.Text = ("");
            }
        }

        private void databaseUsernameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databaseUsernameTextBox.Text = ("");
            }
        }

        private void databasePasswordTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (Settings.Default.clickToEmptyTextBoxes)
            {
                databasePasswordTextBox.Text = ("");
            }
        }

        private void howComeMyDatabasePasswordDoesntWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your database password cannot contain any semicolons in it. ( ; )",
                "How come my database password doesn't work?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}