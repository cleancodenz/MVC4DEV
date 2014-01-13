using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.Controllers
{
    public class FileController : Controller
    {
        //
        // GET: /File/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> pfiles)
        {
            /**
            HttpPostedFileBase photo = Request.Files["photo"];

            if (photo != null)
            {
                string fileName = Server.MapPath(@"~/Data/" + photo.FileName);

                photo.SaveAs(fileName);
            }
             * */

            foreach (var file in pfiles)
            {
                string fileName = Server.MapPath(@"~/Data/" + file.FileName);

                file.SaveAs(fileName);
            }


            return RedirectToAction("Index");

        }

       
        public FilePathResult PDF()
        {
            //FileResult is abstract
            //Other types are FileContentResult, and FileStreamResult, and they are using different input

          
            string fileName = Server.MapPath(@"~/Data/Booking.pdf");
            string contentType = "application/pdf";

            return File(fileName, contentType);
        }
    }
}