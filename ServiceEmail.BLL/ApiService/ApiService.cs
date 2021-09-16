using Newtonsoft.Json;
using RestSharp;
using ServiceEmail.BLL.ModelBLL.CoronavirusInfo;
using ServiceEmail.BLL.ModelBLL.MetalPrice;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using ServiceEmail.BLL.ModelBLL.WeatherInfo;
using ServiceEmail.BLL.TextService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.ApiService
{
    public class ApiService
    {
        public static string GetJsonInfo(TaskInfoBLL task)
        {
            if(task.FreeApi == AppSettings.Weather)
            {
                var client = new RestClient($"https://weatherapi-com.p.rapidapi.com/forecast.json?q={task.AppSettings}&days=3");
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-host", "weatherapi-com.p.rapidapi.com");
                request.AddHeader("x-rapidapi-key", "1169d35dd1mshd13d0e1dc0bee19p111a91jsn22b9882a51d2");
                IRestResponse response = client.Execute(request);

                var json = response.Content;
                WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(json);

                return GetStringInfo(weatherInfo);
            }
            else if(task.FreeApi == AppSettings.Coronavirus)
            {
                var client = new RestClient($"https://coronavirus-smartable.p.rapidapi.com/stats/v1/{task.AppSettings}/");
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-host", "coronavirus-smartable.p.rapidapi.com");
                request.AddHeader("x-rapidapi-key", "1169d35dd1mshd13d0e1dc0bee19p111a91jsn22b9882a51d2");
                IRestResponse response = client.Execute(request);

                var json = response.Content;
                Coronavirus coronaInfo = JsonConvert.DeserializeObject<Coronavirus>(json);

                return GetStringInfo(coronaInfo);
            }
            else if (task.FreeApi == AppSettings.MetalPrice)
            {
                var client = new RestClient("https://live-metal-prices.p.rapidapi.com/v1/latest/XAU,XAG,PA,PL,GBP,EUR/{task.AppSettings}");
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-host", "live-metal-prices.p.rapidapi.com");
                request.AddHeader("x-rapidapi-key", "1169d35dd1mshd13d0e1dc0bee19p111a91jsn22b9882a51d2");
                IRestResponse response = client.Execute(request);

                var json = response.Content;
                MetalPrice metal = JsonConvert.DeserializeObject<MetalPrice>(json);

                return GetStringInfo(metal);
            }

            return "";
        }
        private static string GetStringInfo(WeatherInfo weather)
        {
            return $"Location name {weather?.Location.Name}, Region - {weather?.Location.Region}, Cloud - {weather?.current.Cloud}, Condition {weather?.current.Condition}," +
                $" Temperature - {weather?.current.FahrenheitTemperature}F, Temperature - " +
                $"{weather?.current.TemperatureByCelius}C, Pressure - {weather?.current.PressureMb}, Wind (kph){weather?.current.WindKph}";
        }

        private static string GetStringInfo(Coronavirus coronavirus)
        {
            return $"Location name {coronavirus?.Location.CountryOrRegion}, IsoCode - {coronavirus?.Location?.IsoCode}, New Deaths - {coronavirus?.Statistic.NewDeath}," +
                $" NewlyConfirmedCases {coronavirus?.Statistic.NewlyConfirmedCases}, TotalConfirmedCases - {coronavirus?.Statistic.TotalConfirmedCases}, TotalDeaths -" +
                $" {coronavirus?.Statistic.TotalDeaths}, TotalRecoveredCases - {coronavirus?.Statistic.TotalRecoveredCases}";
        }

        private static string GetStringInfo(MetalPrice metal)
        {
            return $"Base currency {metal?.BaseCurrency}, EUR - {metal?.Rates.EUR}, GBR - {metal?.Rates.GBR}," +
                $" PA - {metal?.Rates.PA}, PL - {metal?.Rates.PL},  XAG -" +
                $" {metal?.Rates.XAG}, XAU - {metal?.Rates.XAU}";
        }
    }
}
