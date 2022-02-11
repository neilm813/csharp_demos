using System;
using System.Collections.Generic;
using FavoriteVideos.Models;
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
            VideosView viewModel = new VideosView();

            return View("Videos", viewModel);
        }

        /* 
        <form> need 2 routes, the route to GET the page with the <form>

        and the route to process the <form> submission.
        */
        [HttpGet("/users/register")]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost("/users/process-registration")]
        public IActionResult ProcessRegistration(User newUser)
        {
            // return View("Guest", newUser);
            return RedirectToAction("Guest", newUser);
        }

        // Catch all not found route.
        [HttpGet("{**path}")]
        public IActionResult Unknown(string path)
        {
            Console.WriteLine("*****UNKNOWN ROUTE: " + path);
            return RedirectToAction("Index");
        }
    }
}