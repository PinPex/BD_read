using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using BaseRead.Models;
using Microsoft.Data.Sqlite;
using System.IO;
using System;

namespace BaseRead.ViewModels
{
    public class Season_yearTableViewModel : ViewModelBase
    {
        private ObservableCollection<Season_year> table;
        public Season_yearTableViewModel(ObservableCollection<Season_year> season_Years)
        {
            Table = season_Years;
        }

        public ObservableCollection<Season_year> Table
        {
            get
            {
                return table;
            }
            set
            {
                table = value;
            }
        }

        public override ObservableCollection<Season_year> GetTable()
        {
            return Table;
        }
    }
}
