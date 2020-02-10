using PropertyAdministration.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace PropertyAdministration.Core.Model
{
    public class InvoiceEngine : IInvoiceEngine
    {
        private IInvoiceEngine _invoiceRepository;

        public InvoiceEngine(IInvoiceEngine invoiceRepo )
        {
            _invoiceRepository = invoiceRepo;
        }

        public decimal GetBalance(int houseId)
        {
            return _invoiceRepository.GetBalance(houseId);
        }
       
    }       
}
