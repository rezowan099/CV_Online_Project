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
    public class EmploymentHistoryController : Controller
    {
        private CVOContext db = new CVOContext();

        //
        // GET: /EmploymentHistory/

        public ActionResult Index()
        {
            var employmenthistories = db.EmploymentHistories.Include(e => e.PersonalInformation);
            return View(employmenthistories.ToList());
        }

        //
        // GET: /EmploymentHistory/Details/5

        public ActionResult Details(int id = 0)
        {
            EmploymentHistory employmenthistory = db.EmploymentHistories.Find(id);
            if (employmenthistory == null)
            {
                return HttpNotFound();
            }
            return View(employmenthistory);
        }

        //
        // GET: /EmploymentHistory/Create

        public ActionResult Create()
        {
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName");
            return View();
        }

        //
        // POST: /EmploymentHistory/Create

        [HttpPost]
        public ActionResult Create(EmploymentHistory employmenthistory)
        {
            if (ModelState.IsValid)
            {
                db.EmploymentHistories.Add(employmenthistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", employmenthistory.PersonalInfoId);
            return View(employmenthistory);
        }

        //
        // GET: /EmploymentHistory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EmploymentHistory employmenthistory = db.EmploymentHistories.Find(id);
            if (employmenthistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", employmenthistory.PersonalInfoId);
            return View(employmenthistory);
        }

        //
        // POST: /EmploymentHistory/Edit/5

        [HttpPost]
        public ActionResult Edit(EmploymentHistory employmenthistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employmenthistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FathersName", employmenthistory.PersonalInfoId);
            return View(employmenthistory);
        }

        //
        // GET: /EmploymentHistory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EmploymentHistory employmenthistory = db.EmploymentHistories.Find(id);
            if (employmenthistory == null)
            {
                return HttpNotFound();
            }
            return View(employmenthistory);
        }

        //
        // POST: /EmploymentHistory/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EmploymentHistory employmenthistory = db.EmploymentHistories.Find(id);
            db.EmploymentHistories.Remove(employmenthistory);
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