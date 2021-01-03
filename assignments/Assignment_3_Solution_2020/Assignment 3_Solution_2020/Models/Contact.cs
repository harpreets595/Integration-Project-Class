using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone_4A.Models {

    public class Contact {

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "First name cannot contain numbers")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[^0-9]+$", ErrorMessage = "Last name cannot contain numbers")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("[A-z][0-9][A-z][- ]?[0-9][A-z][0-9]", ErrorMessage = "Must be a valid postal code (X1X 1X1)")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@".*@.*\.\w{2,}", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        
        [Required]
        public string Topic { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        
        [Required]
        public string Message { get; set; }
    }
}
