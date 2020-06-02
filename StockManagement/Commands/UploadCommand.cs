using StockManagement.ViewModels;
using System;
using System.Windows.Input;

namespace StockManagement.Commands
{
    public class UploadCommand : ICommand
    {
        private readonly BookViewModel _vm;

        public UploadCommand(BookViewModel vm)
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
            _vm.OpenDialog();
        }
    }
}
