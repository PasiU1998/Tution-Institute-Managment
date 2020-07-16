using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectITP.Models;

namespace ProjectITP.ViewModels
{
    public class UserCustomViewModel
    {
        public IEnumerable<UserTypes> UserTypes { get; set; }


        public RegisterViewModel User { get; set; }


    }
}