using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.CustomFilters
{
    //Authentication is done through owin
    //[assembly: OwinStartupAttribute(typeof(SessionLess.Startup))]
    //Startup.cs,whihc is done at the same time of Global.asax.cs  
    public class MyAuthorizationFilterAttribute
        : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // added by johnson
            var user1 = filterContext.HttpContext.User;
            var user2 = Thread.CurrentPrincipal;
            //the identity of the security context of the Win32 thread
            WindowsIdentity winId = WindowsIdentity.GetCurrent();
            WindowsPrincipal winPrincipal = new WindowsPrincipal(winId);
            
            base.OnAuthorization(filterContext);
            // this is the key for authentication and authorization
            // To authenticate, set this
            // To authorize which is done in the above method from the base class
            // User.Identity.AuthenticationMethod is cookies
            IPrincipal user = HttpContext.Current.User;

            var authenticated =
                user.Identity.IsAuthenticated;

            var cookie = HttpContext.Current.Request.Cookies;
          

        }
    }
}