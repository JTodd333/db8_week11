using CardDeckJeff.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CardDeckJeff.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //static public string DeckId = "";
        // This worked at first, but only had 1 deck shared across all users.
        // Let's give each user their own deck
        //Instead of 

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Version 1
        //async public Task<IActionResult> Index()
        //{
        //    HttpClient web = new HttpClient();
        //    web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");

        //    //First use of our HttpClient instance
        //    var connection = await web.GetAsync("new/shuffle/?deck_count=1");
        //    CardResponse resp = await connection.Content.ReadAsAsync<CardResponse>();

        //    //DeckId = resp.deck_id;   //We're not doing this after all

        //    //Second use of our HttpClient instance
        //    connection = await web.GetAsync($"{resp.deck_id}/draw/?count=5");
        //    resp = await connection.Content.ReadAsAsync<CardResponse>();

        //    return View(resp);
        //}

        async public Task<IActionResult> Index()
        {
            //when calling something async, need to use await to call
            string deck_id = await CardAPI.GetNewDeck();
            CardResponse resp = await CardAPI.GetCards(deck_id, 5);

            return View(resp);
        }


        // Version 1
        //async public Task<IActionResult> DrawFive(string deck_id)
        //{
        //    HttpClient web = new HttpClient();
        //    web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
        //    var connection = await web.GetAsync($"{deck_id}/draw/?count=5");

        //    //These 3 lines added after, just for debugging purposes
        //    if (connection.StatusCode.ToString() == "NotFound")
        //    {
        //        return Content(connection.RequestMessage.RequestUri.OriginalString);
        //    }

        //    CardResponse resp = await connection.Content.ReadAsAsync<CardResponse>();
        //    return View("index", resp);
        //}

        async public Task<IActionResult> DrawFive(string deck_id)
        {
            CardResponse resp = await CardAPI.GetCards(deck_id, 5);
            return View("index", resp);
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