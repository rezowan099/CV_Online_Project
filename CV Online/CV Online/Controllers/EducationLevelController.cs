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
        private CVOContext db = new CVOContext();

        //
        // GET: /EducationLevel/

        public ActionResult Index()
        {
            return View(db.EducationLevels.ToList());
        }

        //
        // GET: /EducationLevel/Details/5

        public ActionResult Details(int id = 0)
        {
            EducationLevel educationlevel = db.EducationLevels.Find(id);
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
        public ActionResult Create(EducationLevel educationlevel)
        {
            if (ModelState.IsValid)
            {
                db.EducationLevels.Add(educationlevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(educationlevel);
        }

        //
        // GET: /EducationLevel/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EducationLevel educationlevel = db.EducationLevels.Find(id);
            if (educationlevel == null)
            {
                return HttpNotFound();
            }
            return View(educationlevel);
        }

        //
        // POST: /EducationLevel/Edit/5

        [HttpPost]
        public ActionResult Edit(EducationLevel educationlevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educationlevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(educationlevel);
        }

        //
        // GET: /EducationLevel/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EducationLevel educationlevel = db.EducationLevels.Find(id);
            if (educationlevel == null)
            {
                return HttpNotFound();
            }
            return View(educationlevel);
        }

        //
        // POST: /EducationLevel/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EducationLevel educationlevel = db.EducationLevels.Find(id);
            db.EducationLevels.Remove(educationlevel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}