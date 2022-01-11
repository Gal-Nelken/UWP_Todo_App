using System.Collections.Generic;
using System.Linq;

namespace UWP_Todo_App.Models
{
    public delegate void RepositoryChanged(TodoRepository repository);
    public class TodoRepository
    {

        #region Singleton
        // Repository Instance
        private static TodoRepository _instance;
        public static TodoRepository Instance => _instance ?? (_instance = new TodoRepository());

        // Repository Update Event
        public event RepositoryChanged UpdateRepository;

        // Constructor
        private TodoRepository()
        {
            _todoItems = new List<TodoItem>();

            for (int i = 0; i < 6; i++)
            {
                _todoItems.Add(new TodoItem
                {
                    ID = i + 1,
                    Title = $"Todo{i+1}",
                    Description = "Do somthing, bla bla bla bla bla bla",
                    IsDone = false
                });
            }
        }

        #endregion

        #region Fields
        private List<TodoItem> _todoItems;

        #endregion

        #region Methods
        // Create
        public void Add(TodoItem todoItem)
        {
            _todoItems.Add(todoItem);
            reindexItems();
            UpdateRepository(Instance);
        }
        
        // Read
        public List<TodoItem> GetAll()
        {
            return _todoItems;
        }
        public TodoItem Get(int id)
        {
            return _todoItems[id];
        }

        // Update
        public void Update(TodoItem todoItem)
        {
            var todo = _todoItems.FirstOrDefault(item => item.ID == todoItem.ID);
            if (todo != null)
            {
                todo.Title = todoItem.Title;
                todo.Description = todoItem.Description;
                todo.IsDone = todoItem.IsDone;
            }
        }

        // Delete
        public void Delete(int id)
        {
            var todo = _todoItems.FirstOrDefault(item => item.ID == id);
            if (todo != null)
            {
            _todoItems.Remove(todo);
            reindexItems();
            }
            UpdateRepository(Instance);
        }

        // Set Items Index
        private void reindexItems()
        {
            for (int i = 0; i < _todoItems.Count; i++)
            {
                _todoItems[i].ID = i + 1;
            }
        }

        #endregion
    }
}


