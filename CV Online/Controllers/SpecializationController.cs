using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Online.Models;
using CV_Online.Repository;
using WebMatrix.WebData;
using System.Web.Security;
using CV_Online.BLL;

namespace CV_Online.Controllers
{
    public class SpecializationController : Controller
    {
        private CVOContext db = new CVOContext();
        private Manager manager = new Manager(); 

        //
        // GET: /Specialization/

        public ActionResult Index()
        {
            var specializations = db.Specializations.Include(s => s.PersonalInformation);
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
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName");
            return View();
        }

        //
        // POST: /Specialization/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                var membership = (SimpleMembershipProvider)Membership.Provider;
                int idUser = membership.GetUserId(User.Identity.Name);
                int id = manager.GetPersonalInfoIdOfCurrentUser(idUser);
                specialization.PersonalInfoId = id;
                db.Specializations.Add(specialization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", specialization.PersonalInfoId);
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
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", specialization.PersonalInfoId);
            return View(specialization);
        }

        //
        // POST: /Specialization/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", specialization.PersonalInfoId);
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
        [ValidateAntiForgeryToken]
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