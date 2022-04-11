using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Session.Models;

namespace Session.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/login")]
        public IActionResult Login(User newUser)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Username", newUser.Username);
                return RedirectToAction("StoryTime");
            }

            // ModelState is invalid, send them back to the form to show errors
            return View("Index");
        }

        [HttpGet("/story")]
        public IActionResult StoryTime()
        {
            string currentStory = HttpContext.Session.GetString("Story");

            if (currentStory == null)
            {
                /* 
                No one has submitted to the story yet, initialize it to an
                empty string so it's ready to be concatenated to when a new
                word is added.
                */

                HttpContext.Session.SetString("Story", "");
            }

            return View("StoryTime");
        }

        public IActionResult AddToStory(StoryFragment fragment)
        {
            string currentStory = HttpContext.Session.GetString("Story");
            currentStory += " " + fragment.Word;
            HttpContext.Session.SetString("Story", currentStory);
            return RedirectToAction("StoryTime");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            // Clears EVERYTHING.
            // HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
