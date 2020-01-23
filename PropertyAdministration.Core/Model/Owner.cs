using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Model
{
   public class Owner
    { 
        public int OwnerId              { get; set; }
        public string FullName          { get; set; }
        public string EmailAddress      { get; set; }
        public string PhoneNumber       { get; set; }
    }
}
