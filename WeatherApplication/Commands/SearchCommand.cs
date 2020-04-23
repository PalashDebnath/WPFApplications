using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApplication.ViewModels;

namespace WeatherApplication.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherVM weatherVM { get; set; }

        public SearchCommand(WeatherVM vm)
        {
            weatherVM = vm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            string context = (string)parameter;
            if (string.IsNullOrWhiteSpace(context))
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            weatherVM.GetCities();
        }
    }
}
