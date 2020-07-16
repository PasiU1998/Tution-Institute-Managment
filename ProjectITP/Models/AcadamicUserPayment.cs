using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class AcadamicUserPayment
    {
        
        public int Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public double Payment { get; set; }

        [Required]
        [Display(Name ="Teacher Name")]
        public string TeacherName { get; set; }

        [Required]
        [Display(Name ="Teacher Id Number")]
        public int IdNumber { get; set; }



    }
}