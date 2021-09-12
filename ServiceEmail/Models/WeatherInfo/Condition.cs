using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceEmail.UI.Models.WeatherInfo
{
    public class Condition
    {
        [JsonProperty("text")]
        public string ConditionWeather { get; set; }
        //public string icon { get; }
    }
}
