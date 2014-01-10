﻿using SessionLess.ActionFilters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.Controllers
{
    public class HomeController : Controller
    {
        [LocalizationFilter]
        public ActionResult Index()
        {
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
    }
}