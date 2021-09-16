using Newtonsoft.Json;

namespace ServiceEmail.BLL.ModelBLL.WeatherInfo
{
    public class Condition
    {
        [JsonProperty("text")]
        public string ConditionWeather { get; set; }
    }
}
