using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quartz;
using RestSharp;
using ServiceEmail.BLL.SessionService;
using ServiceEmail.Models;
using ServiceEmail.UI.Controllers;
using ServiceEmail.UI.Models.TaskModel;
using ServiceEmail.UI.Models.User;
using ServiceEmail.UI.Models.WeatherInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public async Task <IActionResult> Index()
        {
            User person = HttpContext.Session.Get<User>("user");

            var list = new List<TaskInfo>()
            {
                //new TaskInfo(){Name = "Wheather", Description = "Info by wheather", LastDateTime = new DateTime(12,12,1992)},
                //new TaskInfo(){Name = "Play", Description = "Info abput play", LastDateTime = new DateTime(12,12,1992)},
                //new TaskInfo(){Name = "Kino", Description = "Info by wheather", LastDateTime = new DateTime(12,12,1992)}

            };

            var listUser = new List<User>()
            {
                new User(){Name = "Nikita", LastName = "Levashov", Email = "20021992", taskInfo = list},
                new User(){Name = "Pasha", LastName = "Ivanov", Email = "20021992", taskInfo = list},
                new User(){Name = "Igor", LastName = "Ivanov", Email = "20021992", taskInfo = list},
            };


            var jsonText = @"{
        ""HDRDTL"":[""SRNO"",""STK_IDN"",""CERTIMG""],
        ""PKTDTL"":[
        {""SRNO"":""2814"",""STK_IDN"":""1001101259"",""CERTIMG"":""6262941723""},
        {""SRNO"":""2815"",""STK_IDN"":""1001101269"",""CERTIMG"":""6262941726""},
        {""SRNO"":""2816"",""STK_IDN"":""1001101279"",""CERTIMG"":""6262941729""}
        ],
        ""IMGTTL"":
        [""CERTIMG"",""ARRIMG""],
        ""IMGDTL"":{""CERTIMG"":""CRd6z2uq3gvx7kk"",""ARRIMG"":""ASd6z2uq3gvx7kk""}
        }";

            //EmailScheduler.Start();


            //JsonConvert.
            //using (var connection = new SqliteConnection("Data Source=usersdata2.db"))
            //{
            //    connection.Open();

            //    SqliteCommand command = new SqliteCommand();
            //    command.Connection = connection;
            //    command.CommandText = "CREATE TABLE Users(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Age INTEGER NOT NULL)";
            //    command.ExecuteNonQuery();

            //    Console.WriteLine("Таблица Users создана");
            //}


            var client = new RestClient("https://weatherapi-com.p.rapidapi.com/forecast.json?q=Minsk&days=3");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "weatherapi-com.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "1169d35dd1mshd13d0e1dc0bee19p111a91jsn22b9882a51d2");
            IRestResponse response = client.Execute(request); ;

            var json = response.Content;

            //var t = jsonStringToTable(json);

            WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(json);

            var jsonWeth = JsonConvert.SerializeObject(weatherInfo);  


            //ViewBag.Response = response.Content;

            
            //var jtoken = JObject.Parse(json);/*.SelectToken("WeatherInfo");*/

            //var genericClick = jtoken.AsJEnumerable().Select(x => x).First(); /*Where(x => x.Path.Contains("generic_Click"));*/

            //var expandos = genericClick.ToObject<ExpandoObject[]>();
            //string csvText;

            //using (var writer = new StringWriter())
            //{
            //    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            //    {
            //        csv.WriteRecords(expandos as IEnumerable<dynamic>);
            //    }

            //    csvText = writer.ToString();
            //}

            //Console.WriteLine(csvText);
            ///

            //Stream containing your CSV (convert it into bytes, using the encoding of your choice)
            //using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(jsonWeth)))
            //{
            //    MailAddress from = new MailAddress("arhangel205@mail.ru", "Tom");
            //    // кому отправляем
            //    MailAddress to = new MailAddress("arhangel205@mail.ru");
            //    // создаем объект сообщения
            //    MailMessage m = new MailMessage(from, to);

            //    ContentType ct = new ContentType("application/octet-stream");
            //    ct.Name = "message.csv";
            //    //data.ContentType = ct;

            //    m.Attachments.Add(new Attachment(stream, /*new ContentType("text/csv")*/ct));
            //    // тема письма
            //    m.Subject = "Тест";
            //    // текст письма
            //    m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            //    // письмо представляет код html
            //    m.IsBodyHtml = true;
            //    // адрес smtp-сервера и порт, с которого будем отправлять письмо
            //    SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            //    // логин и пароль
            //    smtp.Credentials = new NetworkCredential("arhangel205@mail.ru", "20021992");
            //    smtp.EnableSsl = true;
            //    smtp.Send(m);
            //}
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            //MailAddress from = new MailAddress("arhangel205@mail.ru", "Tom");
            //// кому отправляем
            //MailAddress to = new MailAddress("levashov_92@outlook.com");
            //// создаем объект сообщения
            //MailMessage m = new MailMessage(from, to);
            //m.Attachments.Add(new Attachment(stream, new ContentType("text/csv")));
            //// тема письма
            //m.Subject = "Тест";
            //// текст письма
            //m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            //// письмо представляет код html
            //m.IsBodyHtml = true;
            //// адрес smtp-сервера и порт, с которого будем отправлять письмо
            //SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            //// логин и пароль
            //smtp.Credentials = new NetworkCredential("arhangel205@mail.ru", "20021992");
            //smtp.EnableSsl = true;
            //smtp.Send(m);
            //Console.Read();

     
            return View(person);
        }

        public async Task<IActionResult> UserDetails()
        {
            var list = new List<TaskInfo>()
            {
                new TaskInfo(){Name = "Wheather", Description = "Info by wheather", LastDateTime = new DateTime(12,12,1992)},
                new TaskInfo(){Name = "Play", Description = "Info abput play", LastDateTime = new DateTime(12,12,1992)},
                new TaskInfo(){Name = "Wheather", Description = "Info by wheather", LastDateTime = new DateTime(12,12,1992)}

            };

            return View(new TaskInfo() { Name = "Wheather", Description = "Info by wheather", LastDateTime = new DateTime(12, 12, 1992) });
        }

      

        //public async Task Execute(IJobExecutionContext context)
        //{
        //    using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes("Вроде получилось")))
        //    {
        //        MailAddress from = new MailAddress("arhangel205@mail.ru", "Tom");
        //        // кому отправляем
        //        MailAddress to = new MailAddress("arhangel205@mail.ru");
        //        // создаем объект сообщения
        //        MailMessage m = new MailMessage(from, to);

        //        ContentType ct = new ContentType("application/octet-stream");
        //        ct.Name = "message.csv";
        //        //data.ContentType = ct;

        //        m.Attachments.Add(new Attachment(stream, /*new ContentType("text/csv")*/ct));
        //        // тема письма
        //        m.Subject = "Тест";
        //        // текст письма
        //        m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
        //        // письмо представляет код html
        //        m.IsBodyHtml = true;
        //        // адрес smtp-сервера и порт, с которого будем отправлять письмо
        //        SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
        //        // логин и пароль
        //        smtp.Credentials = new NetworkCredential("arhangel205@mail.ru", "20021992");
        //        smtp.EnableSsl = true;
        //        smtp.Send(m);
        //    }
        //}

        public static string JsonToCsv(string jsonContent, string delimiter)
        {
            var expandos = JsonConvert.DeserializeObject<ExpandoObject[]>(jsonContent);

            using (var writer = new StringWriter())
            {
                using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
                {
                    //csv.Configuration.Delimiter = delimiter;

                    csv.WriteRecords(expandos as IEnumerable<dynamic>);
                }

                return writer.ToString();
            }
        }

        public static DataTable jsonStringToTable(string jsonContent)
        {
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonContent);
            return dt;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
