using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAdministration.ViewModels
{
    public class DeleteInvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] 
        public DateTime InvoiceDate { get; set; }

        public string Description { get; set; }  
        public int HouseId { get; set; }
        public string HouseAddress { get; set; }
}
}
    