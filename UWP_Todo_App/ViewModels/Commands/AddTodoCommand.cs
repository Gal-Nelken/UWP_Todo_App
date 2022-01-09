using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UWP_Todo_App.ViewModels.Commands
{
    public class AddTodoCommand : ICommand
    {
        public TodoItemViewModel ItemVM { get; set; }


        public AddTodoCommand(TodoItemViewModel itemVM)
        {
            ItemVM = itemVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
           string title = parameter as string;
            if (string.IsNullOrWhiteSpace(title)) return false;
            return true;
        }

        public void Execute(object parameter)
        {
            ItemVM.Save();
        }
    }
}

