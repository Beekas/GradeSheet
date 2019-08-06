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
    [SessionCheck(Role ="SuperAdmin,Admin")]
    public class OptionalSubjectsController : Controller
    {
        private MarkSheetEntities db = new MarkSheetEntities();

        // GET: OptionalSubjects
        public ActionResult Index()
        {
            var optionalSubjects = db.OptionalSubjects.Include(o => o.School).Include(o => o.Subject);
            return View(optionalSubjects.ToList());
        }

        // GET: OptionalSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalSubject optionalSubject = db.OptionalSubjects.Find(id);
            if (optionalSubject == null)
            {
                return HttpNotFound();
            }
            return View(optionalSubject);
        }

        // GET: OptionalSubjects/Create
        public ActionResult Create()
        {
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName");
            ViewBag.SubjectId = new SelectList(db.Subjects.Where(m=>m.Optional), "Id", "SubName");
            return View();
        }

        // POST: OptionalSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( OptionalSubject optionalSubject,FormCollection col)
        {
            if (ModelState.IsValid)
            {
                int schoolId = Convert.ToInt32(col["SchoolId"]);
                if (!db.OptionalSubjects.Any(m => m.SchoolId == schoolId))
                {
                    optionalSubject.SchoolId = Convert.ToInt32(col["SchoolId"].ToString());
                    optionalSubject.School = db.Schools.Find(optionalSubject.SchoolId);
                    optionalSubject.SubjectId = Convert.ToInt32(col["Optional1"].ToString());
                    optionalSubject.Subject = db.Subjects.Find(optionalSubject.SubjectId);
                    db.OptionalSubjects.Add(optionalSubject);
                    db.SaveChanges();
                    optionalSubject.SchoolId = Convert.ToInt32(col["SchoolId"].ToString());
                    optionalSubject.School = db.Schools.Find(optionalSubject.SchoolId);
                    optionalSubject.SubjectId = Convert.ToInt32(col["Optional2"].ToString());
                    optionalSubject.Subject = db.Subjects.Find(optionalSubject.SubjectId);
                    db.OptionalSubjects.Add(optionalSubject);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName");
                    ViewBag.SubjectId = new SelectList(db.Subjects.Where(m => m.Optional), "Id", "SubName");
                    ViewBag.msg = "Already exist please edit";
                        return View();
                }
            }

            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", optionalSubject.SchoolId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubName", optionalSubject.SubjectId);
            return View(optionalSubject);
        }

        // GET: OptionalSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalSubject optionalSubject = db.OptionalSubjects.Find(id);
            if (optionalSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", optionalSubject.SchoolId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubName", optionalSubject.SubjectId);
            return View(optionalSubject);
        }

        // POST: OptionalSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SchoolId,SubjectId")] OptionalSubject optionalSubject)
        {
            if (ModelState.IsValid)
            {
                if (!db.OptionalSubjects.Any(m => m.SchoolId == optionalSubject.SchoolId && m.SubjectId == optionalSubject.SubjectId))
                {
                    db.Entry(optionalSubject).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Subject already exist");
                    ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", optionalSubject.SchoolId);
                    ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubName", optionalSubject.SubjectId);
                    return View(optionalSubject);
                }
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "SchoolName", optionalSubject.SchoolId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubName", optionalSubject.SubjectId);
            return View(optionalSubject);
        }

        // GET: OptionalSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionalSubject optionalSubject = db.OptionalSubjects.Find(id);
            if (optionalSubject == null)
            {
                return HttpNotFound();
            }
            return View(optionalSubject);
        }

        // POST: OptionalSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OptionalSubject optionalSubject = db.OptionalSubjects.Find(id);
            db.OptionalSubjects.Remove(optionalSubject);
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
