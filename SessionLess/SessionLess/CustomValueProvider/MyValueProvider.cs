using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.CustomValueProvider
{
    public class MyValueProvider : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            var myValues = new NameValueCollection();
            
            //to carry out name conversion
            if (controllerContext.
                HttpContext.Request.Form["mytitle"] !=null)
            {
               myValues.Add("Title", controllerContext.
               HttpContext.Request.Form["mytitle"]);
            }

            return new NameValueCollectionValueProvider(
              myValues, CultureInfo.CurrentCulture);
        }
    }
}