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

namespace FRC_Scouting_V2
{
    class RecycleRush_Pit_Scouting_Team
    {
        public string Author { get; set; }
        public string Last_Editor { get; set; }
        public DateTime Time_Created { get; set; }
        public string UniqueID { get; set; }

        public int Team_Number { get; set; }
        public string Team_Name { get; set; }

        public double Robot_Weight { get; set; }
        public double Robot_Height { get; set; }

        public string Drive_Train { get; set; }
        public int Number_Of_Robots { get; set; }

        public Boolean Can_Move_Totes { get; set; }
        public Boolean Can_Move_Bins { get; set; }
        public Boolean Can_Acquire_Bins { get; set; }

        public Boolean Needs_Special_Starting_Position { get; set; }
        public string Special_Starting_Position { get; set; }

        public int Stack_Capacity { get; set; }
        public Boolean Can_It_Bin { get; set; }
        public Boolean Can_It_Manipulate_Litter { get; set; }

        public Boolean Human_Tote_Loading { get; set; }
        public Boolean Human_Litter_Loading { get; set; }
        public Boolean Human_Litter_Throwing { get; set; }

        public string Know_Weaknesses { get; set; }
        public string Known_Strengths { get; set; }

        public string Comments { get; set; }

        public byte[] Front_Picture { get; set; }
        public byte[] Left_Side_Picture { get; set; }
        public byte[] Left_Isometric_Picture { get; set; }
        public byte[] Right_Side_Picture { get; set; }
        public byte[] Right_Isometric_Picture { get; set; }
        public byte[] Other_Picture { get; set; }
    }
}
