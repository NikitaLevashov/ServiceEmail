using Newtonsoft.Json;

namespace ServiceEmail.BLL.ModelBLL.WeatherInfo
{
    public class WeatherInfo
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("current")]
        public Current current { get; set; }
    }
}
