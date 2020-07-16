using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class Subject
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Subject Name")]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "Only Strings are allowed")]
        public string  name { get; set; }

        [Required]
        [Display(Name = "Enrollment Key")]
        [RegularExpression("^[0-9]*$", ErrorMessage ="Only numbers allowed")]
        public int enrollmentKey { get; set; }

        [Required]
        [Display(Name = "Grade")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only Numbers allowed")]
        public int grade { get; set; }


                public SubjectCategory SubjectCategory { get; set; }
 

        [Display(Name ="Type")]
                public int SubjectCategoryId { get; set; }

              


        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name ="Teacher ID")]
        public int ApplicationUserId { get; set; }
        

    }
}