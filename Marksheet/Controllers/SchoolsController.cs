using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Marksheet.DAL;
using Marksheet.Filters;
using Marksheet.Models;
using Marksheet.ViewModels;

namespace Marksheet.Controllers
{
    [SessionCheck]
    public class SchoolsController : Controller
    {
        private MarkSheetEntities db = new MarkSheetEntities();

        // GET: Schools
        public ActionResult Index()
        {
            return View(db.Schools);
        }

        // GET: Schools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        public ActionResult Index1()
        {
            return View();
        }

        // GET: Schools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School school, HttpPostedFileBase ImageFile)
            {
            School admin = db.Schools.FirstOrDefault(m => m.Email == school.Email);
            if (admin == null)
            {

                var objAdmin = db.Schools.OrderByDescending(m => m.Id).FirstOrDefault();

                school.Password = Crypto.Hash(school.Password);
                HttpFileCollectionBase image = Request.Files;

                // string fileName1 = ImageFile.FileName;
                string filename = "1.jpg";
                if (objAdmin != null)
                {
                    filename = (objAdmin.Id + 1).ToString() + ".jpg";
                }
                string name = "/Images/";
                bool exist = System.IO.Directory.Exists(Server.MapPath(name));
                if (!exist)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(name));
                }

                // string filename = Path.GetFileNameWithoutExtension(tb.ImageFile.FileName);
                // string extension = Path.GetExtension(tb.ImageFile.FileName);


                //filename = filename + extension;



                school.Logo = "/images/" + filename;

                if (ImageFile != null)
                {
                    filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                    ImageFile.SaveAs(filename);
                }

                db.Schools.Add(school);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else

            {
                ViewBag.ErrorMessage = "Email Alredy Exist";
            }
            return View(school);
        }


        public ActionResult ChangePassword()
        {
            if (Session["id"] != null)
            {
                {
                    return View();
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
        [HttpPost]
        public ActionResult ChangePassword(ViewModels.ChangePasswordViewModel ch)
        {
            int employeeid = Convert.ToInt32(Session["Id"].ToString());

            School us = db.Schools.Single(m => m.Id == employeeid);// (u => u.Id == employeeid && u.Password == ch.OldPassword).FirstOrDefault();
            if (us != null)
            {
                var pass = Crypto.Hash(ch.OldPassword);
                if (string.Compare(pass, us.Password) == 0)

                {
                    if (ch.NewPassword == ch.ConfirmNew)
                    {
                        us.Password = Crypto.Hash(ch.NewPassword);
                        db.SaveChanges();
                        ViewBag.Message = "Password Changed Successfully";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "New Password and Confirm Password Mismatched";
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Password not matched with previous one!";
                }
            }
            ModelState.Clear();
            return View();
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SchoolName,Slogan,URL,State,Username,Municipality,WardNo,Logo,Phone1,Phone2,Email,Address,Details")] School school, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                HttpFileCollectionBase image = Request.Files;
                string fileName1 = school.Id + ".jpg";
                if (ImageFile != null)
                {


                    ///string filename = Path.GetFileNameWithoutExtension(admin.ImageFile.FileName);
                    //string extension = Path.GetExtension(admin.ImageFile.FileName);
                    //filename = admin.Id + extension;
                    school.Logo = "/images/" + fileName1;
                    string filename = Path.Combine(Server.MapPath("~/Images/"), fileName1);
                    ImageFile.SaveAs(filename);
                }
                school.Logo = "/images/" + fileName1;
                db.Entry(school).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(school);
        }

        // GET: Schools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            School school = db.Schools.Find(id);
            db.Schools.Remove(school);
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
