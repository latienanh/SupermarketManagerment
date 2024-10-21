namespace Supermarket.Application.Abstractions.ISendMailServices
{
    public interface ISendMailServices
    {
        bool SendMail(string to, string subject, string body, string attachFile);
    }
}
