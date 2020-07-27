﻿using System;
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
            new Todo { Id = 1, Name = "Meet Friend",TaskDate=DateTime.Today, Cathegory = "Home",Description="Jane att 10:00",ischecked=true },
            new Todo { Id = 2, Name = "Clean House",TaskDate=DateTime.Today, Cathegory = "Home",Description="Reminder:Don't forget the fridge",ischecked=false },
            new Todo { Id = 3, Name = "Buy Groceries",TaskDate=DateTime.Today, Cathegory = "Home",Description="Apples,Pasta,Ketchup",ischecked=false }
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
               TaskDate=DateTime.Today,
               Description=task.Description,
               Cathegory="Home",
               ischecked=false
            }
                );

            id++;
        }
    }
}
