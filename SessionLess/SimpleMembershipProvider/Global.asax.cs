using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace SimpleMembershipProvider
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", true); 

            // one off 
            /**
            WebSecurity.CreateUserAndAccount("Admin", "Admin");
            WebSecurity.CreateUserAndAccount("johnson", "1234");
            Roles.CreateRole("Administrator");
            Roles.AddUserToRole("Admin", "Administrator");
             **/
            // this will validate user and set authcookie for formsauthentication

            WebSecurity.Login("Admin", "admin", true);
        }
    }
}
