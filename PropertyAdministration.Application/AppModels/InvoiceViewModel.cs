using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAdministration.Application.AppModels 
{
    public class InvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public int HouseId { get; set; }
        [Required(ErrorMessage = "Enter a invoice date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Invoicing Date")]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(1000, MinimumLength = 4)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter an amount")] 
        [Range(1, 20000,
            ErrorMessage = "Amount must be between R{1} and R{2}.")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Date Paid ")]
        public DateTime? DatePaid { get; set; }
        public bool  IsPaid{ get; set; }
    }
}
