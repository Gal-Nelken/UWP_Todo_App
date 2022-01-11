using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_Todo_App.Models;

namespace UWP_Todo_App.ViewModels
{
    public class TodoItemViewModel : TodoItem
    {
        #region Fields
        
        private bool isEditMode;

        public bool IsEditMode
        {
            get { return isEditMode; }
            set { isEditMode = value; }
        }

        #endregion

        #region Constructors
        // Constructor for new TodoItem
        public TodoItemViewModel()
        {
            Description = "";
            Title = "";
            IsDone = false;
            IsEditMode = false;
        }

        // Constructor for converting TodoItem to TodoItemViewModel
        public TodoItemViewModel(TodoItem todoitem)
        {
            ID = todoitem.ID;
            Description = todoitem.Description;
            Title = todoitem.Title;
            IsDone = todoitem.IsDone;
            IsEditMode = false;
        }

        #endregion

        #region Methods
        public void Save()
        {
            Description = "";
            Title = "";
        }

        #endregion

    }
}
