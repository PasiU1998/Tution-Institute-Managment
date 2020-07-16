﻿using System;
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
    
    public class SubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subjects
        public ActionResult Index()
        {
            var subject = db.Subject.Include(s => s.SubjectCategory).Include(u => u.ApplicationUser);
            

            if (User.IsInRole(RoleName.CanManageAll))
                return View(subject.ToList());


            return View("IndexReadOnly",subject.ToList());

        }


        //Subject Report

        public ActionResult Reports(string ReportType)
        {

            var subjects = db.Subject.Include(s => s.SubjectCategory).Include(u => u.ApplicationUser);


            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/SubjectReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "SubjectDataSet";
            reportDataSource.Value = subjects.ToList();
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
            Response.AddHeader("content-disposition", "attachment;filename=Subject_report." + fileNameExtension);
            return File(renderedByte, fileNameExtension);









        }




        // GET: Subjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        //when click the create button loadin the create form
        public ActionResult Create()
        {
            ViewBag.SubjectCategoryId = new SelectList(db.SubjectCategories, "Id", "Type");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Id");
            return View();
        }

        // POST: Subjects/Create
        //to send the data to the database
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,enrollmentKey,grade,SubjectCategoryId,ApplicationUserId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subject.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.SubjectCategoryId = new SelectList(db.SubjectCategories, "Id", "Type");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Id");

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectCategoryId = new SelectList(db.SubjectCategories, "Id", "Type");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Id");
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,enrollmentKey,grade,SubjectCategoryId,ApplicationUserId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectCategoryId = new SelectList(db.SubjectCategories, "Id", "Type");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Id");

            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subject.Find(id);
            db.Subject.Remove(subject);
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
