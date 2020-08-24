using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyAdministration.Core.Model
{
    public class Xaction
    { 
        public int Id  { get; private set; }
        public int HouseId { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime XactionDate { get; private set; }  
        public bool IsCanceled { get; private set; }

        public Xaction(int id, int houseId, string description, decimal amount )
        {
            Id = id;
            HouseId = houseId;
            Amount = amount;
            Description = description;
        } 
        public void SetXactionDate(DateTime date)
        {
            this.XactionDate = date;
        } 
        public bool MaximumAmount() => this.Amount > 20000.00M;

        public void Cancel() => IsCanceled = true;
       

    }
}
