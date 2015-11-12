using CV_Online.Models;
using CV_Online.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_Online.Controllers
{
    public class ImageFileController : Controller
    {
        //
        // GET: /ImageFile/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult FileUpload(HttpPostedFileBase file)
        {

            if (file != null)
            {
                CVOContext db = new CVOContext();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                //update new record in database
                PersonalInformation personalinformation = db.PersonalInformations.SingleOrDefault(p => p.Id == 1);
                personalinformation.Photo = ImageName;
                db.Entry(personalinformation).State = EntityState.Modified;
                db.SaveChanges();


            }
            return View();
            //ViewBag.Id = 1;
            //Display records
            //return RedirectToAction("../ImageFile/Display/");
        }

        public ActionResult Display()
        {
            return View();
        }


    }

}
