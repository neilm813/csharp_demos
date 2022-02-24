using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TripPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace TripPlanner.Controllers
{
    public class DestinationMediasController : Controller
    {
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        private bool loggedIn
        {
            get
            {
                return uid != null;
            }
        }

        private TripPlannerContext db;
        public DestinationMediasController(TripPlannerContext context)
        {
            db = context;
        }

        [HttpGet("/destinations/all")]
        public IActionResult All()
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            List<DestinationMedia> destinations = db.DestinationMedias
                .ToList();
            return View("All", destinations);
        }

        [HttpGet("/destinations/new")]
        public IActionResult New()
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpGet("/destinations/{destinationMediaId}")]
        public IActionResult Details(int destinationMediaId)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            DestinationMedia destination = db.DestinationMedias
                .FirstOrDefault(dm => dm.DestinationMediaId == destinationMediaId);

            if (destination == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", destination);
        }

        [HttpPost("/destinations/create")]
        public IActionResult Create(DestinationMedia newDestination)
        {
            if (ModelState.IsValid == false)
            {
                // Go back to form to display error messages.
                return View("New");
            }

            newDestination.UserId = (int)uid;
            db.DestinationMedias.Add(newDestination);
            db.SaveChanges();
            return RedirectToAction("Details", new { destinationMediaId = newDestination.DestinationMediaId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
