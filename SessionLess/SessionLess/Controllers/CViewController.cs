using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.Controllers
{
    public class CViewController : Controller
    {
        //
        // GET: /CView/
        public ActionResult Index()
        {
            return View();
        }
	}
}