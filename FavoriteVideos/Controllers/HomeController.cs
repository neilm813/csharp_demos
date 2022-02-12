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
            /* 
            Problem: display a List<int> on the page while also having
            a <form> that creates a User.

            The page has @model User so that the ProcessRegistration method
            can receive a User instance so the model is already being used
            and we can't put the List<int> into the model.

            Solution 1: Use the ViewBag AND View Model.
            */
            List<int> luckyNumbers = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < 4; i++)
            {
                luckyNumbers.Add(rand.Next());
            }

            ViewBag.LuckyNumbers = luckyNumbers;
            return View("Register");
        }

        // A duplicate of the register page showing another solution.
        [HttpGet("/users/register2")]
        public IActionResult Register2()
        {
            /* 
            See Register method above for comments.

            Solution 2: Don't use the ViewBag, put everything into the View Model.
            */

            List<int> luckyNumbers = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < 4; i++)
            {
                luckyNumbers.Add(rand.Next());
            }

            RegisterView viewModel = new RegisterView()
            {
                LuckyNumbers = luckyNumbers
            };

            return View("Register2", viewModel);
        }

        [HttpPost("/users/process-registration")]
        public IActionResult ProcessRegistration(User newUser)
        {
            return View("Guest", newUser);
        }

        /* 
        Technically, the original ProcessRegistration route still works because
        the Framework automatically finds the User inside the RegisterView
        class which is being used as the Register page's ViewModel.
        */
        [HttpPost("/users/process-registration2")]
        public IActionResult ProcessRegistration2(RegisterView submittedModel)
        {
            return View("Guest", submittedModel.NewUser);
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