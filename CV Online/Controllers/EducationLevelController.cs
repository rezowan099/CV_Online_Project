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
    public class EducationLevelController : Controller
    {
        private IGenericRepository<EducationLevel> repository = null;

        public EducationLevelController()
        {
            this.repository = new GenericRepository<EducationLevel>();
        }
        //
        // GET: /EducationLevel/

        public ActionResult Index()
        {
            var educationLevel = repository.SelectAll().ToList();
            return View(educationLevel);
        }

        //
        // GET: /EducationLevel/Details/5

        public ActionResult Details(int id = 0)
        {
            EducationLevel educationlevel = repository.SelectById(id);
            if (educationlevel == null)
            {
                return HttpNotFound();
            }
            return View(educationlevel);
        }

        //
        // GET: /EducationLevel/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EducationLevel/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EducationLevel educationlevel)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(educationlevel);
                repository.Save();
                return RedirectToAction("Index");
            }

            return View(educationlevel);
        }

        //
        // GET: /EducationLevel/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var educationlevel = repository.SelectById(id);
            if (educationlevel == null)
            {
                return HttpNotFound();
            }
            return View(educationlevel);
        }

        //
        // POST: /EducationLevel/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EducationLevel educationlevel)
        {
            if (ModelState.IsValid)
            {
                repository.Update(educationlevel);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(educationlevel);
        }

        //
        // GET: /EducationLevel/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var educationlevel = repository.SelectById(id);
            if (educationlevel == null)
            {
                return HttpNotFound();
            }
            return View(educationlevel);
        }

        //
        // POST: /EducationLevel/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var educationlevel = repository.SelectById(id);
            repository.Delete(educationlevel);
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