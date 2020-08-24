using PropertyAdministration.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string email, string subject, string message)
        {
            // TODO: Wire this up to actual email sending logic via SendGrid, local SMTP, etc.
        }
    }
}
