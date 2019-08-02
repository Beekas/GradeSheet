using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marksheet.Models;
using Marksheet.DAL;
using Marksheet.ViewModels;

namespace Marksheet.Controllers
{
    public class RequestController : Controller
    {
        private readonly MarkSheetEntities db;

        public RequestController(MarkSheetEntities _db)
        {
            db = _db;
        }
        // GET: Request
        public ActionResult Index()
        {
            return View();
        }
    }
}