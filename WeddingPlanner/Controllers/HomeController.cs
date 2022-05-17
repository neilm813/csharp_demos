using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private WeddingPlannerContext db;

    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UserId");
        }
    }

    public HomeController(WeddingPlannerContext ctx, ILogger<HomeController> logger)
    {
        db = ctx;
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        if (uid != null)
        {
            return RedirectToAction("All", "Weddings");
        }
        return View("Index");
    }

    [HttpPost("/register")]
    public IActionResult Register(User registeringUser)
    {
        if (ModelState.IsValid)
        {
            bool isEmailTaken = db.Users.Any(u => u.Email == registeringUser.Email);

            if (isEmailTaken)
            {
                ModelState.AddModelError("Email", "is taken.");
            }
        }

        // Display any errors that were manually added above.
        if (ModelState.IsValid == false)
        {
            return View("Index");
        }

        PasswordHasher<User> hasher = new PasswordHasher<User>();
        registeringUser.Password = hasher.HashPassword(registeringUser, registeringUser.Password);

        db.Users.Add(registeringUser);
        db.SaveChanges();

        // After save changes, newUser has been updated with the Primary Key
        HttpContext.Session.SetInt32("UserId", registeringUser.UserId);
        HttpContext.Session.SetString("FullName", registeringUser.FullName());
        return RedirectToAction("All", "Weddings");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid == false)
        {
            // Display Errors
            return View("Index");
        }

        User? dbUser = db.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);

        if (dbUser == null)
        {
            ModelState.AddModelError("LoginEmail", "not found.");
            // Show errors on form.
            return View("Index");
        }

        PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCompareResult = hasher.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

        if (pwCompareResult == 0)
        {
            ModelState.AddModelError("LoginPassword", "invalid.");
            return View("Index");
        }

        HttpContext.Session.SetInt32("UserId", dbUser.UserId);
        HttpContext.Session.SetString("FullName", dbUser.FullName());
        return RedirectToAction("All", "Weddings");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
