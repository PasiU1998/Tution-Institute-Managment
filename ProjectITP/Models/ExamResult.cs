using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class ExamResult
    {
        public int Id { get; set; }


        [Required]
        public int Grade { get; set; }
       
        
        [Display(Name ="URL")]
        public string Resultpdf { get; set; }


        
        
        public Subject Subject { get; set; }

        [Display(Name ="Enroolment Key")]
        public int SubjectId { get; set; }


    }
}