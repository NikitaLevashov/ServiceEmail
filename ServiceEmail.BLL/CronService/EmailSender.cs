using Microsoft.AspNetCore.Http;
using Quartz;
using ServiceEmail.BLL.SessionService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.CronService
{
    //public class EmailSender : IJob
    //{
    //    private readonly IHttpContextAccessor context;
    //    private readonly ServiceEmail
    //    public EmailSender(ISession session, IHttpContextAccessor context)
    //    {
    //        user = context.HttpContext.Session.Get<User>("user");
    //    }
    //    public async Task Execute(IJobExecutionContext context)
    //    {
    //        using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(user.taskInfo.Last().DataOfTask)))
    //        {
    //            MailAddress from = new MailAddress("arhangel205@mail.ru", "Tom");
    //            // кому отправляем
    //            MailAddress to = new MailAddress(user.Email);
    //            // создаем объект сообщения
    //            MailMessage m = new MailMessage(from, to);

    //            ContentType ct = new ContentType("application/octet-stream");
    //            ct.Name = "message.csv";
    //            //data.ContentType = ct;

    //            m.Attachments.Add(new Attachment(stream, /*new ContentType("text/csv")*/ct));
    //            // тема письма
    //            m.Subject = "Тест";
    //            // текст письма
    //            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
    //            // письмо представляет код html
    //            m.IsBodyHtml = true;
    //            // адрес smtp-сервера и порт, с которого будем отправлять письмо
    //            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
    //            // логин и пароль
    //            smtp.Credentials = new NetworkCredential("arhangel205@mail.ru", "20021992");
    //            smtp.EnableSsl = true;
    //            smtp.Send(m);
    //        }
    //    }
    //}
}
