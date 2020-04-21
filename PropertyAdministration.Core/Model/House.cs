using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PropertyAdministration.Core.Model
{
    public class House
    {
        public int HouseId { get; set; }
        public int StreetNumber{ get; set; } 
        [Column(TypeName = "varchar(70)")]
        public string StreetName{ get; set; }
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }
        public int OwnerId {  get; set; }
        [Column(TypeName = "varchar(10)")]
        public string ERF {  get; set; }
        public DateTime DateMoveIn{ get; set; }
        public bool IsPlot { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Owner Owner { get; set; } 

        public virtual ICollection<Invoice> Invoices { get; set; }
        public House()
        {
            Invoices = new Collection<Invoice>();
        }
    }
}
