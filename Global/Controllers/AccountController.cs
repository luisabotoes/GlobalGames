using Global.Dados.Entidades;
using Global.Helpers;
using Global.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Global.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper userHelper;

        public AccountController(IUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (this.Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return this.Redirect(this.Request.Query["ReturnUrl"].First());
                    }
                    return this.RedirectToAction("Index2", "Inscricoes");

                }
            }
            this.ModelState.AddModelError(string.Empty, "Failed to Login!");
            return this.View(model);
        }
        
        public async Task<IActionResult> Logout()
        {
            await this.userHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegisterNewUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.userHelper.GetUserByEmailAsync(model.UserName);
                if(user == null)
                {
                    user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.UserName,
                        UserName = model.UserName
                    };

                    var result = await this.userHelper.AddUserAsync(user, model.Password);
                    if (result != IdentityResult.Success)
                    {
                        this.ModelState.AddModelError(string.Empty, "The user could not be created.");
                        return this.View(model);
                    }

                    var loginViewModel = new LoginViewModel
                    {
                        Password = model.Password,
                        RememberMe = false,
                        Username = model.UserName
                    };

                    var result2 = await this.userHelper.LoginAsync(loginViewModel);
                    if (result2.Succeeded)
                    {
                        return this.RedirectToAction("Index", "Home");
                    }
                    this.ModelState.AddModelError(string.Empty, "Não foi possível fazer log in deste utilizador.");
                }
                this.ModelState.AddModelError(string.Empty, "Este utilizador já está registado.");
            }
            return this.View(model);
        }

    }
}
