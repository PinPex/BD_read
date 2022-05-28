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
    public class TeamsTableViewModel : ViewModelBase
    {
        private ObservableCollection<Teams> table;
        public TeamsTableViewModel(ObservableCollection<Teams> _cars)
        {
            Table = _cars;
        }

        public ObservableCollection<Teams> Table
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

        public override ObservableCollection<Teams> GetTable()
        {
            return Table;
        }
    }
}
