using System;
using System.Collections.Generic;

namespace BaseRead.Models
{
    public partial class Matches
    {

        public string Match { get; set; }

        public string Vennue { get; set; }
        public string Match_conditions { get; set; }
        public string Toss { get; set; }
        public string Player_of_match { get; set; }
        public string Points { get; set; }


        public object? this[string property]
        {
            get
            {
                switch (property)
                {
                    case "Match": return Match;
                    case "Vennue": return Vennue;
                    case "Match_conditions": return Match_conditions;
                    case "Toss": return Toss;
                    case "Player_of_match": return Player_of_match;
                    case "Points": return Points;
                }
                return null;
            }
        }
    }
}
