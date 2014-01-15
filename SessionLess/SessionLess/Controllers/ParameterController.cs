using SessionLess.CustomControllerFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.Controllers
{
    public class ParameterController : Controller
    {
        private ILogger _logger;
        // DefaultControllerFactory is calling underlining DependencyResolver to create 
        // Controller instance
        public ParameterController(ILogger logger)
        {
            _logger = logger; 
        }
        //
        // GET: /Parameter/
        public ActionResult Index()
        {
            return View();
        }
	}
}