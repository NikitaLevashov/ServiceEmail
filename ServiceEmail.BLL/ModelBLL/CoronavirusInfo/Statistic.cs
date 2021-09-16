using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.ModelBLL.CoronavirusInfo
{
    public class Statistic
    {
        [JsonProperty("totalConfirmedCases")]
        public int TotalConfirmedCases { get; set; }

        [JsonProperty("newlyConfirmedCases")]
        public int NewlyConfirmedCases { get; set; }

        [JsonProperty("totalDeaths")]
        public int TotalDeaths { get; set; }

        [JsonProperty("newDeaths")]
        public int NewDeath { get; set; }

        [JsonProperty("totalRecoveredCases")]
        public int TotalRecoveredCases { get; set; }
    }
}
