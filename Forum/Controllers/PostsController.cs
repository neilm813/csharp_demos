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

        private bool loggedIn
        {
            get
            {
                return uid != null;
            }
        }

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
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
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

            newPost.UserId = (int)uid;
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
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Post> allPosts = db.Posts
                /* 
                The data given to .Include is ALWAYS the data type from the
                table being queried (we are querying the Post table here).
                */
                .Include(p => p.Author) // Joins the related author to each Post.
                .ToList();

            /* The ORM created this query based on the above methods.
            SELECT * FROM posts AS p
            JOIN users AS u ON u.UserId = p.UserId
            */
            return View("All", allPosts);
        }

        /* 
        <a 
            asp-controller="Posts"       
            asp-action="Details" asp-route-postId="@post.PostId">@post.Topic
        >
        </a>
        */
        [HttpGet("/posts/{postId}")]
        public IActionResult Details(int postId)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            // class properties are PascalCase, params are camelCase, hence
            //  class Property == param value
            //          PostId == postId
            Post post = db.Posts
                .Include(p => p.Author)
                .FirstOrDefault(p => p.PostId == postId);

            // In case the url was navigated to manually with a bad id.
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

            if (post != null)
            {
                db.Posts.Remove(post);
                db.SaveChanges();
            }

            return RedirectToAction("All");
        }

        [HttpGet("/posts/{postId}/edit")]
        public IActionResult Edit(int postId)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            Post post = db.Posts.FirstOrDefault(p => p.PostId == postId);

            // If uid doesn't match, user in session is NOT the author.
            if (post == null || post.UserId != uid)
            {
                return RedirectToAction("All");
            }

            return View("Edit", post);
        }

        [HttpPost("/posts/{postId}/update")]
        public IActionResult Update(Post editedPost, int postId)
        {
            if (ModelState.IsValid == false)
            {
                /* 
                Because the id is not in any input box on the form, it is not
                in editedPost because it is instantiated from form data.
                However, the "Edit" cshtml page NEEDS the id, so we have to add
                it here.

                If you use this naming convention where the param name matches
                primary key name it actually happens automatically. The code is
                left for clarity.
                */
                editedPost.PostId = postId;
                // Send back to the form to display error messages.
                return View("Edit", editedPost);
            }

            Post dbPost = db.Posts.FirstOrDefault(p => p.PostId == postId);

            if (dbPost == null)
            {
                return RedirectToAction("All");
            }

            dbPost.Topic = editedPost.Topic;
            dbPost.Body = editedPost.Body;
            dbPost.ImgUrl = editedPost.ImgUrl;
            dbPost.UpdatedAt = DateTime.Now;

            db.Posts.Update(dbPost);
            db.SaveChanges();

            // new dict to pass param values (args) to Details method.
            //                                 new { paramName1 = value1, paramName2 = value2 }
            return RedirectToAction("Details", new { postId = postId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
