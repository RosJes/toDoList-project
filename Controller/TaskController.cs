using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using toDoList_project.Model;

namespace toDoList_project.Controllers
{
    public class TaskController : Controller
    {
        TaskService service;

        public TaskController(TaskService service) // DI
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var model=service.GetAll();
            return View(model);
        }
    }
}
