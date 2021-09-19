using Microsoft.Extensions.Configuration;
using Quartz;
using ServiceEmail.BLL.TextService;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.CronService
{
    public class EmailSender : IJob
    {
        public IConfiguration CronConfiguration { get; set; }
        public async Task Execute(IJobExecutionContext context)
        {
            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(UserHelper.user.TaskInfo.Last().DataOfTask)))
            {
                var host = CronConfiguration["Host"];
                int.TryParse(CronConfiguration["Port"], out int port);

                var builder = new ConfigurationBuilder().AddJsonFile("cronconfig.json");
                CronConfiguration = builder.Build();

                MailAddress from = new MailAddress(AppSettings.EmailApiService, "Nik"); 
                MailAddress to = new MailAddress(UserHelper.user.Email);
                MailMessage m = new MailMessage(from, to);
                ContentType ct = new ContentType(CronConfiguration["ContentType"]);
                ct.Name = CronConfiguration["CSV"];  
                m.Attachments.Add(new Attachment(stream, ct));
                m.Subject = "Mike";
                m.Body = "<h2>Message-test</h2>";
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(host, port);
                smtp.Credentials = new NetworkCredential(AppSettings.EmailApiService, AppSettings.PasswordApiService);
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
        }
    }
}