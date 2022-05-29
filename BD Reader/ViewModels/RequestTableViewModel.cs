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
    public class RequestTableViewModel : MainWindowViewModel
    {
        public ObservableCollection<string[]> Rows { get; set; }

        private List<List<string>> queryList;
        public RequestTableViewModel(List<List<string>> _queryList)
        {
            queryList = _queryList;
        }

        public List<List<string>> QueryList
        {
            get
            {
                return queryList;
            }
        }
    }
}
