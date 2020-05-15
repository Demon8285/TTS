using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TTS.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private UserManager<TTS.Entities.ApplicationUser> _userManager { get; set; }
        private TTS.Data.ApplicationDbContext context { get; set; }
        public ProjectController(UserManager<TTS.Entities.ApplicationUser> userManager, TTS.Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            this.context = context;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var list = context.Projects.Where(x => x.UserId == userId).ToList();
            return View(list);
        }
        public IActionResult Tasks(Guid id)
        {
            var list = context.Tasks.Where(x => x.ProjectId == id).ToList();
            ViewBag.ProjectId = id;
            ViewBag.ProjectName = context.Projects.First(x => x.ProjectId == id).ProjectName;
            return View(list);
        }
        public bool TaskDelete(Guid id)
        {
            var task = context.Tasks.First(x => x.TaskId == id);
            context.Tasks.Remove(task);
            context.SaveChanges();
            return true;
        }
        public bool ProjectDelete(Guid id)
        {
            context.Projects.Remove(context.Projects.First(x => x.ProjectId == id));
            context.SaveChanges();
            return true;
        }
        public bool UpdateTaskName (Guid id, string new_name)
        {
            var task = context.Tasks.First(x => x.TaskId == id);
            task.TaskName = new_name;
            context.Tasks.Update(task);
            context.SaveChanges();
            return true;
        }
        public bool UpdateTaskTime(Guid id, double new_time)
        {
            var task = context.Tasks.First(x => x.TaskId == id);
            task.TaskTime = new_time;
            context.Tasks.Update(task);
            context.SaveChanges();
            return true;
        }
        public bool UpdateTaskStatus(Guid id, bool new_status)
        {
            var task = context.Tasks.First(x => x.TaskId == id);
            task.TaskStatus = new_status;
            context.Tasks.Update(task);
            context.SaveChanges();
            return true;
        }
        public Guid AddTask(string name, Guid projectid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.Users.First(x => x.Id == userId);
            if (user.Subscribe == null || user.Subscribe.Ticks < DateTime.Now.Ticks)
            {
                RedirectToAction("Subscribe", "Home");
            }
            var task = new Entities.Task { TaskName = name, ProjectId = projectid };
            context.Tasks.Add(task);
            context.SaveChanges();
            return task.TaskId;
        }
        public IActionResult ProjectAdd(string name, string about)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.Users.First(x => x.Id == userId);
            if (user.Subscribe == null || user.Subscribe.Ticks < DateTime.Now.Ticks)
            {
                RedirectToAction("Subscribe", "Home");
            }
            var projetct = new Entities.Project { ProjectName = name, About = about, UserId = userId };
            context.Projects.Add(projetct);
            context.SaveChanges();
            return RedirectToAction("Tasks", "Project", new { @id = projetct.ProjectId });
        }
    }
}