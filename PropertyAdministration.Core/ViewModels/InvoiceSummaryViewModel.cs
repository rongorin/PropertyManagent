using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.ViewModels
{
    public class InvoiceSummaryViewModel
    {
        public decimal Balance { get; set; }
        public bool OwingIndicator { get; set; }
    }
}
