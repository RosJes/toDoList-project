using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace toDoList_project.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TaskDate { get; set; }
        public string Cathegory { get; set; }
        public string Description { get; set; }
        public bool ischecked { get; set; }
        public bool isImportant{ get; set; }
    }
}
