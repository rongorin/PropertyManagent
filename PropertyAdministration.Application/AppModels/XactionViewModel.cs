using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Application.AppModels
{
    public class XactionViewModel
    { 
        public int Id { get; set; } 
        public int HouseId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
