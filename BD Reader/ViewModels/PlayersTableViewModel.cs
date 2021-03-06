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
    public class PlayersTableViewModel : ViewModelBase
    {
        private ObservableCollection<Players> table;
        public PlayersTableViewModel(ObservableCollection<Players> players)
        {
            Table = players;
        }

        public ObservableCollection<Players> Table
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

        public override ObservableCollection<Players> GetTable()
        {
            return Table;
        }
    }
}
