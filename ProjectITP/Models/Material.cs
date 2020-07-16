using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class Material
    {

        public int id { get; set; }

        [Required]
        [Display(Name = "Teacher")]
        public String teacher { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
        public int quantity { get; set; }

        [Display(Name ="Material Image")]
        public String materialURL { get; set; }


        public Subject Subject { get; set; }
        [Display(Name ="Enrollment Key")]

        public int SubjectId { get; set; }

        public MaterialTypes MaterialTypes { get; set; }


        [Display(Name ="Material Type")]
        public int MaterialTypesId { get; set; }


    }
}