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
        private IInvoiceEngine _invoiceRepo;
        // GET: /<controller>/
        public HouseController(IHouseRepository houseRepository, IInvoiceEngine  invoiceEngine)
        {
            _houseRepo = houseRepository;
            _invoiceRepo = invoiceEngine; 

        }
        public ActionResult Index()
        {  
            var houseViewModel = _houseRepo.GetAll
              .Select(a => new HOMEIndexViewModel
              {
                  HouseId = a.HouseId,
                  StreetNumber = a.StreetNumber,
                  StreetName = a.StreetName,
                  Description = a.Description,
                  CategoryName = a.Category.CategoryName,
                  FullName = a.Owner.FullName  
              }) ;

           // houseViewModel.CurrentCategory = "the current category";

            return View(houseViewModel);
          
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
