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
    [Authorize]
    public class AnalysisController : Controller
    {
        private UserManager<TTS.Entities.ApplicationUser> _userManager { get; set; }
        private TTS.Data.ApplicationDbContext context { get; set; }
        public AnalysisController(UserManager<TTS.Entities.ApplicationUser> userManager, TTS.Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllProjectInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var list = context.Projects.Include(x => x.Tasks).Where(x => x.UserId == userId).ToList();
            var v = new Dictionary<string, double>();
            foreach(var item in list)
            {
                v.Add(item.ProjectName, item.Tasks.Select(x => x.TaskTime).Sum());
            }
            return Json(v);
        }
        public JsonResult GetProjectInfo(string project)
        {
            var tasks = context.Projects.Include(x => x.Tasks).First(x => x.ProjectName == project).Tasks;
            var v = new Dictionary<string, double>();
            foreach (var item in tasks)
            {
                v.Add(item.TaskName, item.TaskTime);
            }
            return Json(v);
        }
    }
}