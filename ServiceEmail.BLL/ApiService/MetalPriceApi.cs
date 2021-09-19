using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using ServiceEmail.BLL.Interfaces;
using ServiceEmail.BLL.ModelBLL.MetalPrice;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.ApiService
{
    public class MetalPriceApi : IApiInfo
    {
        public IConfiguration ApiConfiguration { get; set; }
        public string GetApiInfo(TaskInfoBLL task)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("apiconfig.json");
            ApiConfiguration = builder.Build();

            var host = ApiConfiguration["Host"];
            var key = ApiConfiguration["Key"];
            var metalPriceHost = ApiConfiguration["MetalPriceValueHost"];
            var metalValueKey = ApiConfiguration["ValueKey"];

            var client = new RestClient("https://live-metal-prices.p.rapidapi.com/v1/latest/XAU,XAG,PA,PL,GBP,EUR/{task.AppSettings}");
            var request = new RestRequest(Method.GET);
            request.AddHeader(host, metalPriceHost);
            request.AddHeader(key, metalValueKey);
            IRestResponse response = client.Execute(request);

            var json = response.Content;
            MetalPrice metal = JsonConvert.DeserializeObject<MetalPrice>(json);

            return GetStringInfo(metal);
        }
        private static string GetStringInfo(MetalPrice metal)
        {
            return $"Base currency {metal?.BaseCurrency}, EUR - {metal?.Rates.EUR}, GBR - {metal?.Rates.GBR}," +
                $" PA - {metal?.Rates.PA}, PL - {metal?.Rates.PL},  XAG -" +
                $" {metal?.Rates.XAG}, XAU - {metal?.Rates.XAU}";
        }
    }
}
