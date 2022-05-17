using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class WeddingsController : Controller
    {
        private WeddingPlannerContext db;

        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        public WeddingsController(WeddingPlannerContext ctx)
        {
            Console.WriteLine("Constructing WeddingsController.");
            db = ctx;
        }

        [HttpGet("/weddings")]
        public IActionResult All()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Wedding> weddings = db.Weddings
                .Include(w => w.Planner)
                .Include(w => w.UserWeddingGuests)
                .ThenInclude(uwg => uwg.Guest)
                .ToList();

            return View("All", weddings);
        }

        [HttpGet("/weddings/new")]
        public IActionResult New()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpPost("/weddings/create")]
        public IActionResult Create(Wedding wedding)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid == false)
            {
                // Send back to the form to show error messages.
                return View("New");
            }

            wedding.UserId = (int)uid;
            db.Weddings.Add(wedding);


            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpPost("/weddings/{weddingId}/delete")]
        public IActionResult Delete(int weddingId)
        {
            Wedding? wedding = db.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);

            if (wedding == null || uid == null || wedding.UserId != uid)
            {
                return RedirectToAction("Index", "Home");
            }


            db.Weddings.Remove(wedding);
            db.SaveChanges();
            return RedirectToAction("All");
        }
    }
}