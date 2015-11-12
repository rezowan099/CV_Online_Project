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
    public class EducationController : Controller
    {
        private CVOContext db = new CVOContext();

        //
        // GET: /Education/

        public ActionResult Index()
        {
            var educations = db.Educations.Include(e => e.PersonalInformation).Include(e => e.ConcentrationMajorGroup);
            return View(educations.ToList());
        }

        //
        // GET: /Education/Details/5

        public ActionResult Details(int id = 0)
        {
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        //
        // GET: /Education/Create

        public ActionResult Create()
        {
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName");
            ViewBag.ConcentrationMajorGroupId = new SelectList(db.ConcentrationMajorGroups, "Id", "Type");
            return View();
        }

        //
        // POST: /Education/Create

        [HttpPost]
        public ActionResult Create(Education education)
        {
            if (ModelState.IsValid)
            {
                db.Educations.Add(education);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", education.PersonalInfoId);
            ViewBag.ConcentrationMajorGroupId = new SelectList(db.ConcentrationMajorGroups, "Id", "Type", education.ConcentrationMajorGroupId);
            return View(education);
        }

        //
        // GET: /Education/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", education.PersonalInfoId);
            ViewBag.ConcentrationMajorGroupId = new SelectList(db.ConcentrationMajorGroups, "Id", "Type", education.ConcentrationMajorGroupId);
            return View(education);
        }

        //
        // POST: /Education/Edit/5

        [HttpPost]
        public ActionResult Edit(Education education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", education.PersonalInfoId);
            ViewBag.ConcentrationMajorGroupId = new SelectList(db.ConcentrationMajorGroups, "Id", "Type", education.ConcentrationMajorGroupId);
            return View(education);
        }

        //
        // GET: /Education/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        //
        // POST: /Education/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Education education = db.Educations.Find(id);
            db.Educations.Remove(education);
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