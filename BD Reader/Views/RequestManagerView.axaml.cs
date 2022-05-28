using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Input;
using BaseRead.ViewModels;
using BaseRead.Views;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Avalonia.Interactivity;

namespace BaseRead.Views
{
    public partial class RequestManagerView : UserControl
    {
        public RequestManagerView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        private void AddRequest(object control, RoutedEventArgs args)
        {
            RequestManagerViewModel? context = this.DataContext as RequestManagerViewModel;
            if (context != null)
            {
                Table select_item = this.FindControl<ListBox>("TableList").SelectedItem as Table;
                string selectedTable = select_item.Name;
                ListBox columns = this.FindControl<ListBox>("TablesColumnsList");
                RequestManagerViewModel.ColumnListItem col = columns.SelectedItem as RequestManagerViewModel.ColumnListItem;
                ListBox group = this.FindControl<ListBox>("GroupsColumnsList");
                RequestManagerViewModel.ColumnListItem group_by_ = group.SelectedItem as RequestManagerViewModel.ColumnListItem;

                var list = this.FindControl<ListBox>("TablesColumnsList").SelectedItems;
                var table_name = this.FindControl<ListBox>("TableList").SelectedItems;
                var groupBy = this.FindControl<ListBox>("GroupsColumnsList").SelectedItems;


                List<RequestManagerViewModel.ColumnListItem> ls = new List<RequestManagerViewModel.ColumnListItem>();
                List<Table> table_names = new List<Table>();
                List<RequestManagerViewModel.ColumnListItem> grpBy = new List<RequestManagerViewModel.ColumnListItem>();
                for (int i = 0; i < list.Count; i++)
                {
                    ls.Add(list[i] as RequestManagerViewModel.ColumnListItem);
                }
                for (int i = 0; i < table_name.Count; i++)
                {
                    table_names.Add(table_name[i] as Table);
                }
                for (int i = 0; i < groupBy.Count; i++)
                {
                    grpBy.Add(groupBy[i] as RequestManagerViewModel.ColumnListItem);
                }

                context.AddRequest(this.FindControl<TextBox>("RequestName").Text, table_names, ls, grpBy);
                this.FindControl<Button>("Accept").IsEnabled = false;

            }
        }
        private string req;
        //private string selectedTable;
        private void RequestNameChanged(object control, KeyEventArgs args)
        {
            TextBox? requestName = control as TextBox;
            if (requestName != null)
            {
                var context = this.DataContext as RequestManagerViewModel;
                bool tableExist = false;
                foreach (var table in context.Tables)
                {
                    if (table.Name == requestName.Text)
                    {
                        tableExist = true;
                        break;
                    }
                }
                if (requestName.Text != "" && !tableExist)
                    this.FindControl<Button>("Accept").IsEnabled = true;
                else
                    this.FindControl<Button>("Accept").IsEnabled = false;
            }
        }
        
        
        private void TableSelected(object control, SelectionChangedEventArgs args)
        {
            ListBox? tablesList = control as ListBox;
            
            if (tablesList != null)
            {
                var context = this.DataContext as RequestManagerViewModel;
                if (context != null)
                {
                    List<Table> tables = new List<Table>();
                    foreach (var table in tablesList.SelectedItems)
                    {
                        tables.Add(table as Table);
                    }
                    context.SelectedTables = tables;
                    context.UpdateColumnList();
                }
            }
        }
    }
}
