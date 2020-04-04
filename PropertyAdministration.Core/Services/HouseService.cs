using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Services
{
    public class HouseService
    { 
        private IHouseRepository _houseRepository;
        private ICategoryRepository _categoryRepository;

        public HouseService(IHouseRepository houseRepository, ICategoryRepository catRepository)
        { 
            _houseRepository = houseRepository;
            _categoryRepository = catRepository;

        }
        public HouseViewModel GetById(int id) 
        {
            House house = _houseRepository.GetById(id);
            var houseV = new HouseViewModel
            {
                 HouseId = house.HouseId,
                 Description = house.Description,
                 ERF = house.ERF,
                 StreetName = house.StreetName,
                 StreetNumber = house.StreetNumber,
                 FullName =   house.Owner.FullName,
                 CategoryId = house.CategoryId,
                 IsPlot =   house.IsPlot,
                 DateMoveIn = house.DateMoveIn,
                 OwnerId = house.OwnerId

            } ; 
            return houseV;

        }
        public void Edit(HouseViewModel houseV)
        {
            House house = new House()
            {
                HouseId = houseV.HouseId,
                OwnerId = houseV.OwnerId,
                StreetName = houseV.StreetName,
                StreetNumber = houseV.StreetNumber,
                Description = houseV.Description,
                DateMoveIn = houseV.DateMoveIn,
                IsPlot = houseV.IsPlot,
                CategoryId = houseV.CategoryId,
                ERF = houseV.ERF 
            };
            _houseRepository.Edit(house);

        }

    }
}
