using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAdministration.ViewModels
{
    public class CreateBulkInvoiceViewModel
    {
        public InvoiceViewModel Invoicev { get; set; }
        public bool IsCreate { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber  { get; set; }
        public string FullName { get; set; }
 


    }
}
