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
    public class MatchesTableViewModel : ViewModelBase
    {
        public int Index_of_data_grid = 0;
        private ObservableCollection<Matches> table;
        public MatchesTableViewModel(ObservableCollection<Matches> match)
        {
            Table = match;
        }

        public ObservableCollection<Matches> Table
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

        public override ObservableCollection<Matches> GetTable()
        {
            return Table;
        }
    }
}
