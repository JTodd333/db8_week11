//http://xkcd.com/info.0.json

Console.WriteLine("Which comic number would you like to see?");
string entry = Console.ReadLine();


//==============================
//These 4 lines connect to an API server and get back an instance of a class
//HttpClient web = new HttpClient();
//web.BaseAddress = new Uri("http://xkcd.com/");
//var connection = await web.GetAsync($"{entry}/info.0.json");
//Comic com = await connection.Content.ReadAsAsync<Comic>();
//===============================
//
//Console.WriteLine(com.alt);
//Console.WriteLine(com.img);
//



HttpClient web = new HttpClient();
web.BaseAddress = new Uri("http://xkcd.com/");
var connection = await web.GetAsync($"{entry}/info.0.json");

try
{
    Comic com = await connection.Content.ReadAsAsync<Comic>();
    Console.WriteLine(com.alt);
    Console.WriteLine(com.img);
}
catch (Exception e)
{
    Console.WriteLine("Sorry, I could not find that comic.");
}


//This code was used before creating a class//
//var connection = await web.GetAsync("info.0.json");
//var connection = await web.GetAsync("614/info.0.json");
//string result = await connection.Content.ReadAsStringAsync();
//Console.WriteLine(result);


   
class Comic
{
    public int month { get; set; }
    public int num { get; set; }
    public string link { get; set; }
    public int year { get; set; }
    public string news { get; set; }
    public string safe_title { get; set; }
    public string transcript { get; set; }
    public string alt { get; set; }
    public string img { get; set; }
    public string title { get; set; }
    public int day { get; set; }
}


//Can copy and do special paste to make class. Jeff does not suggest.
//public class Rootobject
//{
//    public string month { get; set; }
//    public int num { get; set; }
//    public string link { get; set; }
//    public string year { get; set; }
//    public string news { get; set; }
//    public string safe_title { get; set; }
//    public string transcript { get; set; }
//    public string alt { get; set; }
//    public string img { get; set; }
//    public string title { get; set; }
//    public string day { get; set; }
//}
