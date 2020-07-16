using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class Profit
    {

        public int Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        [Display(Name ="Teacher's Payment")]
        public double TeacherPayment { get; set; }

        [Required]
        [Display(Name ="Non Acadamic's Payment")]
        public double NonAcadamicPayment { get; set; }

        [Required]
        [Display(Name ="Utility Payment")]
        public double UtilityPayment { get; set; }

        [Required]
        [Display(Name ="Other Payment")]
        public double Others { get; set; }

        [Required]
        [Display(Name = "Monthly Income")]
        public double MonthlyIncome { get; set; }


    }
}