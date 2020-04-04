 using System.Web.mv
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAdministration.ViewModels
{
    public class HouseEditViewModel
    { 
            public HouseViewModel House { get; set; }
            public List<SelectListItem> Categories { get; set; }
            public int CategoryId { get; set; } 
    }
}
