using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCompany.Business;
using Microsoft.Practices.Unity;

namespace MVC4Application.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult BeginProductInquiry()
        {
            // to get some service
            return Content(Server.HtmlEncode(DateTime.Now.ToLongDateString()));;
        }

        public ActionResult KnockoutInquiry()
        {
            return View();
        }

    }
}
