 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertyAdministration.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PropertyAdministration.Test.UnitTestSyndicates
{
    [TestClass]
    public class EmailSend
    {
        [TestMethod]
        public void EmailSender_TestSendEmail()
        {
            //arrange
            var emailByConsole = new EmailByConsole();


            //act assert
            emailByConsole.SendEmail("","",""); 

        }
    }

    //concrete implemnetation:
    public class EmailByConsole : IEmailSender
    {
        public void SendEmail(string email, string subject, string message)
        {
            Console.WriteLine($"sent email to {email} message: {message}");
        }
         
    }
}
