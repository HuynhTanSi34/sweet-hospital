using PagedList;
using SweetHospitalver3.Common;
using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        HospitalDbContext db = new HospitalDbContext();
        public ActionResult Account(string searchString, string searchChucdanh, int page = 1, int pageSize = 10)
        {
            IQueryable<TAIKHOAN> list = db.TAIKHOAN.OrderBy(x => x.Id);
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.TK.Contains(searchString) || x.TrangThai.Contains(searchString) || x.ChucDanh.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(searchChucdanh))
            {
                list = list.Where(x => x.ChucDanh.Contains(searchChucdanh));
            }
            ViewBag.SearchString = searchString;
            return View(list.OrderBy(x => x.Id).ToPagedList(page, pageSize));
        }
        [HttpGet]
        public ActionResult Createacc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Createacc(TAIKHOAN tAIKHOAN)
        {
            if (string.IsNullOrEmpty(tAIKHOAN.TK) == true)
            {
                ModelState.AddModelError("", "Chưa điền tên tài khoản.");
                return View(tAIKHOAN);
            }
            if (string.IsNullOrEmpty(tAIKHOAN.Pass) == true)
            {
                ModelState.AddModelError("", "Chưa điền mật khẩu.");
                return View(tAIKHOAN);
            }
            if (string.IsNullOrEmpty(tAIKHOAN.ChucDanh) == true)
            {
                ModelState.AddModelError("", "Chưa chọn chức danh.");
                return View(tAIKHOAN);
            }
            if (string.IsNullOrEmpty(tAIKHOAN.TrangThai) == true)
            {
                ModelState.AddModelError("", "Chưa chọn trạng thái.");
                return View(tAIKHOAN);
            }
            var ency = Encryptor.MD5Hash(tAIKHOAN.Pass);
            tAIKHOAN.Pass = ency;
            db.TAIKHOAN.Add(tAIKHOAN);
            db.SaveChanges();
                if (!string.IsNullOrEmpty(tAIKHOAN.TK))
                {
                    return RedirectToAction("Account");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới thành công");
                return View(tAIKHOAN);
                }
        }
        [HttpGet]
        public ActionResult Editacc(string Idc)
        {
            var det = db.TAIKHOAN.Find(Idc);
            return View(det);
        }
        [HttpPost]
        public ActionResult Editacc(TAIKHOAN tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                var up = db.TAIKHOAN.Find(tAIKHOAN.TK);
                if (!string.IsNullOrEmpty(tAIKHOAN.Pass))
                {
                    up.Pass = tAIKHOAN.Pass;
                }
                up.ChucDanh = tAIKHOAN.ChucDanh;
                up.TrangThai = tAIKHOAN.TrangThai;
                db.SaveChanges();
                if (!string.IsNullOrEmpty(tAIKHOAN.Pass))
                {
                    var ency = Encryptor.MD5Hash(tAIKHOAN.Pass);
                    tAIKHOAN.Pass = ency;
                }
                    ModelState.AddModelError("", "Cập nhật thành công");
                    return RedirectToAction("Account");  
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string TK)
        {
            var user = db.TAIKHOAN.SingleOrDefault(x => x.Id.ToString() == TK);
            db.TAIKHOAN.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Account");
        }

    }
}