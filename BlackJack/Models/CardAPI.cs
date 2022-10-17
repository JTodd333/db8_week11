namespace BlackJack.Models
{
    public class CardAPI
    {
		public class CardResponse
		{
			public bool success { get; set; }
			public string deck_id { get; set; }
			
			public List<APICard> cards { get; set; }
			public int remaining { get; set; }
		}

		public class APICard
		{
			public string code { get; set; }
			public string image { get; set; }
			public string value { get; set; }
			public string suit { get; set; }
		}

		public class CreatingCardAPI
        {
			public static HttpClient _web = null;

			public static HttpClient GetHttpClient()
			{
				if (_web == null)
				{
					_web = new HttpClient();
					_web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
				}
				return _web;
			}

			async public static Task<string> GetNewDeck()
			{
				HttpClient web = GetHttpClient();
				var connection = await web.GetAsync("new/shuffle/?deck_count=1");
				CardResponse resp = await connection.Content.ReadAsAsync<CardResponse>();
				return resp.deck_id;
			}

		}

	}
}
