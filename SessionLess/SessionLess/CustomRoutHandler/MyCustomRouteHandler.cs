using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.CustomRoutHandler
{
    public class MyCustomRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(
            System.Web.Routing.RequestContext requestContext)
        {
            string importantValue = requestContext.
                HttpContext.Request.Headers.Get(
                "User-Agent");
            //The process is UrlRouteModule is first called to get route
            // then RouteHandler of that route is called
            // Default RouteHandler is MvcRouteHandler
            // Then RouteHandler.GetHttpHandler is called
            // For MvcRouteHandler.GetHttpHandler  is MvcHandler
            // Then MvcHandler.ProcessRequestInit ic called
            // Then Controller instance is created 
            // Controller.BeginExecuteCore starts to excute action

            //Route decided and route data already populated 
            if (!string.IsNullOrWhiteSpace(importantValue))
            {
                
                /** 
                requestContext.RouteData.Values["action"] = 
                    importantValue +
                requestContext.RouteData.Values["action"];
                 **/ 
            }

            return base.GetHttpHandler(requestContext);
        }
    }
}