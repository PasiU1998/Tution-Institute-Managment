using ProjectITP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectITP.Controllers
{
    [Authorize]

    //[Authorize(Roles = RoleName.CanManageAll)]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult HomeForStudentManagment()
        {
            return View();
        }


        public ActionResult StudentList()
        {
            return View();
        }


    }
}