using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.Reactive;
using BaseRead.Models;
using BaseRead.ViewModels;
using Microsoft.Data.Sqlite;
using System.IO;
using System;

namespace BaseRead.Views
{
    public partial class Season_yearTableView : UserControl
    {
        public Season_yearTableView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void DeleteNullColumn(object control, DataGridAutoGeneratingColumnEventArgs args)
        {
            if (args.PropertyName == "Item")
            {
                args.Cancel = true;
            }
        }
        private void clicked(object control, DataGridAutoGeneratingColumnEventArgs args)
        {
            DataGrid dat = this.FindControl<DataGrid>("Table");
            //int tab = dat;
            dat.SelectAll();
            //throw new System.Exception(tab.ToString());
        }
    }
}
