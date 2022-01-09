using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UWP_Todo_App.ViewModels.Commands
{
    public class RemoveTodoCommand : ICommand
    {

        public TodoListViewModel ListVM { get; set; }

        public RemoveTodoCommand(TodoListViewModel vm)
        {
            ListVM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ListVM.DeleteItem();
        }
    }
}

