using PagedList;
using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        // GET: Admin/Staff
        HospitalDbContext db = new HospitalDbContext();
        public ActionResult Staff(string searchString, string searchTrangthai, int page = 1, int pageSize = 10)
        {
            IQueryable<NHANVIEN> list = db.NHANVIEN.OrderBy(x => x.MaNV);
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.MaNV.Contains(searchString) || x.TK.Contains(searchString) || x.HoTen.Contains(searchString) || x.Sdt.ToString().Contains(searchString) || x.Email.Contains(searchString) || x.NgayBD.ToString().Contains(searchString) || x.TrangThai.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(searchTrangthai))
            {
                list = list.Where(x => x.TrangThai.Contains(searchTrangthai));
            }
            ViewBag.SearchString = searchString;
            return View(list.OrderBy(x => x.MaNV).ToPagedList(page, pageSize));
        }
        [HttpGet]
        public ActionResult Staffinfor(string Id)
        {
            var det = db.NHANVIEN.Find(Id);
            return View(det);
        }
        [HttpGet]
        public ActionResult Editstaff(string Id)
        {
            var det = db.NHANVIEN.Find(Id);
            return View(det);
        }
        [HttpPost]
        public ActionResult Editstaff(NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                var up = db.NHANVIEN.Find(nHANVIEN.MaNV);
                up.HoTen = nHANVIEN.HoTen;
                up.TK = nHANVIEN.TK;
                up.NgaySinh = nHANVIEN.NgaySinh;
                up.Sdt = nHANVIEN.Sdt;
                up.GioiTinh = nHANVIEN.GioiTinh;
                up.NgayBD = nHANVIEN.NgayBD;
                up.CCCD = nHANVIEN.CCCD;
                up.Email = nHANVIEN.Email;
                up.ViTri = nHANVIEN.ViTri;
                up.DiaChi = nHANVIEN.DiaChi;
                up.TrangThai = nHANVIEN.TrangThai;
                up.Lương = nHANVIEN.Lương;
                up.Ha = nHANVIEN.Ha;
                db.SaveChanges();
                ModelState.AddModelError("", "Cập nhật thành công");
                return RedirectToAction("Staff");
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string Id)
        {
            var user = db.NHANVIEN.Find(Id);
            db.NHANVIEN.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Staff");
        }
        [HttpGet]
        public ActionResult Createstaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Createstaff(NHANVIEN nHANVIEN)
        {
            string mnv = "NV0";
            if (db.NHANVIEN.Find(mnv) == null)
            {
                nHANVIEN.MaNV = mnv;
            }
            else
            {
                string st1 = db.NHANVIEN.Max(x => x.MaNV);
                string st3 = st1.Substring(2);
                int str2 = int.Parse(st3);
                nHANVIEN.MaNV = "NV" + (str2 + 1).ToString();
            }
            if (string.IsNullOrEmpty(nHANVIEN.HoTen) == true)
            {
                ModelState.AddModelError("", "Chưa điền họ và tên.");
                return View(nHANVIEN);
            }
            if (string.IsNullOrEmpty(nHANVIEN.NgaySinh.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền ngày sinh.");
                return View(nHANVIEN);
            }
            if (string.IsNullOrEmpty(nHANVIEN.Sdt.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền số điện thoại.");
                return View(nHANVIEN);
            }
            if (string.IsNullOrEmpty(nHANVIEN.CCCD.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền căn cước công dân.");
                return View(nHANVIEN);
            }
            if (string.IsNullOrEmpty(nHANVIEN.Email) == true)
            {
                ModelState.AddModelError("", "Chưa điền Email.");
                return View(nHANVIEN);
            }
            if (string.IsNullOrEmpty(nHANVIEN.DiaChi) == true)
            {
                ModelState.AddModelError("", "Chưa điền địa chỉ.");
                return View(nHANVIEN);
            }
            if (string.IsNullOrEmpty(nHANVIEN.GioiTinh) == true)
            {
                ModelState.AddModelError("", "Chưa điền giới tính.");
                return View(nHANVIEN);
            }
            if (string.IsNullOrEmpty(nHANVIEN.TK) == true)
            {
                ModelState.AddModelError("", "Chưa điền tài khoản, lưu ý tạo tài khoản trước khi tạo hồ sơ cho nhân viên.");
                return View(nHANVIEN);
            }
            if (string.IsNullOrEmpty(nHANVIEN.ViTri) == true)
            {
                ModelState.AddModelError("", "Chưa điền vị trí công việc.");
                return View(nHANVIEN);
            }
            if (string.IsNullOrEmpty(nHANVIEN.NgayBD.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền ngày bắt đầu làm việc.");
                return View(nHANVIEN);
            }
            if (string.IsNullOrEmpty(nHANVIEN.Lương.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền lương.");
                return View(nHANVIEN);
            }
            if (string.IsNullOrEmpty(nHANVIEN.TrangThai) == true)
            {
                ModelState.AddModelError("", "Chưa điền trạng thái.");
                return View(nHANVIEN);
            }
            db.NHANVIEN.Add(nHANVIEN);
            db.SaveChanges();
            if (!string.IsNullOrEmpty(nHANVIEN.MaNV))
                {
                    return RedirectToAction("Staff");
                }
                else
                {
                ModelState.AddModelError("", "Tạo nhân viên không thành công");
                    return View(nHANVIEN);
            }
            }
        }
    }
