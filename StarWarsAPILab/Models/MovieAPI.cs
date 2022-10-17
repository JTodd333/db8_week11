namespace StarWarsAPILab.Models
{
    public class MovieAPI
    {
        public string title { get; set; }
        public int episode_id { get; set; }
        public string release_date { get; set; }
        public List<string> characters { get; set; }

        public List <string> starships { get; set; }
    }

    public class APICharacter
    {
        public string name { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string height { get; set; }
    }

    public class APIStarship
    {
        public string name { get; set; }
        public string manufacturer { get; set; }
        public string length { get; set; }
        public string passengers { get; set; }
    }



	public class DALMovieAPI
    {
        //Movie API Functionality
        //GetMovie()   
        //GetCharacters (int episode_id) - return list of characters
        //GetStarships (int episode_id) - return list of starships


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

        async public static Task<Movie> GetMovie(int movieNum)
        {
            HttpClient web = GetHttpClient();
            var connection = await web.GetAsync($"films/{movieNum}/");
            MovieAPI resp = await connection.Content.ReadAsAsync<MovieAPI>();

            Movie movie = new Movie();
            //movie.characters = new List<string>();
            //movie.starships = new List<string>();
            movie.title = resp.title;
            movie.year = int.Parse(resp.release_date.Substring(0,4));
            //movie.year = resp.release_date.Year;   (went back to string instead of Date/Time)
            
            foreach (string charlink in resp.characters)
            {
                connection = await web.GetAsync(charlink);
                APICharacter charresp = await connection.Content.ReadAsAsync<APICharacter>();
                Character ch = new Character();
                ch.name = charresp.name;
                ch.birth_year = charresp.birth_year;
                ch.gender = charresp.gender;
                ch.height = charresp.height;
                movie.characters.Add(ch);
                
            }

            foreach (string shiplink in resp.starships)
            {
                connection = await web.GetAsync(shiplink);
                APIStarship shipresp = await connection.Content.ReadAsAsync<APIStarship>();
                Starship ship = new Starship();
                ship.name = shipresp.name;
                ship.manufacturer = shipresp.manufacturer;
                ship.length = shipresp.length;
                ship.passengers = shipresp.passengers;
                movie.starships.Add(ship);

            }
            return movie;

        }

        //async public static Task<APICharacter> GetCharacter(string charlink)
        //{
        //    HttpClient web = GetHttpClient();
        //    var connection = await web.GetAsync(charlink);
        //    APICharacter resp = await connection.Content.ReadAsAsync<APICharacter>();
        //    Character character = new Character();
        //    character.name = resp.name;
        //    character.birth_year = resp.birth_year;
        //    character.gender = resp.gender;
        //    character.height = resp.height;
        //    return resp;
        //}

        //async public static Task<APIStarship> GetStarship(string shiplink)
        //{
        //    HttpClient web = GetHttpClient();
        //    var connection = await web.GetAsync(shiplink);
        //    APIStarship resp = await connection.Content.ReadAsAsync<APIStarship>();
        //    Starship ship = new Starship();
        //    ship.name = resp.name;
        //    ship.manufacturer = resp.manufacturer;
        //    ship.length = resp.length;
        //    ship.passengers = resp.passengers;
        //    return resp;
        //}


    }


}



