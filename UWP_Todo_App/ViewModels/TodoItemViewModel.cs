using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_Todo_App.Models;

namespace UWP_Todo_App.ViewModels
{
    public class TodoItemViewModel : INotifyPropertyChanged
    {
        #region Fields

        // ID
        private int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        // IsDone
        private bool isDone;
        public bool IsDone
        {
            get { return isDone; }
            set
            {
                if(isDone != value)
                isDone = value;
               
                OnPropertyChanged("IsDone");
            }
        }

        // Title
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        // Description
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        
        // IsEditMode
        private bool isEditMode;
        public bool IsEditMode
        {
            get { return isEditMode; }
            set { isEditMode = value; }
        }


        // Repository Instance
        private TodoRepository _repository;

        #endregion

        #region Constructors
        // Constructor for new TodoItem ---- TODO bring repo
        public TodoItemViewModel(TodoRepository repository)
        {
            Description = "";
            Title = "";
            IsDone = false;
            IsEditMode = false;
            _repository = repository;
        }

        // Constructor for converting TodoItem to TodoItemViewModel
        public TodoItemViewModel(TodoItem todoitem, TodoRepository repository)
        {
            ID = todoitem.ID;
            Description = todoitem.Description;
            Title = todoitem.Title;
            IsDone = todoitem.IsDone;
            IsEditMode = false;
            _repository = repository;
        }

        #endregion

        #region Methods

        // Update Item
        public void Update()
        {
            _repository.Update(new TodoItem()
            {
                ID = this.ID,
                IsDone = this.IsDone,
                Title = this.Title,
                Description = this.Description
            });
        }

        // Save New Item
        public void Save()
        {
            _repository.Add(new TodoItem()
            {
                ID = 0,
                IsDone = false,
                Title = this.Title,
                Description = this.Description
            });
        }

        #endregion


        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
