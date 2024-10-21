using Supermarket.Application.Abstractions.ISendMailServices;
using System.Net.Mail;
using System.Net;

namespace Supermarket.Application.Services.Mail.Command;

public class SendMailServices : ISendMailServices
{
    public bool SendMail(string to, string subject, string body, string attachFile)
    {
        try
        {
            MailMessage msg = new MailMessage(MailConfig.emailSender, to, subject, body);
            using (var client = new SmtpClient(MailConfig.hostEmail, MailConfig.portEmail))
            {
                client.EnableSsl = true;
                if (!string.IsNullOrEmpty(attachFile))
                {
                    Attachment attachment = new Attachment(attachFile);
                    msg.Attachments.Add(attachment);
                }
                NetworkCredential credential = new NetworkCredential(MailConfig.emailSender, MailConfig.passwordSender);
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