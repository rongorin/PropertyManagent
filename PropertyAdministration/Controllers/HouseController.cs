using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyAdministration
{
    public class HouseController : Controller
    {
        private IHouseRepository _houseRepo;
        // GET: /<controller>/
        public HouseController(IHouseRepository houseRepository)
        {
            _houseRepo = houseRepository;

        }
        public ActionResult Index()
        {
            HouseListViewModel houselistVM = new HouseListViewModel();

            houselistVM.Houses = _houseRepo.GetAll;
            houselistVM.CurrentCategory = "the current category";
            return View(houselistVM);
        }
        public IActionResult Details(int id)
        {
            var house = _houseRepo.GetById(id);
            if (house == null)
                return NotFound();

            return View(house);


        }
    }
}
