using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace MVC4Application.DependencyResolver
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            _container = container;

        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (Exception ex)
            {
                return null;
            }

            //if (!_container.IsRegistered(serviceType))
            //{
            //    return null;
            //}
            //else
            //{
            //    return _container.Resolve(serviceType);
            //}
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);

            }
            catch (Exception ex)
            {
                return new List<object>();
            }


        }
    }
}