using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SessionLess.CustomRoutHandler
{
    public class MyDeepRouteHandler : IRouteHandler
    {

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new HelloHandler();
        }
    }
}