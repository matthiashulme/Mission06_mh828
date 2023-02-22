using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieContext _Context { get; set; }

        public HomeController(MovieContext contextName)
        {
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
            ViewBag.Categories = _Context.Categories.ToList();

            return View();
        }

        // MovieSubmission Page Post Route
        [HttpPost]
        public IActionResult MovieSubmission(Movie m)
        {
            // Validation Branch if Model is Valid
            if (ModelState.IsValid)
            {
                _Context.Add(m);
                _Context.SaveChanges();

                return View("Confirmation", m);
            }
            // Reroute back to page if Model is Invalid
            else
            {
                ViewBag.Categories = _Context.Categories.ToList();
                return View(m);
            }
            
        }

        // MyPodcasts Route
        public IActionResult MyPodcasts()
        {
            return View();
        }

        // Movie List Page Route
        public IActionResult MovieList()
        {
            var movies = _Context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View(movies);
        }

        // Edit Page Post Route
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            _Context.Update(m);
            _Context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        // Edit Page Get Route
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _Context.Categories.ToList();

            var application = _Context.Movies.Single(x => x.MovieId == movieid);

            return View("MovieSubmission", application);
        }

        // Delete Page Post Route
        [HttpPost]
        public IActionResult Delete(Movie m)
        {
            _Context.Movies.Remove(m);
            _Context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        // Delete Page Get Route
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var application = _Context.Movies.Single(x => x.MovieId == movieid);
            return View(application);
        }
    }
}
