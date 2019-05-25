using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Project.VM;

namespace Project.Controllers
{
    public class AccountController: Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /*
         *
         */

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }

            var user = await _userManager.FindByNameAsync(loginVm.name);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVm.pwd, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Student");
                }
            }

            ModelState.AddModelError("", "用户名/密码不正确");
            return View(loginVm);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registerVM.name
                };

                var result = await _userManager.CreateAsync(user, registerVM.pwd);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Student");
                }
            }

            return View(registerVM);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Student");
        }
    }
}
