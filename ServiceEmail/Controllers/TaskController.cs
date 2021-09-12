using Microsoft.AspNetCore.Mvc;
using ServiceEmail.BLL.ApiService;
using ServiceEmail.BLL.SessionService;
using ServiceEmail.UI.Mapping;
using ServiceEmail.UI.Models.TaskModel;
using ServiceEmail.UI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceEmail.UI.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            var list = new List<TaskInfo>()
            {
                //new TaskInfo(){Name = "Wheather", Description = "Info by wheather", LastDateTime = new DateTime(12,12,1992)},
                //new TaskInfo(){Name = "Play", Description = "Info abput play", LastDateTime = new DateTime(12,12,1992)},
                //new TaskInfo(){Name = "Kino", Description = "Info by wheather", LastDateTime = new DateTime(12,12,1992)}

            };

            var listUser = new List<User>()
            {
                new User(){Name = "Nikita", LastName = "Levashov", Email = "20021992", taskInfo = list},
                new User(){Name = "Pasha", LastName = "Ivanov", Email = "20021992", taskInfo = list},
                new User(){Name = "Igor", LastName = "Ivanov", Email = "20021992", taskInfo = list},
            };

            ViewBag.Api = list;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskInfo taskInfo)
        {
            User user = HttpContext.Session.Get<User>("user");
            
            taskInfo.DataOfTask = ApiService.GetJsonInfo(taskInfo.FreeApi, taskInfo.AppSettings);
            taskInfo.LastDateTime = DateTime.Now;

            user.taskInfo.Add(taskInfo);

            Helper.user = user;

            var t = new EmailScheduler();
            
            user.taskInfo.Last().EmailSheduler = t;

            var e = user.MapperForBLL();

            HttpContext.Session.Set<User>("user", user);
            //t.Start();

            return RedirectToAction("Index","Home");
        }
    }

    public static class Helper
    {
        public static User user;
    }
}
