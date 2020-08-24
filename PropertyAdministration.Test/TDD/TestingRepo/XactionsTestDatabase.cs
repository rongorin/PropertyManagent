using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Test.TDD.TestingRepo
{
    public class XactionsTestDatabase : IXactionResository
    {
        public void Create(Xaction transact)
        {
            Save();
        }

        public void Edit(Xaction transaction)
        {
            new Xaction(transaction.Id, transaction.HouseId, transaction.Description, transaction.Amount);
            
        }

        public IEnumerable<Xaction> GetAllByHouseId(int id)
             
        {
            var listing = new List<Xaction>
            {
               new Xaction(1,100,"",900.00M) ,
               new Xaction(2,100,"",900.00M) ,
               new Xaction(3,100,"",150.00M) 
            };

            return listing; 
        }

        public Xaction ReadById(int id)
        {
            //throw new NotImplementedException(); 
            return new Xaction(1, 100,"Descript of transaction", 3500.00M);
        }

        public void Save()
        {
            
        }

        public void Update(Xaction transaction)
        {
            new Xaction(transaction.Id, transaction.HouseId, transaction.Description, transaction.Amount);
        }
    }

}
