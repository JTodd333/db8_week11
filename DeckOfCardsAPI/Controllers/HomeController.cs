using DeckOfCardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        async public Task<IActionResult> Index()
        {
            //HttpClient web = new HttpClient();
            //web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/");
            //var connection = await web.GetAsync("deck/new/shuffle/?deck_count=1");
            //CardResponse deck = await connection.Content.ReadAsAsync<CardResponse>();

            string deck_id = await CardAPI.GetNewDeck();
            CardResponse resp = await CardAPI.GetCards(deck_id, 5);

            return View(resp);
        }

        async public Task<IActionResult> DrawFive(string deck_id)
        {
            CardResponse resp = await CardAPI.GetCards(deck_id, 5);
            return View("index", resp);
        }

        //async public Task<IActionResult> Draw(string deckid)
        //{
        //    HttpClient web = new HttpClient();
        //    web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/");
        //    var connection = await web.GetAsync($"deck/{deckid}/draw/?count=5");
        //    CardResponse deckdraw = await connection.Content.ReadAsAsync<CardResponse>();



        //    return View(drawdeck.cards);
        //}

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