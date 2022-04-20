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
                .Include(t => t.TripUserJoins)
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
            // See Trip.cs for custom [FutureDate] validator attribute which
            // comes from CustomValidators.cs
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid == false)
            {
                // Display errors on the form page.
                return View("New");
            }

            if (trip.ReturnDate <= trip.DepartureDate)
            {
                ModelState.AddModelError("ReturnDate", "Return date must be after the departure date.");
                return View("New");
            }

            // Relate the creator to the new trip.
            trip.UserId = (int)uid;
            db.Trips.Add(trip);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpPost("/trips/{tripId}/join")]
        public IActionResult Join(int tripId)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            TripUserJoin existingJoin = db.TripUserJoins
                .FirstOrDefault(j => j.TripId == tripId && j.UserId == uid);

            if (existingJoin == null)
            {
                TripUserJoin newJoin = new TripUserJoin()
                {
                    UserId = (int)uid,
                    TripId = tripId
                };

                db.TripUserJoins.Add(newJoin);
            }
            else
            {
                db.Remove(existingJoin);
            }

            db.SaveChanges();

            // new {} means new dictionary is being created.
            //     RedirectToAction("Details", new { paramName1 = paramValue1, paramName2 = paramValue2 });
            return RedirectToAction("Details", new { tripId = tripId });
        }

        [HttpGet("/trips/{tripId}")]
        public IActionResult Details(int tripId)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Trip trip = db.Trips
                .Include(t => t.Planner)
                .Include(t => t.TripUserJoins).ThenInclude(join => join.User)
                .FirstOrDefault(t => t.TripId == tripId);

            if (trip == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", trip);
        }

        [HttpPost("/trips/{tripId}/delete")]
        public IActionResult Delete(int tripId)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Trip trip = db.Trips.FirstOrDefault(t => t.TripId == tripId);

            if (trip == null || trip.UserId != uid)
            {
                return RedirectToAction("All");
            }

            db.Trips.Remove(trip);
            db.SaveChanges();
            return RedirectToAction("All");
        }
    }
}
