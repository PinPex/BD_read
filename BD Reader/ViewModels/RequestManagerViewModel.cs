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
    public class RequestManagerViewModel : ViewModelBase
    {


        public class ColumnListItem
        {
            public ColumnListItem(string _TableName, string _ColumnName)
            {
                TableName = _TableName + ": ";
                ColumnName = _ColumnName;
            }
            public string TableName { get; set; }
            public string ColumnName { get; set; }
        }

        private DBViewerViewModel DbViewer;
        private ObservableCollection<Table> tables;
        private ObservableCollection<Table> requests;
        private ObservableCollection<ColumnListItem> columnList;

        public RequestManagerViewModel(DBViewerViewModel _DBViewer)
        {
            DbViewer = _DBViewer;
            tables = DbViewer.Tables;
            requests = DbViewer.Requests;
            columnList = new ObservableCollection<ColumnListItem>();

            SelectedTables = new List<Table>();
            req = new ObservableCollection<string>();
        }

        public void UpdateColumnList()
        {
            ColumnList = new ObservableCollection<ColumnListItem>();
            foreach (Table table in SelectedTables)
            {
                foreach (var column in table.Properties)
                {
                    ColumnList.Add(new ColumnListItem(table.Name, column));
                }
            }

        }
        public ObservableCollection<string> req { get; set; }

        public void AddRequest(string tableName, List<Table> table_names, List<RequestManagerViewModel.ColumnListItem> ls, List<RequestManagerViewModel.ColumnListItem> grpBy)
        {
            string path = @"Assets\cricket.db";
            string directoryPath = Directory.GetCurrentDirectory();
            directoryPath = directoryPath.Remove(directoryPath.LastIndexOf("bin"));
            string DbPath = directoryPath + path;
            SqliteConnection con = new SqliteConnection("Data Source=" + DbPath);
            con.Open();
            SqliteCommand com = new SqliteCommand();

            string columns = "";
            string from = "";
            string group_by = "";
            for(int i = 0; i < ls.Count; i++)
            {
                columns += ls[i].ColumnName;
                if (i != ls.Count - 1) columns += ", ";
            }

            for (int i = 0; i < table_names.Count; i++)
            {
                from += table_names[i].Name;
                if (i != table_names.Count - 1) from += ", ";
            }
            for (int i = 0; i < grpBy.Count; i++)
            {
                group_by += grpBy[i].ColumnName;
                if (i != grpBy.Count - 1) group_by += ", ";
            }

            com.CommandText = "SELECT " + columns + " FROM " + from + " GROUP BY " + group_by + ";";
            com.Connection = con;
            SqliteDataReader read = com.ExecuteReader();
            List<List<object>> list = new List<List<object>>();
            if (read.HasRows)
            {
                List<object> a = new List<object>();
                while (read.Read())
                {
                    for (int i = 0; i < read.FieldCount; ++i)
                    {
                        a.Add(read.GetValue(i));
                    }
                    list.Add(a);
                }
                tables.Add(new Table(tableName, true, new RequestTableViewModel(list), new ObservableCollection<string>()));
                req.Add(tableName);
            }
            
        }

        public List<Table> SelectedTables { get; set; }

        public ObservableCollection<ColumnListItem> ColumnList
        {
            get => columnList;
            set
            {
                this.RaiseAndSetIfChanged(ref columnList, value);
            }
        }
        public ObservableCollection<Table> Tables
        {
            get => tables;
            set
            {
                this.RaiseAndSetIfChanged(ref tables, value);
            }
        }
        public ObservableCollection<Table> Requests
        {
            get => requests;
            set
            {
                this.RaiseAndSetIfChanged(ref requests, value);
            }
        }
        public DBViewerViewModel DBViewer { get; }
    }
}
