using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.IdentityModel.Services.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACSApp.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            FederatedAuthentication.WSFederationAuthenticationModule.SignOut();

            return RedirectToAction("Index","Home");
        }
    }
}