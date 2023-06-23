using PagedList;
using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Areas.Admin.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Admin/Doctor
        HospitalDbContext db = new HospitalDbContext();
        public ActionResult Doctor(string searchString, string searchKhoa, string searchTrangthai, int page = 1, int pageSize = 10)
        {
            IQueryable<BACSI> list = db.BACSI.OrderBy(x => x.MaBS);
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.MaBS.Contains(searchString) || x.HoTen.Contains(searchString) || x.Khoa.Contains(searchString) || x.NgayBD.ToString().Contains(searchString) || x.TrangThai.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(searchKhoa))
            {
                list = list.Where(x => x.Khoa.Contains(searchKhoa));
            }
            if (!string.IsNullOrEmpty(searchTrangthai))
            {
                list = list.Where(x => x.TrangThai.Contains(searchTrangthai));
            }
            ViewBag.SearchString = searchString;
            return View(list.OrderBy(x => x.MaBS).ToPagedList(page, pageSize));
        }
        [HttpGet]
        public ActionResult Doctorinfor(string Id)
        {
            var det = db.BACSI.Find(Id);
            return View(det);
        }
        [HttpGet]
        public ActionResult Editdoctor(string Id)
        {
            var det = db.BACSI.Find(Id);
            return View(det);
        }
        [HttpPost]
        public ActionResult Editdoctor(BACSI bACSI)
        {
            if (ModelState.IsValid)
            {
                var up = db.BACSI.Find(bACSI.MaBS);
                up.HoTen = bACSI.HoTen;
                up.TK = bACSI.TK;
                up.TK = bACSI.TAIKHOAN.TK;
                up.NgaySinh = bACSI.NgaySinh;
                up.Sdt = bACSI.Sdt;
                up.GioiTinh = bACSI.GioiTinh;
                up.NgayBD = bACSI.NgayBD;
                up.CCCD = bACSI.CCCD;
                up.Email = bACSI.Email;
                up.Khoa = bACSI.Khoa;
                up.DiaChi = bACSI.DiaChi;
                up.TrangThai = bACSI.TrangThai;
                up.Lương = bACSI.Lương;
                up.Ha = bACSI.Ha;
                up.GiaKham = bACSI.GiaKham;
                db.SaveChanges();
                ModelState.AddModelError("", "Cập nhật thành công");
                    return RedirectToAction("Doctor");
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string Id)
        {
            var user = db.BACSI.Find(Id);
            db.BACSI.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Doctor");
        }
        [HttpGet]
        public ActionResult Createdoctor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Createdoctor(BACSI bACSI)
        {
            string mnv = "BS0";
            if (db.BACSI.Find(mnv) == null)
            {
                bACSI.MaBS = mnv;
            }
            else
            {
                string st1 = db.BACSI.Max(x => x.MaBS);
                string st3 = st1.Substring(2);
                int str2 = int.Parse(st3);
                bACSI.MaBS = "BS" + (str2 + 1).ToString();
            }
            if (string.IsNullOrEmpty(bACSI.HoTen) == true)
            {
                ModelState.AddModelError("", "Chưa điền họ và tên.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.NgaySinh.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền ngày sinh.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.Sdt.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền số điện thoại.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.CCCD.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền căn cước công dân.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.Email) == true)
            {
                ModelState.AddModelError("", "Chưa điền Email.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.DiaChi) == true)
            {
                ModelState.AddModelError("", "Chưa điền địa chỉ.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.GioiTinh) == true)
            {
                ModelState.AddModelError("", "Chưa điền giới tính.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.TK) == true)
            {
                ModelState.AddModelError("", "Chưa điền tài khoản, lưu ý tạo tài khoản trước khi tạo hồ sơ cho nhân viên.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.Khoa) == true)
            {
                ModelState.AddModelError("", "Chưa điền khoa.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.NgayBD.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền ngày bắt đầu làm việc.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.Lương.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền lương.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.TrangThai) == true)
            {
                ModelState.AddModelError("", "Chưa điền trạng thái.");
                return View(bACSI);
            }
            if (string.IsNullOrEmpty(bACSI.GiaKham.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền giá khám.");
                return View(bACSI);
            }
            db.BACSI.Add(bACSI);
            db.SaveChanges();
            if (!string.IsNullOrEmpty(bACSI.MaBS))
            {
                return RedirectToAction("Doctor");
            }
            else
            {
                ModelState.AddModelError("", "Tạo Bác sĩ không thành công");
                return View(bACSI);
            }
        }
    }
}