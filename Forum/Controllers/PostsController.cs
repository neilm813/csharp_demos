using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Forum.Models;

namespace Forum.Controllers
{
    public class PostsController : Controller
    {
        private ForumContext db;
        public PostsController(ForumContext context)
        {
            db = context;
        }

        /* 
        Get the page that has the form to submit a new Post.
        Each Create needs two routes:
            1. GET: the page with the form
            2. POST: Handle the form submission
        */
        [HttpGet("/posts/new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("/posts/create")]
        public IActionResult Create(Post newPost)
        {
            if (ModelState.IsValid == false)
            {
                // Send back to the form to display error messages.
                return View("New");
            }

            // ModelState IS valid b/c the above return didn't happen.
            db.Posts.Add(newPost);

            // Db won't update until you do this.
            // After save changes, the newPost.PostId will be updated from the DB.
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet("/posts")]
        public IActionResult All()
        {
            List<Post> allPosts = db.Posts.ToList();
            return View("All", allPosts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
