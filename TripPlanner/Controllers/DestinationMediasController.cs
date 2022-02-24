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

        [HttpGet("/destinations/{destinationMediaId}/edit")]
        public IActionResult Edit(int destinationMediaId)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            DestinationMedia destination = db.DestinationMedias
                .FirstOrDefault(d => d.DestinationMediaId == destinationMediaId);

            if (destination == null || uid != destination.UserId)
            {
                return RedirectToAction("All", "Trips");
            }

            return View("Edit", destination);
        }

        [HttpPost("/destinations/{destinationMediaId}/update")]
        public IActionResult Update(int destinationMediaId, DestinationMedia editedDestination)
        {
            if (ModelState.IsValid == false)
            {

                /* 
                Show validations on edit form and keep the current edited form 
                data to pre-fill it by passing in editedDestination.

                The <form> tag needs the id for asp-route-destinationMediaId
                so we also add to make sure it's available. The id is
                automatically added if you followed the id naming conventions.
                */
                editedDestination.DestinationMediaId = destinationMediaId;
                return View("Edit", editedDestination);
            }

            DestinationMedia dbDestination = db.DestinationMedias
                .FirstOrDefault(d => d.DestinationMediaId == destinationMediaId);

            if (dbDestination == null)
            {
                return RedirectToAction("All", "Trips");
            }

            dbDestination.UpdatedAt = DateTime.Now;
            dbDestination.Location = editedDestination.Location;
            dbDestination.Src = editedDestination.Src;
            dbDestination.ShortDescription = editedDestination.ShortDescription;
            dbDestination.Type = editedDestination.Type;

            db.DestinationMedias.Update(dbDestination);
            db.SaveChanges();

            return RedirectToAction("All", "Trips");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
