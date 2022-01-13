using UWP_Todo_App.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UWP_Todo_App.Views
{
    public sealed partial class TodoItemModal : UserControl
    {
        #region Fields
        // ITEM VIEW-MODAL
        private TodoItemViewModel itemVM { get; set; }

        #endregion

        #region Propertys
        // PARENT ELEMENT FOR CLOSING MODAL
        private Grid ParentControl;

        #endregion


        #region Constructor
        public TodoItemModal(TodoItemViewModel item, Grid parentControl)
        {
            this.InitializeComponent();
            itemVM = new TodoItemViewModel(item);
            ParentControl = parentControl;
        }
        #endregion

        #region Methods

        // CLOSE MODAL
        private void CloseModalBtn_Click(object sender, RoutedEventArgs e)
        {
            ParentControl.Children.Remove(this);
        }

        // SAVE ITEM
        private void submit_click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(itemVM.Title) || string.IsNullOrWhiteSpace(itemVM.Description)) return;
            if (itemVM.ID != 0) itemVM.Update();
            else itemVM.Save();
            ParentControl.Children.Remove(this);

        }

        #region Int To String 
        // Determine the type of the form for the item modal
        private string IntToString(int id, string param = "")
        {
            if (param == "title")
            {
                if (id != 0) return "Edit Todo";
                return "Add Todo";
            }
            if (id != 0) return "🖊";
            return "➕";
        }
        #endregion

        #region Int To Visibility
        // Determine if IsDone section need to be visible or not - if id is not 0 its in Edit Modal so its visible else in collapsed visibility
        private Visibility IntToVisibility(int id)
        {
            if (id != 0) return Visibility.Visible;
            return Visibility.Collapsed;
        }
        #endregion

        #endregion
    }
}
