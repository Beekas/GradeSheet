using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Marksheet.DAL;
using Marksheet.Models;

namespace Marksheet.Controllers
{
    public class ActiveDaysController : Controller
    {
        private MarkSheetEntities db = new MarkSheetEntities();

        // GET: ActiveDays
        public ActionResult Index()
        {
            var activeDays = db.ActiveDays.Include(a => a.AcademicYear).Include(a => a.School);
            return View(activeDays.ToList());
        }

        // GET: ActiveDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveDays activeDays = db.ActiveDays.Find(id);
            if (activeDays == null)
            {
                return HttpNotFound();
            }
            return View(activeDays);
        }

        // GET: ActiveDays/Create
        public ActionResult Create()
        {
            ViewBag.AcademicYearId = new SelectList(db.AcademicYears, "Id", "FiscalYear");
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName");
            ActiveDays active = new ActiveDays();
            return View(active);
        }
        public ActionResult Add()
        {
            ViewBag.AcademicYearId = new SelectList(db.AcademicYears, "Id", "FiscalYear");
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ViewModels.ActiveDaysVM activeDays)
        {
            if (ModelState.IsValid)
            {
               // db.ActiveDays.Add();
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicYearId = new SelectList(db.AcademicYears, "Id", "FiscalYear", activeDays.AcademicYearId);
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", activeDays.SchoolId);
            return View(activeDays);
        }

        // POST: ActiveDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SchoolId,TerminalName,Activedays,AcademicYearId")] ActiveDays activeDays)
        {
            if (ModelState.IsValid)
            {
                db.ActiveDays.Add(activeDays);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicYearId = new SelectList(db.AcademicYears, "Id", "FiscalYear", activeDays.AcademicYearId);
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", activeDays.SchoolId);
            return View(activeDays);
        }

        // GET: ActiveDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveDays activeDays = db.ActiveDays.Find(id);
            if (activeDays == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicYearId = new SelectList(db.AcademicYears, "Id", "FiscalYear", activeDays.AcademicYearId);
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", activeDays.SchoolId);
            return View(activeDays);
        }

        // POST: ActiveDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SchoolId,TerminalName,Activedays,AcademicYearId")] ActiveDays activeDays)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activeDays).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicYearId = new SelectList(db.AcademicYears, "Id", "FiscalYear", activeDays.AcademicYearId);
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", activeDays.SchoolId);
            return View(activeDays);
        }

        // GET: ActiveDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActiveDays activeDays = db.ActiveDays.Find(id);
            if (activeDays == null)
            {
                return HttpNotFound();
            }
            return View(activeDays);
        }

        // POST: ActiveDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActiveDays activeDays = db.ActiveDays.Find(id);
            db.ActiveDays.Remove(activeDays);
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
