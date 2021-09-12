using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ServiceEmail.Auth.ModelAuth;
using ServiceEmail.BLL.SessionService;
using ServiceEmail.UI.Models.TaskModel;
using ServiceEmail.UI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceEmail.UI.Controllers
{
    public class AccountController : Controller
    {
        List<User> context = new List<User>();
        public AccountController()
        {
            var list = new List<TaskInfo>()
            {
                //new TaskInfo(){Name = "Wheather", Description = "Info by wheather", LastDateTime = new DateTime(12,12,1992)},
                //new TaskInfo(){Name = "Play", Description = "Info abput play", LastDateTime = new DateTime(12,12,1992)},
                //new TaskInfo(){Name = "Kino", Description = "Info by wheather", LastDateTime = new DateTime(12,12,1992)}

            };

            context = new List<User>()
            {
                new User(){Name = "Nikita", LastName = "Levashov",Password = "20021992", Email = "arhangel205@mail.ru", taskInfo = list},
                new User(){Name = "Nikita", LastName = "Levashov",Password = "20021992", Email = "arhangel205@mail.ru", taskInfo = list},
                new User(){Name = "Nikita", LastName = "Levashov",Password = "20021992", Email = "arhangel205@mail.ru", taskInfo = list},
            };
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
                User user = context.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    HttpContext.Session.Set<User>("user", user);
                    //TempData["user"] = user;
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
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
                User user = context.FirstOrDefault(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    context.Add(new User { Email = model.Email, Password = model.Password });
                    //await db.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Login", "Account");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
