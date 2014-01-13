using SessionLess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.Controllers
{
    public class BinderController : Controller
    {
        //
        // GET: /Binder/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HomePageModel model)
        {
            var m = model;
 
            return View();
        }

        public ActionResult Weakly()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Weakly([Bind(Prefix = "my")] WeakPageModel model)
        {
            //field names still need to match 
            var m = model;

            return View();
        }

        public ActionResult ValueProvider()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValueProvider(WeakPageModel model)
        {
            /* ToValueProvider provides similar functions as Bind attribute, but can not do name mismatch
             * 
            WeakPageModel model = new WeakPageModel();
            if(TryUpdateModel(model, formColl.ToValueProvider()))
            {
                UpdateModel(model, formColl.ToValueProvider());
            }
            */
            return View();
        }

	}
}