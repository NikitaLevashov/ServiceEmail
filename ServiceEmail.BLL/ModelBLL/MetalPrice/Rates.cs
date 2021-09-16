using Newtonsoft.Json;

namespace ServiceEmail.BLL.ModelBLL.MetalPrice
{
    public class Rates
    {
        [JsonProperty("EUR")]
        public double EUR { get; set; }

        [JsonProperty("GBR")]
        public double GBR { get; set; }

        [JsonProperty("PA")]
        public double PA { get; set; }

        [JsonProperty("PL")]
        public double PL { get; set; }

        [JsonProperty("XAG")]
        public double XAG { get; set; }

        [JsonProperty("XAU")]
        public double XAU { get; set; }
    }
}
