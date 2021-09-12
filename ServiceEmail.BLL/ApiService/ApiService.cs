using Newtonsoft.Json;
using RestSharp;
using ServiceEmail.BLL.ModelBLL.WeatherInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.ApiService
{
    public class ApiService
    {
        public static string GetJsonInfo(string apiValue, string apiAppsetting) // Task Info
        {
            if(apiValue == "Wheather")
            {
                var client = new RestClient($"https://weatherapi-com.p.rapidapi.com/forecast.json?q={apiAppsetting}&days=3");
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-host", "weatherapi-com.p.rapidapi.com");
                request.AddHeader("x-rapidapi-key", "1169d35dd1mshd13d0e1dc0bee19p111a91jsn22b9882a51d2");
                IRestResponse response = client.Execute(request);

                var json = response.Content;
                WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(json);

                return GetStringInfo(weatherInfo);
                //var jsonWeth = JsonConvert.SerializeObject(weatherInfo);

                //return response.Content;
            }
            else if(apiValue == "Sport")
            {

            }
            else if (apiValue == "Sport")
            {

            }

            return "Not found";
        }

        private static string GetStringInfo(WeatherInfo weather)
        {
            return $"Cloud - {weather.current.Cloud}, Condition {weather.current.Condition}," +
                $" Temperature - {weather.current.FahrenheitTemperature}F, Temperature - " +
                $"{weather.current.TemperatureByCelius}, Pressure - {weather.current.PressureMb},";
        }
    }
}
