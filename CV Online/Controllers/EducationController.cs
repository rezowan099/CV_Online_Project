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
    public class EducationController : Controller
    {
        private CVOContext db = new CVOContext();
        private Manager manager = new Manager(); 
        //
        // GET: /Education/

        public ActionResult Index()
        {
            try
            {
                var membership = (SimpleMembershipProvider)Membership.Provider;
                int idUser = membership.GetUserId(User.Identity.Name);
                int id = manager.GetPersonalInfoIdOfCurrentUser(idUser);
                var educations = db.Educations.Include(e => e.PersonalInformation).Include(e => e.ConcentrationMajorGroup).Include(e => e.Institution).Include(e => e.EducationLevel).Where(e => e.PersonalInfoId == id);
                return View(educations.ToList());
            }
            catch
            {
                return HttpNotFound();
            }

        }

        //
        // GET: /Education/Details/5

        public ActionResult Details(int id=0)
        {
            try
            {
                Education education = db.Educations.Find(id);

                if (education == null)
                {
                    return RedirectToAction("Create");
                }
                return View(education);
            }
            catch
            {
                return HttpNotFound();
            }
        }

        //
        // GET: /Education/Create

        public ActionResult Create()
        {
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName");
            ViewBag.ConcentrationMajorGroupId = new SelectList(db.ConcentrationMajorGroups, "Id", "Type");
            ViewBag.InstitutionId = new SelectList(db.Institutions.Where(i => i.Type == "Education"), "Id", "Name");       //.Where(s => s.StateCode.ToLower() == code.ToLower()); 
            ViewBag.EducationLevelId = new SelectList(db.EducationLevels, "Id", "Level");
            return View();
        }

        public JsonResult GetConcentrationMajorGroups(int id)
        {
            var ConcentrationMajorGroupsList = db.ConcentrationMajorGroups.Where(co => co.EducationLevels.Any( ed => ed.Id == id));
            return this.Json(ConcentrationMajorGroupsList.ToList(), JsonRequestBehavior.AllowGet);
        }

        //http://www.intstrings.com/ramivemula/articles/cascading-dropdownlist-in-asp-net-mvc4-using-knockoutjs/
        //http://www.dotnetexpertguide.com/2012/06/cascading-dropdown-knockoutjs-aspnet.html
        // POST: /Education/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Education education)
        {
            if (ModelState.IsValid)
            {
                var membership = (SimpleMembershipProvider)Membership.Provider;
                int idUser = membership.GetUserId(User.Identity.Name);
                int id = manager.GetPersonalInfoIdOfCurrentUser(idUser);
                education.PersonalInfoId = id;
                db.Educations.Add(education);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", education.PersonalInfoId);
            ViewBag.ConcentrationMajorGroupId = new SelectList(db.ConcentrationMajorGroups, "Id", "Type", education.ConcentrationMajorGroupId);
            ViewBag.InstitutionId = new SelectList(db.Institutions, "Id", "Name", education.InstitutionId);
            ViewBag.EducationLevelId = new SelectList(db.EducationLevels, "Id", "Level", education.EducationLevelId);
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
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", education.PersonalInfoId);
            ViewBag.ConcentrationMajorGroupId = new SelectList(db.ConcentrationMajorGroups, "Id", "Type", education.ConcentrationMajorGroupId);
            ViewBag.InstitutionId = new SelectList(db.Institutions, "Id", "Name", education.InstitutionId);
            ViewBag.EducationLevelId = new SelectList(db.EducationLevels, "Id", "Level", education.EducationLevelId);
            return View(education);
        }

        //
        // POST: /Education/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Education education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonalInfoId = new SelectList(db.PersonalInformations, "Id", "FirstName", education.PersonalInfoId);
            ViewBag.ConcentrationMajorGroupId = new SelectList(db.ConcentrationMajorGroups, "Id", "Type", education.ConcentrationMajorGroupId);
            ViewBag.InstitutionId = new SelectList(db.Institutions, "Id", "Name", education.InstitutionId);
            ViewBag.EducationLevelId = new SelectList(db.EducationLevels, "Id", "Level", education.EducationLevelId);
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
        [ValidateAntiForgeryToken]
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