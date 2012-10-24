using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4Application.Controllers
{
    public class OrdersController : Controller
    {
                
        public ActionResult BeginOrderInquiry()
        {
            // to get some service

            return View("OrderInquiry");
        }

    }
}
