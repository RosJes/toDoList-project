﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using toDoList_project.Model.ViewModel;
using System.Globalization;

namespace toDoList_project.Model
{
    public class TodoService
    {
       
        //// Our "poor mans" DB
        List<Todo> _tasks = new List<Todo>
        {
            new Todo { Id = 1, Name = "Mow Lawn",TaskDate=DateTime.Parse("08/03/2020 12:34:11"), Cathegory = "Home",Description="Garden",isImportant=false},
            new Todo { Id = 2, Name = "Clean House",TaskDate=DateTime.Parse("08/04/2020 22:34:11"), Cathegory = "Home",Description="Reminder:Don't forget the fridge",isImportant=true,Reminder=3},
            new Todo { Id = 3, Name = "Buy Groceries",TaskDate=DateTime.Parse("08/05/2020 22:34:11"), Cathegory = "Home",Description="Apples,Pasta,Ketchup",isImportant=true,Reminder=7},
            new Todo { Id = 4, Name = "Buy Groceries",TaskDate= DateTime.Parse("08/18/2018 07:22:16"), Cathegory = "Home",Description="Apples,Pasta,Ketchup",isImportant=false},
            new Todo { Id = 5, Name = "Leave Report",TaskDate=DateTime.Parse("07/29/2020 22:34:11"), Cathegory = "Work",Description="Jane att 10:00",isImportant=false},
            new Todo { Id = 6, Name = "Send projects",TaskDate=DateTime.Parse("08/05/2020 13:34:11"), Cathegory = "Work",Description="Academic Work",isImportant=true,Reminder=5},
            new Todo { Id = 7, Name = "Talk to John",TaskDate=DateTime.Now, Cathegory = "Work",Description="Lunch",isImportant=true,Reminder=1},
            new Todo { Id = 8, Name = "Call Ellen",TaskDate= DateTime.Parse("08/18/2018 07:22:16"), Cathegory = "Work",Description="+42738056892",isImportant=true,Reminder=4}
        };
      
        public Todo[] GetAll(string cathegory)
        {
            return _tasks.Where(o=>o.Cathegory==cathegory).OrderByDescending(o => o.TaskDate).ToArray();
        }
        public Todo[] GetAll()
        {
            return _tasks.OrderBy(o => o.TaskDate).ToArray();
        }
        static int id;
        public void Create(CreateVM task)
        {
            id = _tasks.Count + 1;
            if(!task.isImportant)
            {
                _tasks.Add(new Todo
                {
                    Id = id,
                    Name = task.Name,
                    TaskDate = task.TaskDate,
                    Description = task.Description,
                    Cathegory = task.Cathegory,
                    isImportant = task.isImportant,
                    Reminder = 0
                }
           );
            }
            else
            {
                _tasks.Add(new Todo
                {
                    Id = id,
                    Name = task.Name,
                    TaskDate = task.TaskDate,
                    Description = task.Description,
                    Cathegory = task.Cathegory,
                    isImportant = task.isImportant,
                    Reminder = task.Reminder
                }
         );
            }
           
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
            if(!task.isImportant)
            {
                _tasks.Add(new Todo
                {
                    Id = task.Id,
                    Name = task.Name,
                    TaskDate = task.TaskDate,
                    Description = task.Description,
                    Cathegory = task.Cathegory,
                    isImportant = task.isImportant,
                    Reminder = 0
                }
                );
            }
            else
            {
                _tasks.Add(new Todo
                {
                    Id = task.Id,
                    Name = task.Name,
                    TaskDate = task.TaskDate,
                    Description = task.Description,
                    Cathegory = task.Cathegory,
                    isImportant = task.isImportant,
                    Reminder = task.Reminder
                }
               );
            }
            
            _tasks.Remove(GetById(task.Id));
            


        }
        List<Calender> _calender;
        public Calender[] GetAllDays(int year, int month,string cathegory)
        {
            var days = 1;
            var hours = 22;
            var minutes = 34;
            var seconds = 11;
            DateTime date = new DateTime(year, month,days,hours,minutes,seconds);
            var calendarDate = new DateTime(date.Year, date.Month, 1);
            int weekdayInt = (int)new DateTime(date.Year, date.Month, 1).DayOfWeek - 1; //mon = 1, tis = 2 osv...
            int totalCalendarSpots = (DateTime.DaysInMonth(date.Year, date.Month) + weekdayInt);
            _calender = new List<Calender>();
            var tasklist = new List<Todo>();
            for (int i = 0; weekdayInt < totalCalendarSpots; i++)//dynamisk forloop
            {
                if (i == weekdayInt)
                {
                    var day = new Calender
                    {
                        Id = i,
                        Year = year,
                        Month = DateTime.DaysInMonth(year, month),
                        Day = calendarDate,
                        bookedTask = tasklist,
                        EmptyDay = false
                        
                };
                    weekdayInt++;
                    date = date.AddDays(1);
                    calendarDate = calendarDate.AddDays(1);
                    tasklist.AddRange(BookedTask((DateTime.Parse(date.ToString())),cathegory));
                    _calender.Add(day);
                    
                }
                else
                {
                    var day = new Calender
                    {
                        Id = i,
                        Year = 0,
                        Month = 0,
                        Day = DateTime.MinValue,
                        EmptyDay = true
                    };
                    _calender.Add(day);


                }
               
            }
            return _calender.ToArray();
        }
        public List<Todo> BookedTask(DateTime date,string Cathegory)
        {
            if (_tasks != null)
                return _tasks.Where(o => o.TaskDate.Day == date.Day&&o.Cathegory==Cathegory).ToList();
            else
                throw new Exception("finns inget");
           
            
        }
        public string[] CatNavBar()
        {
            return _tasks.Select(o=>o.Cathegory).Distinct().ToArray();
        }
        public Todo[] GetAllByDate(DateTime date)
        {
            return _tasks.Where(o => o.TaskDate == date).ToArray();
        }

    }
}

