using DynamicApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DynamicApplication.Commands
{
    public class ExitCommand : ICommand
    {
        public DynamicVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public ExitCommand(DynamicVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
