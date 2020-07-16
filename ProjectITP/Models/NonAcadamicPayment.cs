using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class NonAcadamicPayment
    {

        public int Id { get; set; }

        [Required]
        public int Year { get; set; }
        [Required]
        public int Month { get; set; }

        [Required]
        public double Payment { get; set; }

        
        public NonAcadamicEmployee NonAcadamicEmployee { get; set; }

        [Display(Name ="Employee Id")]
        public int NonAcadamicEmployeeId { get; set; }


    }
}