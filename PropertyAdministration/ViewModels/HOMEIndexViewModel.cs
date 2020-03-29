using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.ViewModels
{
    public class HOMEIndexViewModel
    {
        // public IEnumerable<House> Houses { get; set; }
        public int HouseId { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Description { get; set; } 
        public string ERF { get; set; }
        public DateTime DateMoveIn { get; set; }
        public bool IsPlot { get; set; } 
        public string CategoryName { get; set; }
        public decimal InvoicesBalance { get; set; }
        public string FullName { get; set; }
        // public Category Category { get; set; }
        // public Owner Owner { get; set; }
        //public virtual ICollection<Invoice> Invoices { get; set; }
    }

}
