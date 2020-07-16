using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{




    public class Student
    {

        public int id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int ApplicationUserId { get; set; }
    }
}