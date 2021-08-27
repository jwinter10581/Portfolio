using GuildCars.Data.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using GuildCars.UI.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            AppUser user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }          
            else
            {             
                var employee = EmployeeRepositoryFactory.GetRepository().GetByEmployeeEmail(user.Email);
                if (employee is null)
                {
                    ModelState.AddModelError("", "User does not exist, unable to log into website.");

                    return View(model);
                }
                else if(employee.RoleName.ToLower() == "disabled")
                {
                    ModelState.AddModelError("", "User is disabled, unable to log into website.");

                    return View(model);
                }

                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles = "admin,sales")]
        public ActionResult ChangePassword()
        {
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            model.UserName = EmployeeRepositoryFactory.GetRepository().GetByEmployeeEmail(AuthorizeUtilities.GetEmail(this)).EmployeeEmail;  // Grabs AspNetUser Id & Converts to Employee ID
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async System.Threading.Tasks.Task<ActionResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            // Update on AspNetUsers Table
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var provider = new DpapiDataProtectionProvider("GuildCars");
            userManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(provider.Create("ChangePassword"));
            var token = await userManager.GeneratePasswordResetTokenAsync(AuthorizeUtilities.GetUserId(this));
            await userManager.ResetPasswordAsync(AuthorizeUtilities.GetUserId(this), token, model.Password);

            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}