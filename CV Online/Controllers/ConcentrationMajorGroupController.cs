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
    public class ConcentrationMajorGroupController : Controller
    {
        private CVOContext db = new CVOContext();

        //
        // GET: /ConcentrationMajorGroup/

        public ActionResult Index()
        {
            return View(db.ConcentrationMajorGroups.ToList());
        }

        //
        // GET: /ConcentrationMajorGroup/Details/5

        public ActionResult Details(int id = 0)
        {
            ConcentrationMajorGroup concentrationmajorgroup = db.ConcentrationMajorGroups.Find(id);
            if (concentrationmajorgroup == null)
            {
                return HttpNotFound();
            }
            return View(concentrationmajorgroup);
        }

        //
        // GET: /ConcentrationMajorGroup/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ConcentrationMajorGroup/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConcentrationMajorGroup concentrationmajorgroup)
        {
            if (ModelState.IsValid)
            {
                db.ConcentrationMajorGroups.Add(concentrationmajorgroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(concentrationmajorgroup);
        }

        //
        // GET: /ConcentrationMajorGroup/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ConcentrationMajorGroup concentrationmajorgroup = db.ConcentrationMajorGroups.Find(id);
            if (concentrationmajorgroup == null)
            {
                return HttpNotFound();
            }
            return View(concentrationmajorgroup);
        }

        //
        // POST: /ConcentrationMajorGroup/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConcentrationMajorGroup concentrationmajorgroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concentrationmajorgroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(concentrationmajorgroup);
        }

        //
        // GET: /ConcentrationMajorGroup/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ConcentrationMajorGroup concentrationmajorgroup = db.ConcentrationMajorGroups.Find(id);
            if (concentrationmajorgroup == null)
            {
                return HttpNotFound();
            }
            return View(concentrationmajorgroup);
        }

        //
        // POST: /ConcentrationMajorGroup/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConcentrationMajorGroup concentrationmajorgroup = db.ConcentrationMajorGroups.Find(id);
            db.ConcentrationMajorGroups.Remove(concentrationmajorgroup);
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