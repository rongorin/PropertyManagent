using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyAdministration.Application.AppModels;
using PropertyAdministration.Core.Services;

namespace PropertyAdministration.Controllers
{
    public class OwnerController : Controller
    {
        private OwnerService _ownerService;
        public OwnerController(OwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        public IActionResult Index()
        {
            var owners = _ownerService.GetAll();
            return View(owners);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var owner = _ownerService.GetById(id);
              
            if (owner == null) return RedirectToAction("Index" ); 

            var ownerVM  = new OwnerEditViewModel
            { 
                Owner = new OwnerViewModel
                {
                    EmailAddress = owner.EmailAddress, 
                    EmailAddress2 = owner.EmailAddress2,
                    Title = owner.Title,
                    FullName = owner.FullName,
                    OwnerId = owner.OwnerId,
                    PhoneNumber = owner.PhoneNumber,
                    PhoneNumber2 = owner.PhoneNumber2,
                    PhoneNumber3 = owner.PhoneNumber3,
                    PropertiesOwned = owner.PropertiesOwned 
                     
                }
            };

            return View(ownerVM);
        }
        [HttpPost]
        public ActionResult Edit( OwnerEditViewModel ownerVm)
        {
            if (ownerVm == null)
            {
                ModelState.AddModelError("", "no owner object has been passed!");
            }
            if (!ModelState.IsValid)
            {
                return View(ownerVm);
            }

            _ownerService.Edit(ownerVm);
            TempData.Add("ResultMessage", "Owner edited Successfully!");
            return RedirectToAction("Index");
             
        }

        [HttpGet]
        public IActionResult Delete(int id, bool? saveChangesError = false)
        {
            var owner = _ownerService.GetById(id);

            if (owner == null)
                return NotFound();

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Possible due to Owner still linked to house. If persists, call your system administrator.";
            }

            var deleteVM = new OwnerViewModel
            {
                 OwnerId = owner.OwnerId,
                 EmailAddress = owner.EmailAddress,
                 PhoneNumber = owner.PhoneNumber,
                 PropertiesOwned = owner.PropertiesOwned,
                 FullName  = owner.FullName 
            };
             
           return View(deleteVM);

      
        }

        // GET: /<controller>/
        public IActionResult Create(int id)
        {
            var newOwnerViewModel = new OwnerEditViewModel();
          
            return View(newOwnerViewModel);
        }
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OwnerEditViewModel ownerVM)
        {
            try
            {
                //ownerVM.Owner.OwnerId = ownerVM.OwnerId;

                if (ModelState.IsValid)
                {
                    _ownerService.Create(ownerVM);  
                    _ownerService.Save(); //finally commit 

                    TempData.Add("ResultMessage", "Owner created Successfully!");

                    return RedirectToAction("Index" );
                }

                return View(ownerVM);
            }
            catch
            {
            }

            //ownerVM.ownersList = GetownerList();

            return View(ownerVM);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleteId = id;
            var invoice = _ownerService.GetById(deleteId);

            if (invoice == null)
                return RedirectToAction(nameof(Delete), new { id = deleteId, saveChangesError = true });

            try
            {
                _ownerService.Delete(deleteId);
                _ownerService.Save();
                 TempData.Add("ResultMessage", "Owner deleted successfully!");
           
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = deleteId, saveChangesError = true });
            }

            catch (InvalidOperationException )
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = deleteId, saveChangesError = true });
            }
            return RedirectToAction(nameof(Index) );

        }
    }
}