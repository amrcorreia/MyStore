using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Web.Helpers
{
    public interface IMailHelper
    {
        void SendMail(string to, string subject, string body);

        void SendEmailPlusAttachment(string to, string subject, string body, byte[] pdf);
    }
}
