using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using toDoList_project.Model.ViewModel;

namespace toDoList_project.Model
{
    public class TodoService
    {
        //// Our "poor mans" DB
        List<Todo> _tasks = new List<Todo>
        {
            new Todo { Id = 1, Name = "Meet Friend",TaskDate=DateTime.Today, Cathegory = "Home",Description="Jane att 10:00"},
            new Todo { Id = 2, Name = "Clean House",TaskDate=DateTime.Today, Cathegory = "Home",Description="Reminder:Don't forget the fridge"},
            new Todo { Id = 3, Name = "Buy Groceries",TaskDate=DateTime.Today, Cathegory = "Home",Description="Apples,Pasta,Ketchup"}
        };
        public Todo[] GetAll()
        {
            return _tasks.ToArray();
        }
        static int id = 4;
        public void Create(CreateVM task)
        {
            _tasks.Add(new Todo
            {
               Id=id,
               Name=task.Name,
               TaskDate=task.TaskDate,
               Description=task.Description,
               Cathegory="Home",
            }
                );
            id++;
        }
        public void Delete(int id)
        {
           var item= _tasks.Where(o => o.Id == id).FirstOrDefault();
            _tasks.Remove(item);
        }
        public Todo GetById(int id)
        {
            return _tasks.Where(p => p.Id == id).First();
        }
        public void Edit(Todo task)
        {
            _tasks.Add(new Todo
            {
                Id = task.Id,
                Name = task.Name,
                TaskDate = task.TaskDate,
                Description = task.Description,
                Cathegory = "Home",
            }
                );
            _tasks.Remove(GetById(task.Id));


        }
    }
}

