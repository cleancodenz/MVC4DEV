using SessionLess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.CustomBinder
{
    public class HomeCustomDataBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(HomePageModel))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;

                string title = request.Form.Get("Title");
                string day = request.Form.Get("Day");
                string month = request.Form.Get("Month");
                string year = request.Form.Get("Year");

                return new HomePageModel
                {
                    Title = title,
                    Date = day + "a/a" + month + "b/b" + year
                };

                //// call the default model binder this new binding context
                //return base.BindModel(controllerContext, newBindingContext);
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }
}