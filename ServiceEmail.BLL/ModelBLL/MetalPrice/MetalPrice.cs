using Newtonsoft.Json;

namespace ServiceEmail.BLL.ModelBLL.MetalPrice
{
    public class MetalPrice
    {
        [JsonProperty("rates")]
        public Rates Rates { get; set; }

        [JsonProperty("baseCurrency")]
        public string BaseCurrency { get; set; }
    }
}
