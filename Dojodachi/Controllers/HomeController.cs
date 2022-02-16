using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
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

            // The Pet as a JSON string in session is converted back into a Pet instance.
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("Pet");

            if (sessionPet == null)
            {
                // Instantiate with default values to set session for the
                // first time.
                Pet newPet = new Pet();

                // newPet is converted into a JSON string
                HttpContext.Session.SetObjectAsJson("Pet", newPet);

                return View("Index", newPet);
            }


            return View("Index", sessionPet);
        }

        [HttpGet("/pet/feed")]
        public IActionResult Feed()
        {
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
            sessionPet.Feed(HttpContext.Session);
            return RedirectToAction("Index");
        }

        [HttpGet("/pet/play")]
        public IActionResult Play()
        {
            Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
            sessionPet.Play(HttpContext.Session);
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
