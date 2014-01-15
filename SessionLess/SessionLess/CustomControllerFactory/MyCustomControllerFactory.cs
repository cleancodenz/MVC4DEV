using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.CustomControllerFactory
{
    // DefaultControllerFactory is calling underlining DependencyResolver to create 
    // Controller instance

    public class MyCustomControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(
            System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            ILogger logger = new DefaultLogger();
            IController controller = Activator.CreateInstance(
                controllerType, new[] { logger }) as Controller;
            return controller;
            
        }
    }
}