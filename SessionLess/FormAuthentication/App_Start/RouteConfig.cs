using FormAuthentication.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FormAuthentication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { id = @"\d*", controller = @"^(?!api)\w+$" }
            );

            //Not using WebServiceHostFactory here which is creating WebHttpBinding
            //We want to use wshttpbinding here so it has to be ServiceHostFactory
            RouteTable.Routes.Add(
                new ServiceRoute(
                    @"api/Math2Service",
                    new ServiceHostFactory(),
                    typeof(SecuredIISwsHTTPService)));
        }
    }
}
