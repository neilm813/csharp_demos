using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteVideos.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")] // attribute
        public ViewResult Index() // methods are called Actions in ASP.NET
        {
            return View("Index");
        }

        [HttpGet("/videos")]
        public ViewResult Videos()
        {
            List<string> youtubeVideoIds = new List<string>
            {
            "fbqHK8i-HdA", "CUe2ymg1RHs", "rEIOkGCbo8", "ftJxh5i2M8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "e0vT8idXNS4", "6avJHaC3C2U", "_mZBa3sqTrI"
            };

            /* 
            Each controller method / 'action' has it's own ViewBag that is
            SEPARATE, the data is not shared between them.

            The ViewBag properties are automatically available in the View
            that is returned from this method.
            */
            ViewBag.YoutubeVideoIds = youtubeVideoIds;
            ViewBag.Message = $"Here are {youtubeVideoIds.Count} of my favorite videos!";

            return View("Videos");
        }
    }
}