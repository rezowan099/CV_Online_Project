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
    public class LanguageController : Controller
    {
        private IGenericRepository<Language> repository = null;

        public LanguageController()
        {
            this.repository = new GenericRepository<Language>();
        }

        //
        // GET: /Language/

        public ActionResult Index()
        {
            var language = repository.SelectAll().ToList();
            return View(language);
        }

        //
        // GET: /Language/Details/5

        public ActionResult Details(int id = 0)
        {
            var language = repository.SelectById(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        //
        // GET: /Language/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Language/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Language language)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(language);
                repository.Save();
                return RedirectToAction("Index");
            }

            return View(language);
        }

        //
        // GET: /Language/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var language = repository.SelectById(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        //
        // POST: /Language/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Language language)
        {
            if (ModelState.IsValid)
            {
                repository.Update(language);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(language);
        }

        //
        // GET: /Language/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var language = repository.SelectById(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        //
        // POST: /Language/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}