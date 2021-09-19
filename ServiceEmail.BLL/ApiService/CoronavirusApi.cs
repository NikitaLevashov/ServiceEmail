using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using ServiceEmail.BLL.Interfaces;
using ServiceEmail.BLL.ModelBLL.CoronavirusInfo;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.ApiService
{
    public class CoronavirusApi : IApiInfo
    {
        public IConfiguration ApiConfiguration { get; set; }
        public string GetApiInfo(TaskInfoBLL task)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("apiconfig.json");

            ApiConfiguration = builder.Build();

            var host = ApiConfiguration["Host"];
            var key = ApiConfiguration["Key"];
            var coronaHost = ApiConfiguration["CoronaValueHost"];
            var coronaValue = ApiConfiguration["ValueKey"];

            var client = new RestClient($"https://coronavirus-smartable.p.rapidapi.com/stats/v1/{task.AppSettings}/");
            var request = new RestRequest(Method.GET);
            request.AddHeader(host, coronaHost);
            request.AddHeader(key, coronaValue);
            IRestResponse response = client.Execute(request);

            var json = response.Content;
            Coronavirus coronaInfo = JsonConvert.DeserializeObject<Coronavirus>(json);

            return GetStringInfo(coronaInfo);
        }

        private static string GetStringInfo(Coronavirus coronavirus)
        {
            return $"Location name {coronavirus?.Location.CountryOrRegion}, IsoCode - {coronavirus?.Location?.IsoCode}, New Deaths - {coronavirus?.Statistic.NewDeath}," +
                $" NewlyConfirmedCases {coronavirus?.Statistic.NewlyConfirmedCases}, TotalConfirmedCases - {coronavirus?.Statistic.TotalConfirmedCases}, TotalDeaths -" +
                $" {coronavirus?.Statistic.TotalDeaths}, TotalRecoveredCases - {coronavirus?.Statistic.TotalRecoveredCases}";
        }
    }
}
