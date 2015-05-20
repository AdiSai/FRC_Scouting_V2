﻿namespace UsefulSnippets.TheBlueAlliance.Models
{
    internal class EventMatches
    {
        public class EventMatchList
        {
            public Match[] matches { get; set; }
        }

        public class Match
        {
            public string comp_level { get; set; }

            public int match_number { get; set; }

            public object[] videos { get; set; }

            public object time_string { get; set; }

            public int set_number { get; set; }

            public string key { get; set; }

            public object time { get; set; }

            public object score_breakdown { get; set; }

            public Alliances alliances { get; set; }

            public string event_key { get; set; }
        }

        public class Alliances
        {
            public Blue blue { get; set; }

            public Red red { get; set; }
        }

        public class Blue
        {
            public int score { get; set; }

            public string[] teams { get; set; }
        }

        public class Red
        {
            public int score { get; set; }

            public string[] teams { get; set; }
        }
    }
}