using System.Collections.Generic;


namespace UWP_Todo_App.Models
{
    public class TodoRepository
    {

        #region Singleton
        private static TodoRepository _instance;
        public static TodoRepository Instance => _instance ?? (_instance = new TodoRepository());

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
        public void Add(TodoItem todoItem)
        {
            _todoItems.Add(todoItem);
            reindexItems();
        }

        public void Delete(TodoItem todoItem)
        {
            _todoItems.RemoveAt(todoItem.ID - 1);
            reindexItems();
        }

        public TodoItem Get(int id)
        {
            return _todoItems[id];
        }

        public List<TodoItem> GetAll()
        {
            return _todoItems;
        }

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


