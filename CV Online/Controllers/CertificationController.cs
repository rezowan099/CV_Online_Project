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
    public class CertificationController : Controller
    {
        private CVOContext db = new CVOContext();

        //
        // GET: /Certification/

        public ActionResult Index()
        {
            var certifications = db.Certifications.Include(c => c.Institution);
            return View(certifications.ToList());
        }

        //
        // GET: /Certification/Details/5

        public ActionResult Details(int id = 0)
        {
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        //
        // GET: /Certification/Create

        public ActionResult Create()
        {
            ViewBag.InstitutionId = new SelectList(db.Institutions, "Id", "Name");
            return View();
        }

        //
        // POST: /Certification/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Certification certification)
        {
            if (ModelState.IsValid)
            {
                db.Certifications.Add(certification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstitutionId = new SelectList(db.Institutions, "Id", "Name", certification.InstitutionId);
            return View(certification);
        }

        //
        // GET: /Certification/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstitutionId = new SelectList(db.Institutions, "Id", "Name", certification.InstitutionId);
            return View(certification);
        }

        //
        // POST: /Certification/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Certification certification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InstitutionId = new SelectList(db.Institutions, "Id", "Name", certification.InstitutionId);
            return View(certification);
        }

        //
        // GET: /Certification/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        //
        // POST: /Certification/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Certification certification = db.Certifications.Find(id);
            db.Certifications.Remove(certification);
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