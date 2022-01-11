using System.Collections.ObjectModel;
using UWP_Todo_App.Models;

namespace UWP_Todo_App.ViewModels
{
    public class TodoListViewModel
    {

        #region Fields
        // TODO ITEMS COLLECTION
        public ObservableCollection<TodoItemViewModel> Items { get; set; }

        // NEW ITEM
        private TodoItemViewModel newTodo;
        public TodoItemViewModel NewTodo
        {
            get { return newTodo; }
            set { newTodo = value; }
        }


        // SELECTED ITEM
        private TodoItemViewModel selectedItem;
        public TodoItemViewModel SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }

        // Repository Instance
        private TodoRepository _repository;

        #endregion

        // CONSTRUCTOR
        public TodoListViewModel(TodoRepository repository)
        {
            Items = new ObservableCollection<TodoItemViewModel>();
            _repository = repository;
            getTodos();
        }

        #region Methods
        public void DeleteItem()
        {
            if (selectedItem != null)
            {
                TodoItem itemToRemove = new TodoItem()
                {
                    Title = selectedItem.Title,
                    Description = selectedItem.Description,
                    ID = selectedItem.ID,
                    IsDone = selectedItem.IsDone
                };

                _repository.Delete(itemToRemove);
                getTodos();
            }
        }


        public void AddItem()
        {
            newTodo.ID = 0;
            _repository.Add(new TodoItem()
            {
                ID = newTodo.ID,
                Title = newTodo.Title,
                Description = newTodo.Description,
                IsDone = newTodo.IsDone
            });
            getTodos();
            newTodo.Save();
        }

        private void getTodos()
        {
            var items = _repository.GetAll();
            Items.Clear();
            foreach (var item in items) Items.Add(new TodoItemViewModel(item));
        }

        #endregion

    }
}
