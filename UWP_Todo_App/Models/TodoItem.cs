using System;

namespace UWP_Todo_App.Models
{
    public class TodoItem
    {
        #region Properties
        private int id;
        public int ID
        {
            get { return id; }
            private set { id = value; }
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

        #endregion


        #region Constructor
        public TodoItem(string title, string description, bool isDone = false, int id = 0)
        {
            if (id == 0) ID = getRandomInt();
            else ID = id;
            Title = title;
            Description = description;
            IsDone = isDone;
        }

        #endregion


        #region Methods
        // --- Random Int For ID --- 
        private int getRandomInt()
        {
            Random rnd = new Random();
            return rnd.Next(1, 99999);
        }

        #endregion


    }
}
