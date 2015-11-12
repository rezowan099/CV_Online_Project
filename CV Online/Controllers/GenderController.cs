using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Online.Models;
using CV_Online.Repository;

namespace CV_Online.Controllers
{
    public class GenderController : Controller
    {
        private IGenericRepository<Gender> repository = null;

        public GenderController()
        {
            this.repository = new GenericRepository<Gender>();
        }

        //
        // GET: /Gender/
        
        public ActionResult Index()
        {
            var gender = repository.SelectAll().ToList();
            return View(gender);
        }

        //
        // GET: /Gender/Details/5

        public ActionResult Details(int id = 0)
        {
            var gender = repository.SelectById(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        //
        // GET: /Gender/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gender/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gender gender)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(gender);
                repository.Save();
                return RedirectToAction("Index");
            }

            return View(gender);
        }

        //
        // GET: /Gender/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gender gender = repository.SelectById(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        //
        // POST: /Gender/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gender gender)
        {
            if (ModelState.IsValid)
            {
                repository.Update(gender);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(gender);
        }

        //
        // GET: /Gender/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gender gender = repository.SelectById(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        //
        // POST: /Gender/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}