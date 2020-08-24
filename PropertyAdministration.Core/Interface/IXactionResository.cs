using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Interface
{
    public interface IXactionResository
    {
        Xaction ReadById(int id);
        IEnumerable<Xaction> GetAllByHouseId(int id);
        void Create(Xaction transaction);  
        void Update(Xaction transaction);
        void Save();
    }
}
