using SessionLess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.CustomBinder
{
    public class HomeCustomBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
                           ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            string title = request.Form.Get("Title");
            string day = request.Form.Get("Day");
            string month = request.Form.Get("Month");
            string year = request.Form.Get("Year");

            return new HomePageModel
            {
                Title = title,
                Date = day + "1/1" + month + "1/1" + year
            };
        }

      
    }
}