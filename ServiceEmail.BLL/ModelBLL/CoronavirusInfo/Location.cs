using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.ModelBLL.CoronavirusInfo
{
    public class Location
    {
        [JsonProperty("countryOrRegion")]
        public string CountryOrRegion { get; set; }

        [JsonProperty("isoCode")]
        public string IsoCode { get; set; }
    }
}
