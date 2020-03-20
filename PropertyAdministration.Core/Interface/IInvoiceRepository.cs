using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Interface
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetAll { get; } 
        IEnumerable<Invoice> GetAllForHouse(int houseId);
        decimal GetHouseBalance(int houseId);
        Invoice GetById(int invoiceId);

        void Create(Invoice invoice);
        void Edit(Invoice invoice);
        void Delete(int invoiceId);

    }
}
