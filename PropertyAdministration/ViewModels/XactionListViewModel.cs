using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyAdministration.ViewModels
{
    public class XactionListViewModel
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool IsCancelled { get; set; }
    }
}
