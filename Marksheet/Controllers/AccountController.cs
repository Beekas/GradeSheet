using Marksheet.DAL;
using Marksheet.Filters;
using Marksheet.Models;
using Marksheet.ViewModels;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Marksheet.Controllers
{
    [SessionCheck]
    public class AccountController : Controller
    {


        public ActionResult Index()
        {
            var accout = _db.Accounts.ToList();
            return View(accout);
        }

        MarkSheetEntities _db = new MarkSheetEntities();

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

            Account us = _db.Accounts.Single(m => m.Id == employeeid);// (u => u.Id == employeeid && u.Password == ch.OldPassword).FirstOrDefault();
            if (us != null)
            {
                var pass = Crypto.Hash(ch.OldPassword);
                if (string.Compare(pass, us.Password) == 0)

                {
                    if (ch.NewPassword == ch.ConfirmNew)
                    {
                        us.Password = Crypto.Hash(ch.NewPassword);
                        _db.SaveChanges();
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

        public ActionResult CreateAdmin()
        {
            return View();

        }
        public ActionResult uploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult uploadFile(HttpPostedFileBase file)
        {
            string name = file.FileName;
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(Account tb, HttpPostedFileBase ImageFile)
        {
            Account admin = _db.Accounts.FirstOrDefault(m => m.Email == tb.Email);
            if (admin == null)
            {

                tb.ModifiedDate = DateTime.Now;
                
                tb.CreatedDate = DateTime.Now;
                
                tb.Password = Crypto.Hash(tb.Password);
                var objAdmin = _db.Accounts.OrderByDescending(m => m.Id).FirstOrDefault();
                

                HttpFileCollectionBase image = Request.Files;

                // string fileName1 = ImageFile.FileName;
                string filename = "1.jpg";
                if (objAdmin != null)
                {
                  filename = (objAdmin.Id + 1).ToString() + ".jpg";
                }
                string name = "/Images/Account/";
                bool exist = System.IO.Directory.Exists(Server.MapPath(name));
                if (!exist)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(name));
                }

                // string filename = Path.GetFileNameWithoutExtension(tb.ImageFile.FileName);
                // string extension = Path.GetExtension(tb.ImageFile.FileName);


                //filename = filename + extension;



                tb.PPSizePhoto = "/Images/Account/" + filename;

                if (ImageFile != null)
                {
                    filename = Path.Combine(Server.MapPath("~/Images/Account"), filename);
                    ImageFile.SaveAs(filename);
                }
                _db.Accounts.Add(tb);
                _db.SaveChanges();
                return RedirectToAction("Index");


            }
            else
            {
                ViewBag.ErrorMessage = "Email Alredy Exist";
            }
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account tb = new Account();
            tb = _db.Accounts.Where(x => x.Id == id).FirstOrDefault();

            Account Admin = _db.Accounts.Find(id);
            if (Admin == null)
            {
                return HttpNotFound();
            }
            return View(Admin);


        }
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account admin = _db.Accounts.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            return View(admin);

        }

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account admin, HttpPostedFileBase ImageFile)
        {

            if (ModelState.IsValid)
            {
                var objadmin = _db.Accounts.Find(admin.Id);
                objadmin.CreatedDate = DateTime.Now;
                objadmin.CreatedBy = "admin";
                objadmin.ModifiedDate = DateTime.Now;
                objadmin.ModifiedBy = "admin";

                objadmin.FullName = admin.FullName;
                objadmin.Phone = admin.Phone;
                objadmin.URL = admin.URL;
                objadmin.Email = admin.Email;
                objadmin.WorkPhone = admin.WorkPhone;

                objadmin.Status = admin.Status;

                objadmin.UserName = admin.UserName;
                objadmin.Category = admin.Category;

                HttpFileCollectionBase image = Request.Files;
                if (ImageFile != null)
                {

                    string fileName1 = admin.Id + ".jpg";
                    ///string filename = Path.GetFileNameWithoutExtension(admin.ImageFile.FileName);
                    //string extension = Path.GetExtension(admin.ImageFile.FileName);
                    //filename = admin.Id + extension;
                    objadmin.PPSizePhoto = "/Images/Account" + fileName1;
                    string filename = Path.Combine(Server.MapPath("~/Images/Account"), fileName1);
                    ImageFile.SaveAs(filename);
                }




                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
             .Select(x => new { x.Key, x.Value.Errors }).ToArray();
            return View(admin);


        }

        // GET: /Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account Admin = _db.Accounts.Find(id);
            _db.Accounts.Remove(Admin);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        internal class ChallengeResult : ActionResult
        {
            private string provider;
            private string v1;
            private string v2;

            public ChallengeResult(string provider, string v1, string v2)
            {
                this.provider = provider;
                this.v1 = v1;
                this.v2 = v2;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                throw new NotImplementedException();
            }
        }
    }

}
