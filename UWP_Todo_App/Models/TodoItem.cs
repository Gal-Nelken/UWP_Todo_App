namespace UWP_Todo_App.Models
{
    public class TodoItem
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private bool isDone;
        public bool IsDone
        {
            get { return isDone; }
            set { isDone = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
