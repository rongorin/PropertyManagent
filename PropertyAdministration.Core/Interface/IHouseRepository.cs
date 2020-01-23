using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Interface
{
   public interface IHouseRepository
    {
        IEnumerable<House> GetAll { get; }
      
        House GetById(int invoiceId);
    }
}
