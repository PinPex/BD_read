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
    public class Season2021TableViewModel : ViewModelBase
    {
        private ObservableCollection<Season2021> table;
        public Season2021TableViewModel(ObservableCollection<Season2021> _cars)
        {
            Table = _cars;
        }

        public ObservableCollection<Season2021> Table
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

        public override ObservableCollection<Season2021> GetTable()
        {
            return Table;
        }
    }
}
