using Microsoft.AspNetCore.Mvc;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAdministration.Components
{
    public class InvoiceSummary : ViewComponent
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceSummary(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public IViewComponentResult Invoke(int houseId)
        {
            decimal invoiceSummaryAmt = _invoiceRepository.GetHouseBalance (houseId);
            //var vm = new InvoiceSummaryViewModel
            //{
            //    Balance = invoiceSummary
            //}
            return View(invoiceSummaryAmt);
        }
    } 
}
