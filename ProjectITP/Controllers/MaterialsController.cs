using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectITP.Models;
using Microsoft.Reporting.WebForms;

namespace ProjectITP.Controllers
{
    [Authorize]
    public class MaterialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Materials
        public ActionResult Index()
        {
            var materials = db.Materials.Include(m => m.MaterialTypes).Include(m => m.Subject);

            if (User.IsInRole(RoleName.CanManageAll))
                return View(materials.ToList());


            return View("IndexReadOnly",materials.ToList());
        }

        // GET: Materials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: Materials/Create
        public ActionResult Create()
        {
            ViewBag.MaterialTypesId = new SelectList(db.MaterialTypes, "id", "type");
            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey");
            return View();
        }

        // POST: Materials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,teacher,quantity,materialURL,SubjectId,MaterialTypesId")] Material material , HttpPostedFileBase UploadFile)
        {
            if (ModelState.IsValid)
            {

                if(UploadFile != null)
                {

                    if(UploadFile.ContentType == "image/jpg" || UploadFile.ContentType == "image/png" ||
                        UploadFile.ContentType == "image/gif" || UploadFile.ContentType == "image/jpeg" ||
                        UploadFile.ContentType == "application/pdf")
                    {
                        UploadFile.SaveAs(Server.MapPath("/") + "/Images/" + UploadFile.FileName);
                        material.materialURL = UploadFile.FileName;
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



                db.Materials.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaterialTypesId = new SelectList(db.MaterialTypes, "id", "type", material.MaterialTypesId);
            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey", material.SubjectId);
            return View(material);
        }

        // GET: Materials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaterialTypesId = new SelectList(db.MaterialTypes, "id", "type", material.MaterialTypesId);
            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey", material.SubjectId);
            return View(material);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,teacher,quantity,materialURL,SubjectId,MaterialTypesId")] Material material , HttpPostedFileBase UploadFile)
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
                        material.materialURL = UploadFile.FileName;
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






                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaterialTypesId = new SelectList(db.MaterialTypes, "id", "type", material.MaterialTypesId);
            ViewBag.SubjectId = new SelectList(db.Subject, "id", "enrollmentKey", material.SubjectId);
            return View(material);
        }

        // GET: Materials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Material material = db.Materials.Find(id);
            db.Materials.Remove(material);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //Report
        public ActionResult Reports(string ReportType)
        {

            var materials = db.Materials.Include(m => m.MaterialTypes).Include(m => m.Subject);
           

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/MaterialReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "MaterialDataSet";
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
            Response.AddHeader("content-disposition", "attachment;filename=Material_report." + fileNameExtension);
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
