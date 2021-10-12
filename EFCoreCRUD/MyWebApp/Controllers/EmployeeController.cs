using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreCRUD;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MyWebApp.Controllers
{
    public class EmployeeController : Controller
    {
       
        AppDbContext _db;
        private readonly IHostingEnvironment _hostingEnv;
        public EmployeeController(AppDbContext db, IHostingEnvironment hostingEnv)
        {
            _db = db;
            _hostingEnv = hostingEnv;

        }
        public IActionResult Index()
        {
            var data = _db.Employees.ToList();
            return View(data);
        }
       
        // create
        public IActionResult Create()
        {
            ViewBag.Departments = _db.Departments.ToList();

            return View();
        }

       


       
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            model.ImagePath = "";
             ModelState.Remove("EmpId");

            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    var FileDic = "uploads";
                    string FilePath = Path.Combine(_hostingEnv.WebRootPath, FileDic);
                    var fileName = model.File.FileName;
                    var filePath = Path.Combine(FilePath, fileName);
                    model.ImagePath = Path.Combine(FileDic.ToString(), fileName);

                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        model.File.CopyTo(fs);
                    }
                }
                _db.Employees.Add(model);
                _db.SaveChanges();
               return  RedirectToAction("Index");
            }

            var data = _db.Employees.ToList();
            return View(data);
        }


        // uodate

        public IActionResult Edit(int id)
        {
            ViewBag.Departments = _db.Departments.ToList();
            Employee model = _db.Employees.Find(id);
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                if(model.File!=null)
                {
                    var fileName = model.File.FileName;
                    var FileDic = "uploads";
                    string filePath = Path.Combine(_hostingEnv.WebRootPath, FileDic,fileName );
                    model.ImagePath = Path.Combine(FileDic, fileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        model.File.CopyTo(fs);
                    }
                }
                else
                {
                    var fileName = model.ImagePath;
                    string FilePath = Path.Combine(_hostingEnv.WebRootPath, fileName);
                    if ((System.IO.File.Exists(FilePath)))
                    {
                        System.IO.File.Delete(FilePath);
                    }
                    model.ImagePath = null;
                }

                _db.Employees.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            var data = _db.Employees.ToList();
            return View(data);

        }

        public IActionResult Delete(int id)
        {

                Employee model = _db.Employees.Find(id);
                if(model!=null)
                {

                if (model.ImagePath != null && model.ImagePath != "")
                {
                    var fileName = model.ImagePath;
                    string FilePath = Path.Combine(_hostingEnv.WebRootPath, fileName);
                    if ((System.IO.File.Exists(FilePath)))
                    {
                        System.IO.File.Delete(FilePath);
                    }

                }

                _db.Employees.Remove(model);
                    _db.SaveChanges();
                }
            return RedirectToAction("Index");

        }


    }
}
