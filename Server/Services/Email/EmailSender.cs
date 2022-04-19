using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using UmotaWebApp.Shared.Config;

namespace UmotaWebApp.Server.Services.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            //Send(emailMessage);

            var body = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content);
            Email(body, emailMessage.Subject, message.To[0].Address, message.Attachments, message.From, message.SmtpPassword);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content) };

            if (message.Attachments != null && message.Attachments.Any())
            {            
                bodyBuilder.Attachments.Add("teklif.pdf", message.Attachments);
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(mailMessage);

                }
                catch(Exception ex)
                {
                    //log an error message or throw an exception or both.
                    throw ex;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        public void Email(string htmlString, string subject, string toMailAddress, byte[] attachment, string from, string password)
        {
            try
            {
                MailMessage message = new MailMessage();
                var smtp = new  System.Net.Mail.SmtpClient();
                message.From = new MailAddress(from); //new MailAddress(_emailConfig.From);
                message.To.Add(new MailAddress(toMailAddress));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;

                var ms = new System.IO.MemoryStream(attachment);
                var ct = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
                var attach = new System.Net.Mail.Attachment(ms, ct);
                attach.ContentDisposition.FileName = "teklif.pdf";
                message.Attachments.Add(attach);


                smtp.Port = _emailConfig.Port;
                smtp.Host = _emailConfig.SmtpServer; //for gmail host  
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                
                smtp.Send(message);
            }
            catch (Exception ex) 
            {
                throw ex; 
            }
        }
    }
}
