using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class UtilityBills
    {

        public int id { get; set; }

        [Required]
        [Display(Name = "Bill Number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public int billNumber { get; set; }

        [Required]
        [Display(Name = "Bill Type")]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Only Strings are allowed")]
        public string billType { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Description")]
        
        public string description { get; set; }

        [Required]
        [Display(Name = "Price")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public double price { get; set; }

        [Required]
        [Display(Name = "Total")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public double total { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }



    }
}