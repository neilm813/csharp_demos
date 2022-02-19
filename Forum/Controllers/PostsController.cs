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

        /**************************************************************
        All page that displays all posts AND has a <form> to create a new post.
        Display data from ViewBag
        Use @model for the <form>.
        */
        [HttpGet("/posts")]
        public IActionResult All()
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Posts = db.Posts
                /* 
                The data given to .Include is ALWAYS the data type from the
                table being queried (we are querying the Post table here).
                */
                .Include(p => p.Author) // Joins the related author to each Post.
                .Include(p => p.Likes)
                .ToList();

            /* The ORM created this query based on the above methods.
            SELECT * FROM posts AS p
            JOIN users AS u ON u.UserId = p.UserId
            */

            return View("All");
        }

        /**************************************************************
        All page that only displays all posts
        */
        // [HttpGet("/posts")]
        // public IActionResult All()
        // {
        //     if (!loggedIn)
        //     {
        //         return RedirectToAction("Index", "Home");
        //     }

        //     List<Post> allPosts = db.Posts
        //         /* 
        //         The data given to .Include is ALWAYS the data type from the
        //         table being queried (we are querying the Post table here).
        //         */
        //         .Include(p => p.Author) // Joins the related author to each Post.
        //         .ToList();

        //     /* The ORM created this query based on the above methods.
        //     SELECT * FROM posts AS p
        //     JOIN users AS u ON u.UserId = p.UserId
        //     */
        //     return View("All", allPosts);
        // }

        /**************************************************************
        All page that displays all posts AND has a <form> to create a new post.
        Display data with ViewModel
        Use <partial> view for the <form> so it ALSO can use View Model..
        */
        // [HttpGet("/posts")]
        // public IActionResult All()
        // {
        //     if (!loggedIn)
        //     {
        //         return RedirectToAction("Index", "Home");
        //     }

        //     List<Post> posts = db.Posts
        //         /* 
        //         The data given to .Include is ALWAYS the data type from the
        //         table being queried (we are querying the Post table here).
        //         */
        //         .Include(p => p.Author) // Joins the related author to each Post.
        //         .ToList();

        //     /* The ORM created this query based on the above methods.
        //     SELECT * FROM posts AS p
        //     JOIN users AS u ON u.UserId = p.UserId
        //     */

        //     return View("All", posts);
        // }

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
                // HOVER over the lambda param to see it's data type
                // .Include lambda param is ALWAYS data from the table queried.
                .Include(p => p.Author)
                .Include(p => p.Likes)
                // .ThenInclude lambda param is ALWAYS the data that was just included above.
                .ThenInclude(like => like.User)
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

        /* 
        Because we only needed an id, the <form> didn't need it's own model,
        we have all the info we need from the URL parameters.
        */
        [HttpPost("/posts/{postId}/like")]
        public IActionResult Like(int postId)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            UserPostLike existingLike = db.UserPostLikes
                .FirstOrDefault(like => like.PostId == postId && (int)uid == like.UserId);

            if (existingLike == null)
            {
                UserPostLike like = new UserPostLike()
                {
                    PostId = postId,
                    UserId = (int)uid
                };

                db.UserPostLikes.Add(like);
            }
            else
            {
                db.UserPostLikes.Remove(existingLike);
            }


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
