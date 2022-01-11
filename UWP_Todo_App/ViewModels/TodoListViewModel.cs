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

        // REPOSITORY INSTANCE
        private TodoRepository _repository;

        #endregion

        // CONSTRUCTOR
        public TodoListViewModel(TodoRepository repository)
        {
            Items = new ObservableCollection<TodoItemViewModel>();
            _repository = repository;
            repository.UpdateRepository += new RepositoryChanged(getTodos);
            getTodos(_repository);
        }

        #region Methods
        // DELETE
        public void DeleteItem()
        {
            if (selectedItem != null)
            {
                _repository.Delete(selectedItem.ID);
            }
        }

        // On Repository Update, Update Collection
        private void getTodos(TodoRepository repository)
        {
            var items = repository.GetAll();
            Items.Clear();
            foreach (var item in items) Items.Add(new TodoItemViewModel(item, _repository));
        }

        #endregion

    }
}
