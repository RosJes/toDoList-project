using System;
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
            new Todo { Id = 1, Name = "Meet Friend",TaskDate=DateTime.Parse("07/29/2020 22:34:11"), Cathegory = "Home",Description="Jane att 10:00"},
            new Todo { Id = 2, Name = "Clean House",TaskDate=DateTime.Parse("07/01/2020 22:34:11"), Cathegory = "Home",Description="Reminder:Don't forget the fridge"},
            new Todo { Id = 3, Name = "Buy Groceries",TaskDate=DateTime.Parse("07/15/2020 22:34:11"), Cathegory = "Home",Description="Apples,Pasta,Ketchup"},
            new Todo { Id = 4, Name = "Buy Groceries",TaskDate= DateTime.Parse("08/18/2018 07:22:16"), Cathegory = "Home",Description="Apples,Pasta,Ketchup"},
         new Todo { Id = 5, Name = "Leave Report",TaskDate=DateTime.Parse("07/29/2020 22:34:11"), Cathegory = "Work",Description="Jane att 10:00"},
            new Todo { Id = 6, Name = "Book meeting",TaskDate=DateTime.Now, Cathegory = "Work",Description="Promotion"},
            new Todo { Id = 7, Name = "Talk to John",TaskDate=DateTime.Now, Cathegory = "Work",Description="Lunch"},
            new Todo { Id = 8, Name = "Call Ellen",TaskDate= DateTime.Parse("08/18/2018 07:22:16"), Cathegory = "Work",Description="+42738056892"}
        };
        Calender calender = new Calender();
        public Todo[] GetAll(string cathegory)
        {
            return _tasks.Where(o=>o.Cathegory==cathegory).OrderByDescending(o => o.TaskDate).ToArray();
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
               Cathegory=task.Cathegory,
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
                Cathegory = task.Cathegory,
            }
                );
            _tasks.Remove(GetById(task.Id));


        }
        List<Calender> _calender;
        public Calender[] GetAllDays(int year, int month,string cathegory)
        {
            var days = 1;
            var hours = 22;
            var minutes = 34;
            var seconds = 11;
            var reservations = _tasks.ToArray();
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
    }
}

