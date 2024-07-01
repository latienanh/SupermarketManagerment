using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.IServices;

namespace Supermarket.Application.Services
{
    public class SendMailServices : ISendMailServices
    {
        public bool SendMail(string to, string subject, string body, string attachFile)
        {
            try
            {
                MailMessage msg = new MailMessage(MailConfig.emailSender,to,subject,body);
                using (var client= new SmtpClient(MailConfig.hostEmail,MailConfig.portEmail))
                {
                    client.EnableSsl = true;
                    if (!string.IsNullOrEmpty(attachFile))
                    {
                        Attachment attachment = new Attachment(attachFile);
                        msg.Attachments.Add(attachment);
                    }
                    NetworkCredential credential = new NetworkCredential(MailConfig.emailSender,MailConfig.passwordSender);
                    client.UseDefaultCredentials = false;
                    client.Credentials = credential;
                    client.Send(msg);
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
