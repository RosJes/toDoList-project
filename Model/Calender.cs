using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toDoList_project.Model
{
    public class Calender
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public DateTime Day { get; set; }
        public  bool EmptyDay { get; set; }
    }
}
