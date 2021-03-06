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
    public partial class MatchesTableView : UserControl
    {
        public MatchesTableView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void DeleteNullColumn(object control, DataGridAutoGeneratingColumnEventArgs args)
        {
            if ( args.PropertyName == "Item")
            {
                args.Cancel = true;
            }
        }
        private void get_index(object control, DataGridAutoGeneratingColumnEventArgs args)
        {
            MatchesTableViewModel mat = this.DataContext as MatchesTableViewModel;
            DataGrid dat = this.FindControl<DataGrid>("Table");
            mat.Index_of_data_grid = dat.SelectedIndex;
        }

    }
}
