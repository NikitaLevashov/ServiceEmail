using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.ModelBLL.WeatherInfo
{
    public class Condition
    {
        [JsonProperty("text")]
        public string ConditionWeather { get; set; }
        //public string icon { get; }
    }
}
