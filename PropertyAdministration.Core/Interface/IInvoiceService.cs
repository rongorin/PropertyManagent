using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Interface
{
    public interface IInvoiceService
    { 

        decimal AmountHouse { get; set; }
        decimal AmountPlot { get; set; } 

        IEnumerable<Invoice> GetAll();

        IEnumerable<Invoice> GetAllForHouse(int houseId);

        bool SetPaid(int invoiceId, bool isPaid);
         
        void Edit(int invoiceId, int houseId, DateTime invoiceDate, decimal Amount, string description, bool isPaid, DateTime? paidDate);
         
        void Create(int invoiceId, int houseId, DateTime invoiceDate, decimal Amount, string description, bool isPaid, DateTime? paidDate);
         
        void Save();

        Invoice GetById(int id);
         
        void Delete(int id);

        int BulkCreate(List<CreateBulkInvoiceViewModel> invoices);

        decimal CalcInvoiceAmount(bool IsPlot);
    }
}
