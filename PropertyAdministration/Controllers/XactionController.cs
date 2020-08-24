using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyAdministration.Core.Interface;

namespace PropertyAdministration.Controllers
{
    public class XactionController : Controller
    {
        private IXactionsService _xactionService;

        public XactionController(IXactionsService xactionService)
        {
            _xactionService = xactionService;
        }

        // GET: Xaction
        public ActionResult Index(int houseId)
        {
            var result = _xactionService.ReadByHouseId(houseId);
            return View(result);

        }

        // GET: Xaction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Xaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Xaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Xaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Xaction/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Xaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Xaction/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}