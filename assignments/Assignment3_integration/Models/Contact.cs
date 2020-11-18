using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_integration.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength =2)]
        public string LastName { get; set; }
        
        [Required]
        [DataType(DataType.PostalCode)]
        [RegularExpression("^[ABCEGHJ-NPRSTVXYabceghj-nprstvxy]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Zabceghj-nprstv-z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Zabceghj-nprstv-z]{1}[0-9]{1}$", ErrorMessage = "Postal Code format accepted: [J7V 0H1]")]
        public string PostalCode { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        public string Topic { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
