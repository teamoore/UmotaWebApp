using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Server.Services.Email
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
