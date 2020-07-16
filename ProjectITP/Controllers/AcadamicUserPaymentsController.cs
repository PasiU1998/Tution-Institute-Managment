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
    public class AcadamicUserPaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AcadamicUserPayments
        public ActionResult Index()
        {
            return View(db.acadamicUserPayments.ToList());
        }


        //Filter
        [HttpPost]
        public ActionResult Index(int? Year, int? Month)
        {

            var acadamicUserPayments = from emp in db.acadamicUserPayments select emp;

            if ((Year != null))
            {
                acadamicUserPayments = acadamicUserPayments.Where((e => e.Year == Year));
                acadamicUserPayments = acadamicUserPayments.Where(e => e.Month == Month);


            }

            return View(acadamicUserPayments);
        }





        // GET: AcadamicUserPayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcadamicUserPayment acadamicUserPayment = db.acadamicUserPayments.Find(id);
            if (acadamicUserPayment == null)
            {
                return HttpNotFound();
            }
            return View(acadamicUserPayment);
        }

        // GET: AcadamicUserPayments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcadamicUserPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,Month,Payment,TeacherName,IdNumber")] AcadamicUserPayment acadamicUserPayment)
        {
            if (ModelState.IsValid)
            {
                db.acadamicUserPayments.Add(acadamicUserPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acadamicUserPayment);
        }

        // GET: AcadamicUserPayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcadamicUserPayment acadamicUserPayment = db.acadamicUserPayments.Find(id);
            if (acadamicUserPayment == null)
            {
                return HttpNotFound();
            }
            return View(acadamicUserPayment);
        }

        // POST: AcadamicUserPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,Month,Payment,TeacherName,IdNumber")] AcadamicUserPayment acadamicUserPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acadamicUserPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acadamicUserPayment);
        }

        // GET: AcadamicUserPayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcadamicUserPayment acadamicUserPayment = db.acadamicUserPayments.Find(id);
            if (acadamicUserPayment == null)
            {
                return HttpNotFound();
            }
            return View(acadamicUserPayment);
        }

        // POST: AcadamicUserPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcadamicUserPayment acadamicUserPayment = db.acadamicUserPayments.Find(id);
            db.acadamicUserPayments.Remove(acadamicUserPayment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Report
        public ActionResult Reports(string ReportType)
        {

            var acadamicUserPayments = db.acadamicUserPayments;


            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/AcadamicPaymentReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "AcadamicPaymentDataSet";
            reportDataSource.Value = acadamicUserPayments.ToList();
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
            Response.AddHeader("content-disposition", "attachment;filename=AcadamicUserPayment_report." + fileNameExtension);
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
