using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.ViewModels
{
    public class InvoiceListViewModel
    { 
            public IEnumerable<Invoice> Invoices { get; set; }
            public int HouseId { get; set; }
            public decimal InvoicesTotal { get; set; }
            public string HouseAddress { get; set; }
    }
}
