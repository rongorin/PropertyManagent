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
using System.Diagnostics;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyAdministration.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IConfiguration _config;
         
         
        private IHouseService _houseService; 
        private IInvoiceService _invoiceService;

        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(IInvoiceService invoiceService,
                                 IHouseService houseService,
                                 ILogger<InvoiceController> logger,
                                 IConfiguration config)
        {   
            _invoiceService = invoiceService;
            _houseService = houseService;  
             _logger = logger;
            _config = config; 
        }
        
        // GET: /<controller>/  
        public IActionResult Index(int? id)
        {
            _logger.LogInformation("testmeessage in the index");

            return View( GetListing(id ?? null));

        }  
          
        // GET: /<controller>/
        public IActionResult Create(int houseId)
        {  
            var newInvoiceViewModel = new InvoiceNewViewModel
            {
                Invoice = new InvoiceViewModel { InvoiceDate = DateTime.Now, HouseId = houseId },
                HouseId = houseId, 
                HousesList = GetHouseList()
            };
              
            return View(newInvoiceViewModel);
        }

        private List<SelectListItem> GetHouseList()
        {
            var houses = _houseService.GetAll(null); 
            var housesList = houses.Select(c => new SelectListItem
            {
                Text = $"{c.StreetNumber} {c.StreetName}",
                Value = c.HouseId.ToString() 
            }).ToList();
            return housesList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InvoiceNewViewModel invoiceVM)
        {
            try
            {
                invoiceVM.Invoice.HouseId = invoiceVM.HouseId;

                if (ModelState.IsValid)
                {
                    _invoiceService.Create(invoiceVM.Invoice.InvoiceId,
                                      invoiceVM.HouseId,
                                       invoiceVM.Invoice.InvoiceDate,
                                       invoiceVM.Invoice.Amount,
                                       invoiceVM.Invoice.Description,
                                       invoiceVM.Invoice.IsPaid,
                                       invoiceVM.Invoice.DatePaid);

                     _invoiceService.Save();  
                    TempData.Add("ResultMessage", "Invoice created Successfully!"); 
                     
                    return RedirectToAction("Index", new { id = invoiceVM.HouseId  });
                }
            }
            catch
            {
                ViewData["ErrorMessage"] = "Create failed ";
            }

            invoiceVM.HousesList = GetHouseList();

            return View(invoiceVM);
        }
        public IActionResult InvoiceComplete()
        {
            ViewBag.InvoiceCompleteMsg = "Invoice created successfully!";
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int invoiceId, int houseId)
        {
            Invoice invoice = _invoiceService.GetById(invoiceId); 

            if (invoice == null) return RedirectToAction("Index", new { id = houseId });

            var invoiceEditVModel = new InvoiceEditViewModel
            {
                HouseAddress =  (GetAddress(houseId).Item1),
               
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
                _invoiceService.Edit(invoiceVM.Invoice.InvoiceId,
                                    invoiceVM.Invoice.HouseId,
                                     invoiceVM.Invoice.InvoiceDate,
                                     invoiceVM.Invoice.Amount,
                                     invoiceVM.Invoice.Description,
                                     invoiceVM.Invoice.IsPaid, 
                                     invoiceVM.Invoice.DatePaid);

                TempData.Add("ResultMessage", String.Format("Invoice for {0} edited successfully!", invoiceVM.HouseAddress));
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

            var deleteVM = new DeleteInvoiceViewModel
            {
                InvoiceId = invoice.InvoiceId,
                Amount = invoice.Amount,
                Description = invoice.Description,
                InvoiceDate = invoice.InvoiceDate,
                HouseId = invoice.HouseId,
                HouseAddress = $"{invoice.House.StreetNumber} {invoice.House.StreetName}"
            };

            return View(deleteVM);

        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleteInvoiceId = id;
            var invoice = _invoiceService.GetById(deleteInvoiceId);

            if (invoice == null)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });

            try
            {
                _invoiceService.Delete(deleteInvoiceId);
                _invoiceService.Save();
                 TempData.Add("ResultMessage", "Invoice deleted successfully!");
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
            var house = _houseService.GetById(houseId);
            return ($"{house.StreetNumber} {house.StreetName}", house.FullName);

        }
        [HttpGet]
        public IActionResult BulkMain()
        { 
            var errMsg = TempData["Message"] as string;

            //ViewBag.InvoiceTemplateMsg = _config["InvoiceTemplateMsg"];
            //ViewBag.InvoiceAmount = _config["InvoiceAmount"];


            InvoiceBulkMainViewModel invoiceBulkMainViewModel = new InvoiceBulkMainViewModel
            {
                InvoiceTemplateMsg = "Type in description of invoice",
                InvoiceAmountPlot = 0,
                InvoiceAmountHouse = 0
            };

            return View(invoiceBulkMainViewModel);
        }
        [HttpPost]
        public IActionResult BulkMain(InvoiceBulkMainViewModel bulkMainVm)
        {
            TempData["TemplateMessage"] = bulkMainVm.InvoiceTemplateMsg;

            if (!ModelState.IsValid)
                return View(bulkMainVm);

            //if (!Decimal.TryParse(bulkMainVm.InvoiceAmount, out _invoiceService.AmountHouse))
            //{
            //    //ModelState.AddModelError("InvoiceAmountTemplate", "The InvoiceAmount in the settings is not a valid amount");
            //    TempData["Message"] = "Error: Check the Invoice template settings as error on the Amount";

            //    return RedirectToAction("BulkMain");
            //}
            //if (!Decimal.TryParse(_config["InvoiceAmountPlot"], out _invoiceService.AmountPlot))
            //{
            //    TempData["Message"] = "Error: Check the Invoice template settings as error on the Plot amount";
            //    return RedirectToAction("BulkMain");
            //}


            return RedirectToAction("BulkCreate","Invoice", bulkMainVm);
             

        }
        [HttpGet]
        public IActionResult BulkCreate(InvoiceBulkMainViewModel bulkMainVm)
        {
            Debug.WriteLine(bulkMainVm.InvoiceTemplateMsg); 
 
            TempData["Message"] = "";

            _invoiceService.AmountPlot = bulkMainVm.InvoiceAmountPlot;
            _invoiceService.AmountHouse = bulkMainVm.InvoiceAmountHouse; 

            //if (!Decimal.TryParse(_config["InvoiceAmountPlot"], out _invoiceService.AmountPlot))
            //{
            //    TempData["Message"] = "Error: Check the Invoice template settings as error on the Plot amount"; 
            //    return RedirectToAction("BulkMain");
            //} 

            var bulkInvoiceViewModel = _houseService.GetAll(null)
                .Select(a => new CreateBulkInvoiceViewModel
                {  
                    Invoicev = new InvoiceViewModel
                    {
                        InvoiceDate = DateTime.Now,
                        IsPaid = false,
                        Amount = _invoiceService.CalcInvoiceAmount(a.IsPlot),
                        Description = bulkMainVm.InvoiceTemplateMsg,
                        HouseId = a.HouseId
                    },
                    IsCreate = true,
                    StreetNumber = a.StreetNumber,
                    StreetName = a.StreetName,
                    FullName =  a.FullName
                }) ;

            return View(bulkInvoiceViewModel.ToList());
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
        private InvoiceListVM GetListing(int? id)
        {
            if (id.HasValue && id == 0)
                id = null;

            InvoiceListVM indexVM;
            if (id.HasValue)
            {
                indexVM = new InvoiceListVM
                {
                    invoiceListViewModel = _invoiceService.GetAllForHouse(id.Value)
                    .Select(a => new InvoiceListViewModel
                    {
                        FullName = a.House.Owner.FullName,
                        Invoicev = new Invoice
                        {
                            Amount = a.Amount,
                            DatePaid = a.DatePaid,
                            Description = a.Description,
                            InvoiceDate = a.InvoiceDate,
                            IsPaid = a.IsPaid,
                            InvoiceId = a.InvoiceId,
                            HouseId = a.HouseId

                        },
                        HouseAddress = $"{a.House.StreetNumber} {a.House.StreetName } ",
                        HouseId = a.HouseId
                    }).ToList()
                };

                indexVM.InvoicesTotal = indexVM.invoiceListViewModel.Where(a => a.Invoicev.IsPaid==false).Sum(a => a.Invoicev.Amount);
                indexVM.ListingHeader = $"{indexVM.invoiceListViewModel.Select(a => a.HouseAddress).FirstOrDefault()} - {indexVM.invoiceListViewModel.Select(a => a.FullName).FirstOrDefault()}";
                indexVM.HouseId = id.Value;

            }
            else
            {

                indexVM = new InvoiceListVM
                {
                    invoiceListViewModel = _invoiceService.GetAll()
                    .Select(a => new InvoiceListViewModel
                    {
                        FullName = a.House.Owner.FullName,
                        Invoicev = new Invoice
                        {
                            Amount = a.Amount,
                            DatePaid = a.DatePaid,
                            Description = a.Description,
                            InvoiceDate = a.InvoiceDate,
                            IsPaid = a.IsPaid,
                            InvoiceId = a.InvoiceId,
                            HouseId = a.HouseId
                        },
                        HouseAddress = $"{a.House.StreetNumber} {a.House.StreetName } ",
                        HouseId = a.HouseId,

                    }).ToList()
                };

                indexVM.ListAll = true;
                indexVM.InvoicesTotal = indexVM.invoiceListViewModel.Where(a => a.Invoicev.IsPaid == false).Sum(a => a.Invoicev.Amount);
                indexVM.ListingHeader = "Invoices for all properties";


            }
            return indexVM;

        }

    }
}