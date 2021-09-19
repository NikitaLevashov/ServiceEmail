using Newtonsoft.Json;
using RestSharp;
using ServiceEmail.BLL.Interfaces;
using ServiceEmail.BLL.ModelBLL.CoronavirusInfo;
using ServiceEmail.BLL.ModelBLL.MetalPrice;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using ServiceEmail.BLL.ModelBLL.WeatherInfo;
using ServiceEmail.BLL.TextService;


namespace ServiceEmail.BLL.ApiService
{
    public class ApiService
    {
        public static string GetInfo(TaskInfoBLL task)
        {
            if(task.FreeApi == AppSettings.Weather)
            {
                IApiInfo info = new WeatherApi();
                return info.GetApiInfo(task);
            }
            else if(task.FreeApi == AppSettings.Coronavirus)
            {
                IApiInfo info = new CoronavirusApi();
                return info.GetApiInfo(task);
            }
            else if (task.FreeApi == AppSettings.MetalPrice)
            {
                IApiInfo info = new MetalPriceApi();
                return info.GetApiInfo(task);
            }

            return string.Empty;
        }
    }
}
