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
    public class ReferenceController : Controller
    {
        private CVOContext db = new CVOContext();

        //
        // GET: /Reference/

        public ActionResult Index()
        {
            var references = db.References.Include(r => r.PersonalInformation);
            return View(references.ToList());
        }

        //
        // GET: /Reference/Details/5

        public ActionResult Details(int id = 0)
        {
            Reference reference = db.References.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        //
        // GET: /Reference/Create

        public ActionResult Create()
        {
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName");
            return View();
        }

        //
        // POST: /Reference/Create

        [HttpPost]
        public ActionResult Create(Reference reference)
        {
            if (ModelState.IsValid)
            {
                db.References.Add(reference);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", reference.PersonalInfoId);
            return View(reference);
        }

        //
        // GET: /Reference/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reference reference = db.References.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", reference.PersonalInfoId);
            return View(reference);
        }

        //
        // POST: /Reference/Edit/5

        [HttpPost]
        public ActionResult Edit(Reference reference)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reference).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", reference.PersonalInfoId);
            return View(reference);
        }

        //
        // GET: /Reference/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reference reference = db.References.Find(id);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        //
        // POST: /Reference/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Reference reference = db.References.Find(id);
            db.References.Remove(reference);
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