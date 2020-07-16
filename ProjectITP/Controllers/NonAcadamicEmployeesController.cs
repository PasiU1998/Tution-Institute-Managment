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
    public class NonAcadamicEmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NonAcadamicEmployees
        public ActionResult Index()
        {
            return View(db.NonAcadamicEmployees.ToList());
        }



        //Non Acadamic Employees Report

        public ActionResult Reports(string ReportType)
        {

            var nonAcadamic = db.NonAcadamicEmployees.ToList();


            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/NonAcadamicReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "NonAcadamicDataSet";
            reportDataSource.Value = nonAcadamic.ToList();
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
            Response.AddHeader("content-disposition", "attachment;filename=NonAcadamicEmployee_report." + fileNameExtension);
            return File(renderedByte, fileNameExtension);









        }


        // GET: NonAcadamicEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcadamicEmployee nonAcadamicEmployee = db.NonAcadamicEmployees.Find(id);
            if (nonAcadamicEmployee == null)
            {
                return HttpNotFound();
            }
            return View(nonAcadamicEmployee);
        }

        // GET: NonAcadamicEmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NonAcadamicEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,email,PhoneNumber,address")] NonAcadamicEmployee nonAcadamicEmployee)
        {
            if (ModelState.IsValid)
            {
                db.NonAcadamicEmployees.Add(nonAcadamicEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nonAcadamicEmployee);
        }

        // GET: NonAcadamicEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcadamicEmployee nonAcadamicEmployee = db.NonAcadamicEmployees.Find(id);
            if (nonAcadamicEmployee == null)
            {
                return HttpNotFound();
            }
            return View(nonAcadamicEmployee);
        }

        // POST: NonAcadamicEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,email,PhoneNumber,address")] NonAcadamicEmployee nonAcadamicEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nonAcadamicEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nonAcadamicEmployee);
        }

        // GET: NonAcadamicEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NonAcadamicEmployee nonAcadamicEmployee = db.NonAcadamicEmployees.Find(id);
            if (nonAcadamicEmployee == null)
            {
                return HttpNotFound();
            }
            return View(nonAcadamicEmployee);
        }

        // POST: NonAcadamicEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NonAcadamicEmployee nonAcadamicEmployee = db.NonAcadamicEmployees.Find(id);
            db.NonAcadamicEmployees.Remove(nonAcadamicEmployee);
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
