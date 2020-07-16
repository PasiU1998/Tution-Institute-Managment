using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectITP.Controllers
{
    [Authorize]
    public class ExamManagemntController : Controller
    {
        // GET: ExamManagemnt
        public ActionResult Index()
        {
            return View();
        }
    }
}