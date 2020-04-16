using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PropertyAdministration.Application.AppModels
{
   public class OwnerListViewModel
    {

        public OwnerViewModel OwnerViewModel { get; set; }
        [Display(Name = "House")]
        // public List<SelectListItem> HousesList { get; set; }
        public int OwnerId { get; set; }
        public int HouseId { get; set; }

    }
}
