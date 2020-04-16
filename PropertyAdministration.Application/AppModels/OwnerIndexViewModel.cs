using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Application.AppModels
{
    public class OwnerIndexViewModel
    { 
        public int OwnerId { get; set; }

        public string Title { get; set; }
       
        public string FullName { get; set; }
        
        public string EmailAddress { get; set; } 

        public string PhoneNumber { get; set; } 
        
        public int PropertiesOwned { get; set; }

        public string HouseAddress { get; set; }
 
    }
}
