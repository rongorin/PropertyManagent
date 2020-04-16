using Microsoft.EntityFrameworkCore;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
   public class OwnerRepository : IOwnerRepository
    {
        private readonly AppDBContext _appDbContext;

        public OwnerRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Owner> GetAll
        {
            get
            {
                return _appDbContext.Owners.
                                Include(o => o.Houses);
            }
        }

        public void Edit(Owner owner)
        {
            _appDbContext.Owners.Update(owner);
        }

        public Owner GetById(int id)
        {
            return _appDbContext.Owners.
                     Include(o => o.Houses).FirstOrDefault(c => c.OwnerId == id);
        } 
      
        public void Create(Owner owner)
        {
            _appDbContext.Owners.Add(owner);
        }
         
        public void Delete(int id)
        {
            var owner = GetById(id);
            _appDbContext.Set<Owner>().Remove(owner);

        }
        public void Save()
        {
            _appDbContext.SaveChanges();

        }


    }
}
