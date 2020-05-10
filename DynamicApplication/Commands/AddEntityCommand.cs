using DynamicApplication.ViewModels;
using DynamicApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DynamicApplication.Commands
{
    public class AddEntityCommand : ICommand
    {
        public DynamicVM VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AddEntityCommand(DynamicVM vm)
        {
            VM = vm;
        }
                
        public bool CanExecute(object parameter)
        {
            string entityName = (string) parameter;

            if (string.IsNullOrWhiteSpace(entityName))
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            VM.AddEntity();
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Close();
        }
    }
}
