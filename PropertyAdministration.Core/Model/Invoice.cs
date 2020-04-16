using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PropertyAdministration.Core.Model
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int HouseId { get; set; }
        [Required(ErrorMessage = "Enter a invoice date")]
        [DataType(DataType.Date)] 
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}" )]
        [Display(Name = "Invoicing Date")]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter an amount")] 
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}" )]
        [Display(Name = "Date Paid")]
        public DateTime? DatePaid{ get; set; }

        [Display(Name = "Is Paid")]
        public bool IsPaid { get; set; }

        public virtual House House { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            Invoice compareInv = obj as Invoice;

            if (compareInv != null &&
                compareInv.InvoiceId == this.InvoiceId &&
                compareInv.HouseId == this.HouseId &&
                compareInv.Amount == this.Amount &&
                compareInv.IsPaid == this.IsPaid &&
                compareInv.Description == this.Description &&
                compareInv.DatePaid == this.DatePaid)
                return true;

            return base.Equals(obj);    
        }
    }
}
