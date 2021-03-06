using System;
using System.Collections.Generic;

namespace BaseRead.Models
{
    public partial class Season_year
    {
        public int? Id { get; set; }
        public string Match { get; set; }

        public string Date_Year { get; set; }
        public string Date_month_day { get; set; }
        public string Teams { get; set; }
        public string Ground { get; set; }
        public string Result { get; set; }


        public object? this[string property]
        {
            get
            {
                switch (property)
                {
                    case "Id": return Id;
                    case "Match": return Match;
                    case "Date_Year": return Date_Year;
                    case "Date_month_day": return Date_month_day;
                    case "Teams": return Teams;
                    case "Ground": return Ground;
                    case "Result": return Ground;
                }
                return null;
            }
        }

        public virtual Seasons SeasonsIdNavigation { get; set; }
    }
}
