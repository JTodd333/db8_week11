using Microsoft.AspNetCore.Mvc;
using StarWarsDemoJeff.Models;
using System.Diagnostics;

namespace StarWarsDemoJeff.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        async public Task<IActionResult> FilmDetails(int id)
        {
            Movie mymovie = await StarWarsAPI.FindMovie(id);
            return View(mymovie);
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
}