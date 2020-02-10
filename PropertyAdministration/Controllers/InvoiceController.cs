using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyAdministration.Core.Interface;
using PropertyAdministration.Core.Model;
using PropertyAdministration.Core.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyAdministration.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceRepository _invoiceRepo; 
        public InvoiceController(IInvoiceRepository InvoiceRepository)
        {
            _invoiceRepo = InvoiceRepository;
        }
        // GET: /<controller>/

        public IActionResult Index(int houseId)
        { 
            var indexViewModel = new InvoiceListViewModel
            {
                HouseId = houseId,
                Invoices = _invoiceRepo.GetAllForHouse(houseId)
            };
            indexViewModel.InvoicesTotal = indexViewModel.Invoices.Sum(o => o.Amount); 

            return View(indexViewModel);
        }
        // GET: /<controller>/
        public IActionResult Create(int houseId)
        { 
            return View();
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
                    return RedirectToAction("Index", new { houseId = invoice.HouseId });
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
    }
}
