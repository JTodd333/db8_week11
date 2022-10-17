namespace StarWarsAPILab.Models
{
    public class Movie
    {
        public string title { get; set; }
        public int year { get; set; }
        public List<Character> characters { get; set; } 
        public List<Starship> starships { get; set; }

        public Movie()
        {
            characters = new List<Character>();
            starships = new List<Starship>();
        }

    }

    public class Character
    {
        public string name { get; set; }
        public string birth_year  { get; set; }
        public string gender { get; set; }
        public string height { get; set; }

    }

    public class Starship
    {
        public string name { get; set; }
        public string manufacturer { get; set; }
        public string length { get; set; }
        public string passengers { get; set; }
    }

}
