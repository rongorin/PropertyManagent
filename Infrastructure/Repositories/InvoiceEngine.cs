using PropertyAdministration.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Infrastructure.Repositories
{
    public class InvoiceEngine : IInvoiceEngine
    {
        private readonly AppDBContext _appDbContext;

        public InvoiceEngine(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public decimal GetBalance(int houseId)
        {
            return _appDbContext.Invoices.Where(c => c.HouseId == houseId).Select(c => c.Amount).Sum();
        }

    }       
}
