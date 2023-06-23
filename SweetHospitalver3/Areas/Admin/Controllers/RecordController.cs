using PagedList;
using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Areas.Admin.Controllers
{
    public class RecordController : Controller
    {
        // GET: Admin/Record
        HospitalDbContext db = new HospitalDbContext();
        public ActionResult Record(string searchString, int page = 1, int pageSize = 10)
        {
            IQueryable<HOSO> list = db.HOSO.OrderBy(x => x.MaHS);
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.MaHS.Contains(searchString) || x.TK.Contains(searchString) || x.GioiTinh.Contains(searchString));
            }
            ViewBag.SearchString = searchString;
            return View(list.OrderBy(x => x.MaHS).ToPagedList(page, pageSize));
        }
        [HttpGet]
        public ActionResult Recordinfor(string Id)
        {
            var det = db.HOSO.Find(Id);
            return View(det);
        }
        [HttpGet]
        public ActionResult Editrecord(string Id)
        {
            var det = db.HOSO.Find(Id);
            return View(det);
        }
        [HttpPost]
        public ActionResult Editrecord(HOSO hOSO)
        {
            if (ModelState.IsValid)
            {
                var up = db.HOSO.Find(hOSO.MaHS);
                up.HoTen = hOSO.HoTen;
                up.NgaySinh = hOSO.NgaySinh;
                up.Sdt = hOSO.Sdt;
                up.GioiTinh = hOSO.GioiTinh;
                up.NgheNghiep = hOSO.NgheNghiep;
                up.CCCD = hOSO.CCCD;
                up.Email = hOSO.Email;
                up.DanToc = hOSO.DanToc;
                up.DiaChi = hOSO.DiaChi;
                db.SaveChanges();
                ModelState.AddModelError("", "Cập nhật thành công");
                    return RedirectToAction("Record");
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string Id)
        {
            var user = db.HOSO.Find(Id);
            db.HOSO.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Record");
        }
        [HttpGet]
        public ActionResult Createrecord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Createrecord(HOSO hOSO)
        {
            if (string.IsNullOrEmpty(hOSO.TK) == true)
            {
                ModelState.AddModelError("", "Chưa điền tài khoản.");
                return View(hOSO);
            } 
            if (string.IsNullOrEmpty(hOSO.MaHS) == true)
            {
                ModelState.AddModelError("", "Chưa điền mã hồ sơ.");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.HoTen) == true)
            {
                ModelState.AddModelError("", "Chưa điền họ và tên.");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.NgaySinh.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền ngày sinh.");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.Sdt.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền số điện thoại nè bạn ơi!");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.CCCD.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền CCCD");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.Email) == true)
            {
                ModelState.AddModelError("", "Chưa điền email nè bạn ơi!");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.DiaChi) == true)
            {
                ModelState.AddModelError("", "Chưa chọn địa chỉ");
                return View(hOSO);
            }
            db.HOSO.Add(hOSO);
            db.SaveChanges();
            if (!string.IsNullOrEmpty(hOSO.MaHS))
            {
                return RedirectToAction("Record");
            }
            else
            {
                ModelState.AddModelError("", "Tạo hồ sơ không thành công");
                return View(hOSO);
            }
        }
        [HttpGet]
        public ActionResult Recordhistory(string Id)
        {
            var det = db.KETQUA.Find(Id);
            return View(det);
        }
        [HttpGet]
        public ActionResult Editrecordhis(string Id)
        {
            var det = db.KETQUA.Find(Id);
            return View(det);
        }
        [HttpPost]
        public ActionResult Editrecordhis(KETQUA hOSO)
        {
            if (ModelState.IsValid)
            {
                var up = db.KETQUA.Find(hOSO.MaPhieu);
                up.Khoa = hOSO.Khoa;
                up.KetQua1 = hOSO.KetQua1;
                up.ChuanDoan = hOSO.ChuanDoan;
                up.LoiKhuyen = hOSO.LoiKhuyen;
                up.NgayKham = hOSO.NgayKham;
                up.NgayTK = hOSO.NgayTK;
                up.Ha1 = hOSO.Ha1;
                up.Ha2 = hOSO.Ha2;
                up.TrangThai = hOSO.TrangThai;
                db.SaveChanges();
                ModelState.AddModelError("", "Cập nhật thành công");
                return RedirectToAction("Record");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Createrecordhis(/*string Id*/)
        {
            //var det = db.KETQUA.Find(Id);
            return View();
        }
        [HttpPost]
        public ActionResult Createrecordhis(KETQUA hOSO)
        {
            if (string.IsNullOrEmpty(hOSO.MaPhieu) == true)
            {
                ModelState.AddModelError("", "Chưa điền mã phiếu.");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.Khoa) == true)
            {
                ModelState.AddModelError("", "Chưa điền khoa.");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.NgayKham.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền ngày khám.");
                return View(hOSO);
            }
            if (string.IsNullOrEmpty(hOSO.TrangThai) == true)
            {
                ModelState.AddModelError("", "Chưa điền trạng thái.");
                return View(hOSO);
            }
            db.KETQUA.Add(hOSO);
            db.SaveChanges();
            if (!string.IsNullOrEmpty(hOSO.MaPhieu))
            {
                return RedirectToAction("Record");
            }
            else
            {
                ModelState.AddModelError("", "Tạo hồ sơ không thành công");
                return View(hOSO);
            }
        }
    }
    }