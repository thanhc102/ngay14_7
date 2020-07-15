using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ngay14_7.Models.ViewModels;

namespace ngay14_7.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginAccountRequest loginAccountRequest)
        {
            if(!ModelState.IsValid)
            {
                return View(loginAccountRequest);
            }
            var user = await _userManager.FindByNameAsync(loginAccountRequest.UserName);
            if(user==null)
            {
                return RedirectToAction(nameof(Register));
                 
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginAccountRequest.Passwword, false, false);
            if(result.Succeeded)
            {
                return RedirectToAction("SecretIndex","Home");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountRequest registerAccountRequest)
        {
            if(!ModelState.IsValid)
            {
                return View(registerAccountRequest);
            }
            var user = await _userManager.FindByNameAsync(registerAccountRequest.UserName);
            if (user != null) return View();
            IdentityUser newuser = new IdentityUser(registerAccountRequest.UserName);
            var result = await _userManager.CreateAsync(newuser, registerAccountRequest.Password);
            if(!result.Succeeded)
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SecretIndex", "Home");
        }

    }

}
