using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class SubjectFee
    {

        public int id { get; set; }

        [Display(Name = "Class Fee")]
        public double fee { get; set; }


        public Subject Subject { get; set; }

        public int SubjectId { get; set; }


    }
}