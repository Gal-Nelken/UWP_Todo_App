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

        // --- ID --- 
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        // --- INDEX --- 
        private int idx;
        public int Idx
        {
            get { return idx; }
            set { 
                idx = value;
                OnPropertyChanged("Idx");
            }
        }

        // --- IsDone --- 
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

        // --- Title --- 
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

        // --- Description --- 
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

        #endregion


        #region Propertys
        // --- Repository Instance --- 
        private TodoRepository _repository;

        #endregion


        #region Constructors
        // --- Constructor for new TodoItem View-Model --- 
        public TodoItemViewModel(TodoRepository repository)
        {
            ID = 0;
            Description = "";
            Title = "";
            _repository = repository;
        }

        // --- Constructor for converting TodoItem to TodoItemViewModel --- 
        public TodoItemViewModel(TodoItem todoItem, int idx, TodoRepository repository)
        {
            ID = todoItem.ID;
            Idx = idx;
            Description = todoItem.Description;
            Title = todoItem.Title;
            IsDone = todoItem.IsDone;
            _repository = repository;
        }       

        // --- Constructor for Edit TodoItem: a copy for the original item --- 
        public TodoItemViewModel(TodoItemViewModel todoItem)
        {
            ID = todoItem.ID;
            Description = todoItem.Description;
            Title = todoItem.Title;
            IsDone = todoItem.IsDone;
            _repository = todoItem._repository;
        }

        #endregion


        #region Methods

        // --- Update Item --- 
        public void Update()
        {
            _repository.Update(new TodoItem(Title, Description, IsDone, ID));
        }

        // --- Save New Item --- 
        public void Save()
        {
            _repository.Add(new TodoItem(Title, Description));
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
