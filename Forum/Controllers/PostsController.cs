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
        private readonly ILogger<PostsController> _logger;
        private ForumContext db;

        public PostsController(ForumContext context, ILogger<PostsController> logger)
        {
            db = context;
            _logger = logger;
        }

        [HttpGet("/posts")]
        public IActionResult All()
        {
            List<Post> allPosts = db.Posts.ToList();
            return View("All", allPosts);
        }

        [HttpGet("/posts/new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("/posts/create")]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid == false)
            {
                // Send back to the form to show error messages.
                return View("New");
            }

            db.Posts.Add(post);
            /* 
            The ORM generates the SQL query for us:
            INSERT INTO posts (Topic, Body, ImgUrl, CreatedAt, UpdatedAt)
            VALUES (post.Topic, post.Body, post.ImgUrl, post.CreatedAt, post.UpdatedAt);
            */

            db.SaveChanges();
            return RedirectToAction("All");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
