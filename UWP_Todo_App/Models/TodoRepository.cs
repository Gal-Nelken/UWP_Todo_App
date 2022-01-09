using SQLite;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWP_Todo_App.ViewModels;

namespace UWP_Todo_App.Models
{
    public class TodoRepository
    {

        static string DataBaseName = "Todos.db";
        static string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static string DataBasePath = Path.Combine(FolderPath, DataBaseName);

        private List<TodoItem> _todoItems { get; set; }

        // CUNSTRUCTOR
        public TodoRepository()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DataBasePath))
            {
                connection.CreateTable<TodoItem>();
                _todoItems = connection.Table<TodoItem>().ToList();

                // FOR FIRST TIME RUN
             //   if (_todoItems.Count == 0)
             //   {
             //       _todoItems.Add(new TodoItem {
             //       Title = "Todo1",
             //       Description = "Description bla bla bla",
             //       IsDone = false
             //       });  
             //       _todoItems.Add(new TodoItem {
             //       Title = "Todo2",
             //       Description = "Description bla bla bla",
             //       IsDone = false
             //       });
             //       _todoItems.Add(new TodoItem {
             //       Title = "Todo3",
             //       Description = "Description bla bla bla",
             //       IsDone = false
             //       });
             //       _todoItems.Add(new TodoItem {
             //       Title = "Todo4",
             //       Description = "Description bla bla bla",
             //       IsDone = false
             //       });
             //       connection.InsertAll(_todoItems);
             //   }
            }
        }


        public void Add(TodoItem todoItem)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DataBasePath))
            {
                connection.CreateTable<TodoItem>();
                connection.Insert(todoItem);
            }
        }


        public void Delete(TodoItem todoItem)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DataBasePath))
            {
                connection.CreateTable<TodoItem>();
                connection.Delete(todoItem);
            }
        }


        public TodoItem Get(int id)
        {
            return _todoItems[id];
        }


        public List<TodoItem> GetAll()
        {
            return _todoItems;
        }

    }
}


