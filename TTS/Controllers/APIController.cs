using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TTS.Controllers
{
    public class APIController : Controller
    {
        private UserManager<TTS.Entities.ApplicationUser> _userManager { get; set; }
        private TTS.Data.ApplicationDbContext context { get; set; }
        public APIController(UserManager<TTS.Entities.ApplicationUser> userManager, TTS.Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            this.context = context;
        }
        public JsonResult GetProject(string useremail)
        {
            var user = context.Users.FirstOrDefault(x => x.Email == useremail);
            if (user == null) return null;
            var project = context.Projects.Include(x => x.Tasks).Where(x => x.UserId == user.Id).ToArray();
            foreach(var x in project)
            {
                x.User = null;
                foreach(var y in x.Tasks)
                {
                    y.Project = null;
                }
            }
            return Json(project);
        }
        public JsonResult GetTask(string useremail)
        {
            var user = context.Users.FirstOrDefault(x => x.Email == useremail);
            if (user == null) return null;
            var task = context.Tasks.Include(x => x.Project).Where(x => x.Project.UserId == user.Id).ToArray();
            foreach(var x in task)
            {
                x.Project.Tasks = null;
            }
            return Json(task);
        }
        public JsonResult CheckEmail(string email)
        {
            return Json(context.Users.Any(x => x.Email == email));
        }
        public JsonResult AddTaskTime(Guid id, double time)
        {
            try
            {
                var task = context.Tasks.FirstOrDefault(x => x.TaskId == id);
                if (task == null)
                {
                    return Json(new { result = false, message = "Email is not exist"});
                }
                task.TaskTime += time;
                context.Update(task);
                context.SaveChanges();
                return Json(new { result = true, messgae = ""});
            }
            catch(Exception error)
            {
                return Json(new { result = false, message = error.Message });
            }
        }
    }
}