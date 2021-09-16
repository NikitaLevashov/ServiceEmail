using Newtonsoft.Json;

namespace ServiceEmail.BLL.ModelBLL.CoronavirusInfo
{
    public class Coronavirus
    {
        [JsonProperty("stats")]
        public Statistic Statistic { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
