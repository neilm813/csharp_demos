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
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

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
                .Include(t => t.TripDestinations)
                // .ThenInclude is given what was just included to then include something from that.
                // Used for displaying data from a many to many navigation property
                .ThenInclude(tripDestination => tripDestination.Destination)
                .FirstOrDefault(t => t.TripId == tripId);

            if (trip == null)
            {
                return RedirectToAction("All");
            }

            ViewBag.DestinationsToAdd = db.DestinationMedias.ToList();

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
            return RedirectToAction("Details", new { tripId = newTrip.TripId });
        }

        [HttpPost("/trips/{tripId}/add-destination")]
        public IActionResult AddDestination(int tripId, TripDestination newTripDestination)
        {
            /* 
            newTripDestination comes with the selected DestinationMediaId from
            <select> menu and just needs the TripId URL param to be added.
            */

            newTripDestination.TripId = tripId;
            db.TripDestinations.Add(newTripDestination);
            db.SaveChanges();
            return RedirectToAction("Details", new { tripId = tripId });
        }

        // Removing a many to many relationship.
        [HttpPost("/trips/{tripId}/destinations/{destinationMediaId}/remove-destination")]
        public IActionResult RemoveDestination(int tripId, int destinationMediaId)
        {
            TripDestination existingTripDestination = db.TripDestinations
                .FirstOrDefault(td => td.TripId == tripId && td.DestinationMediaId == destinationMediaId);

            if (existingTripDestination != null)
            {
                db.TripDestinations.Remove(existingTripDestination);
                db.SaveChanges();
            }
            return RedirectToAction("Details", new { tripId = tripId });
        }

        [HttpPost("/trips/{tripId}/delete")]
        public IActionResult Delete(int tripId)
        {
            Trip trip = db.Trips.FirstOrDefault(t => t.TripId == tripId);

            if (trip != null && uid == trip.UserId)
            {
                db.Trips.Remove(trip);
                db.SaveChanges();
            }

            return RedirectToAction("All");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
