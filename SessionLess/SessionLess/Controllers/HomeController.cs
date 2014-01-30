using SessionLess.ActionFilters;
using SessionLess.CustomControllerFactory;
using SessionLess.CustomFilters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
           // System.Diagnostics.EventLog.w 
            Trace.WriteLine("Home Controller Created","MyApp");
    
        }
        
        [LocalizationFilter]
       // [CompressFilter]
        public ActionResult Index()
        {
            var s = Request;
            Trace.WriteLine("Home Controller Index Action Executing", "MyApp");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult WebSocket()
        {
            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }



        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Redirect()
        {
            return Redirect("/StoreManager/Edit/2");

            // return RedirectToAction("Edit","StoreManager",new {id =2}); //302
            //return RedirectToActionPermanent("About"); // 301

            //return RedirectToRoute("routename"); //this must be routename defined in maproute

        }

        public ContentResult ReadXML()
        {
            string fileName = Server.MapPath(@"~/Data/xmldata.xml");
            TextReader tr = new StreamReader(fileName);
            string contents = tr.ReadToEnd();
            return Content(contents, "text/xml");
        }

    }
}