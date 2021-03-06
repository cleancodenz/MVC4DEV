﻿using SessionLess.Controllers;
using SessionLess.CustomBinder;
using SessionLess.CustomControllerFactory;
using SessionLess.CustomModelValidator;
using SessionLess.CustomValueProvider;
using SessionLess.CustomViewEngine;
using SessionLess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;

namespace SessionLess
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AppDomain.CurrentDomain.FirstChanceException +=
                CurrentDomain_FirstChanceException;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Set the database
            AppConfig.Configure();
            // Set the mobile display mode
            DisplayModeProvider.Instance.Modes.Insert(
                0, new OperaMobiDisplayMode());
            // Set customized model binder
          //  ModelBinders.Binders.Add(typeof(HomePageModel),
           //     new HomeCustomBinder());

            ModelBinders.Binders.DefaultBinder =
                new HomeCustomDataBinder();

            // custom value provider for binder/ValueProvider
            var factory = new MyValueProvider();
            ValueProviderFactories.Factories.Add(factory);

            // custom controller factory
         //   ControllerBuilder.Current.SetControllerFactory(
         //   typeof(MyCustomControllerFactory));

            //Custom model data validator provider
            ModelValidatorProviders.Providers.Add(new AllRequiredValidatorProvider());


            //add new custom view engine
            ViewEngines.Engines.Add(new MyCustomViewEngine());

        }
        protected void Application_Error(object sender, EventArgs e)
        {
          /**
           
            // this handles 404 http exceptions which are not handled by HandleError in controller
            var httpContext = ((MvcApplication)sender).Context;
            var currentController = " ";
            var currentAction = " ";
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            var ex = Server.GetLastError();
            var controller = new ErrorController();
            var routeData = new RouteData();
            var action = "Index";

           // if (ex is HttpException)
           // {
           //     var httpEx = ex as HttpException;

           //     switch (httpEx.GetHttpCode())
            //    {
            //        case 404:
            //            action = "Index";
            //            break;

                    // others if any
            //    }
            //}

            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
            httpContext.Response.TrySkipIisCustomErrors = true;

            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = action;

            controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        **/
       }


        protected void CurrentDomain_FirstChanceException(object sender,
System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            if (e.Exception is NotImplementedException)
            {
                // do something special when the functionality is not implemented
            }
        }
    }
}
