using System.Collections.ObjectModel;
using System.ComponentModel;
using UWP_Todo_App.Models;
using UWP_Todo_App.ViewModels.Commands;

namespace UWP_Todo_App.ViewModels
{
    public class TodoListViewModel : INotifyPropertyChanged
    {

        // TODO ITEMS COLLECTION
        public ObservableCollection<TodoItemViewModel> Items { get; set; }

        // REMOVE TODO COMMAND
        public RemoveTodoCommand RemoveButtonCommand { get; set; }


        // SELECTED ITEM
        private TodoItemViewModel selectedItem;
        public TodoItemViewModel SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        // CONSTRUCTOR
        public TodoListViewModel()
        {
            Items = new ObservableCollection<TodoItemViewModel>();
            RemoveButtonCommand = new RemoveTodoCommand(this);

            setTodosToShow();
        }


        public void DeleteItem()
        {
            if (selectedItem != null)
            {
                TodoRepository repository = new TodoRepository();
                repository.Delete(SelectedItem);
               Items.Remove(SelectedItem);
            }
        }


        public void AddItem()
        {
            // TODO: OPEN A NEW WINDOW TO CREATE A NEW TODO
        }



        private void setTodosToShow()
        {
            var repository = new TodoRepository();
            var items = repository.GetAll();
            foreach (TodoItem item in items) Items.Add(new TodoItemViewModel(item));
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
