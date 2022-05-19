using System;
using System.Collections.Generic;

namespace BaseRead.Models
{
    public partial class Seasons
    {

        public string Year { get; set; }

        public string Winner { get; set; }

        public object? this[string property]
        {
            get
            {
                switch (property)
                {
                    case "Year": return Year;
                    case "Winner": return Winner;
                }
                return null;
            }
        }
    }
}
