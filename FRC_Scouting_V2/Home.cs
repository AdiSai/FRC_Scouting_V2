﻿using System;
using System.Windows.Forms;
using FRC_Scouting_V2.Properties;
using FRC_Scouting_V2.Test_Objects;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class Home : Form
    {
        //Variables
        private readonly UsefulSnippets us = new UsefulSnippets();

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            eventSelector.Items.Add("Aerial Assist | Northbay | 2014");
            eventSelector.Items.Add("Aerial Assist | Rah Cha Cha | 2014");

            if (Settings.Default.firstTimeLoad)
            {
                if (
                    MessageBox.Show(
                        "Since this is the first time you have used this program please take a look at the settings page. This will prevent any headaches when trying to use the program. Do you want to be taken to the settings page now?",
                        "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var settingsPage = new MainSettings();
                    settingsPage.Show();
                }
                Settings.Default.firstTimeLoad = false;
                Settings.Default.Save();
            }
        }

        private void programInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var programInfo = new ProgramInformation();
            programInfo.Show();
        }

        private void resetAllSavedSettingsToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us.ClearSettings();
        }

        private void fRC3710TeamInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var team3710Info = new Team3710Information();
            team3710Info.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void licenseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var li = new License();
            li.Show();
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var changeLog = new Changelog();
            changeLog.Show();
        }

        private void eventSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eventSelector.SelectedIndex == 0)
            {
                var aaNorthbay2014 = new AerialAssist_Northbay();
                aaNorthbay2014.Show();

                if (Settings.Default.minimizeHomeWentEventLoads)
                {
                    WindowState = FormWindowState.Minimized;
                }
            }
            else
            {
                if (eventSelector.SelectedIndex == 1)
                {
                    var aaRahChaCha = new AerialAssist_RahChaCha();
                    aaRahChaCha.Show();

                    if (Settings.Default.minimizeHomeWentEventLoads)
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                }
            }
        }

        //Opens up the test form page
        private void eventSelector_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                var testForm = new TestForm();
                testForm.Show();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mainSettings = new MainSettings();
            mainSettings.Show();
        }
    }
}