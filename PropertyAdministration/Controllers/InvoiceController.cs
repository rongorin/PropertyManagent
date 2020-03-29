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


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyAdministration.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceRepository _invoiceRepo;
        private IHouseRepository _houseRepo;
        private ICategoryRepository _categoryRepository;
        private InvoiceService _invoiceService;
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(IInvoiceRepository InvoiceRepository,
                                 IHouseRepository HouseRepository,
                                 ICategoryRepository CategoryRepository,
                                 InvoiceService invoiceService,
                                 ILogger<InvoiceController> logger
                                 )
        {
            _invoiceRepo = InvoiceRepository;
            _houseRepo = HouseRepository;
            _categoryRepository = CategoryRepository;
            _invoiceService = invoiceService;
            _logger = logger;

        }
        // GET: /<controller>/


        public IActionResult Index(int id)
        {
            _logger.LogInformation( "testmeessage in the index");
            var indexViewModel = new  InvoiceListViewModel
            {
                HouseId = id,
                //Invoices = _invoiceRepo.GetAllForHouse(id)  .ToList(),
                Invoices = _invoiceService.GetAllForHouse(id).ToList(),
                HouseAddress = GetAddress(id)
            };
            indexViewModel.InvoicesTotal = indexViewModel.Invoices.Sum(o => o.Amount); 

            return View(indexViewModel);
        }
        // GET: /<controller>/
        public IActionResult Create(int houseId)
        {
            var newInvoice = new Invoice { InvoiceDate = DateTime.Now };

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
                        // _shoppingCart.ClearCart();
                    return RedirectToAction("Index", new { id = invoice.HouseId });
                }
            }
            catch
            { 
            }
            
            return View( );
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
            var categories = _categoryRepository.GetAll  ; //for dropdown

            if (invoice == null) return RedirectToAction("Index", new { id = houseId });

            var invoiceEditVModel = new InvoiceEditViewModel
            { 
                HouseAddress = GetAddress(houseId),
                Categories = categories.Select(c => new SelectListItem() 
                                        { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList() ,
                Invoice = new InvoiceViewModel
                {
                      InvoiceDate = invoice.InvoiceDate,
                      Amount  = invoice.Amount,
                      DatePaid = invoice.DatePaid,
                      IsPaid = invoice.IsPaid,
                      Description = invoice.Description,
                      InvoiceId  = invoice.InvoiceId,
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
            if(ModelState.IsValid)
            {
                // _invoiceRepo.Edit(invoice ); 
                _invoiceService.Edit(invoiceVM.Invoice.InvoiceId ,
                                    invoiceVM.Invoice.HouseId,
                                     invoiceVM.Invoice.InvoiceDate,
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
                 InvoiceId  = invoice.InvoiceId,
                 Description  = invoice.Description,
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
        private string GetAddress(int houseId)
        {
            House house = _houseRepo.GetById(houseId);
            return $"{house.StreetNumber} {house.StreetName}";

        }
    }
}
