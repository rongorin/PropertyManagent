using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PropertyAdministration.Core;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;

namespace Infrastructure.Repositories 
{
    public class HouseRepository : IHouseRepository
    {
        private readonly AppDBContext _appDbContext;
            
        public HouseRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext; 
        }

        public IEnumerable<House> GetAll
        {
            get
            {
                return _appDbContext.Houses.
                                Include(c => c.Category).
                                Include(o => o.Owner).
                                Include(i => i.Invoices);  
            } 
        }
        //public IEnumerable<House> GetAll(string searchCriteria)
        //{
        //    return _appDbContext.Houses.
        //                               Include(c => c.Category).
        //                               Include(o => o.Owner).
        //                               Include(i => i.Invoices);
        //}
        public House GetById(int houseId)
        {
            return _appDbContext.Houses.
                                Include(o => o.Owner).FirstOrDefault(c => c.HouseId == houseId);
           
        }
        public void Edit(House house)
        {
            _appDbContext.Houses.Update(house);
        }
        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
