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
        public async Task Execute(IJobExecutionContext context)
        {
            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(UserHelper.user.taskInfo.Last().DataOfTask)))
            {
                MailAddress from = new MailAddress($"{AppSettings.EmailApiService}", "Nik"); 
                MailAddress to = new MailAddress(UserHelper.user.Email);
                MailMessage m = new MailMessage(from, to);
                ContentType ct = new ContentType("application/octet-stream");
                ct.Name = "message.csv";  
                m.Attachments.Add(new Attachment(stream, ct));
                m.Subject = "Mike";
                m.Body = "<h2>Message-test</h2>";
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
                smtp.Credentials = new NetworkCredential(AppSettings.EmailApiService, AppSettings.PasswordApiService);
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
        }
    }
}