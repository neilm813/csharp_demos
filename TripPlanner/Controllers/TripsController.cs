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
    public class TripsController : Controller
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
        public TripsController(TripPlannerContext context)
        {
            db = context;
        }

        [HttpGet("/trips/all")]
        public IActionResult All()
        {
            List<Trip> trips = db.Trips
                .Include(t => t.CreatedBy)
                .ToList();
            return View("All", trips);
        }

        [HttpGet("/trips/new")]
        public IActionResult New()
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpGet("/trips/{tripId}")]
        public IActionResult Details(int tripId)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Trip trip = db.Trips
                .Include(t => t.CreatedBy)
                .FirstOrDefault(t => t.TripId == tripId);

            if (trip == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", trip);
        }

        [HttpPost("/trips/create")]
        public IActionResult Create(Trip newTrip)
        {
            if (ModelState.IsValid == false)
            {
                // Go back to form to display error messages.
                return View("New");
            }

            newTrip.UserId = (int)uid;
            db.Trips.Add(newTrip);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
