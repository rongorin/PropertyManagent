using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Interface
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetAll { get; }
            //  IEnumerable<Invoice> PiesOfTheWeek { get; }
        Invoice GetById(int invoiceId);
    }
}
