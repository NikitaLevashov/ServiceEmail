using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using ServiceEmail.BLL.Interfaces;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using ServiceEmail.BLL.ModelBLL.WeatherInfo;


namespace ServiceEmail.BLL.ApiService
{
    public class WeatherApi : IApiInfo
    {
        public IConfiguration ApiConfiguration { get; set; }
        public string GetApiInfo(TaskInfoBLL task)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("apiconfig.json");
            ApiConfiguration = builder.Build();

            var host = ApiConfiguration["Host"];
            var key = ApiConfiguration["Key"];
            var weatherHost = ApiConfiguration["WeatherValueHost"];
            var weatherValue = ApiConfiguration["ValueKey"];

            var client = new RestClient($"https://weatherapi-com.p.rapidapi.com/forecast.json?q={task.AppSettings}&days=3");
            var request = new RestRequest(Method.GET);
            request.AddHeader(host, weatherHost);
            request.AddHeader(key, weatherValue);
            IRestResponse response = client.Execute(request);

            var json = response.Content;
            WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(json);

            return GetStringInfo(weatherInfo);
        }

        private static string GetStringInfo(WeatherInfo weather)
        {
            return $"Location name {weather?.Location.Name}, Region - {weather?.Location.Region}, Cloud - {weather?.current.Cloud}, Condition {weather?.current.Condition}," +
                $" Temperature - {weather?.current.FahrenheitTemperature}F, Temperature - " +
                $"{weather?.current.TemperatureByCelius}C, Pressure - {weather?.current.PressureMb}, Wind (kph){weather?.current.WindKph}";
        }
    }
}
