using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Yvadev.Infrastructure.EF.Models;
using Yvadev.Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await signInManager.PasswordSignInAsync(model.UserName,model.Password,model.RememberMe, false);

            if (result.Succeeded)
            {
                return Redirect("/" + returnUrl);
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model, string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = mapper.Map<AppUser>(model);

            var result = userManager.CreateAsync(newUser, model.Password);
            if (!result.Result.Succeeded) return new BadRequestObjectResult(ModelState);

            return new OkObjectResult("Account Created");
        }
    }
}