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
    public class AddAttributeCommand : ICommand
    {
        public DynamicVM VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AddAttributeCommand(DynamicVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            bool value = (bool)parameter;
            return value;
        }

        public void Execute(object parameter)
        {
            Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive).Close();
            VM.AddAttribute(VM.SelectedEntityRecord.Entity.Id);
        }
    }
}
