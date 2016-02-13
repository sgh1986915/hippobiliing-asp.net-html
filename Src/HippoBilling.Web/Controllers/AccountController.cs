using HippoBilling.Processor.Commands.Accounts;
using HippoBilling.Service.Accounts;
using HippoBilling.Web.Models.Account;
using HippoBilling.Web.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using HippoBilling.Web.Mvc.Models;

namespace HippoBilling.Web.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : HippoControllerBase
    {
        private readonly IAuthenticationService _authService;
        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }

   
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return Json(null);

            var result = new CommandResult {Success = false};

            var user = _authService.GetUser(model.Email);
            if (user == null)
            {
                result.Errors = new List<ErrorResult>
                {
                    new ErrorResult {Name = "LoginError", Error = "The account does not exist."}
                };
            }
            else if (!user.Active)
            {
                result.Errors = new List<ErrorResult>
                {
                    new ErrorResult {Name = "LoginError", Error = "The account is inactive."}
                };
            }
            else
            {
                result.Success = true;
                result.Redirect = "/Home/Index";
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                Response.Cookies.Add(new HttpCookie("UserName", user.Name));
            }

            return Json(result);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        [Route("forgot-password")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("forgot-password")]
        [HttpPost]
        public ActionResult ForgotPassword(SendVerificationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); 
            }

            var command =new SendVerificationCommand(){
                Email = model.Email,
                Link = GetAbsoluteUrl("change-password", "account")
            };
            CommandService.Execute(command);

            return RedirectToAction("SendVerification");
        }

        [AllowAnonymous]
        [Route("change-password/{code}")]
        public ActionResult ChangePassword(string code)
        {
            var passwordRecovery = _authService.GetVerificationCode(code);
            if (passwordRecovery == null)
            {
                ModelState.AddModelError("Error", "The code does not exist.");
            }
            return View(new ChangePasswordViewModel());
        }
        [AllowAnonymous]
        [Route("change-password/{code}")]
        [HttpPost]
        public ActionResult ChangePassword(string code,ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            CommandService.Execute(new ChangePasswordCommand() {
                VerificationCode=code,
                Password=model.Password
            });

            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        [Route("send-verification")]
        public ActionResult SendVerification()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("send-verification")]
        [HttpPost]
        public ActionResult SendVerification(SendVerificationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); 
            }
            var command = new SendVerificationCommand()
            {
                Email = model.Email,
                Link = GetAbsoluteUrl("change-password","account")
            };
            CommandService.Execute(command);
            return RedirectToAction("SendVerification");
        }

        private string GetAbsoluteUrl(string action, string controller)
        {
        
            var requestUrl = Request.Url;
            var absoluteAction = string.Format("{0}://{1}{2}/",
                                                  requestUrl.Scheme,
                                                  requestUrl.Authority,
                                                  Url.Action(action, controller));
            return absoluteAction;


        }
    }
}
