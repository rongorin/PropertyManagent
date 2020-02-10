using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyAdministration.Controllers
{
    public class HomeController : Controller
    {
        readonly IHouseRepository houseRepository;

        public HomeController(IHouseRepository HouseRepo)
        {
            houseRepository = HouseRepo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var houseViewModel = houseRepository.GetAll 
                .Select(a => new HOMEIndexViewModel
                {
                    HouseId = a.HouseId,
                    StreetNumber = a.StreetNumber,
                    StreetName = a.StreetName,
                    Description = a.Description,
                    CategoryName = a.Category.CategoryName,
                    FullName = a.Owner.FullName ,
                    InvoicesBalance = a.Invoices.Sum(o => o.Amount),
                }).Where(o => o.InvoicesBalance > 10)   ;

            return View(houseViewModel);
        }
    }
}
