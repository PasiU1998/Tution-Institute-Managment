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
    public class ExamResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExamResults
        public ActionResult Index()
        {
            var examResult = db.ExamResult.Include(e => e.Subject);
            

            if (User.IsInRole(RoleName.CanManageAll))
                return View(examResult.ToList());


            return View("IndexReadOnly", examResult.ToList());

        }

        // GET: ExamResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = db.ExamResult.Find(id);
            if (examResult == null)
            {
                return HttpNotFound();
            }
            return View(examResult);
        }

        // GET: ExamResults/Create
        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey");
            return View();
        }

        // POST: ExamResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Grade,Resultpdf,SubjectId")] ExamResult examResult , HttpPostedFileBase UploadFile)
        {
            if (ModelState.IsValid)
            {
                if (UploadFile != null)
                {

                    if (UploadFile.ContentType == "image/jpg" || UploadFile.ContentType == "image/png" ||
                        UploadFile.ContentType == "image/gif" || UploadFile.ContentType == "image/jpeg" ||
                        UploadFile.ContentType == "application/pdf")
                    {
                        UploadFile.SaveAs(Server.MapPath("/") + "/Images/" + UploadFile.FileName);
                        examResult.Resultpdf = UploadFile.FileName;
                    }
                    else
                    {
                        return View();
                    }

                }
                else
                {
                    return View();
                }







                db.ExamResult.Add(examResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey", examResult.SubjectId);
            return View(examResult);
        }

        // GET: ExamResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = db.ExamResult.Find(id);
            if (examResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey", examResult.SubjectId);
            return View(examResult);
        }

        // POST: ExamResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Grade,Resultpdf,SubjectId")] ExamResult examResult, HttpPostedFileBase UploadFile)
        {
            if (ModelState.IsValid)
            {

                if (UploadFile != null)
                {

                    if (UploadFile.ContentType == "image/jpg" || UploadFile.ContentType == "image/png" ||
                        UploadFile.ContentType == "image/gif" || UploadFile.ContentType == "image/jpeg" ||
                        UploadFile.ContentType == "application/pdf")
                    {
                        UploadFile.SaveAs(Server.MapPath("/") + "/Images/" + UploadFile.FileName);
                        examResult.Resultpdf = UploadFile.FileName;
                    }
                    else
                    {
                        return View();
                    }

                }
                else
                {
                    return View();
                }






                db.Entry(examResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey", examResult.SubjectId);
            return View(examResult);
        }

        // GET: ExamResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = db.ExamResult.Find(id);
            if (examResult == null)
            {
                return HttpNotFound();
            }
            return View(examResult);
        }

        // POST: ExamResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamResult examResult = db.ExamResult.Find(id);
            db.ExamResult.Remove(examResult);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Exam Result Report
        public ActionResult Reports(string ReportType)
        {

            var examsResuuls = db.ExamResult.Include(e => e.Subject);


            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/ExamResultReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "ExamResultDataSet";
            reportDataSource.Value = examsResuuls.ToList();
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
            Response.AddHeader("content-disposition", "attachment;filename=ExamsResult_report." + fileNameExtension);
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
