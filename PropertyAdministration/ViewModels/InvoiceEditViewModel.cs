using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAdministration.ViewModels
{
    public class InvoiceEditViewModel
    {
        public InvoiceViewModel Invoice { get; set; }

        public string HouseAddress { get; set; }

         public List<SelectListItem> Categories { get; set; }

         public int CategoryId { get; set; }

    }
}
