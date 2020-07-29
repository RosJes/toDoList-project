using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using toDoList_project.Model;
using toDoList_project.Model.ViewModel;
namespace toDoList_project.Controllers
{
    public class ToDoController : Controller
    {
        TodoService service;
        CalenderService calender;

        public ToDoController(TodoService service,CalenderService calender) // DI
        {
            this.service = service;
            this.calender = calender;
        }
        [Route("")]
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            // Show empty form
            return View();
        }
        [Route("Calender/{year}/{month}")]
        [HttpGet]
        public IActionResult Calender(int year,int month)
        {
            var model = service.GetAllDays(year,month);
            // Show empty form
            return View(model);
        }
        [Route("_todolist")]
        [HttpGet]
        public IActionResult _todolist()
        {
            var model = service.GetAll();
            // Show empty form
            return PartialView(model);
        }
       
        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            // Show empty form
            return View();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(CreateVM task) // Model binding
        {
            // Validate (server-side)
            if (!ModelState.IsValid)
                return View(task);

            // Add customer to DB
            service.Create(task);

            // Redirect to index
            return RedirectToAction("Create");
        }
        [Route("Delete/{id}")]
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [Route("Delete/{id}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return View(id);

            // Add customer to DB
            service.Delete(id);

            // Redirect to index
            return RedirectToAction("Create");
        }
        
        [Route("Edit/{id}")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = service.GetById(id);
            return View(model);
        }
        [Route("Edit/{id}")]
        [HttpPost]
        public IActionResult Edit(Todo task)
        {
            if (!ModelState.IsValid)
                return View(task);

            // Add customer to DB
            service.Edit(task);

            // Redirect to index
            return RedirectToAction("Create");
        }
    }
}

