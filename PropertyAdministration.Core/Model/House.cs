using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Model
{
    public class House
    {
        public int HouseId { get; set; }
        public int StreetNumber{ get; set; } 
        public string StreetName{ get; set; }
        public string Description { get; set; }
        public int OwnerId {  get; set; }
        public string ERF {  get; set; }
        public DateTime DateMoveIn{ get; set; }
        public bool IsPlot { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Owner Owner { get; set; }
    }
}
