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
        [Required(ErrorMessage = "Enter a number")]
        public int StreetNumber { get; set; }
        [Required(ErrorMessage = "Enter a streetname")]
        [StringLength(70)]
        public string StreetName { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public string FullName { get; set; }
        [StringLength(10)]
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
        public string CategoryName { get; set; }

    }
}
    