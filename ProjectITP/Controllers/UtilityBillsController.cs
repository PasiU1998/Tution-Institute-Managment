using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using ProjectITP.Models;

namespace ProjectITP.Controllers
{
    [Authorize]
    public class UtilityBillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UtilityBills
        public ActionResult Index()
        {
            return View(db.UtilityBills.ToList());
        }

        [HttpPost]
        public ActionResult Index(int? Year,int? Month)
        {

            var utilityBills = from emp in db.UtilityBills select emp;

            if ( (Year != null)  )
            {
                utilityBills = utilityBills.Where((e => e.Year == Year) );
                utilityBills = utilityBills.Where(e => e.Month == Month);


            }

            return View(utilityBills);
        }





        // GET: UtilityBills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilityBills utilityBills = db.UtilityBills.Find(id);
            if (utilityBills == null)
            {
                return HttpNotFound();
            }
            return View(utilityBills);
        }

        // GET: UtilityBills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtilityBills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,billNumber,billType,Date,description,price,Year,Month")] UtilityBills utilityBills)
        {
            if (ModelState.IsValid)
            {
                db.UtilityBills.Add(utilityBills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(utilityBills);
        }

        // GET: UtilityBills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilityBills utilityBills = db.UtilityBills.Find(id);
            if (utilityBills == null)
            {
                return HttpNotFound();
            }
            return View(utilityBills);
        }

        // POST: UtilityBills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,billNumber,billType,Date,description,price,Year,Month")] UtilityBills utilityBills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilityBills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(utilityBills);
        }

        // GET: UtilityBills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilityBills utilityBills = db.UtilityBills.Find(id);
            if (utilityBills == null)
            {
                return HttpNotFound();
            }
            return View(utilityBills);
        }

        // POST: UtilityBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UtilityBills utilityBills = db.UtilityBills.Find(id);
            db.UtilityBills.Remove(utilityBills);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //Report

        public ActionResult Reports(string ReportType)
        {

            var utilityBills = db.UtilityBills;


            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/UtilityReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "UtilityDataSet";
            reportDataSource.Value = utilityBills.ToList();
            localReport.DataSources.Add(reportDataSource);
            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension;

            if (reportType == "Excel")
            {
                fileNameExtension = "xlsx";
            }
            else if (reportType == "Word")
            {
                fileNameExtension = "docx";
            }
            else if (reportType == "Pdf")
            {
                fileNameExtension = "pdf";
            }
            else
            {
                fileNameExtension = "jpg";
            }


            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = localReport.Render(reportType, "",
                out mimeType, out encoding, out fileNameExtension, out streams,
                out warnings);
            Response.AddHeader("content-disposition", "attachment;filename=UtilityBills_report." + fileNameExtension);
            return File(renderedByte, fileNameExtension);









        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
