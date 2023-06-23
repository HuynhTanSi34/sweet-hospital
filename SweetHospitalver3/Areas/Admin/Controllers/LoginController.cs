using SweetHospitalver3.Areas.Admin.Content;
using SweetHospitalver3.Common;
using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        HospitalDbContext db = new HospitalDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(TAIKHOAN model)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoginAdmin();
                var res = dao.Login(model.TK, Encryptor.MD5Hash(model.Pass), model.ChucDanh);
                if (res == 1)
                {
                    var user = dao.GetById(model.TK);
                    var userSession = new UserLogin();
                    userSession.TK = user.TK;
                    Session.Add(Common.Constant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                if (res == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đã bị khóa.");
                }
                if (res == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu sai.");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View("Index");

        }
    }
}