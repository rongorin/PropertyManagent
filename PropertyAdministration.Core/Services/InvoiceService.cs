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

        public InvoiceService(IInvoiceRepository invoiceRepository,
            IHouseRepository houseRepository, ICategoryRepository catRepository)
        {
            _invoiceRepository = invoiceRepository;
            _houseRepository = houseRepository;
            _categoryRepository = catRepository;

        }
        public IEnumerable<Invoice> GetAllForHouse( int houseId )
        {
            var i = _invoiceRepository.GetAllForHouse(houseId);
            return i; 
        } 
        public void Edit(int invoiceId, int houseId, DateTime invoiceDate, string description,bool isPaid,
                        DateTime? paidDate)
        { 
            Invoice invoice = new Invoice()
            {
                InvoiceId = invoiceId,
                HouseId= houseId ,
                InvoiceDate = invoiceDate,
                DatePaid = paidDate,
                IsPaid = isPaid,
                Description = description
            };  
             
             _invoiceRepository.Edit(invoice); 
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
    }
}
