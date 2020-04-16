using System;
using System.Collections.Generic;
using System.Text;
using PropertyAdministration.Core.Model;

namespace PropertyAdministration.Core.Interface
{
    public interface  IOwnerRepository
    {
        IEnumerable<Owner> GetAll { get; } 
        Owner GetById(int id);
        void Edit(Owner house);
        void Create(Owner house); 
        void Delete(int id);
        void Save(); 

    }
}
