using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Practice_as3.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength =2)]
        [RegularExpression("^[a-zA-Z ]*$",ErrorMessage ="First Name must be between 2 and 50 characters.")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage ="Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }


        //public string PostalCode { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Topic { get; set; }

        public string Message { get; set; }
    }
}
