using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Groapa.Domain.Models;
using Groapa.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Groapa.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> logger;
        private readonly SignInManager<UserSqlView> signInManager;

        public AccountController(ILogger<AccountController> logger, SignInManager<UserSqlView> signInManager)
        {
            this.logger = logger;
            this.signInManager = signInManager;
        }

        public SignInManager<UserSqlView> SignInManager { get; }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View();
        }
    }
}