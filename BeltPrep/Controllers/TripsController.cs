using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BeltPrep.Models;

namespace BeltPrep.Controllers
{
    public class TripsController : Controller
    {
        private BeltPrepContext db;

        public TripsController(BeltPrepContext context)
        {
            db = context;
        }

        [HttpGet("/trips")]
        public IActionResult All()
        {
            return View("All");
        }
    }
}
