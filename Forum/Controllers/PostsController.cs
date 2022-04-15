using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Forum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Forum.Controllers
{
    public class PostsController : Controller
    {
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

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
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            /* 
            The .Include generates a SQL join for us:
            SELECT * FROM users AS u
            JOIN posts AS p ON u.UserId = p.UserId
            */

            List<Post> allPosts = db.Posts
                .Include(p => p.Author)
                .ToList();
            return View("All", allPosts);
        }

        [HttpGet("/posts/new")]
        public IActionResult New()
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("New");
        }

        [HttpPost("/posts/create")]
        public IActionResult Create(Post post)
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

            post.UserId = (int)uid;
            db.Posts.Add(post);
            /* 
            The ORM generates the SQL query for us:
            INSERT INTO posts (Topic, Body, ImgUrl, CreatedAt, UpdatedAt)
            VALUES (post.Topic, post.Body, post.ImgUrl, post.CreatedAt, post.UpdatedAt);
            */

            db.SaveChanges();
            // After SaveChanges, it has been created in the DB and the primary key now exists.
            return RedirectToAction("Details", new { postId = post.PostId });
        }

        [HttpGet("/posts/{postId}")]
        public IActionResult Details(int postId)
        {
            if (uid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Post post = db.Posts
                .Include(p => p.Author)
                .FirstOrDefault(p => p.PostId == postId);

            if (post == null)
            {
                return RedirectToAction("All");
            }

            return View("Details", post);
        }

        [HttpPost("/posts/{postId}/delete")]
        public IActionResult Delete(int postId)
        {
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            // If post not found or user is not the author.
            if (post == null || uid == null || post.UserId != uid)
            {
                return RedirectToAction("Index", "Home");
            }


            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet("/posts/{postId}/edit")]
        public IActionResult Edit(int postId)
        {
            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            // If post not found or user is not the author.
            if (post == null || uid == null || post.UserId != uid)
            {
                return RedirectToAction("All");
            }

            return View("Edit", post);
        }

        [HttpPost("/posts/{postId}/update")]
        public IActionResult Update(int postId, Post editedPost)
        {
            Post dbPost = db.Posts.FirstOrDefault(p => p.PostId == postId);

            // If post not found or user is not the author.
            if (dbPost == null || uid == null || dbPost.UserId != uid)
            {
                return RedirectToAction("All");
            }

            if (ModelState.IsValid == false)
            {
                /*
                This happens automatically because we named the param the same as
                the property. The submitted form instantiates a new Post using the
                form data, but the form data does not include the PostId, the PostId
                is in the URL. Add it into the editedPost before returning the "Edit"
                page because the "Edit" page needs the PostId for the form URL.
                */
                editedPost.PostId = postId;
                // Send back to the page with the form so error messages are displayed

                return View("Edit", editedPost);
            }

            dbPost.Topic = editedPost.Topic;
            dbPost.Body = editedPost.Body;
            dbPost.ImgUrl = editedPost.ImgUrl;
            dbPost.UpdatedAt = DateTime.Now;

            db.Posts.Update(dbPost);
            db.SaveChanges();

            return RedirectToAction("Details", new { postId = postId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
