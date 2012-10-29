﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCompany.Business;
using Microsoft.Practices.Unity;

namespace MVC4Application.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult BeginProductInquiry()
        {
            // to get some service
            return Content(Server.HtmlEncode(DateTime.Now.ToLongDateString()));;
        }

    }
}
