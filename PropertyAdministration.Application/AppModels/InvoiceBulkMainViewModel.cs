using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PropertyAdministration.Application.AppModels
{
    public class InvoiceBulkMainViewModel
    {
        [Required(ErrorMessage = "Enter a invoice description")]
        [StringLength(50, MinimumLength = 4)]
        [Display(Name = "Invoice Description")]
        public string InvoiceTemplateMsg { get; set; }

        [Required(ErrorMessage = "Please enter an amount")]
        [Display(Name = "Amount to invoice - House)")]
        [Range(1, 20000,
            ErrorMessage = "Value for {0} must be between R{1} and R{2}.")]
        public decimal InvoiceAmountHouse { get; set; }
        [Required(ErrorMessage = "Please enter an amount")]
        [Display(Name = "Amount to invoice -Plot")]
        [Range(1, 20000,
            ErrorMessage = "Value for {0} must be between R{1} and R{2}.")] 
        public decimal InvoiceAmountPlot { get; set; }

    }
}
