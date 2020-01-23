using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Model
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int HouseId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DatePaid{ get; set; }
    }
}
