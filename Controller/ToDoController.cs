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
        [Route("_list")]
        [HttpGet]
        public IActionResult _list()
        {
            var model = service.GetAll();
            return PartialView(model);
        }

        [Route("_calender/{year}/{month}/{cathegory}")]
        [HttpGet]
        public IActionResult _calender(int year, int month, string cathegory)
        {
            var model = service.GetAllDays(year, month, cathegory);
            // Show empty form
            return PartialView(model);
        }
        [Route("Calender")]
        [HttpGet]
        public IActionResult Calender()
        {
            return View();
        }
        [Route("_CatNavBar")]
        [HttpGet]
        public IActionResult _CatNavBar()
        {
            var model = service.CatNavBar();
            // Show empty form
            return PartialView(model);
        }
        [Route("_todolist/{cathegory}")]
        [HttpGet]
        public IActionResult _todolist(string cathegory)
        {
            var model = service.GetAll(cathegory);
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

