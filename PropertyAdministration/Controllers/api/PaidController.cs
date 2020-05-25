using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyAdministration.Application.AppModels; 
using PropertyAdministration.Core.Services;
using PropertyAdministration.Core.Model;
using Microsoft.AspNetCore.Authorization;
using PropertyAdministration.Application.Dtos;
using PropertyAdministration.Core.Interface;

namespace PropertyAdministration.Controllers.api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaidController : ControllerBase
    {
        private IInvoiceService _invoiceService;
        public PaidController(IInvoiceService invoiceService)
        {  
            _invoiceService = invoiceService;
        }
       //[HttpPost]
        [HttpGet("{id}")]
        public IActionResult SetPaid(  int id)
        {
            try 
            {
                if (_invoiceService.SetPaid(id, true))
                    return Ok();
                else
                    return BadRequest("Update unsuccesful! Possibly invoice doesnt exist.");
            }
            catch
            {
               return  StatusCode(StatusCodes.Status500InternalServerError, $"Failure accessing invoice {id}");
            } 

        }   
    }
}