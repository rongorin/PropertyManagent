using System.Collections.Generic;

namespace PropertyAdministration.Core.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName{ get; set; }
        public string Description { get; set; }
        public List<House> Houses { get; set; }
    }
}