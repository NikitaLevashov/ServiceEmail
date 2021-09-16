using Newtonsoft.Json;

namespace ServiceEmail.BLL.ModelBLL.WeatherInfo
{
    public class Current
    {
        [JsonProperty("condition")]
        public Condition Condition { get; set; }

        [JsonProperty("temp_c")]
        public double TemperatureByCelius { get; set; }

        [JsonProperty("temp_f")]
        public double FahrenheitTemperature { get; set; }

        [JsonProperty("last_updated")]
        public string LastUpdated { get; set; }

        [JsonProperty("wind_mph")]
        public double WindMph { get; set; }

        [JsonProperty("wind_kph")]
        public double WindKph { get; set; }

        /// <summary>
        /// /давление милибар
        /// </summary>
        [JsonProperty("pressure_mb")]
        public double PressureMb { get; set; }

        //осадки
        [JsonProperty("precip_mm")]
        public double PrecipMm { get; set; }

        //влажность %
        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("cloud")]
        public double Cloud { get; set; }

        //порыв ветра
        [JsonProperty("gust_mph")]
        public double GustMph { get; set; }

        [JsonProperty("gust_kph")]
        public double Gust_kph { get; set; }
    }
}
