namespace MarsRoverAPI.Models
{
    public class RoverResponse
    {
        public List<PhotoResponse> photos { get; set; }

    }

    public class Camera
    {
        public string full_name { get; set; }

    }

    public class PhotoResponse
    {
        public string img_src { get; set; }
        public string earth_date { get; set; }
        public Camera camera { get; set; }
        public Rover rover { get; set; }

    }

    public class Rover
    {
        public string name { get; set; }
    }
    


    public class NASAAPI
    {
        public static HttpClient _web = null;

        public static HttpClient GetHttpClient()
        {

            if (_web == null)
            {
                _web = new HttpClient();
                _web.BaseAddress = new Uri("https://api.nasa.gov/mars-photos/api/v1/rovers/");
            }
            return _web;
        }

        //async public static Task<MarsRover> GetRoverPics(string date, string rover)
        //{
        //    HttpClient web = GetHttpClient();
        //    var connection = await web.GetAsync($"{rover}/photos?earth_date={date}&api_key=ZJAfPMAS1NbFdCIJcWJtfZbDY9o1QNP2FwJoK914");
        //    RoverResponse resp = await connection.Content.ReadAsAsync<RoverResponse>();

        //    MarsRover RoverPics = new MarsRover();
        //    RoverPics.EarthDate = resp.earth_date;
            

        //    return RoverPics;
        //}




    }

   





}
