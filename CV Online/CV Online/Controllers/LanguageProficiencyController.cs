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
    public class LanguageProficiencyController : Controller
    {
        private CVOContext db = new CVOContext();

        //
        // GET: /LanguageProficiency/

        public ActionResult Index()
        {
            var languageproficiency = db.LanguageProficiency.Include(l => l.Language);
            return View(languageproficiency.ToList());
        }

        //
        // GET: /LanguageProficiency/Details/5

        public ActionResult Details(int id = 0)
        {
            LanguageProficiency languageproficiency = db.LanguageProficiency.Find(id);
            if (languageproficiency == null)
            {
                return HttpNotFound();
            }
            return View(languageproficiency);
        }

        //
        // GET: /LanguageProficiency/Create

        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            return View();
        }

        //
        // POST: /LanguageProficiency/Create

        [HttpPost]
        public ActionResult Create(LanguageProficiency languageproficiency)
        {
            if (ModelState.IsValid)
            {
                db.LanguageProficiency.Add(languageproficiency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", languageproficiency.LanguageId);
            return View(languageproficiency);
        }

        //
        // GET: /LanguageProficiency/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LanguageProficiency languageproficiency = db.LanguageProficiency.Find(id);
            if (languageproficiency == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", languageproficiency.LanguageId);
            return View(languageproficiency);
        }

        //
        // POST: /LanguageProficiency/Edit/5

        [HttpPost]
        public ActionResult Edit(LanguageProficiency languageproficiency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(languageproficiency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", languageproficiency.LanguageId);
            return View(languageproficiency);
        }

        //
        // GET: /LanguageProficiency/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LanguageProficiency languageproficiency = db.LanguageProficiency.Find(id);
            if (languageproficiency == null)
            {
                return HttpNotFound();
            }
            return View(languageproficiency);
        }

        //
        // POST: /LanguageProficiency/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            LanguageProficiency languageproficiency = db.LanguageProficiency.Find(id);
            db.LanguageProficiency.Remove(languageproficiency);
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