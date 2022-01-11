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
    public partial class AddNewTodo : UserControl
    {
        public TodoListViewModel listVM { private get; set; }
        
        public AddNewTodo()
        {
            this.InitializeComponent();
            
        }

        private void CloseModalBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(listVM.NewTodo.Title) || string.IsNullOrWhiteSpace(listVM.NewTodo.Description)) return;
            listVM.AddItem();
            this.Visibility = Visibility.Collapsed;
        }
    }
}
