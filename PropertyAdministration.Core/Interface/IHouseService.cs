using PropertyAdministration.Application.AppModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Interface
{
    public interface IHouseService
    {
        //private IHouseRepository _houseRepository;
        //private ICategoryRepository _categoryRepository;
         
          IEnumerable<HOMEIndexViewModel> GetAll(string searchTerm); 
          HouseViewModel GetById(int id); 
          void Edit(HouseViewModel houseV);
       
    }
}
