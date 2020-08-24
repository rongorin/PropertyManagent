using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class XactionRepository : IXactionResository
    {
        private readonly AppDBContext _appDbContext;

        public XactionRepository(AppDBContext appDbContext)  
        {
            _appDbContext = appDbContext;

        }

         public void Create(Xaction transaction)
        { 
            _appDbContext.Xactions.Add(transaction);

        }

        
        IEnumerable<Xaction> IXactionResository.GetAllByHouseId(int id)
        {
            return _appDbContext.Xactions.Where(c => c.HouseId == id);

        }

        Xaction IXactionResository.ReadById(int id)
        {
            return _appDbContext.Xactions.FirstOrDefault(c => c.Id == id);

        }

        void IXactionResository.Save()
        {
            _appDbContext.SaveChanges();

        }

        void IXactionResository.Update(Xaction transaction)     
        {
            _appDbContext.Xactions.Update(transaction);
            _appDbContext.SaveChanges();
        }
    }
}
