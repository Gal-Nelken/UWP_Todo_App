using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_Todo_App.ViewModels;
using UWP_Todo_App.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Todo_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Properties
            private TodoListViewModel listVM;
        #endregion

        #region Constructor
            public MainPage()
            {
                this.InitializeComponent();
                listVM = new TodoListViewModel(Models.TodoRepository.Instance);
            }
        #endregion

        #region Methods

        // --- Add Todo Modal ---
        private void addTodoBtn_Click(object sender, RoutedEventArgs e)
            {
            
            var newTodoModal = new AddNewTodo()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
            MainGrid.Children.Add(newTodoModal);
            Grid.SetRowSpan(newTodoModal, 3);
            newTodoModal.ParentControl = MainGrid;            
            }

        // --- Edit Todo Modal ---
        private void EditBtn_Click(object sender, RoutedEventArgs e)
            {
                var button = sender as Button;
                var ItemToEdit = (TodoItemViewModel)button.DataContext;

                var editTodoModal = new EditTodoItem(ItemToEdit)
                {
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                };
                MainGrid.Children.Add(editTodoModal);
                Grid.SetRowSpan(editTodoModal, 3);
                editTodoModal.ParentControl = MainGrid;
            }

        #endregion

    }
}
