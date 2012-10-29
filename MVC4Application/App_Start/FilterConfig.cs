using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Microsoft.Practices.Unity;

namespace MVC4Application
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
          //  filters.Add(new System.Web.Mvc.AuthorizeAttribute()); 
        }
   
    }
}