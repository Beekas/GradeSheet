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
using System.Web.Services.Description;

namespace Marksheet.Controllers
{
    // [Authorize]

    public class LoginController : Controller
    {


        MarkSheetEntities _db = new MarkSheetEntities();

        [ValidateInput(false)]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(LoginViewModel l, string ReturnUrl = "")
        {
            using (MarkSheetEntities db = new MarkSheetEntities())
            {



                var Admin = _db.Accounts.FirstOrDefault(a => (a.UserName == l.UserName || a.Email == l.UserName));
                if (Admin != null)
                {
                    var pass = Crypto.Hash(l.Password);
                    if (string.Compare(pass, Admin.Password) == 0)
                    {
                            string imageUrl = "../../Images/Account/" + Admin.Id + ".jpg";
                        if (System.IO.File.Exists(Server.MapPath(@"~/images/Account" + Admin.Id + ".jpg")))
                            {
                                imageUrl = "../../images/Account" + Admin.Id + ".jpg";
                            }
                            Session.Add("id", Admin.Id);
                            Session.Add("userName", Admin.UserName);
                            Session.Add("userEmail", Admin.Email);
                            Session.Add("FullName", Admin.FullName);
                            Session.Add("Category", Admin.Category);
                            Session.Add("Category", Admin.Category);
                            Session.Add("imageUrl", imageUrl);


                            return RedirectToAction("Index", "schools");
                        
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
            }
            return View();

        }
        public ActionResult AdminDetial()
        {
            int id = Convert.ToInt32(Session["id"].ToString());
            Account admin = _db.Accounts.Find(id);
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
        public ActionResult ForgetPassword(Account admin)
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
                    var tb = _db.Accounts.Where(u => u.Email == admin.Email).FirstOrDefault();

                    if (tb == null)
                    {
                        ViewBag.Message = "email Doesnot Exist Please enter valid email";
                        return View();
                    }
                    else
                    {
                        var message = new MailMessage();
                        message.To.Add(new MailAddress(admin.Email));

                        message.Subject = "Password Recovery";
                        message.Body = "Use this Password to login:" + password;


                        message.IsBodyHtml = false;



                        using (var smtp = new SmtpClient())
                        {
                            try
                            {
                                smtp.Send(message);

                                ViewBag.Message = "Your Password Is Sent to your email";
                                var query = (from q in _db.Accounts
                                             where q.Email == admin.Email
                                             select q).First();
                                query.randompass = password;
                                _db.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                return RedirectToAction("Error");
                            }



                        }
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
        public ActionResult conformation(Account admin)
        {

            string message = TempData["Message"].ToString();
            TempData.Keep();
            TempData["info"] = (_db.Accounts.Any(u => u.Email == message && u.randompass == admin.randompass));
            if (admin.randompass != null)
            {
                if (_db.Accounts.Any(u => u.Email == message && u.randompass == admin.randompass))
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
                var query = (from q in _db.Accounts
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
