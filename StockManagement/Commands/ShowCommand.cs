using StockManagement.Models;
using StockManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StockManagement.Commands
{
    public class ShowCommand : ICommand
    {
        private readonly BookViewModel _vm;

        public ShowCommand(BookViewModel vm)
        {
            _vm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string title = (string)parameter;
            _vm.DisplayDescription(title);
        }
    }
}
