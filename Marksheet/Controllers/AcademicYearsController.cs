using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Marksheet.DAL;
using Marksheet.Filters;
using Marksheet.Models;


namespace Marksheet.Controllers
{
    [SessionCheck(Role ="SuperAdmin")]
    public class AcademicYearsController : Controller
    {
        private MarkSheetEntities db = new MarkSheetEntities();

        // GET: AcademicYears
        public ActionResult Index()
        {
            return View(db.AcademicYears.ToList());
        }

        public ActionResult signin()
        {
            return View();
        }
        [HttpPost]
        public JsonResult changeStatus(string fyId)
        {
            try
            {
                if (db.AcademicYears.Any(m => m.ActiveYear == true))
                {
                    var activeFiscalYear = db.AcademicYears.FirstOrDefault(m => m.ActiveYear == true);
                    activeFiscalYear.ActiveYear = false;
                }
                int id = Convert.ToInt32(fyId);
                var objFisYear = db.AcademicYears.Find(id);
                objFisYear.ActiveYear = true;
                db.SaveChanges();
              
                return Json(true);

            }
            catch
            {
                return Json(false);
            }

        }

        // GET: AcademicYears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYears.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // GET: AcademicYears/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FiscalYear,Year,ActiveYear")] AcademicYear academicYear)
        {
            if (ModelState.IsValid)
            {
                academicYear.ActiveYear = false;
                db.AcademicYears.Add(academicYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academicYear);
        }

        // GET: AcademicYears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYears.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // POST: AcademicYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FiscalYear,Year,ActiveYear,ActiveYearEnglish,ResultDate")] AcademicYear academicYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academicYear);
        }

        // GET: AcademicYears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicYear academicYear = db.AcademicYears.Find(id);
            if (academicYear == null)
            {
                return HttpNotFound();
            }
            return View(academicYear);
        }

        // POST: AcademicYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicYear academicYear = db.AcademicYears.Find(id);
            db.AcademicYears.Remove(academicYear);
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
