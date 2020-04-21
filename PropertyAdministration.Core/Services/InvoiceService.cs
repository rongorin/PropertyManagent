using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyAdministration.Core.Services
{
    public class InvoiceService
    {
        private IInvoiceRepository _invoiceRepository;
        private IHouseRepository _houseRepository;
        private ICategoryRepository _categoryRepository;

        public decimal AmountHouse;

        public decimal AmountPlot; 

        public InvoiceService(IInvoiceRepository invoiceRepository,
            IHouseRepository houseRepository, ICategoryRepository catRepository)
        {
            _invoiceRepository = invoiceRepository;
            _houseRepository = houseRepository;
            _categoryRepository = catRepository;

        }
        public IEnumerable<Invoice> GetAll()
        {
            var invoices = _invoiceRepository.GetAll.ToList()
                                                    .OrderByDescending(a => a.InvoiceDate);
            return invoices;
        }
        public IEnumerable<Invoice> GetAllForHouse( int houseId )
        {
            var invoices = _invoiceRepository.GetAllForHouse(houseId).OrderByDescending(a =>a.InvoiceDate);
                return invoices;    
        } 
        public void Edit(int invoiceId, int houseId, DateTime invoiceDate, decimal Amount, string description,bool isPaid, 
                        DateTime? paidDate)
        { 
            Invoice invoice = new Invoice()
            {
                InvoiceId = invoiceId,
                HouseId= houseId ,
                InvoiceDate = invoiceDate,
                Amount = Amount,
                DatePaid = (isPaid) ? paidDate: null,
                IsPaid = isPaid,
                Description = description  
            };  
             
             _invoiceRepository.Edit(invoice); 
        }
        public void Create(int invoiceId, int houseId, DateTime invoiceDate, decimal Amount, string description, bool isPaid,
                        DateTime? paidDate)
        {
            Invoice invoice = new Invoice()
            {
                InvoiceId = invoiceId,
                HouseId = houseId,
                InvoiceDate = invoiceDate,
                Amount = Amount,
                DatePaid = paidDate,
                IsPaid = isPaid,
                Description = description
            };

            _invoiceRepository.Create(invoice);

        }
        public void Save()
        {
              _invoiceRepository.Save(); //finally commit:
        }

         public Invoice GetById(int id)
        {
            Invoice invoice = _invoiceRepository.GetById(id);
            return invoice; 
        }

        public void Delete(int id)
        {
            _invoiceRepository.Delete(id); 
        }

        public int BulkCreate(List<CreateBulkInvoiceViewModel> invoices)
        {
            int counter = 0;
            foreach (var invoice in invoices)
            {
                if (!invoice.IsCreate)
                    continue;
                Invoice newInvoice = new Invoice()
                {
                     Amount = invoice.Invoicev.Amount,
                     DatePaid = invoice.Invoicev.DatePaid, 
                     HouseId = invoice.Invoicev.HouseId,
                     Description = invoice.Invoicev.Description,
                     InvoiceDate = invoice.Invoicev.InvoiceDate,
                     IsPaid = invoice.Invoicev.IsPaid  
                };
                _invoiceRepository.Create(newInvoice);
                counter++;
            }
           
            _invoiceRepository.Save(); //finally commit:

            return counter;

        }

        public decimal CalcInvoiceAmount(bool IsPlot)
        {
            if (IsPlot)
                return AmountPlot;
            else
                return AmountHouse;
        }
    }
}
