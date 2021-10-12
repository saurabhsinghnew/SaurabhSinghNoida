using EFCoreDb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext _db;
        public ProductController(AppDbContext db)
        {

            _db = db;
        }
        public IActionResult Index()
        {
            var data = _db.Products.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _db.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(model);
                _db.SaveChanges();
                RedirectToAction("Index");
            }

            var data = _db.Products.ToList();
            return View(data);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _db.Categories.ToList();
            Product model = _db.Products.Find(id);
            return View("Create",model);
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(model);
                _db.SaveChanges();
                RedirectToAction("Index");
            }

            var data = _db.Products.ToList();
            return View("Create", model);

        }


        [HttpPost]
        public IActionResult Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Product model = _db.Products.Find(id);
                _db.Products.Remove(model);
                _db.SaveChanges();
                RedirectToAction("Index");
            }

            var data = _db.Products.ToList();
            return View(data);

        }
    }
}