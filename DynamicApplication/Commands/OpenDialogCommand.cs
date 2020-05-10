using DynamicApplication.Models;
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
    public class OpenDialogCommand : ICommand
    {
        public DynamicVM VM { get; set; }

        public event EventHandler CanExecuteChanged;

        public OpenDialogCommand(DynamicVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int id = (int)parameter;
            if(id == -1)
            {
                EntityDialog dialog = new EntityDialog();
                dialog.DataContext = VM;
                dialog.ShowDialog();
            }
            else
            {
                VM.SelectedEntityRecord = (EntityRecord)VM.EntityRecords.Where(item => item.Entity.Id == id).FirstOrDefault();
                AttributeDialog dialog = new AttributeDialog();
                dialog.DataContext = VM;
                dialog.ShowDialog();
            }
        }
    }
}
