using PagedList;
using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Areas.Admin.Controllers
{
    public class NumberdoctorController : Controller
    {
        // GET: Admin/Numberdoctor
        HospitalDbContext db = new HospitalDbContext();
        public ActionResult Numberdoctor(string searchString, string searchKhoa, string searchTrangthai, /*DateTime searchNgay,*/ int page = 1, int pageSize = 10)
        {
            IQueryable<PHIEUHEN> list = db.PHIEUHEN.OrderBy(x => x.MaPhieu);
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.MaPhieu.Contains(searchString) || x.HOSO.HoTen.Contains(searchString) || x.THOIGIANBS.BACSI.Khoa.Contains(searchString) || x.THOIGIANBS.BACSI.HoTen.Contains(searchString) || x.THOIGIANBS.Ngay.ToString().Contains(searchString) || x.TrangThai.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(searchKhoa))
            {
                list = list.Where(x => x.THOIGIANBS.BACSI.Khoa.Contains(searchKhoa));
            }
            if (!string.IsNullOrEmpty(searchTrangthai))
            {
                list = list.Where(x => x.TrangThai.Contains(searchTrangthai));
            }
            //if (searchNgay != null)
            //{
            //    list = list.Where(x => x.NgayHen.ToString().Contains(searchNgay.ToString()));
            //}
            var model = list.OrderBy(x => x.MaPhieu).ToPagedList(page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Numberdoctorinfor(string Id)
        {
            var det = db.PHIEUHEN.Find(Id);
            return View(det);
        }
        [HttpGet]
        public ActionResult Createndo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Createndo(PHIEUHEN pHIEUHEN)
        {
            string macdinh =  "PH-" + "1";
            string trangmd = "Chưa khám";
            if (db.PHIEUHEN.Find(macdinh) == null)
            {
                pHIEUHEN.MaPhieu = macdinh;
            }
            else
            {
                string st1 = db.PHIEUHEN.Max(x => x.MaPhieu);
                string st3 = st1.Substring(3);
                int str2 = int.Parse(st3);
                pHIEUHEN.MaPhieu ="PH-" + (str2 + 1).ToString();
            }
            if (string.IsNullOrEmpty(pHIEUHEN.MaHS) == true)
            {
                ModelState.AddModelError("", "Chưa chọn hồ sơ.");
                return View(pHIEUHEN);
            }
            if (string.IsNullOrEmpty(pHIEUHEN.MaDK) == true)
            {
                ModelState.AddModelError("", "Chưa chọn giờ hẹn với Bác sĩ");
                return View(pHIEUHEN);
            }
            db.PHIEUHEN.Add(pHIEUHEN);
            db.SaveChanges();
            if (!string.IsNullOrEmpty(pHIEUHEN.MaPhieu))
            {
                return RedirectToAction("Numberdoctor");
            }
            else
            {
                ModelState.AddModelError("", "Tạo phiếu không thành công");
                return View(pHIEUHEN);
            }
        }
        [HttpGet]
        public ActionResult Editndo(string Id)
        {
            var det = db.PHIEUHEN.Find(Id);
            return View(det);
        }
        [HttpPost]
        public ActionResult Editndo(PHIEUHEN pHIEUHEN)
        {
            if (ModelState.IsValid)
            {
                var up = db.PHIEUHEN.SingleOrDefault(x => x.MaPhieu == pHIEUHEN.MaPhieu);
                up.MaHS = pHIEUHEN.MaHS;
                up.MaDK = pHIEUHEN.MaDK;
                up.TrangThai = pHIEUHEN.TrangThai;
                db.SaveChanges();
                ModelState.AddModelError("", "Cập nhật thành công");
                return RedirectToAction("Numberdoctor");
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string STT)
        {
            var user = db.PHIEUHEN.Find(STT);
            db.PHIEUHEN.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Numberdoctor");
        }
    }
}