using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Utility;
using PropertyAdministration.ViewModels; 
using PropertyAdministration.Core.Services;
using Microsoft.AspNetCore.Localization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyAdministration
{
    public class HouseController : Controller
    { 
        private ICategoryService _categoryService;
        private IHouseService _houseService;
        private IOwnerService _ownerService;

        private readonly IMemoryCache _memoryCache; 

        // GET: /<controller>/
        public HouseController(  IHouseService houseService,
                                 IOwnerService ownerService,
                                 ICategoryService categoryService,
                                 IMemoryCache memoryCache)
        { 
            _memoryCache = memoryCache;
            _categoryService = categoryService;
            _houseService = houseService;
            _ownerService = ownerService;

        }
        public ActionResult Index(string searchTerm = null)
        {  
            var houseViewModel = _houseService.GetAll(searchTerm)
                  .Select(a => new HOMEIndexViewModel
                  {
                      HouseId = a.HouseId,
                      StreetNumber = a.StreetNumber,
                      StreetName = a.StreetName,
                      Description = a.Description,
                      CategoryName = a.CategoryName,
                      FullName = a.FullName,
                      InvoicesBalance = a.InvoicesBalance,
                      ImageThumbnail = a.ImageThumbnail
                  }).OrderBy(a => a.StreetName).ThenBy(a =>a.StreetNumber);

            bool isAjaxCall = HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
            if (isAjaxCall)
                return PartialView("_Houses", houseViewModel );
             
            return View(houseViewModel); 
        } 

        public IActionResult Edit(int id)
        { 
            var categories = _categoryService.GetAll(); //for dropdown
            var owners = _ownerService.GetAll(); //for dropdown

            var house = _houseService.GetById(id);

            var houseViewModel = new HouseEditViewModel
            {
                House = house,
                CategoryId = house.CategoryId,
                Categories = categories.Select(c => new SelectListItem { Text = c.CategoryName,
                    Value = c.CategoryId.ToString() }).ToList(),
                OwnerId = house.OwnerId,
                Owners = GetOwnersList()

            };

            return View(houseViewModel);
        }
        [HttpPost]
        public IActionResult Edit(HouseEditViewModel houseVM)
        {
            if (houseVM == null)
                return NotFound();

            houseVM.House.CategoryId = houseVM.CategoryId; 
            houseVM.House.OwnerId = houseVM.OwnerId;

            if (ModelState.IsValid)
            {  
                var house = houseVM.House;

                _houseService.Edit(house); 

                TempData.Add("ResultMessage", "House Edited Successfully!");

                return RedirectToAction("Details", new { id = house.HouseId});  

            }
            houseVM.Owners = GetOwnersList();
            return View(houseVM);
        }
         
    
        public IActionResult Details(int id)
        {
            var house = _houseService.GetById(id);
            if (house == null)
                return NotFound();

            return View(house);  
        }
        private List<SelectListItem> GetOwnersList()
        {
            var owners = _ownerService.GetAll();

            return owners.Select(c => new SelectListItem
            {
                Text = c.FullName,
                Value = c.OwnerId.ToString()
            }).ToList();
        }

    }
}
