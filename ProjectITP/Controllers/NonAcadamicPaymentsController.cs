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
    public class NonAcadamicPaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NonAcadamicPayments
        public ActionResult Index()
        {
            var nonAcadamicPayments = db.nonAcadamicPayments.Include(n => n.NonAcadamicEmployee);
            return View(nonAcadamicPayments.ToList());
        }


        //filter
        [HttpPost]
        public ActionResult Index(int? Year, int? Month)
        {

            var nonAcadamicPayments = db.nonAcadamicPayments.Include(n => n.NonAcadamicEmployee);

            if ((Year != null))
            {
                nonAcadamicPayments = nonAcadamicPayments.Where((e => e.Year == Year));
                nonAcadamicPayments = nonAcadamicPayments.Where(e => e.Month == Month);


            }

            return View(nonAcadamicPayments);
        }


        // GET: NonAcadamicPayments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcadamicPayment nonAcadamicPayment = db.nonAcadamicPayments.Find(id);
            if (nonAcadamicPayment == null)
            {
                return HttpNotFound();
            }
            return View(nonAcadamicPayment);
        }

        // GET: NonAcadamicPayments/Create
        public ActionResult Create()
        {
            ViewBag.NonAcadamicEmployeeId = new SelectList(db.NonAcadamicEmployees, "id", "id");
            return View();
        }

        // POST: NonAcadamicPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,Month,Payment,NonAcadamicEmployeeId")] NonAcadamicPayment nonAcadamicPayment)
        {
            if (ModelState.IsValid)
            {
                db.nonAcadamicPayments.Add(nonAcadamicPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NonAcadamicEmployeeId = new SelectList(db.NonAcadamicEmployees, "id", "id", nonAcadamicPayment.NonAcadamicEmployeeId);
            return View(nonAcadamicPayment);
        }

        // GET: NonAcadamicPayments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcadamicPayment nonAcadamicPayment = db.nonAcadamicPayments.Find(id);
            if (nonAcadamicPayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.NonAcadamicEmployeeId = new SelectList(db.NonAcadamicEmployees, "id", "id", nonAcadamicPayment.NonAcadamicEmployeeId);
            return View(nonAcadamicPayment);
        }

        // POST: NonAcadamicPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,Month,Payment,NonAcadamicEmployeeId")] NonAcadamicPayment nonAcadamicPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nonAcadamicPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NonAcadamicEmployeeId = new SelectList(db.NonAcadamicEmployees, "id", "id", nonAcadamicPayment.NonAcadamicEmployeeId);
            return View(nonAcadamicPayment);
        }

        // GET: NonAcadamicPayments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcadamicPayment nonAcadamicPayment = db.nonAcadamicPayments.Find(id);
            if (nonAcadamicPayment == null)
            {
                return HttpNotFound();
            }
            return View(nonAcadamicPayment);
        }

        // POST: NonAcadamicPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NonAcadamicPayment nonAcadamicPayment = db.nonAcadamicPayments.Find(id);
            db.nonAcadamicPayments.Remove(nonAcadamicPayment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Report
        public ActionResult Reports(string ReportType)
        {

            var nonAcadamicPayments = db.nonAcadamicPayments.Include(n => n.NonAcadamicEmployee);


            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/NonAcadamicPaymentReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "NonAcadamicPaymentDataSet";
            reportDataSource.Value = nonAcadamicPayments.ToList();
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
            Response.AddHeader("content-disposition", "attachment;filename=NonAcadamicPayment_report." + fileNameExtension);
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
