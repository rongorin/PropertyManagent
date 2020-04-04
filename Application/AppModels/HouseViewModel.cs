using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAdministration.ViewModels
{
    public class HouseViewModel
    {
        public int HouseId { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public string ERF { get; set; }
        public DateTime DateMoveIn { get; set; }
        public bool IsPlot { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        //public OwnerViewModel Owner { get; set; }
         
    }
}
