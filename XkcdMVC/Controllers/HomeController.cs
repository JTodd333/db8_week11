using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XkcdMVC.Models;

namespace XkcdMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Add asyn before public and add Task, put IActionResult in <>
        //the other 4 lines are copied from other program
        async public Task<IActionResult> Index(string comicnum)
        {
            //Version 1
            //HttpClient web = new HttpClient();
            //web.BaseAddress = new Uri("http://xkcd.com/");
            //var connection = await web.GetAsync($"{comicnum}/info.0.json");
            ////                  https://xkcd.com//info.0.json
            //Comic com = await connection.Content.ReadAsAsync<Comic>();
            //return View(com);

            //Version 2
            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("http://xkcd.com/");
            var connection = await web.GetAsync($"{comicnum}/info.0.json");
            //                  https://xkcd.com//info.0.json
            try
            {
                Comic com = await connection.Content.ReadAsAsync<Comic>();
                return View(com);
            }
            catch (Exception e)
            {
                //return Content("Sorry that comic wasn't found.");

                return View();
            }
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





