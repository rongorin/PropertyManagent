using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAdministration.ViewModels
{
    public class InvoiceListVM
    {
        public IEnumerable<InvoiceListViewModel> invoiceListViewModel { get; set; }
        public decimal InvoicesTotal { get; set; } 
        public bool ListAll { get; set; }
        public string ListingHeader { get; set; }
        public int HouseId { get; set; }


    }
}
