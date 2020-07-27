using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toDoList_project.Model
{
    public class TaskService
    {
        //// Our "poor mans" DB
        List<Task> _tasks = new List<Task>
        {
            new Task { Id = 1, Name = "Meet Friend",TaskDate=DateTime.Today, Cathegory = "Home" },
            new Task { Id = 2, Name = "Clean House",TaskDate=DateTime.Today, Cathegory = "Home" },
            new Task { Id = 3, Name = "Buy Groceries",TaskDate=DateTime.Today, Cathegory = "Home" }
        };
        public Task[] GetAll()
        {
            return _tasks.ToArray();
        }
        public void Create(Task task)
        {
            _tasks.Add(task);

        }
    }
}

