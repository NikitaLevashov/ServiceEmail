using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using ServiceEmail.BLL.SessionService;
using ServiceEmail.Models;
using ServiceEmail.UI.Models.UserModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ServiceEmail.Controllers
{
    [Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            User person = await Task.Run(() => HttpContext.Session.Get<User>("user"));

            if(person == null)
            {
                _logger.LogWarning("Getting user failed");

                return BadRequest();
                
            }

            _logger.LogInformation("Getting user was successful");
     
            return View(person);
        }

        [Authorize(Roles = "user")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
