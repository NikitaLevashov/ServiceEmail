using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ServiceEmail.Auth.ModelAuth;
using ServiceEmail.BLL.Interfaces;
using ServiceEmail.UI.Mapping;
using ServiceEmail.BLL.SessionService;
using ServiceEmail.UI.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceEmail.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _service;
        public AccountController(IUserService service)
        {
            _service = service ??throw new ArgumentNullException();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _service.GetAll().MapToEnumerableUsers().FirstOrDefault(u 
                    => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    await Authenticate(user);

                    HttpContext.Session.Set<User>("user", user);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Not correct login and(or) password");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _service.GetAll().MapToEnumerableUsers().FirstOrDefault(u 
                    => u.Email == model.Email && u.Password == model.Password);

                if (user == null)
                {
                    _service.Create(new User { Email = model.Email, Password = model.Password,
                        LastName = model.LastName, Name = model.Name, Role = new Role { Id = 1} }.MapToBLLUser());

                    await Authenticate(user);

                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("", "Not correct login and(or) password");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
