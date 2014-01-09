using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.ActionFilters
{
    public class LocalizationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var lang = filterContext.HttpContext.Request.UserLanguages[0];

               //ui interface cuture, locale-dependent resource searches
            Thread.CurrentThread.CurrentUICulture
                = new CultureInfo(lang);
            //ui culture for dates and currencies 
            Thread.CurrentThread.CurrentCulture
                = new CultureInfo(lang);

            filterContext.Controller.ViewBag.Language = lang;
         
        }
    }
}