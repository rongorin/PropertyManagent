using PropertyAdministration.Application.AppModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Interface
{
    public interface IOwnerService
    { 
          IEnumerable<OwnerIndexViewModel> GetAll();

          OwnerViewModel GetById(int id);

          void Edit(OwnerEditViewModel ownerVM);

          void Create(OwnerEditViewModel ownerVM);

          void Delete(int id);
         
          void Save(); 
    }
}
