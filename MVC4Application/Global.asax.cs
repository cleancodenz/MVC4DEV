using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVC4Application.DependencyResolver;
using Microsoft.Practices.Unity;
using MyCompany.Business;
using MyCompany.Logging;
using System.Configuration;
using MyCompany.Data.Entity;
using MyCompany.Data.Persistence.EF;
using MyCompany.Business.Repository;

namespace MVC4Application
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            try
            {

                AreaRegistration.RegisterAllAreas();

                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                AuthConfig.RegisterAuth();

                // register service
                IUnityContainer container = new UnityContainer();

                // to get the connection string
                var connectionsetting = ConfigurationManager.ConnectionStrings["DefaultConnection"];

                if (connectionsetting == null)
                {
                    throw new Exception("No connection setting can be found."); 
                }

                // Register unitof work
                container.RegisterType<IUnitOfWork, EFUnitOfWork>
                    (new PerHttpRequestLifetime(), new InjectionConstructor(connectionsetting.ConnectionString));

                //register concrete respository for invidual repositories 
                container.RegisterType<IRepository<Product>, EFRepository<Product>>
                  (new PerHttpRequestLifetime());

                // register serivces
                container.RegisterType<IProductService, ProductService>(
                  new PerHttpRequestLifetime());


                UnityDependencyResolver unityDependencyResolver =
                    new UnityDependencyResolver(container);

                System.Web.Mvc.DependencyResolver.SetResolver((IDependencyResolver)unityDependencyResolver);

            }
            catch (Exception ex)
            {
                LogUtil.Error(this.GetType(), ex);
                throw ex;
            }

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            if (ex is Exception)
            {
                LogUtil.Error(this.GetType(), ex);
            }
        }
    }
}