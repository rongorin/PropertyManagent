using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Utility;
using PropertyAdministration.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyAdministration
{
    public class HouseController : Controller
    {
        private IHouseRepository _houseRepo;
        private IInvoiceEngine _invoiceRepo;

        private readonly IMemoryCache _memoryCache; 

        // GET: /<controller>/
        public HouseController(IHouseRepository houseRepository, IInvoiceEngine  invoiceEngine, IMemoryCache memoryCache)
        {
            _houseRepo = houseRepository;
            _invoiceRepo = invoiceEngine;
            _memoryCache = memoryCache;

        }
        public ActionResult Index()
        {
            //IEnumerable<HOMEIndexViewModel> housesCached;
            //if (!_memoryCache.TryGetValue(CacheEntryConstants.AllHouses, out housesCached))
            //{
            //    housesCached = _houseRepo.GetAll
            //          .Select(a => new HOMEIndexViewModel
            //          {
            //              HouseId = a.HouseId,
            //              StreetNumber = a.StreetNumber,
            //              StreetName = a.StreetName,
            //              Description = a.Description,
            //              CategoryName = a.Category.CategoryName,
            //              FullName = a.Owner.FullName
            //          });

            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
            //    //cacheEntryOptions.RegisterPostEvictionCallback(FillCacheAgain, this);

            //    _memoryCache.Set(CacheEntryConstants.AllHouses, housesCached, cacheEntryOptions);
            //}
            var houseViewModel = _houseRepo.GetAll
              .Select(a => new HOMEIndexViewModel
              {
                  HouseId = a.HouseId,
                  StreetNumber = a.StreetNumber,
                  StreetName = a.StreetName,
                  Description = a.Description,
                  CategoryName = a.Category.CategoryName,
                  FullName = a.Owner.FullName
              });

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
