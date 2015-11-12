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
    public class InstitutionController : Controller
    {
        private IGenericRepository<Institution> repository = null;

        public InstitutionController()
        {
            this.repository = new GenericRepository<Institution>();
        }

        //
        // GET: /Institution/

        public ActionResult Index()
        {
            var institution = repository.SelectAll().ToList();
            return View(institution);
        }

        //
        // GET: /Institution/Details/5

        public ActionResult Details(int id = 0)
        {
            var institution = repository.SelectById(id);
            if (institution == null)
            {
                return HttpNotFound();
            }
            return View(institution);
        }

        //
        // GET: /Institution/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Institution/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Institution institution)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(institution);
                repository.Save();
                return RedirectToAction("Index");
            }

            return View(institution);
        }

        //
        // GET: /Institution/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var institution = repository.SelectById(id);
            if (institution == null)
            {
                return HttpNotFound();
            }
            return View(institution);
        }

        //
        // POST: /Institution/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Institution institution)
        {
            if (ModelState.IsValid)
            {
                repository.Delete(institution);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(institution);
        }

        //
        // GET: /Institution/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var institution = repository.SelectById(id);
            if (institution == null)
            {
                return HttpNotFound();
            }
            return View(institution);
        }

        //
        // POST: /Institution/Delete/5

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