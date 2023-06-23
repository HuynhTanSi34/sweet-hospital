using PagedList;
using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Areas.Admin.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Admin/Schedule
        HospitalDbContext db = new HospitalDbContext();
        public ActionResult Schedule(string searchString, string searchKhoa, string searchTrangthai, /*DateTime searchNgay,*/ int page = 1, int pageSize = 10)
        {
            IQueryable<THOIGIANBS> list = db.THOIGIANBS.OrderBy(x => x.MaDK);
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.MaBS.Contains(searchString) || x.BACSI.HoTen.Contains(searchString) || x.BACSI.Khoa.Contains(searchString) || x.Ngay.ToString().Contains(searchString) || x.Gio.ToString().Contains(searchString) || x.TrangThai.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(searchKhoa))
            {
                list = list.Where(x => x.BACSI.Khoa.Contains(searchKhoa));
            }
            if (!string.IsNullOrEmpty(searchTrangthai))
            {
                list = list.Where(x => x.TrangThai.Contains(searchTrangthai));
            }
            //if (searchNgay != null)
            //{
            //    list = list.Where(x => x.Ngay.ToString().Contains(searchNgay.ToString()));
            //}
            var model = list.OrderBy(x => x.MaBS).ToPagedList(page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Scheduleinfor(string Id)
        {
            var det = db.THOIGIANBS.Find(Id);
            return View(det);
        }
        [HttpGet]
        public ActionResult Editschedule(string Id)
        {
            var det = db.THOIGIANBS.Find(Id);
            return View(det);
        }
        [HttpPost]
        public ActionResult Editschedule(THOIGIANBS tHOIGIANBS)
        {
            if (ModelState.IsValid)
            {
                var up = db.THOIGIANBS.Find(tHOIGIANBS.MaDK);
                up.Gio = tHOIGIANBS.Gio;
                up.TrangThai = tHOIGIANBS.TrangThai;
                db.SaveChanges();
                    ModelState.AddModelError("", "Cập nhật thành công");
                    return RedirectToAction("Schedule");
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string Id)
        {
            var user = db.THOIGIANBS.Find(Id);
            db.THOIGIANBS.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Schedule");
        }
        [HttpGet]
        public ActionResult Createschedule()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Createschedule(THOIGIANBS tHOIGIANBS)
        {
            string ttmd = "Chưa đặt";
            string st1 = db.THOIGIANBS.Max(x => x.MaDK);
            string st3 = st1.Substring(3);
            int str2 = int.Parse(st3);
            tHOIGIANBS.MaDK = "SCH" + (str2 + 1).ToString();
            tHOIGIANBS.TrangThai = ttmd;
            if (string.IsNullOrEmpty(tHOIGIANBS.MaBS) == true)
            {
                ModelState.AddModelError("", "Chưa chọn mã Bác sĩ!");
                return View(tHOIGIANBS);
            }
            if (tHOIGIANBS.Ngay.ToString() == "01/01/0001")
            {
                ModelState.AddModelError("", "Chưa chọn ngày!");
                return View(tHOIGIANBS);
            }
            if (tHOIGIANBS.Gio.ToString() == "00:00:00")
            {
                ModelState.AddModelError("", "Chưa chọn giờ!");
                return View(tHOIGIANBS);
            }
            db.THOIGIANBS.Add(tHOIGIANBS);
            db.SaveChanges();
            if (!string.IsNullOrEmpty(tHOIGIANBS.MaDK))
            {
                return RedirectToAction("Schedule");
            }
            else
            {
                ModelState.AddModelError("", "Đăng ký lịch không thành công");
                return View(tHOIGIANBS);
            }
        }
    }
}