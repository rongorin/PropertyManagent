using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace PropertyAdministration.Application.AppModels
{
    public class HouseViewModel
    {
        public int HouseId { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public string FullName { get; set; }
        public string ERF { get; set; }

        [Required(ErrorMessage = "Enter a moved in date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name = "Moved-In Date")]
        public DateTime DateMoveIn { get; set; }
        public bool IsPlot { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        //public OwnerViewModel Owner { get; set; }
         
    }
}
