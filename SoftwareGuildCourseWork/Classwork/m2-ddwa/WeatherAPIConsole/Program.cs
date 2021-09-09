using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPIConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a zip code: ");
            string zipcode = Console.ReadLine();
            
            DoWeatherSearch(zipcode);
        }

        private static void DoWeatherSearch(string zipcode)
        {
            string myAPIKey = "a7d01ddf11554225213ca60fedd44e98";
            WeatherAPIResult model = null;

            HttpClient client = new HttpClient();
            
            string uri = $"http://api.openweathermap.org/data/2.5/weather?" +
                $"zip={zipcode},us&units=imperial&appid={myAPIKey}";

            var task = client.GetAsync(uri)
                .ContinueWith((taskForResponse) =>
                {
                    HttpResponseMessage response = taskForResponse.Result;
                    var processJson = response.Content.ReadAsAsync<WeatherAPIResult>();
                    processJson.Wait();
                    model = processJson.Result;
                });

            task.Wait();
            DisplaySearchResults(model);
        }

        private static void DisplaySearchResults(WeatherAPIResult model)
        {
            Console.WriteLine($"Tempurature (F): {model.Main.Temperature}");
            Console.WriteLine($"Humidity: {model.Main.Humidity}%");
            Console.WriteLine($"Pressure: {model.Main.Pressure}");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    public class WeatherAPIResult
    {
        [JsonProperty("main")]
        public MainData Main { get; set; }
    }


    public class MainData
    {
        [JsonProperty("temp")]
        public decimal Temperature { get; set; }
        [JsonProperty("humidity")]
        public decimal Humidity { get; set; }
        [JsonProperty("pressure")]
        public decimal Pressure { get; set; }
    }
}
