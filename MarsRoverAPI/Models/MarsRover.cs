namespace MarsRoverAPI.Models
{
    public class MarsRover
    {
        
        public string EarthDate { get; set; }
        public string RoverName { get; set; }
        public List<Photo> photos { get; set; }

    }

    public class Photo
    {
        public string Image { get; set; }
        public string CameraName { get; set; }
    }

}
