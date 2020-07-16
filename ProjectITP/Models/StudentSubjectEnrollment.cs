using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectITP.Models
{
    public class StudentSubjectEnrollment
    {

        public int Id { get; set; }


        public string Date { get; set; }
    /*    public ApplicationUser ApplicationUser { get; set; }

        public int ApplicationUserId { get; set; }
        */
        public Subject Subject { get; set; }

        public int? SubjectId { get; set; }

    }
}