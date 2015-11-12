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
    public class MaritalStatusController : Controller
    {
        private IGenericRepository<MaritalStatus> repository = null;

        public MaritalStatusController()
        {
            this.repository = new GenericRepository<MaritalStatus>();
        }

        //
        // GET: /MaritalStatus/

        public ActionResult Index()
        {
            var maritalStatus = repository.SelectAll().ToList();
            return View(maritalStatus);
        }

        //
        // GET: /MaritalStatus/Details/5

        public ActionResult Details(int id = 0)
        {
            var maritalstatus = repository.SelectById(id);
            if (maritalstatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalstatus);
        }

        //
        // GET: /MaritalStatus/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MaritalStatus/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaritalStatus maritalstatus)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(maritalstatus);
                repository.Save();
                return RedirectToAction("Index");
            }

            return View(maritalstatus);
        }

        //
        // GET: /MaritalStatus/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var maritalstatus = repository.SelectById(id);
            if (maritalstatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalstatus);
        }

        //
        // POST: /MaritalStatus/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MaritalStatus maritalstatus)
        {
            if (ModelState.IsValid)
            {
                repository.Update(maritalstatus);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(maritalstatus);
        }

        //
        // GET: /MaritalStatus/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var maritalstatus = repository.SelectById(id);
            if (maritalstatus == null)
            {
                return HttpNotFound();
            }
            return View(maritalstatus);
        }

        //
        // POST: /MaritalStatus/Delete/5

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