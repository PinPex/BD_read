﻿using System.Collections.Generic;
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
        private ObservableCollection<Matches> table;
        public MatchesTableViewModel(ObservableCollection<Matches> _cars)
        {
            Table = _cars;
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