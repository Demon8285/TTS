using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TTS.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace TTS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<TTS.Entities.ApplicationUser> _userManager { get; set; }
        private TTS.Data.ApplicationDbContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, UserManager<TTS.Entities.ApplicationUser> userManager, TTS.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Subscribe()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.userid = userId;
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Subscribe(string id)
        {
            var user = context.Users.First(x => x.Id == id);
            user.Subscribe = DateTime.Now.AddDays(30);
            context.Users.Update(user);
            context.SaveChanges();
            return RedirectToAction("Index", "Project");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
