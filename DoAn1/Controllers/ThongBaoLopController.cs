using DoAn1.Common;
using DoAn1.Models;
using ModelEF.Dao;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace DoAn1.Controllers
{
    public class ThongBaoLopController : Controller
    {
        // GET: ThongBaoLop
        DBContext dbPro = new DBContext();        
        ThongBaoLopDao aDB = new ThongBaoLopDao();
        //
        // GET: /Administrator/Product/
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


        [HandleError]
        [HttpGet]
        public ActionResult Create()
        {
            var session = (UserLogin)Session[Constants.USER_SESSION];
            if (session == null) { return RedirectToAction("Index", "Login"); }
            else
            {
                return View();
            }
        }

        [HandleError]
        [HttpPost]
        public ActionResult Create(thongbaolop createPro)
        {
            var session = (UserLogin)Session[Constants.USER_SESSION];
            if (session == null) { return RedirectToAction("Index", "Login"); }
            else
            {
                var pro = dbPro.thongbaolops.SingleOrDefault(c => c.maTBLop.Equals(createPro.maTBLop));

                var dao = new ThongBaoLopDao();
                try
                {
                    if (pro != null)
                    {
                        ViewBag.CreateProError = "Mã thông báo đã tồn tại.";
                    }
                    else
                    {
                        var ss = (UserLogin)Session[Constants.USER_SESSION];
                        createPro.maSV = ss.UserName;
                        aDB.ThemTB(createPro);
                        ViewBag.CreateProError = "Thêm thông báo thành công.";
                        return RedirectToAction("Index", "ThongBaoLop");
                    }
                }
                catch (Exception)
                {
                    ViewBag.CreateProError = "Không thể thêm thông báo.";
                }
                return View();
                }
            }

        //[HandleError]
        //[HttpGet]
        //public ActionResult Edit(string id)
        //{
        //    if (Session["accname"] == null)
        //    {
        //        Session["accname"] = null;
        //        return RedirectToAction("Index", "Login");
        //    }
        //    else
        //    {
        //        thongbaolop thongbaolop = dbPro.thongbaolops.Find(id);
        //        var result = aDB.Find(id);
        //        if (result != null)
        //            return View(result);
        //        return View();
        //    }
        //}

        //[HandleError]
        //[HttpPost]
        //public ActionResult Edit(thongbaolop editPro)
        //{
        //    if (Session["accname"] == null)
        //    {
        //        Session["accname"] = null;
        //        return RedirectToAction("Index", "Login");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            aDB.Edit(editPro);
        //            ViewBag.EditProError = "Cập nhật thông báo thành công.";
        //            return RedirectToAction("Index", "ThongBaoLop");

        //        }
        //        catch (Exception)
        //        {
        //            ViewBag.EditProError = "Không thể cập nhật thông báo.";
        //        }
        //        return View();
        //    }
        //}

        //[HandleError]
        //public ActionResult Delete(string maTB)
        //{
        //    var dao = new ThongBaoLopDao();
        //    if (Session["accname"] == null)
        //    {
        //        Session["accname"] = null;
        //        return RedirectToAction("Index", "Login");
        //    }
        //    else
        //    {
        //        var model = dbPro.thongbaolops.SingleOrDefault(h => h.maTBLop.Equals(maTB));
        //        try
        //        {
        //            if (model != null)
        //            {
        //                dao.Delete(maTB);
        //                return RedirectToAction("Index", "ThongBaoLop", new { error = "Xoá thông báo thành công." });
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "ThongBaoLop", new { error = "Thông báo không tồn tại." });
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return RedirectToAction("Index", "ThongBaoLop", new { error = "Không thể xoá thông báo." });
        //        }

        //    }
        //}

        [HandleError]
        public ActionResult Details(string id)
        {
            if (Session["accname"] == null)
            {
                Session["accname"] = null;
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var model = dbPro.thongbaolops.Find(id);
                return View(model);
            }
        }

    }
}