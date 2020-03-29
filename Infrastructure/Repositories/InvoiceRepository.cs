using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDBContext _appDbContext;

        public InvoiceRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Invoice> GetAll
        {
            get
            {
                return _appDbContext.Invoices;
            }
        }

        public Invoice GetById(int invoiceId)
        {
            return _appDbContext.Invoices.FirstOrDefault(c => c.InvoiceId == invoiceId);

        }

        public IEnumerable<Invoice> GetAllForHouse(int houseId)
        {
            var invoices = _appDbContext.Invoices.Where(c => c.HouseId == houseId);
            return invoices;

        }

        public decimal GetHouseBalance(int houseId)
        {
            return _appDbContext.Invoices.Where(c => c.HouseId == houseId).Select(c => c.Amount).Sum();
        }

        public void Create(Invoice invoice)
        {
            _appDbContext.Invoices.Add(invoice);
            _appDbContext.SaveChanges();
        }

        public void Edit(Invoice invoice)
        {
            _appDbContext.Invoices.Update(invoice);
            _appDbContext.SaveChanges();
        }
        
        public void Delete(int invoiceId)
        {
            var invoice = GetById(invoiceId);
            _appDbContext.Set<Invoice>().Remove(invoice);
            _appDbContext.SaveChanges();
        }
    }
}
