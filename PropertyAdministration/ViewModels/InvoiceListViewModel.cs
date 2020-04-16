using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.ViewModels
{
    public class InvoiceListViewModel
    {  
             public  Invoice  Invoicev { get; set; }
            public int HouseId { get; set; }
           // public decimal InvoicesTotal { get; set; }
            public string HouseAddress { get; set; }
            public string FullName { get; set; }
    }
}
