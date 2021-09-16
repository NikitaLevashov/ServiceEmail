using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceEmail.BLL.Interfaces;
using ServiceEmail.UI.Mapping;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceEmail.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _service;
        public AdminController(IUserService service)
        {
            _service = service ?? throw new ArgumentNullException();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var users = _service.GetAll().MapToEnumerableUsers().ToList();

            return View(users);
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> ShowDetails(int positionUserOfTableInView)
        {
            var user = await Task.Run(() => _service.GetAll().FirstOrDefault(x => x.Id == positionUserOfTableInView));

            ViewBag.Tasks = user.MapToUser().taskInfo;

            return PartialView();
        }
    }
}
