using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using System.Collections.Generic;
using System.Linq;
using PropertyAdministration.Core.Extentions;
namespace PropertyAdministration.Core.Services
{
    public class HouseService : IHouseService
    { 
        private IHouseRepository _houseRepository;
        private ICategoryRepository _categoryRepository;

        public HouseService(IHouseRepository houseRepository,
                            ICategoryRepository catRepository)
        { 
            _houseRepository = houseRepository;
            _categoryRepository = catRepository;

        }
        public IEnumerable<HOMEIndexViewModel>  GetAll(string searchTerm)
        {
            var houseViewModel = _houseRepository.GetAll.
                SearchName(searchTerm)
             .Select(a => new HOMEIndexViewModel
             {
                 HouseId = a.HouseId,
                 StreetNumber = a.StreetNumber,
                 StreetName = a.StreetName,
                 Description = a.Description,
                 CategoryName = a.Category.CategoryName,
                 InvoicesBalance = a.Invoices.Where(s => s.IsPaid == false).Sum( s=> s.Amount),
                 FullName = a.Owner.FullName 
             });

            return houseViewModel;
            
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
                 FullName = house.Owner.FullName ==null?"":house.Owner.FullName,
                 CategoryId = house.CategoryId,
                 IsPlot =   house.IsPlot,
                 DateMoveIn = house.DateMoveIn,
                 OwnerId = house.OwnerId

            } ; 
            return houseV;

        }
        public  void Edit(HouseViewModel houseV)
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

            _houseRepository.Save();


        }

    }
}
