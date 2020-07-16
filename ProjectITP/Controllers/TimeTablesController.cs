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
    
    public class TimeTablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeTables
        
        public ActionResult Index()
        {

            var timeTable = db.TimeTables.ToList();

            if (User.IsInRole(RoleName.CanManageAll))
                return View(timeTable);

            return View("IndexReadOnly", timeTable);
        }


        //Time Table Report

        public ActionResult Reports(string ReportType)
        {

            var timeTable = db.TimeTables.ToList();


            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/TimeTableReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "TimeTableDataSet";
            reportDataSource.Value = timeTable.ToList();
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
            Response.AddHeader("content-disposition", "attachment;filename=TimeTable_report." + fileNameExtension);
            return File(renderedByte, fileNameExtension);









        }




        // GET: TimeTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // GET: TimeTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Grade,Year,TimeTableImage")] TimeTable timeTable , HttpPostedFileBase UploadFile)
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
                        timeTable.TimeTableImage = UploadFile.FileName;
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



                db.TimeTables.Add(timeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeTable);
        }

        // GET: TimeTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // POST: TimeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Grade,Year,TimeTableImage")] TimeTable timeTable , HttpPostedFileBase UploadFile)
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
                        timeTable.TimeTableImage = UploadFile.FileName;
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




                db.Entry(timeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeTable);
        }

        // GET: TimeTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeTable timeTable = db.TimeTables.Find(id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            return View(timeTable);
        }

        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeTable timeTable = db.TimeTables.Find(id);
            db.TimeTables.Remove(timeTable);
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
