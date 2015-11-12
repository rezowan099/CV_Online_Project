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
    public class TrainingController : Controller
    {
        private CVOContext db = new CVOContext();
        private Manager manager = new Manager(); 

        //
        // GET: /Training/

        public ActionResult Index()
        {
            var trainings = db.Trainings.Include(t => t.PersonalInformation);
            return View(trainings.ToList());
        }

        //
        // GET: /Training/Details/5

        public ActionResult Details(int id = 0)
        {
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        //
        // GET: /Training/Create

        public ActionResult Create()
        {
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName");
            return View();
        }

        //
        // POST: /Training/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Training training)
        {
            if (ModelState.IsValid)
            {
                var membership = (SimpleMembershipProvider)Membership.Provider;
                int idUser = membership.GetUserId(User.Identity.Name);
                int id = manager.GetPersonalInfoIdOfCurrentUser(idUser);
                training.PersonalInfoId = id;
                db.Trainings.Add(training);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", training.PersonalInfoId);
            return View(training);
        }

        //
        // GET: /Training/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", training.PersonalInfoId);
            return View(training);
        }

        //
        // POST: /Training/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Training training)
        {
            if (ModelState.IsValid)
            {
                db.Entry(training).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", training.PersonalInfoId);
            return View(training);
        }

        //
        // GET: /Training/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        //
        // POST: /Training/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Training training = db.Trainings.Find(id);
            db.Trainings.Remove(training);
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