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
    public class SpecializationController : Controller
    {
        private CVOContext db = new CVOContext();

        //
        // GET: /Specialization/

        public ActionResult Index()
        {
            var specializations = db.Specializations.Include(s => s.PersonalInformation).Include(s => s.LanguageProficiency);
            return View(specializations.ToList());
        }

        //
        // GET: /Specialization/Details/5

        public ActionResult Details(int id = 0)
        {
            Specialization specialization = db.Specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        //
        // GET: /Specialization/Create

        public ActionResult Create()
        {
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName");
            ViewBag.LanguageProficiencyId = new SelectList(db.LanguageProficiency, "Id", "Reading");
            return View();
        }

        //
        // POST: /Specialization/Create

        [HttpPost]
        public ActionResult Create(Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                db.Specializations.Add(specialization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", specialization.PersonalInfoId);
            ViewBag.LanguageProficiencyId = new SelectList(db.LanguageProficiency, "Id", "Reading", specialization.LanguageProficiencyId);
            return View(specialization);
        }

        //
        // GET: /Specialization/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Specialization specialization = db.Specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", specialization.PersonalInfoId);
            ViewBag.LanguageProficiencyId = new SelectList(db.LanguageProficiency, "Id", "Reading", specialization.LanguageProficiencyId);
            return View(specialization);
        }

        //
        // POST: /Specialization/Edit/5

        [HttpPost]
        public ActionResult Edit(Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", specialization.PersonalInfoId);
            ViewBag.LanguageProficiencyId = new SelectList(db.LanguageProficiency, "Id", "Reading", specialization.LanguageProficiencyId);
            return View(specialization);
        }

        //
        // GET: /Specialization/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Specialization specialization = db.Specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        //
        // POST: /Specialization/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Specialization specialization = db.Specializations.Find(id);
            db.Specializations.Remove(specialization);
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