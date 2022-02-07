using DoAn1.Common;
using DoAn1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var session = (UserLogin)Session[Constants.USER_SESSION];
            if (session == null) return RedirectToAction("Index", "Login");
            return View();
        }
    }
}