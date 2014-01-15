using SessionLess.CustomFilters;
using System.Web;
using System.Web.Mvc;

namespace SessionLess
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
          //filters.Add(new MyAuthorizationFilterAttribute());
        }
    }
}
