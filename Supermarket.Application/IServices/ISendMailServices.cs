using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Application.IServices
{
    public interface ISendMailServices
    {
         bool SendMail(string to,string subject,string body,string attachFile);
    }
}
