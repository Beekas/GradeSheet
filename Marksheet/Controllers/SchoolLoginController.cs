using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Marksheet.Models;
using System.Web.Security;
using System.Web.UI.WebControls;
using Marksheet.DAL;
using System.Net.Mail;
using System.Net;
using System.IO;
using Marksheet.ViewModels;
using System.Net.Configuration;
using System.Configuration;
using System.Web.Helpers;

namespace Marksheet.Controllers
{
    // [Authorize]

    public class SchoolLoginController : Controller
    {


        MarkSheetEntities _db = new MarkSheetEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(LoginViewModel l, string ReturnUrl = "")
        {
            using (MarkSheetEntities db = new MarkSheetEntities())
            {


                var Admin = _db.Schools.FirstOrDefault(a => (a.Username == l.UserName || a.Email == l.UserName));
                if (Admin != null)
                {
                    var pass = Crypto.Hash(l.Password);
                    if (string.Compare(pass, Admin.Password) == 0)
                    {

                        string imageUrl = "../../Images/"+Admin.Id+".jpg";
                        //if (System.IO.File.Exists(Server.MapPath(@"/Images/" + Admin.Id + ".jpg")))
                        //{
                        //    imageUrl = "../../images/" + Admin.Id + ".jpg";
                        //}
                        Session.Add("id", Admin.Id);
                        Session.Add("userName", Admin.Username);
                        Session.Add("userEmail", Admin.Email);
                        Session.Add("SchoolName", Admin.SchoolName);
                        Session.Add("imageUrl", imageUrl);
                        return RedirectToAction("Index1", "Schools");
                    }

                    else
                    {
                        ModelState.AddModelError("", "UserName and Password not match");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "UserName and Password not match");
                }
                    return View();

                }
            }

            public ActionResult SchoolDetail()
            {
                int id = Convert.ToInt32(Session["id"].ToString());
                School admin = _db.Schools.Find(id);
                return View(admin);
            }
        
        public ActionResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Login");
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(School admin)
        {


            //string from = "usern";
            //string fromPassword = "my@test#";

            string password = Membership.GeneratePassword(6, 1);

            if (admin.Email != null)
            {
                var mail = new MailMessage();

                //using (MailMessage mail = new MailMessage(admin.Email))


                try
                {
                    var tb = _db.Schools.Where(u => u.Email == admin.Email).FirstOrDefault();

                    if (tb == null)
                    {
                        ViewBag.Message = "email Doesnot Exist Please enter valid email";
                        return View();
                    }
                    else
                    {
                        mail.To.Add(new MailAddress(admin.Email));

                        mail.Subject = "Password Recovery";
                        mail.Body = "Use this Password to login:" + password;


                        mail.IsBodyHtml = false;


                        using (var smtp = new SmtpClient())
                            //smtp.Host = "smtp.gmail.com";
                            //smtp.EnableSsl = true;
                            //smtp.UseDefaultCredentials = false;
                            //NetworkCredential networkCredential = new NetworkCredential(from, fromPassword);

                            //smtp.Credentials = networkCredential;
                            //smtp.Port = 587;
                            smtp.Send(mail);

                        ViewBag.Message = "Your Password Is Sent to your email";
                        var query = (from q in _db.Schools
                                     where q.Email == admin.Email
                                     select q).First();
                        query.randompass = password;
                        _db.SaveChanges();

                    }
                }
                catch (Exception e)
                {
                    return RedirectToAction(e.ToString().Substring(0, 100) + "errorpage");
                }
                TempData["Successmsg"] = "Your reset code is set to your mail";
                TempData["Message"] = admin.Email;
                TempData.Keep();
                return RedirectToAction("conformation");



            }



            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
             .Select(x => new { x.Key, x.Value.Errors }).ToArray();


            return View();


            //return RedirectToAction("Index", "Home");
        }
        public ActionResult conformation()
        {
            if (TempData["Message"] != null)
            {
                string message = TempData["Message"].ToString();
                TempData.Keep();
                if (message != null)
                {
                    return PartialView();
                }
            }
            return RedirectToAction("ForgetPassword");

        }
        [HttpPost]
        public ActionResult conformation(School admin)
        {

            string message = TempData["Message"].ToString();
            TempData.Keep();
            TempData["info"] = (_db.Schools.Any(u => u.Email == message && u.randompass == admin.randompass));
            if (admin.randompass != null)
            {
                if (_db.Schools.Any(u => u.Email == message && u.randompass == admin.randompass))
                {
                    return RedirectToAction("NewPassword");
                }
            }
            //  return PartialView();


            ViewBag.message = "conformation code donot match";
            return PartialView();
        }
        public ActionResult NewPassword()
        {

            if (TempData["info"] != null && TempData["Message"] != null)
            {
                TempData.Keep();
                return PartialView();

            }
            return RedirectToAction("ForgetPassword");
        }
        [HttpPost]
        public ActionResult NewPassword(PasswordConform pass)
        {
            if (ModelState.IsValid)
            {

                string message = TempData["Message"].ToString();
                var query = (from q in _db.Schools
                             where q.Email == message
                             select q).First();
                string password = Crypto.Hash(pass.Password);
                query.Password = password;
                query.randompass = null;
                _db.SaveChanges();
                return RedirectToAction("Login");



            }
            return PartialView();
        }
        public ActionResult errorpage()
        {
            return PartialView();
        }

    }

}
