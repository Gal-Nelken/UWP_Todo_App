using System;
using System.Collections.Generic;
using System.Linq;

namespace UWP_Todo_App.Models
{
    public delegate void RepositoryChanged(TodoRepository repository);
    public class TodoRepository
    {

        #region Singleton
        // --- Repository Instance --- 
        private static TodoRepository _instance;
        public static TodoRepository Instance => _instance ?? (_instance = new TodoRepository());

        // --- Repository Update Event --- 
        public event RepositoryChanged UpdateRepository;

        // --- Constructor --- 
        private TodoRepository()
        {
            _todoItems = new List<TodoItem>();

            for (int i = 0; i < 6; i++)
            {
                _todoItems.Add(new TodoItem($"Todo{i + 1}", "Do something, Text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text text", false));
            }
        }

        #endregion


        #region Propertys
        private List<TodoItem> _todoItems;

        #endregion


        #region Methods
        // --- Create --- 
        public void Add(TodoItem todoItem)
        {
            _todoItems.Add(todoItem);
            UpdateRepository(Instance);
        }

        // --- Read --- 
        public List<TodoItem> GetAll()
        {
            return _todoItems;
        }

        public TodoItem Get(int id)
        {
            return _todoItems[id];
        }

        // --- Update --- 
        public void Update(TodoItem todoItem)
        {
            var todo = _todoItems.FirstOrDefault(item => item.ID == todoItem.ID);
            if (todo != null)
            {
                todo.Title = todoItem.Title;
                todo.Description = todoItem.Description;
                todo.IsDone = todoItem.IsDone;
                UpdateRepository(Instance);
            }
        }

        // --- Delete --- 
        public void Delete(int id)
        {
            var todo = _todoItems.FirstOrDefault(item => item.ID == id);
            if (todo != null)
            {
            _todoItems.Remove(todo);
            UpdateRepository(Instance);
            }
        }

        #endregion


    }
}


