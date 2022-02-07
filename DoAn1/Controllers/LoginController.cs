using DoAn1.Common;
using DoAn1.Models;
using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.login(user.UserName,user.Password);
                if (result == 3)
                {
                    var dv = dao.GetBymaSV(user.UserName);
                    var userSS = new UserLogin();
                    userSS.UserName = dv.maSV;
                    userSS.maLop = dv.maLop;
                    userSS.Status = dv.ttHoc;
                    //ModelState.AddModelError("","Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION, userSS);

                    return RedirectToAction("Index", "Home");
                }
                else if (result == 2)
                {
                    ModelState.AddModelError("", "Bạn không phải là cán bộ lớp");
                }
                else if (result == 1)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn đang bị khóa");
                } else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
                }
            }
            return View("Index");
        }
    }
}