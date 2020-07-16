using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class NonAcadamicEmployee
    {

        public int id { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Only Strings are allowed")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string  email { get; set; }

        [Required]
        [Display(Name ="Phone Number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public int PhoneNumber { get; set; }
        
        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }


        public string ProfileImageUrl { get; set; }

    }
}