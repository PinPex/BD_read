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
    public class SeasonsTableViewModel : ViewModelBase
    {
        private ObservableCollection<Seasons> table;
        public SeasonsTableViewModel(ObservableCollection<Seasons> _cars)
        {
            Table = _cars;
        }

        public ObservableCollection<Seasons> Table
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

        public override ObservableCollection<Seasons> GetTable()
        {
            return Table;
        }
    }
}
