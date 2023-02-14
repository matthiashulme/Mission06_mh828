using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_mh828.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_mh828.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _Context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext contextName)
        {
            _logger = logger;
            _Context = contextName;
        }

        // Index/Home Page Route
        public IActionResult Index()
        {
            return View();
        }

        // MovieSubmission Page Get Route
        [HttpGet]
        public IActionResult MovieSubmission()
        {
            return View();
        }

        // MovieSubmission Page Post Route
        [HttpPost]
        public IActionResult MovieSubmission(Movie m)
        {
            _Context.Add(m);
            _Context.SaveChanges();

            return View("Confirmation", m);
        }

        // MyPodcasts Route
        public IActionResult MyPodcasts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
