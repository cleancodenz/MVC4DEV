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

        /**
         * 
         * public class IssueForm
           {
             Order Order {get; set;}
             Item Item {get; set;}
            Range Range {get; set;}
           }
         * 
         * 
         *   if(propertyDescriptor.Name == "Order") {
            ...
            return;
        }

        if(propertyDescriptor.Name == "Item") {
            ...
            return;
        }

        base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
         * 
        protected override void BindProperty(ControllerContext contContext,
            ModelBindingContext bindContext,
            System.ComponentModel.PropertyDescriptor propDesc)
        {
           List<string> DateTimeTypes = new List<string>{ "BirthDate",
            "StartDate", "EndDate" };
            if (DateTimeTypes.Contains(propDesc.Name))
            {
                if (!string.IsNullOrEmpty(
                        contContext.HttpContext.Request.Form[propDesc.Name + "Year"]))
                {
                        DateTime dt = new DateTime(int.Parse(
                            contContext.HttpContext.Request.Form[propDesc.Name
                            + "Year"]),
                           int.Parse(contContext.HttpContext.Request.Form[propDesc.Name +
                            "Month"]),
                            int.Parse(contContext.HttpContext.Request.Form[propDesc.Name +
                           "Day"]));
                    //can also call SetProperty of DefaultModelBinder
                        propDesc.SetValue(bindContext.Model, dt);
                    return;
                }
            }
            base.BindProperty(contContext, bindContext, propDesc);
        }
         * */
    }
}