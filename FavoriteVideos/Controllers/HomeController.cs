using System.Collections.Generic;
using FavoriteVideos.Models;
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

        /* ViewBag approach */
        // [HttpGet("/videos")]
        // public ViewResult Videos()
        // {
        //     List<string> youtubeVideoIds = new List<string>
        //     {
        //     "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "6avJHaC3C2U", "_mZBa3sqTrI", "GcKkiRl9_qE"
        //     };

        //     /* 
        //     Each controller method / 'action' has it's own ViewBag that is
        //     SEPARATE, the data is not shared between them.

        //     The ViewBag properties are automatically available in the View
        //     that is returned from this method.
        //     */
        //     ViewBag.YoutubeVideoIds = youtubeVideoIds;
        //     ViewBag.Message = $"Here are {youtubeVideoIds.Count} of my favorite videos!";

        //     return View("Videos");
        // }

        /* ViewModel approach */
        [HttpGet("/videos")]
        public ViewResult Videos()
        {
            List<string> youtubeVideoIds = new List<string>
            {
            "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "6avJHaC3C2U", "_mZBa3sqTrI", "GcKkiRl9_qE"
            };

            VideosViewModel viewModel = new VideosViewModel()
            {
                YoutubeVideoIds = youtubeVideoIds,
                Message = "Here are some of my favorite videos!"
            };

            return View("Videos", viewModel);
        }

        [HttpGet("/users/register")]
        public ViewResult Register()
        {
            return View("Register");
        }

        [HttpPost("/users/process-registerion")]
        public ViewResult ProcessRegistration(User newUser)
        {
            return View("Guest", newUser);
        }
    }
}