using Microsoft.AspNetCore.Mvc;

namespace FavoriteVideos.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }
    }
}