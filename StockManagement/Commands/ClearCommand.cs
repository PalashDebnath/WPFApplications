using StockManagement.ViewModels;
using System;
using System.Windows.Input;

namespace StockManagement.Commands
{
    public class ClearCommand : ICommand
    {
        private readonly BookViewModel _vm;

        public ClearCommand(BookViewModel vm)
        {
            _vm = vm;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            bool NoStock = parameter == null ? false : (bool)parameter;
            return NoStock;
        }

        public void Execute(object parameter)
        {
            _vm.ModifyBookCollection();
        }
    }
}
