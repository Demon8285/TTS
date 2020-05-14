using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal;
using Microsoft.AspNetCore.Mvc;

namespace TTS.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tasks(string id)
        {
            return View();
        }
        public bool TaskDelete(string id)
        {
            return true;
        }
        public bool ProjectDelete(string id)
        {
            return true;
        }
        public bool UpdateTaskName (string id, string new_name)
        {
            return true;
        }
        public bool UpdateTaskTime(string id, double new_time)
        {
            return true;
        }
        public bool UpdateTaskStatus(string id, bool new_status)
        {
            return true;
        }
        public string AddTask(string name)
        {
            return Guid.NewGuid().ToString();
        }
        public IActionResult Add(string name)
        {
            return Redirect("https://" + name);
        }
    }
}