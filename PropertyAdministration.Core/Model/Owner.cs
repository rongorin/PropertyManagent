using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PropertyAdministration.Core.Model
{
   public class Owner
    { 
        public int OwnerId              { get; set; }
        [Column(TypeName = "varchar(70)")]
        public string FullName          { get; set; }   
        [Column(TypeName = "varchar(70)")]
        public string EmailAddress { get; set; }
        public string Title { get; set; } 
        [Column(TypeName = "varchar(70)")]
        public string EmailAddress2 { get; set; }  
        [Column(TypeName = "varchar(70)")]
        public string PhoneNumber       { get; set; } 
        [Column(TypeName = "varchar(70)")]
        public string PhoneNumber2 { get; set; } 
        [Column(TypeName = "varchar(70)")]
        public string PhoneNumber3 { get; set; }
        public int PropertiesOwned { get; set; }

        public virtual ICollection<House> Houses { get; set; } 
    }
}
