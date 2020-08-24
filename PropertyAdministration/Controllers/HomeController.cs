using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Services;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyAdministration.Controllers
{
    public class HomeController : Controller
    {
        readonly IHouseRepository houseRepository;
        private IHouseService _houseService;

        public HomeController(IHouseRepository HouseRepo,
                                 IHouseService houseService)
        {
            _houseService = houseService;
            
            houseRepository = HouseRepo;
        }

        // GET: /<controller>/
        public IActionResult Index(string searchTerm = null)
        {
            var houseViewModel = _houseService.GetAll(searchTerm)
                .Select(a => new HOMEIndexViewModel
                {
                    HouseId = a.HouseId,
                    StreetNumber = a.StreetNumber,
                    StreetName = a.StreetName,
                    Description = a.Description,
                    CategoryName = a.CategoryName,
                    FullName = a.FullName ,
                    ImageThumbnail = a.ImageThumbnail,
                    InvoicesBalance = a.InvoicesBalance
                }).Where(o => o.InvoicesBalance > 10)
                .OrderByDescending(a => a.InvoicesBalance)   ;

            bool isAjaxCall = HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
            if (isAjaxCall)
                return PartialView("_Houses", houseViewModel);

            return View(houseViewModel);
             
        }
    }
}
