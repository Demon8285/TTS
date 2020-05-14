using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TTS.Controllers
{
    public class AnalysisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}