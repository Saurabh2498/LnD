using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        //extracting info from db
        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)      
        {
            _db = db;
        }

        //displaying the table data
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        //get - create
        public IActionResult Create()
        {
            return View();
        }

        //Post - create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {                                         //this will show the index action method to see the new category
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET - edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            
            var obj = _db.Category.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        //Post - edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)     //obj will just fetch name and display order and not id
        {
            if (ModelState.IsValid)
            {                                         
                _db.Category.Update(obj);           //update works with Id by default so we hide the id param in edit.cshtml
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET - delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        //Post - delete
        [HttpPost]
        public IActionResult DeletePost(int? id)     //obj will just fetch name and display order and not id
        {
            var obj = _db.Category.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);           //update works with Id by default so we hide the id param in edit.cshtml
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
