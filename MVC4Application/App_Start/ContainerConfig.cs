using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using System.Configuration;
using MyCompany.Data.Entity;
using MyCompany.Data.Persistence.EF;
using MyCompany.Business;
using MVC4Application.DependencyResolver;
using System.Web.Mvc;

namespace MVC4Application
{
    public static class ContainerConfig
    {
        public static void Register()
        {
            // register service
            IUnityContainer container = new UnityContainer();

            // to get the connection string
            var connectionsetting = ConfigurationManager.ConnectionStrings["DefaultConnection"];

            if (connectionsetting == null)
            {
                throw new Exception("No connection setting can be found.");
            }

            // Register unit of work
            container.RegisterType<IUnitOfWork, EFUnitOfWork>
                (new PerHttpRequestLifetime(), new InjectionConstructor(connectionsetting.ConnectionString));

            //register concrete respository for invidual repositories 
            container.RegisterType<IRepository<Product>, EFRepository<Product>>
              (new PerHttpRequestLifetime());

            container.RegisterType<IRepository<Supplier>, EFRepository<Supplier>>
             (new PerHttpRequestLifetime());

            // register serivces
            container.RegisterType<IProductService, ProductService>(
              new PerHttpRequestLifetime());


            UnityDependencyResolver unityDependencyResolver =
                new UnityDependencyResolver(container);

            System.Web.Mvc.DependencyResolver.SetResolver((IDependencyResolver)unityDependencyResolver);

            UnityDependencyResolverAPI unityDependencyResolverAPI
                = new UnityDependencyResolverAPI(container);

            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver =
                unityDependencyResolverAPI;

 
        }
    }
}