using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PropertyAdministration.Application.AppModels
{
    public class OwnerViewModel
    {
        public int OwnerId { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter in the Full Name")]
        [StringLength(60)]
        [Display(Name = "Full name")] 
        public string FullName { get; set; }
        [Required]
        [StringLength(70)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
            //[RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            //ErrorMessage = "The email address is not entered in a correct format")]
        public string EmailAddress { get; set; }

            //[RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            //ErrorMessage = "The email address is not entered in a correct format")]
        [Display(Name = "Email #2")]
        public string EmailAddress2 { get; set; }

        [Required(ErrorMessage = "Please enter a phone number")]
        [StringLength(70)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [StringLength(70)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number#2")]
        public string PhoneNumber2 { get; set; }
        [StringLength(70)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number#3")]
        public string PhoneNumber3 { get; set; }
        public int PropertiesOwned { get; set; }
    }

}
