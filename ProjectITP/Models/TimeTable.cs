using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class TimeTable
    {

        public int id { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public int Grade { get; set; }

        [Required]

        public string Year { get; set; }

        [Display(Name ="Time Table Image")]
        public string TimeTableImage { get; set; }


    }
}