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
    public class ProfessionalQualificationController : Controller
    {
        private CVOContext db = new CVOContext();
        private Manager manager = new Manager(); 

        //
        // GET: /ProfessionalQualification/

        public ActionResult Index()
        {
            var professionalqualifications = db.ProfessionalQualifications.Include(p => p.Certification).Include(p => p.Institution).Include(p => p.PersonalInformation);
            return View(professionalqualifications.ToList());
        }

        //
        // GET: /ProfessionalQualification/Details/5

        public ActionResult Details(int id = 0)
        {
            ProfessionalQualification professionalqualification = db.ProfessionalQualifications.Find(id);
            if (professionalqualification == null)
            {
                return HttpNotFound();
            }
            return View(professionalqualification);
        }

        //
        // GET: /ProfessionalQualification/Create

        public ActionResult Create()
        {
            ViewBag.CertificationId = new SelectList(db.Certifications, "Id", "Title");
            ViewBag.InstitutionId = new SelectList(db.Institutions, "Id", "Name");
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName");
            return View();
        }

        //
        // POST: /ProfessionalQualification/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfessionalQualification professionalqualification)
        {
            if (ModelState.IsValid)
            {
                var membership = (SimpleMembershipProvider)Membership.Provider;
                int idUser = membership.GetUserId(User.Identity.Name);
                int id = manager.GetPersonalInfoIdOfCurrentUser(idUser);
                professionalqualification.PersonalInfoId = id;
                db.ProfessionalQualifications.Add(professionalqualification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CertificationId = new SelectList(db.Certifications, "Id", "Title", professionalqualification.CertificationId);
            ViewBag.InstitutionId = new SelectList(db.Institutions, "Id", "Name", professionalqualification.InstitutionId);
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", professionalqualification.PersonalInfoId);
            return View(professionalqualification);
        }

        //
        // GET: /ProfessionalQualification/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProfessionalQualification professionalqualification = db.ProfessionalQualifications.Find(id);
            if (professionalqualification == null)
            {
                return HttpNotFound();
            }
            ViewBag.CertificationId = new SelectList(db.Certifications, "Id", "Title", professionalqualification.CertificationId);
            ViewBag.InstitutionId = new SelectList(db.Institutions, "Id", "Name", professionalqualification.InstitutionId);
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", professionalqualification.PersonalInfoId);
            return View(professionalqualification);
        }

        //
        // POST: /ProfessionalQualification/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfessionalQualification professionalqualification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professionalqualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CertificationId = new SelectList(db.Certifications, "Id", "Title", professionalqualification.CertificationId);
            ViewBag.InstitutionId = new SelectList(db.Institutions, "Id", "Name", professionalqualification.InstitutionId);
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", professionalqualification.PersonalInfoId);
            return View(professionalqualification);
        }

        //
        // GET: /ProfessionalQualification/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProfessionalQualification professionalqualification = db.ProfessionalQualifications.Find(id);
            if (professionalqualification == null)
            {
                return HttpNotFound();
            }
            return View(professionalqualification);
        }

        //
        // POST: /ProfessionalQualification/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfessionalQualification professionalqualification = db.ProfessionalQualifications.Find(id);
            db.ProfessionalQualifications.Remove(professionalqualification);
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