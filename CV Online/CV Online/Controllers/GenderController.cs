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
        private CVOContext db = new CVOContext();

        //
        // GET: /Gender/

        public ActionResult Index()
        {
            return View(db.Genders.ToList());
        }

        //
        // GET: /Gender/Details/5

        public ActionResult Details(int id = 0)
        {
            Gender gender = db.Genders.Find(id);
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
        public ActionResult Create(Gender gender)
        {
            if (ModelState.IsValid)
            {
                db.Genders.Add(gender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gender);
        }

        //
        // GET: /Gender/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gender gender = db.Genders.Find(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        //
        // POST: /Gender/Edit/5

        [HttpPost]
        public ActionResult Edit(Gender gender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gender);
        }

        //
        // GET: /Gender/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gender gender = db.Genders.Find(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        //
        // POST: /Gender/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Gender gender = db.Genders.Find(id);
            db.Genders.Remove(gender);
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