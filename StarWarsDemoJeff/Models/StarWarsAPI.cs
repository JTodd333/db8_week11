﻿namespace StarWarsDemoJeff.Models
{

    class FilmResponse
    {
        public string title { get; set; }
        public string release_date { get; set; }
        public List<string> characters { get; set; }
       public List<string> starships { get; set; }

    }

    class PersonResponse
    {
        public string name { get; set; }

    }

    class StarshipResponse
    {
        public string name { get; set; }
    }


    public class StarWarsAPI
    {
        public static HttpClient _web = null;

        public static HttpClient GetHttpClient()
        {

            if (_web == null)
            {
                _web = new HttpClient();
                _web.BaseAddress = new Uri("https://swapi.dev/api/");
            }
            return _web;
        }


        public static async Task<Movie> FindMovie(int filmnum)
        {
            HttpClient web = GetHttpClient();
            var connection = await web.GetAsync($"films/{filmnum}");
            FilmResponse resp = await connection.Content.ReadAsAsync<FilmResponse>();

            Movie mymovie = new Movie();
            mymovie.names = new List<string>();
            mymovie.starships = new List<string>();
            mymovie.title = resp.title;
            mymovie.year = int.Parse(resp.release_date.Substring(0, 4));

            int count = 0;
            foreach (string url in resp.characters)
            {
                // url has the full URL as in "https://swapi.dev/api/people/1/",
                // but we really want just the last part of it "people/1/"
                //string realurl = url.Remove
                connection = await web.GetAsync(url);
                PersonResponse presp = await connection.Content.ReadAsAsync<PersonResponse>();
                mymovie.names.Add(presp.name);
                count++;
                if (count == 2)
                {
                    break;
                }

            }
            count = 0;
            foreach (string url in resp.starships)
            {
                connection = await web.GetAsync(url);
                StarshipResponse presp = await connection.Content.ReadAsAsync<StarshipResponse>();
                mymovie.starships.Add(presp.name);
                count++;
                if(count == 2)
                {
                    break;
                }

            }
            return mymovie;
        }
       
    }
}
