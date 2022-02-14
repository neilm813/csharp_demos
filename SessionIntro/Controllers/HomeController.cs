using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SessionIntro.Models;

namespace SessionIntro.Controllers
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
            return View("Index");
        }

        [HttpPost("/login")]
        public IActionResult Login(User newUser)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Username", newUser.Username);
                return RedirectToAction("StoryTime");
            }

            // If ModelState is invalid, send back to same page to see errors.
            return View("Index");
        }

        [HttpGet("/story")]
        public IActionResult StoryTime()
        {
            string story = HttpContext.Session.GetString("story");

            if (story == null)
            {
                /* 
                On the first visit to this page, story has not been started yet
                so it is null in session and we want to initialize it to an empty string.
                */
                HttpContext.Session.SetString("story", "");
            }
            return View("StoryTime");
        }

        [HttpPost("/story/add")]
        public IActionResult AddToStory(StoryFragment storyFragment)
        {
            if (ModelState.IsValid)
            {
                string updatedStory = HttpContext.Session.GetString("story");
                updatedStory += " " + storyFragment.Word;
                HttpContext.Session.SetString("story", updatedStory);

                return RedirectToAction("StoryTime");
            }

            // Dispaly error messages.
            return View("StoryTime");
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            // Clears EVERYTHING.
            // HttpContext.Session.Clear();
            return RedirectToAction("Index");
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
    }
}
