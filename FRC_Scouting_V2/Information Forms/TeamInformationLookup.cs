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
using System.Net;
using System.Reflection;
using Newtonsoft.Json;

//@author xNovax
namespace FRC_Scouting_V2.Information_Forms
{
    public partial class TeamInformationLookup : GeneralFormTemplate.GeneralFormTemplate
    {
        public TeamInformationLookup()
        {
            InitializeComponent();
        }

        string url;
        int teamNumber;
        private string teamName;
        private string teamLocation;
        private string teamWebsite;
        private int rookieYear;

        private void teamNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (teamNumberTextBox.Text != (""))
            {
                teamNumber = Convert.ToInt32(teamNumberTextBox.Text);
            }
        }

        private void findTeamButton_Click(object sender, EventArgs e)
        {
            string downloadedData;
            var wc = new WebClient();
            wc.Headers.Add("X-TBA-App-Id","3710-xNovax:FRC_Scouting_V2:" + Assembly.GetExecutingAssembly().GetName().Version);
            try
            {
                url = ("http://www.thebluealliance.com/api/v2/team/frc3710");
                downloadedData = (wc.DownloadString(url));
                var deserializedData = JsonConvert.DeserializeObject<TeamInformationJSONData>(downloadedData);

                teamName = Convert.ToString(deserializedData.nickname);
                teamNumber = Convert.ToInt16(deserializedData.team_number);
                teamLocation = Convert.ToString(deserializedData.location);
                rookieYear = Convert.ToInt32(deserializedData.rookie_year);
                teamWebsite = Convert.ToString(deserializedData.website);
            }
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }

            teamNameDisplay.Text = teamName;
            teamNumberDisplay.Text = Convert.ToString(teamNumber);
            teamLocationDisplay.Text = teamLocation;
            teamWebsiteDisplay.Text = teamWebsite;
            rookieYearDisplay.Text = Convert.ToString(rookieYear);
        }

        public class TeamInformationJSONData
        {
            public string website { get; set; }
            public string name { get; set; }
            public string locality { get; set; }
            public int rookie_year { get; set; }
            public string region { get; set; }
            public int team_number { get; set; }
            public string location { get; set; }
            public string key { get; set; }
            public string country_name { get; set; }
            public string nickname { get; set; }
        }

        private void teamNumberTextBox_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (FRC_Scouting_V2.Properties.Settings.Default.clickToEmptyTextBoxes == true)
            {
                teamNumberTextBox.Text = ("");
            }
        }
    }
}
