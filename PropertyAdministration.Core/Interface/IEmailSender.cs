using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Interface
{
    public interface IEmailSender
    {
        void SendEmail(string email, string subject, string message);
    } 
}
