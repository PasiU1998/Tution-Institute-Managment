using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class Exam
    {

        public int Id { get; set; }
        
        [Required]
        public string Location { get; set; }
        
        [Required]
        public string Date { get; set; }
        
        [Required]
        public string Time { get; set; }

        
        public ExamType ExamType { get; set; }

        [Display(Name ="Exam Type")]
        public int ExamTypeId { get; set; }

        public Subject Subject { get; set; }


        [Display(Name ="Subject Enrolment Key")]
        public int SubjectId { get; set; }
    }
}