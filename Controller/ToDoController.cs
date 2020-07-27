﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using toDoList_project.Model;
namespace toDoList_project.Controllers
{
    public class ToDoController : Controller
    {
        TodoService service;

        public ToDoController(TodoService service) // DI
        {
            this.service = service;
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
        public IActionResult Create(Todo task) // Model binding
        {
            // Validate (server-side)
            if (!ModelState.IsValid)
                return View(task);

            // Add customer to DB
            service.Create(task);

            // Redirect to index
            return RedirectToAction("Create");
        }
       
    }
}

