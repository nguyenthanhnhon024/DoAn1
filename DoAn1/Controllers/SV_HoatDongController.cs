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
    public class SV_HoatDongController : Controller
    {
        // GET: SV_HoatDong
        DBContext context = new DBContext();
        SV_HoatDongDao aDB = new SV_HoatDongDao();
        [HandleError]
        [HttpGet]
        public ActionResult Index(string id, string error, string name)
        {
            var session = (UserLogin)Session[Constants.USER_SESSION];
            if (session == null) { return RedirectToAction("Index", "Login"); }
            else
            {
                Session.Add(HoatDongs.HD_SESSION, id);
                var lop = session.maLop;
                ViewBag.ProError = error;
                var model = aDB.ListWhereAll(id.Trim(),lop.Trim());
                return View(model);

            }
        }

        public ActionResult Index(hoatdong hd)
        {
            var session = (LoginModel)Session[Constants.USER_SESSION];  
            if (session == null) { return RedirectToAction("Index", "Login"); }
            else
            {
                var lop = session.maLop;
                Session.Add(HoatDongs.HD_SESSION, hd);
                var model = aDB.ListWhereAll(hd.maHD.Trim(),lop.Trim());
                return View(model);

            }
        }

        [HttpPost]
        public JsonResult ChangeStatus(string id , string id2)
        {
            var ss1 = (String)Session[HoatDongs.HD_SESSION];
            id2 = ss1;
            var result = new SV_HoatDongDao().ChangeStatus(id.Trim(),id2.Trim());
            return Json(new { status = result });
        }
    } 
}