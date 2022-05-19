using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using BaseRead.ViewModels;

namespace BaseRead.Views
{
    public partial class DBViewerView : UserControl
    {
        public DBViewerView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void DeleteTab(object control, RoutedEventArgs args)
        {
            Button? btn = control as Button;
            if (btn != null)
            {
                DBViewerViewModel? context = this.DataContext as DBViewerViewModel;
                if (context != null)
                {
                    context.Tables.Remove(btn.DataContext as Table);
                }
            }
        }
    }
}