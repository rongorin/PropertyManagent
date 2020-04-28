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
        private IHouseRepository _houseRepo;
        private IInvoiceEngine _invoiceRepo;
        private ICategoryRepository _categoryRepo;
        private HouseService _houseService;
        private OwnerService _ownerService;

        private readonly IMemoryCache _memoryCache; 

        // GET: /<controller>/
        public HouseController(IHouseRepository houseRepository, IInvoiceEngine  invoiceEngine,
                                ICategoryRepository  categoryRepository,
                                 HouseService houseService,
                                 OwnerService ownerService,
                                IMemoryCache memoryCache)
        {
            _houseRepo = houseRepository;
            _invoiceRepo = invoiceEngine;
            _memoryCache = memoryCache;
            _categoryRepo = categoryRepository;
            _houseService = houseService;
            _ownerService = ownerService;

        }
        public ActionResult Index(string searchTerm = null)
        {  // Retrieves the requested culture

                var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
                // Culture contains the information of the requested culture

                var culture = rqf.RequestCulture.Culture;
             

            var houseViewModel = _houseService.GetAll(searchTerm)
                  .Select(a => new HOMEIndexViewModel
                  {
                      HouseId = a.HouseId,
                      StreetNumber = a.StreetNumber,
                      StreetName = a.StreetName,
                      Description = a.Description,
                      CategoryName = a.CategoryName,
                      FullName = a.FullName,
                      InvoicesBalance = a.InvoicesBalance
                  }).OrderBy(a => a.StreetName).ThenBy(a =>a.StreetNumber);

            bool isAjaxCall = HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";
            if (isAjaxCall)
                return PartialView("_Houses", houseViewModel );
             
            return View(houseViewModel);

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

        public IActionResult Edit(int id)
        { 
            var categories = _categoryRepo.GetAll; //for dropdown
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
         
        //[HttpGet]
        //public IActionResult Edit(int invoiceId, int houseId)
        //{
        //    Invoice invoice = _invoiceRepo.GetById(invoiceId);
        //    var categories = _categoryRepository.GetAll; //for dropdown

        //    if (invoice == null) return RedirectToAction("Index", new { id = houseId });

        //    var invoiceEditVModel = new InvoiceEditViewModel
        //    {
        //        HouseAddress = GetAddress(houseId),
        //        Categories = categories.Select(c => new SelectListItem()
        //        { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
        //        Invoice = new InvoiceViewModel
        //        {
        //            InvoiceDate = invoice.InvoiceDate,
        //            Amount = invoice.Amount,
        //            DatePaid = invoice.DatePaid,
        //            IsPaid = invoice.IsPaid,
        //            Description = invoice.Description,
        //            InvoiceId = invoice.InvoiceId,
        //            HouseId = invoice.HouseId
        //        }
        //    };

        //    return View(invoiceEditVModel);
        //}
        public IActionResult Details(int id)
        {
            var house = _houseRepo.GetById(id);
            if (house == null)
                return NotFound();

            return View(house);  
        }
       
    }
}
