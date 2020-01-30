using PropertyAdministration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.ViewModels
{
    public class HouseListViewModel
    {
        public IEnumerable<House> Houses { get; set; }
        public string CurrentCategory { get; set; } 
    }
}
