using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_Todo_App.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWP_Todo_App.Views
{
    public sealed partial class AddNewTodo : UserControl
    {
        #region Fields
        // ITEM VIEW-MODAL
        private TodoItemViewModel itemVM { get; set; }

        // PARENT ELEMENT FOR CLOSING MODAL
        public Grid ParentControl;

        #endregion


        #region Constructor
        public AddNewTodo()
        {
            this.InitializeComponent();
            itemVM = new TodoItemViewModel(Models.TodoRepository.Instance);
        }
        #endregion

        #region Methods

        // CLOSE MODAL
        private void CloseModalBtn_Click(object sender, RoutedEventArgs e)
        {
            ParentControl.Children.Remove(this);            
        }

        // SAVE ITEM
        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(itemVM.Title) || string.IsNullOrWhiteSpace(itemVM.Description)) return;
            itemVM.Save();
            ParentControl.Children.Remove(this);
        }

        #endregion
    }
}
