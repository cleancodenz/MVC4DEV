using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.Controllers
{
  
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        public ActionResult Index()
        {
            //throw new Exception("Raised by ErrorController");
            // the view does not exist
            return View();
        }
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "ApplicationError")]
        public ActionResult App()
        {
            throw new NullReferenceException("Raised by ErrorController");
            // the view does not exist
            return View();
        }

        public ActionResult Http()
        {
            throw new HttpException(404, "Category not found");
            // the view does not exist
            return View();
        }
	}
}