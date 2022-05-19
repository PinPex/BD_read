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
    public class Season2022TableViewModel : ViewModelBase
    {
        private ObservableCollection<Season2022> table;
        public Season2022TableViewModel(ObservableCollection<Season2022> _cars)
        {
            Table = _cars;
        }

        public ObservableCollection<Season2022> Table
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

        public override ObservableCollection<Season2022> GetTable()
        {
            return Table;
        }
    }
}
