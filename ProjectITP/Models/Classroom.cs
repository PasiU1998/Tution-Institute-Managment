using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class Classroom
    {

        public int id { get; set; }

        [Required]
        [Display(Name = "Class Name")]
        public string className { get; set; }

        [Required]
        [Display(Name = "Building")]
        public string building { get; set; }

        [Required]
        [Display(Name = "Floor")]
        public string floor { get; set; }

        [Required]
        [Display(Name = "Capacity")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public int capasity { get; set; }

        [Required]
        [Display(Name = "Description")]
       
        public string description { get; set; }


    }
}