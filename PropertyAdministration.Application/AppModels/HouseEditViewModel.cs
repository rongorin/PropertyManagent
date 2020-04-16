
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace PropertyAdministration.Application.AppModels
{
    public class HouseEditViewModel
    { 
            public HouseViewModel House { get; set; }
            public List<SelectListItem> Categories { get; set; }
            public int CategoryId { get; set; }
            public List<SelectListItem> Owners { get; set; }
            public int OwnerId { get; set; }

    }
}
