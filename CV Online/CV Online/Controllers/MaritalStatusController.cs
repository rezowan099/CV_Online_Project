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
    public class MaritalStatusController : Controller
    {
        private CVOContext db = new CVOContext();

        //
        // GET: /MaritalStatus/

        public ActionResult Index()
        {
            return View(db.MaritalStatus.ToList());
        }

        //
        // GET: /MaritalStatus/Details/5

        public ActionResult Details(int id = 0)
        {
            MaritalStatus maritalstatus = db.MaritalStatus.Find(id);
            if (maritalstatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalstatus);
        }

        //
        // GET: /MaritalStatus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MaritalStatus/Create

        [HttpPost]
        public ActionResult Create(MaritalStatus maritalstatus)
        {
            if (ModelState.IsValid)
            {
                db.MaritalStatus.Add(maritalstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maritalstatus);
        }

        //
        // GET: /MaritalStatus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MaritalStatus maritalstatus = db.MaritalStatus.Find(id);
            if (maritalstatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalstatus);
        }

        //
        // POST: /MaritalStatus/Edit/5

        [HttpPost]
        public ActionResult Edit(MaritalStatus maritalstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maritalstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maritalstatus);
        }

        //
        // GET: /MaritalStatus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MaritalStatus maritalstatus = db.MaritalStatus.Find(id);
            if (maritalstatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalstatus);
        }

        //
        // POST: /MaritalStatus/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            MaritalStatus maritalstatus = db.MaritalStatus.Find(id);
            db.MaritalStatus.Remove(maritalstatus);
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