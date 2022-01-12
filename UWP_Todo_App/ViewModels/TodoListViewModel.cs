using System;
using System.Collections.ObjectModel;
using System.Linq;
using UWP_Todo_App.Models;

namespace UWP_Todo_App.ViewModels
{
    public class TodoListViewModel
    {
        #region Fields
        // --- TODO ITEMS COLLECTION --- 
        public ObservableCollection<TodoItemViewModel> Items { get; set; }

        // --- SELECTED ITEM --- 
        private TodoItemViewModel selectedItem;
        public TodoItemViewModel SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }

        #endregion

        #region Propertys
        // --- REPOSITORY INSTANCE --- 
        private TodoRepository _repository;

        #endregion

        // --- CONSTRUCTOR --- 
        public TodoListViewModel(TodoRepository repository)
        {
            Items = new ObservableCollection<TodoItemViewModel>();
            _repository = repository;
            repository.UpdateRepository += getTodos;
            getTodos(_repository);
        }

        #region Methods
        // --- DELETE --- 
        public void DeleteItem()
        {
            if (selectedItem != null)
            {
                _repository.Delete(selectedItem.ID);
                Items.Remove(selectedItem);
            }
        }

        // --- On Repository Update, Update Collection --- 
        private void getTodos(TodoRepository repository)
        {
            var repoTodos = repository.GetAll();

            for (int i = 0; i < repoTodos.Count; i++)
            {
                var todo = Items.FirstOrDefault(currItem => currItem.ID == repoTodos[i].ID);
                if (todo != null)
                {
                    todo.Idx = i + 1;
                    todo.Title = repoTodos[i].Title;
                    todo.Description = repoTodos[i].Description;
                    todo.IsDone = repoTodos[i].IsDone;
                }
                else Items.Add(new TodoItemViewModel(repoTodos[i], i + 1, _repository));
            }
        }

        #endregion
        
    }
}
