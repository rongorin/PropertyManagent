﻿using System;
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
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}" )]
        [Display(Name = "Invoicing Date")]
        public DateTime InvoiceDate { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(150)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter an amount")] 
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}" )]
        [Display(Name = "Date Paid ")]
        public DateTime DatePaid{ get; set; }
    }
}
