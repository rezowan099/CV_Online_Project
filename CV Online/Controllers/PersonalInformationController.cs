using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CV_Online.Models;
using CV_Online.Repository;
using CV_Online.BLL;
using WebMatrix.WebData;
using System.Web.Security;

namespace CV_Online.Controllers
{
    public class PersonalInformationController : Controller
    {
        private CVOContext db = new CVOContext();
        private Manager manager = new Manager(); 
        //
        // GET: /PersonalInformation/

        //public ActionResult Index()
        //{
        //    var personalinformations = db.PersonalInformations.Include(p => p.Gender).Include(p => p.MaritalStatus).Include(p => p.UserProfile);
        //    return View(personalinformations.ToList());
        //}

        //
        // GET: /PersonalInformation/Details/5

        public ActionResult Details()
        {

            try
            {
                //if (Request.IsAuthenticated)
                //{
                var membership = (SimpleMembershipProvider)Membership.Provider;
                int idUser = membership.GetUserId(User.Identity.Name);
                int id = manager.GetPersonalInfoIdOfCurrentUser(idUser);
                //}
                PersonalInformation personalinformation = db.PersonalInformations.Find(id);
                if (personalinformation == null)
                {
                    return RedirectToAction("Create");
                    //return HttpNotFound();
                }
                return View(personalinformation);
            }
            catch
            {
                return HttpNotFound();
            }

        }

        //
        // GET: /PersonalInformation/Create

        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Type");
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "Id", "Status");
            ViewBag.UserProfileId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /PersonalInformation/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalInformation personalinformation)
        {
            if (ModelState.IsValid)
            {
                db.PersonalInformations.Add(personalinformation);
                db.SaveChanges();
                return RedirectToAction("Details");
            }

            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Type", personalinformation.GenderId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "Id", "Status", personalinformation.MaritalStatusId);
            ViewBag.UserProfileId = new SelectList(db.UserProfiles, "UserId", "UserName", personalinformation.UserProfileId);
            return View(personalinformation);
        }

        //
        // GET: /PersonalInformation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PersonalInformation personalinformation = db.PersonalInformations.Find(id);
            if (personalinformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Type", personalinformation.GenderId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "Id", "Status", personalinformation.MaritalStatusId);
            ViewBag.UserProfileId = new SelectList(db.UserProfiles, "UserId", "UserName", personalinformation.UserProfileId);
            return View(personalinformation);
        }

        //
        // POST: /PersonalInformation/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonalInformation personalinformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalinformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Type", personalinformation.GenderId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "Id", "Status", personalinformation.MaritalStatusId);
            ViewBag.UserProfileId = new SelectList(db.UserProfiles, "UserId", "UserName", personalinformation.UserProfileId);
            return View(personalinformation);
        }

        //
        // GET: /PersonalInformation/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    PersonalInformation personalinformation = db.PersonalInformations.Find(id);
        //    if (personalinformation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(personalinformation);
        //}

        //
        // POST: /PersonalInformation/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    PersonalInformation personalinformation = db.PersonalInformations.Find(id);
        //    db.PersonalInformations.Remove(personalinformation);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}