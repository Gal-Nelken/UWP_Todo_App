using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_Todo_App.ViewModels.Commands;
using UWP_Todo_App.Models;

namespace UWP_Todo_App.ViewModels
{
    public class TodoItemViewModel : TodoItem
    {
        public AddTodoCommand AddButtonCommand { get; set; }

        private bool isEditMode;

        public bool IsEditMode
        {
            get { return isEditMode; }
            set { isEditMode = value; }
        }

        public TodoItemViewModel()
        {
            AddButtonCommand = new AddTodoCommand(this);
            Description = "";
            Title = "";
            IsDone = false;
            IsEditMode = true;
        }

        public TodoItemViewModel(TodoItem todoitem)
        {
            ID = todoitem.ID;
            Description = todoitem.Description;
            Title = todoitem.Title;
            IsDone = todoitem.IsDone;
            IsEditMode = false;
        }

        public void Save()
        {
            TodoItem todoItem = new TodoItem
            {
                Title = Title,
                Description = Description,
                IsDone = false
            };
            TodoRepository repository = new TodoRepository();
            repository.Add(todoItem);
            Title = "";
            Description = "";
            isEditMode = false;
        }
    }
}
