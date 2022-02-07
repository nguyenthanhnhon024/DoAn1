using DoAn1.Common;
using DoAn1.Models;
using ModelEF.Dao;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn1.Controllers
{
    public class HoatDongController : Controller
    {
        // GET: HoatDong
        DBContext dbPro = new DBContext();
        HoatDongDao aDB = new HoatDongDao();

        [HandleError]
        [HttpGet]
        public ActionResult Index(string error, string name)
        {
            var session = (UserLogin)Session[Constants.USER_SESSION];
            if (session == null) { return RedirectToAction("Index", "Login"); }
            else
            {
                ViewBag.ProError = error;
                var model = aDB.ListAll();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var model = aDB.ListWhereAll(searchString);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Details(string id)
        {
            var model = new HoatDongDao().Find(id);
            return View(model);

        }
    }
}