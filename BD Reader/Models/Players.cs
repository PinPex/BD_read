using System;
using System.Collections.Generic;

namespace BaseRead.Models
{
    public partial class Players
    {

        public string FullName { get; set; }

        public string Born { get; set; }
        public string Bats { get; set; }
        public string Bowls { get; set; }
        public string Matches { get; set; }


        public object? this[string property]
        {
            get
            {
                switch (property)
                {
                    case "FullName": return FullName;
                    case "Born": return Born;
                    case "Bats": return Bats;
                    case "Bowls": return Bowls;
                    case "Matches": return Matches;
                }
                return null;
            }
        }
        public virtual ICollection<Matches> MatchesIdNavigation { get; set; }
        public virtual ICollection<Teams> TeamsIdNavigation { get; set; }
    }
}
