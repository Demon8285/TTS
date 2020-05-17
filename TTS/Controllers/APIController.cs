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
            var project = context.Projects.Where(x => x.UserId == user.Id).ToArray();
            return Json(project);
        }
        public JsonResult GetTask(string useremail, string projectname)
        {
            var user = context.Users.FirstOrDefault(x => x.Email == useremail);
            if (user == null) return null;
            var project = context.Projects.FirstOrDefault(x => x.UserId == user.Id && x.ProjectName == projectname);
            if (project == null) return null;
            var task = context.Tasks.Where(x => x.ProjectId == project.ProjectId).ToArray();
            foreach(var x in task)
            {
                x.Project = null;
            }
            return Json(task);
        }
    }
}