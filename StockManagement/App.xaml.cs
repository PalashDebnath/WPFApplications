using StockManagement.Helpers;
using StockManagement.Views;
using System.Windows;

namespace StockManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DependencyInjector.Register<IFileReader, CSVReader>();
            MainWindow = DependencyInjector.Resolve<StockWindow>();
            MainWindow.Show();
        }
    }
}
