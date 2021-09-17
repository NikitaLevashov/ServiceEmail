using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceEmail.BLL.ApiService;
using ServiceEmail.BLL.CronService;
using ServiceEmail.BLL.Interfaces;
using ServiceEmail.BLL.SessionService;
using ServiceEmail.UI.Mapping;
using ServiceEmail.UI.Models.TaskModel;
using ServiceEmail.UI.Models.UserModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceEmail.UI.Controllers
{
    [Authorize(Roles = "user")]
    public class TaskController : Controller
    {
        private readonly ITaskService _serviceTask;
        public TaskController(IUserService service, ITaskService serviceTask)
        {
            _serviceTask = serviceTask ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskInfo taskInfo)
        {
            User user = HttpContext.Session.Get<User>("user");    
            
            taskInfo.DataOfTask = ApiService.GetJsonInfo(taskInfo.MapToBLLTask());
            taskInfo.LastDateTime = DateTime.Now;
            taskInfo.UserId = user.Id;

            var cron = new Cron().CronSetting(user.MapToBLLUser());
            cron.Start(taskInfo.MapToBLLTask());
            taskInfo.EmailSheduler = cron;

            user.taskInfo.Add(taskInfo);

            _serviceTask.Create(taskInfo.MapToBLLTask());
            HttpContext.Session.Set<User>("user", user);

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            User user = HttpContext.Session.Get<User>("user");
            var task = user.taskInfo.FirstOrDefault(x => x.Id == id);

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskInfo taskInfo)
        {
            User user = HttpContext.Session.Get<User>("user");
            var userHelp = user;

            var itemToRemove = user.taskInfo.SingleOrDefault(r => r.Id == taskInfo.Id);
            if (itemToRemove != null)
                user.taskInfo.Remove(itemToRemove);

            taskInfo.DataOfTask = ApiService.GetJsonInfo(taskInfo.MapToBLLTask());
            taskInfo.LastDateTime = DateTime.Now;
            
            var cron = new Cron().CronSetting(user.MapToBLLUser());
            cron.Start(taskInfo.MapToBLLTask());
            taskInfo.EmailSheduler = cron;

            user.taskInfo.Add(taskInfo);

            HttpContext.Session.Set<User>("user", user);
            _serviceTask.Update(taskInfo.MapToBLLTask());

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                User user = HttpContext.Session.Get<User>("user");

                var task = user.taskInfo.FirstOrDefault(x => x.Id == id);

                if (task != null)
                    return View(task);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskInfo task)
        {
            if (task != null)
            {
                User user = HttpContext.Session.Get<User>("user");

                var itemToRemove = user.taskInfo.SingleOrDefault(r => r.Id == task.Id);
                itemToRemove.EmailSheduler?.Stop(itemToRemove.MapToBLLTask());

                if (itemToRemove != null)
                    user.taskInfo.Remove(itemToRemove);

                _serviceTask.Delete(itemToRemove.MapToBLLTask());
                 HttpContext.Session.Set<User>("user", user);

                return RedirectToAction("Index", "Home");
            }

            return NotFound();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                User user = HttpContext.Session.Get<User>("user");

                var task = user.taskInfo.FirstOrDefault(p => p.Id == id);
                if (task != null)
                    return View(task);
            }

            return NotFound();
        }
    }
}
