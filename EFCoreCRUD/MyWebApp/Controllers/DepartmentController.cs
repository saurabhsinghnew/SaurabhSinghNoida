﻿using EFCoreCRUD;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        AppDbContext _db;
        public DepartmentController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var data = _db.Departments.ToList();
            return View(data);
        }

       
        public IActionResult Create()
        {
            ViewBag.Departments = _db.Departments.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Department model)
        {
            ModelState.Remove("DeptId");
            if (ModelState.IsValid)
            {
              
                _db.Departments.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            var data = _db.Departments.ToList();
            return View(data);
        }

        public IActionResult Edit(int id)
        {
           
            Department model = _db.Departments.Find(id);
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(Department model)
        {
          //  ModelState.Remove("DeptId");
            if (ModelState.IsValid)
            {

                _db.Departments.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            var data = _db.Departments.ToList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            Department model = _db.Departments.Find(id);
            if (model != null)
            {
                _db.Departments.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");

        }


    }
}
