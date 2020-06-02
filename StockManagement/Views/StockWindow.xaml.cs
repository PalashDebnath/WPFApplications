using StockManagement.ViewModels;
using System.Windows;
using Unity;

namespace StockManagement.Views
{
    /// <summary>
    /// Interaction logic for StockWindow.xaml
    /// </summary>
    public partial class StockWindow : Window
    {
        [Dependency]
        public BookViewModel VM { set { DataContext = value; } }

        public StockWindow()
        {
            InitializeComponent();
        }
    }
}
