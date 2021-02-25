using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class ApplicationModelController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ApplicationModelController(ApplicationDBContext db)
        {
            _db = db;
        }

        //displaying the table data
        public IActionResult Index()
        {
            IEnumerable<Application_Model> objList = _db.ApplicationType;
            return View(objList);
        }

        //get - create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Application_Model obj)
        {
            _db.ApplicationType.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");               //this will show the index action method to see the new category
        }

        // GET - edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        //Post - edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Application_Model obj)     //obj will just fetch name and display order and not id
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(obj);           //update works with Id by default so we hide the id param in edit.cshtml
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

            var obj = _db.ApplicationType.Find(id);
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
            var obj = _db.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ApplicationType.Remove(obj);           //update works with Id by default so we hide the id param in edit.cshtml
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
