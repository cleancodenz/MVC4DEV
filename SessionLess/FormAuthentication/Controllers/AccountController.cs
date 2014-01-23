using FormAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormAuthentication.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // GET: /Account/Manage
        public ActionResult Manage()
        {

            return View();
        }

        //
        // GET: /Account/Manage
        [Authorize(Roles = "Admin")]
        public ActionResult AdminManage()
        {
           // using Roles for formsauthentication
           // WSSecutiry for simple membership provider
           var test= Roles.IsUserInRole("Admin");
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            /**
            if (ModelState.IsValid)
            {
                if (model.UserName == "j")
                {
                    FormsAuthentication.SetAuthCookie("Johnson",true);
                       return RedirectToLocal(returnUrl);
                }


            }**/

            if (ModelState.IsValid && Membership.ValidateUser(
                model.UserName,
                model.Password
                ))
            {
              
                FormsAuthentication.SetAuthCookie(model.UserName, true);
                return RedirectToLocal(returnUrl);
 
            }
            /**
                var user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }**/
           

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
	}
}