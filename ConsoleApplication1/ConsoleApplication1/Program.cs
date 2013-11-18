using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpClient Smtp = new SmtpClient("mail", 25);

            Smtp.Credentials = new NetworkCredential("мыло", "пароль");
            Smtp.EnableSsl = false;

            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("SpeekSound@enterra-inc.com");
            Message.To.Add(new MailAddress("vasilyev@enterra-inc.com"));
            Message.Bcc.Add(new MailAddress("vasilyev@enterra-inc.com"));
            Message.CC.Add(new MailAddress("vasilyev@enterra-inc.com"));
            Message.IsBodyHtml = true;
            Message.Attachments.Add(new Attachment("ConsoleApplication1.pdb"));            
            Message.Subject = "Тема";
            //Message.Body = "Текст Тела письма в простом тексте";
            StreamReader r = new StreamReader(@"d:\Icon\index.html", Encoding.UTF8);
            Message.Body = r.ReadToEnd();
            r.Close();
            r.Dispose();

            //Message.Priority = MailPriority.High;
            //Message.Priority = MailPriority.Low;
            //Message.Priority = MailPriority.Normal;
            
            Smtp.Send(Message);

        }
    }
}
