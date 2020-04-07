using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using PropertyAdministration.Core.Services;
using PropertyAdministration.ViewModels;
using Microsoft.Extensions.Configuration;
using PropertyAdministration.Application.AppModels;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyAdministration.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IConfiguration _config;

        private IInvoiceRepository _invoiceRepo;
        private IHouseRepository _houseRepo;
        private ICategoryRepository _categoryRepository;
        private InvoiceService _invoiceService;
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(IInvoiceRepository InvoiceRepository,
                                 IHouseRepository HouseRepository,
                                 ICategoryRepository CategoryRepository,
                                 InvoiceService invoiceService,
                                 ILogger<InvoiceController> logger,
                                 IConfiguration config
                                 )
        {
            _invoiceRepo = InvoiceRepository;
            _houseRepo = HouseRepository;
            _categoryRepository = CategoryRepository;
            _invoiceService = invoiceService;
            _logger = logger;
            _config = config;


        }
        // GET: /<controller>/  
        public IActionResult Index(int? id)
        {
            _logger.LogInformation("testmeessage in the index");
            InvoiceListViewModel indexViewModel ;
            if (id.HasValue)
            {
                indexViewModel = new InvoiceListViewModel
                {
                    HouseId = id.Value,
                    //Invoices = _invoiceRepo.GetAllForHouse(id)  .ToList(),
                    Invoices = _invoiceService.GetAllForHouse(id.Value).ToList(),
                    HouseAddress =( GetAddress(id.Value).Item1),
                    FullName =( GetAddress(id.Value).Item1)
                };
                indexViewModel.InvoicesTotal = indexViewModel.Invoices.Sum(o => o.Amount);

            }
            else
            {
                indexViewModel = _invoiceService.GetAllByHouse
                indexViewModel = new InvoiceListViewModel
                {
                    //Invoices = _invoiceRepo.GetAllForHouse(id)  .ToList(),
                    Invoices = _invoiceService.GetAll(),
                    //HouseAddress = GetAddress(id)
                };
            }
           
            return View(indexViewModel);

        } // GET: /<controller>/  
         
        // GET: /<controller>/
        public IActionResult Create(int houseId)
        {
            var newInvoice = new Invoice { InvoiceDate = DateTime.Now, HouseId = houseId };

            return View(newInvoice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Invoice invoice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _invoiceRepo.Create(invoice);
                    _invoiceRepo.Save();
                    // _shoppingCart.ClearCart();
                    return RedirectToAction("Index", new { id = invoice.HouseId });
                }
            }
            catch
            {
            }

            return View(invoice);
        }
        public IActionResult InvoiceComplete()
        {
            ViewBag.InvoiceCompleteMsg = "Invoice created successfully!";
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int invoiceId, int houseId)
        {
            Invoice invoice = _invoiceRepo.GetById(invoiceId);
            var categories = _categoryRepository.GetAll; //for dropdown

            if (invoice == null) return RedirectToAction("Index", new { id = houseId });

            var invoiceEditVModel = new InvoiceEditViewModel
            {
                HouseAddress =  (GetAddress(houseId).Item1),
                Categories = categories.Select(c => new SelectListItem()
                { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                Invoice = new InvoiceViewModel
                {
                    InvoiceDate = invoice.InvoiceDate,
                    Amount = invoice.Amount,
                    DatePaid = invoice.DatePaid,
                    IsPaid = invoice.IsPaid,
                    Description = invoice.Description,
                    InvoiceId = invoice.InvoiceId,
                    HouseId = invoice.HouseId
                }
            };

            return View(invoiceEditVModel);
        }
        [HttpPost]
        public IActionResult Edit(InvoiceEditViewModel invoiceVM)
        {
            if (invoiceVM == null)
            {
                ModelState.AddModelError("", "no invoice object has been passed!");
            }
            if (ModelState.IsValid)
            {
                // _invoiceRepo.Edit(invoice ); 
                _invoiceService.Edit(invoiceVM.Invoice.InvoiceId,
                                    invoiceVM.Invoice.HouseId,
                                     invoiceVM.Invoice.InvoiceDate,
                                     invoiceVM.Invoice.Amount,
                                     invoiceVM.Invoice.Description,
                                     invoiceVM.Invoice.IsPaid,
                                     invoiceVM.Invoice.DatePaid);

                return RedirectToAction("Index", new { id = invoiceVM.Invoice.HouseId });

            }
            return View(invoiceVM);
        }
        [HttpGet]
        public IActionResult Delete(int id, bool? saveChangesError = false)
        {
            var invoice = _invoiceService.GetById(id);

            if (invoice == null)
                return NotFound();

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists call your system administrator.";
            }

            var deleteInvoiceViewModel = new DeleteInvoiceViewModel
            {
                InvoiceId = invoice.InvoiceId,
                Description = invoice.Description,
                InvoiceDate = invoice.InvoiceDate,
                HouseId = invoice.HouseId
            };

            return View(deleteInvoiceViewModel);

        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleteInvoiceId = id;
            var invoice = _invoiceService.GetById(deleteInvoiceId);

            if (invoice == null)
                return RedirectToAction(nameof(DeleteConfirmed), new { id = id, saveChangesError = true });

            try
            {
                _invoiceService.Delete(deleteInvoiceId);
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }

            return RedirectToAction(nameof(Index), new { id = invoice.HouseId });

        }
        private (string,string) GetAddress(int houseId)
        {
            House house = _houseRepo.GetById(houseId);
            return ($"{house.StreetNumber} {house.StreetName}",house.Owner.FullName);

        }
        [HttpGet]
        public IActionResult BulkMain()
        { 
            var errMsg = TempData["Message"] as string; 
            return View("BulkMain"); 
        }
        [HttpGet]
        public IActionResult BulkCreate()
        {
            ViewBag.InvoiceTemplateMsg = _config["InvoiceTemplateMsg"];
            ViewBag.InvoiceAmount = _config["InvoiceAmount"];
            TempData["Message"] = "";
  
            if (!Decimal.TryParse(_config["InvoiceAmountHouse"], out _invoiceService.AmountHouse))
            {
                //ModelState.AddModelError("InvoiceAmountTemplate", "The InvoiceAmount in the settings is not a valid amount");
                TempData["Message"] = "Error: Check the Invoice template settings as error on the Amount";

                return RedirectToAction("BulkMain");
            }
            if (!Decimal.TryParse(_config["InvoiceAmountPlot"], out _invoiceService.AmountPlot))
            {
                TempData["Message"] = "Error: Check the Invoice template settings as error on the Plot amount"; 
                return RedirectToAction("BulkMain");
            }
            var invoiceViewModel = _houseRepo.GetAll
                .Select(a => new CreateBulkInvoiceViewModel
                {
                    Invoicev = new InvoiceViewModel
                    {
                        InvoiceDate = DateTime.Now,
                        IsPaid = false,
                        Amount = _invoiceService.CalcInvoiceAmount(a.IsPlot),
                        Description = "Annual Subs 2020",
                        HouseId = a.HouseId
                    },
                    IsCreate = true,
                    StreetNumber = a.StreetNumber,
                    StreetName = a.StreetName,
                    FullName = a.Owner.FullName
                });

            return View(invoiceViewModel.ToList());
        }
        [HttpPost]
        public IActionResult BulkCreate(List<CreateBulkInvoiceViewModel> invoices)
        {
            TempData["Message"] = "";

            try
            {
                if (ModelState.IsValid)
                {
                    int count = _invoiceService.BulkCreate(invoices);
                    //_invoiceRepo.Create(invoice);
                    ////  _shoppingCart.ClearCart();
                    TempData["Message"] = (count > 0) ? $"Successfully created {count} invoices!" : "No invoices created";
                    return RedirectToAction("BulkMain");
                }
            }
            catch
            {
                throw;
            }

            return View(invoices);
        }
    }
}
