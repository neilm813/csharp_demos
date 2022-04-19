using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeltPrep.Models;
using Microsoft.AspNetCore.Http;

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

            return View("All");
        }
    }
}
