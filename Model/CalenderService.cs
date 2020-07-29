using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toDoList_project.Model
{
    public class CalenderService
    {
       
        List<Calender> _calender;
        public Calender[] GetAllDays(int year,int month)
        {
            DateTime date = new DateTime(year, month, 1);
            var calendarDate = new DateTime(date.Year, date.Month, 1);
            int weekdayInt = (int)new DateTime(date.Year, date.Month, 1).DayOfWeek - 1; //mon = 1, tis = 2 osv...
            int totalCalendarSpots = (DateTime.DaysInMonth(date.Year, date.Month) + weekdayInt);
            _calender = new List<Calender>();
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
                        EmptyDay=false

                    };
                    weekdayInt++;
                    calendarDate = calendarDate.AddDays(1);
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
    }
}
