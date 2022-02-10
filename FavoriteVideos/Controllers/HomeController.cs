using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteVideos.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpGet("/videos")]
        public ViewResult Videos()
        {
            // When we have a DB, this data would be requested here from the DB.
            List<string> youtubeVideoIds = new List<string>()
            {
            "5qap5aO4i9A", "EHtsQ9thkIY", "0rBG9BAiiC4", "cCwiZdFz63w", "fb9-OzVuV6g", "-y8aKyi6-OQ", "kVaiWk7H7n0",
            "UDA6Kd6uYqs", "eg9_ymCEAF8", "Q8vnqwtOf8E"
            };

            // Every method (action) has it's own ViewBag, they are NOT shared.

            // ViewBag is a dynamic data type, you can add new properties of 
            // any data to it.
            ViewBag.YoutubeVideoIds = youtubeVideoIds;
            ViewBag.RandomNumber = new System.Random().Next();

            // The ViewBag doesn't need to be passed in to the HTML page
            // it is automatically availale on the page.
            return View("Videos");
        }

        // Catch all not found route.
        [HttpGet("{**path}")]
        public RedirectToActionResult Unknown(string path)
        {
            Console.WriteLine("*****UNKNOWN ROUTE: " + path);
            return RedirectToAction("Index");
        }
    }
}