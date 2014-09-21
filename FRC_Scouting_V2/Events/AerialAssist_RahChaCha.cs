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

using FRC_Scouting_V2.Properties;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace FRC_Scouting_V2
{
    //@author xNovax
    public partial class AerialAssist_RahChaCha : Form
    {
        private const string TABLE_NAME = ("AerialAssist_RahChaCha");

        //Variables
        private readonly UsefulSnippets us = new UsefulSnippets();

        private int rookieYear;
        private string teamLocation = ("");
        private string teamName = ("");
        private int teamNumber;
        private string url = ("http://www.thebluealliance.com/api/v2/team/frc");

        public AerialAssist_RahChaCha()
        {
            InitializeComponent();
        }

        private void AerialAssist_RahChaCha_Load(object sender, EventArgs e)
        {
            Settings.Default.currentTableName = (TABLE_NAME);
            Settings.Default.Save();

            //Starting the clock so that the current time will be displayed and updated every second
            timer.Start();
            currentTimeDisplay.Text = ("Current Time: " + us.GetCurrentTime());

            //Setting toolTips
            var ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(teamSelector,
                "Use this to select the team that you want to enter data / look at data for!");
            ToolTip1.SetToolTip(currentTimeDisplay,
                "Displays the current time so that you don't get too focused on scouting and lose track of time.");

            //Adding teams to TeamSelector Control
            teamSelector.Items.Add("Test");
        }

        private void eventInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aaRahChaChaEventInfo = new AerialAssist_RahChaCha_Information();
            aaRahChaChaEventInfo.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us.ExportTableToCSV(TABLE_NAME);
        }

        private void howComeICannotSeeAnyTeamInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            us.ShowInformationMessage(
                "The team information is pulled from TheBluAlliance's API, this means that you need to have an internet connection to get the data.");
        }

        private void teamSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string downloadedData;
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id", "3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            url = (url + teamNumber);
            try
            {
                downloadedData = (wc.DownloadString(url));
                var deserializedData = JsonConvert.DeserializeObject<TeamInformationJSONData>(downloadedData);

                teamName = Convert.ToString(deserializedData.nickname);
                teamNumber = Convert.ToInt32(deserializedData.team_number);
                teamLocation = Convert.ToString(deserializedData.location);
                rookieYear = Convert.ToInt32(deserializedData.rookie_year);
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }

            teamNameDisplay.Text = teamName;
            teamNumberDisplay.Text = Convert.ToString(teamNumber);
            teamLocationDisplay.Text = teamLocation;
            rookieYearDisplay.Text = Convert.ToString(rookieYear);

            Settings.Default.selectedTeamName = teamName;
            Settings.Default.selectedTeamNumber = teamNumber;
            Settings.Default.Save();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            currentTimeDisplay.Text = ("Current Time: " + us.GetCurrentTime());
        }

        public class TeamInformationJSONData
        {
            public string country_name { get; set; }

            public string key { get; set; }

            public string locality { get; set; }

            public string location { get; set; }

            public string name { get; set; }

            public string nickname { get; set; }

            public string region { get; set; }

            public int rookie_year { get; set; }

            public int team_number { get; set; }

            public string website { get; set; }
        }
    }
}