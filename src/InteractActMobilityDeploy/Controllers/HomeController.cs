using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InteractActMobilityDeploy.Models;
using Microsoft.Extensions.Logging;

namespace InteractActMobilityDeploy.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _log;

        public HomeController(ILogger<HomeController> log)
        {
            _log = log;
        }

        public IActionResult Index()
        {
            _log.LogInformation("Hello, world!");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
