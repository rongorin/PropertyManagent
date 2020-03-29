using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PropertyAdministration.Controllers
{
    public class AppExceptionController : Controller
    {
        //just to return an empty page!
        public IActionResult Index()
        {
            return View();
        }
    }
}