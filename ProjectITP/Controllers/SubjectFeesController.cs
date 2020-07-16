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
    public class SubjectFeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubjectFees
        public ActionResult Index()
        {
            var subjectFee = db.SubjectFee.Include(s => s.Subject);
            return View(subjectFee.ToList());
        }

        //Subject Fee Report

        public ActionResult Reports(string ReportType)
        {

            var materials = db.SubjectFee.Include(s => s.Subject);

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/SubjectFeeReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "SubjectFeeDataSet";
            reportDataSource.Value = materials.ToList();
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
            Response.AddHeader("content-disposition", "attachment;filename=SubjectFee_report." + fileNameExtension);
            return File(renderedByte, fileNameExtension);









        }

        // GET: SubjectFees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectFee subjectFee = db.SubjectFee.Find(id);
            if (subjectFee == null)
            {
                return HttpNotFound();
            }
            return View(subjectFee);
        }

        // GET: SubjectFees/Create
        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey");
            return View();
        }

        // POST: SubjectFees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fee,SubjectId")] SubjectFee subjectFee)
        {
            if (ModelState.IsValid)
            {
                db.SubjectFee.Add(subjectFee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey", subjectFee.SubjectId);
            return View(subjectFee);
        }

        // GET: SubjectFees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectFee subjectFee = db.SubjectFee.Find(id);
            if (subjectFee == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey", subjectFee.SubjectId);
            return View(subjectFee);
        }

        // POST: SubjectFees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fee,SubjectId")] SubjectFee subjectFee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectFee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey", subjectFee.SubjectId);
            return View(subjectFee);
        }

        // GET: SubjectFees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectFee subjectFee = db.SubjectFee.Find(id);
            if (subjectFee == null)
            {
                return HttpNotFound();
            }
            return View(subjectFee);
        }

        // POST: SubjectFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectFee subjectFee = db.SubjectFee.Find(id);
            db.SubjectFee.Remove(subjectFee);
            db.SaveChanges();
            return RedirectToAction("Index");
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
