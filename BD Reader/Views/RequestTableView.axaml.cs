using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace BaseRead.Views
{
    public partial class RequestTableView : UserControl
    {
        public RequestTableView()
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
    }
}
