using Newtonsoft.Json;

namespace ServiceEmail.BLL.ModelBLL.WeatherInfo
{
    public class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("localtime")]
        public string Localtime { get; set; }
    }
}
