using System.Web.Mvc;

namespace SessionLess.Areas.Order
{
    public class OrderAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Order";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Order_default",
                "Order/{controller}/{action}/{id}",
                new {controller ="Home2",  action = "Index", id = UrlParameter.Optional }
              //  , new string[] { "SessionLess.Areas.Order.Controllers" }
            );
        }
    }
}