using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeltPrep.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BeltPrep.Controllers
{
    public class TripsController : Controller
    {
        private BeltPrepContext db;

        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        public TripsController(BeltPrepContext context)
        {
            db = context;
        }

        [HttpGet("/trips")]
        public IActionResult All()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Trip> allTrips = db.Trips
                .Include(t => t.Planner)
                .ToList();

            return View("All", allTrips);
        }

        [HttpGet("/trips/new")]
        public IActionResult New()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpPost("/trips/create")]
        public IActionResult Create(Trip trip)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid == false)
            {
                // Display errors on the form page.
                return View("New");
            }

            // Relate the creator to the new trip.
            trip.UserId = (int)uid;
            db.Trips.Add(trip);
            db.SaveChanges();
            return RedirectToAction("All");
        }
    }
}
