using System;
using System.Collections.Generic;

namespace BaseRead.Models
{
    public partial class Teams
    {
        public int? Id { get; set; }
        public string Team_name { get; set; }
        public string Players { get; set; }
        public string Match { get; set; }



        public object? this[string property]
        {
            get
            {
                switch (property)
                {
                    case "Id": return Id;
                    case "Team_name": return Team_name;
                    case "Players": return Players;
                    case "Match": return Match;
                }
                return null;
            }
        }
        public virtual Players PlayersIdNavigation { get; set; }
        public virtual Matches MatchesIdNavigation { get; set; }
    }
}
