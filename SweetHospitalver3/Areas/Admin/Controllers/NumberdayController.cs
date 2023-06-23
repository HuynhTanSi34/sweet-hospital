using PagedList;
using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Areas.Admin.Controllers
{
    public class NumberdayController : Controller
    {
        // GET: Admin/Numberday
        HospitalDbContext db = new HospitalDbContext();
        public ActionResult Numberday(string searchString, string searchKhoa, string searchTrangthai/*, DateTime searchNgay*/, int page = 1, int pageSize = 10)
        {
            IQueryable<CAPSO> list = db.CAPSO.OrderBy(x => x.STT);
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.HoTen.Contains(searchString) || x.STT.Contains(searchString) || x.Khoa.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(searchKhoa))
            {
                list = list.Where(x => x.Khoa.Contains(searchKhoa));
            }
            //if(searchKhoa == "Tất cả")
            //{
            //    list = list.Where(x => x.Khoa != searchKhoa);
            //}
            //if (searchTrangthai == "Tất cả")
            //{
            //    list = list.Where(x => x.TrangThai != searchTrangthai);
            //}
            if (!string.IsNullOrEmpty(searchTrangthai))
            {
                list = list.Where(x => x.TrangThai.Contains(searchTrangthai));
            }
            ViewBag.SearchString = searchString;
            return View(list.OrderBy(x => x.STT).ToPagedList(page, pageSize));
        }
        [HttpGet]
        public ActionResult Numberdayinfor(string id)
        {
            var det = db.CAPSO.Find(id);
            return View(det);
        }
        [HttpGet]
        public ActionResult Editnd(string Id)
        {
            var det = db.CAPSO.SingleOrDefault(x=>x.STT == Id);
            return View(det);
        }
        [HttpPost]
        public ActionResult Editnd(CAPSO cAPSO)
        {
            if (ModelState.IsValid)
            {
                var up = db.CAPSO.SingleOrDefault(x => x.STT == cAPSO.STT);
                up.HoTen = cAPSO.HoTen;
                up.Sdt = cAPSO.Sdt;
                up.Email = cAPSO.Email;
                up.Khoa = cAPSO.Khoa;
                up.TrangThai = cAPSO.TrangThai;
                db.SaveChanges();
                ModelState.AddModelError("", "Cập nhật thành công");
                return RedirectToAction("Numberday"); 
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string Id)
        {
            var user = db.CAPSO.Find(Id);
            db.CAPSO.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Numberday");
        }
        [HttpGet]
        public ActionResult Creatend()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Creatend(CAPSO cAPSO)
        {
            string macdinh = DateTime.Today.ToString("dd/MM/yyyy").Replace("/", "") + "-" + "1";
            string trangmd = "Đang chờ";
            if (db.CAPSO.Find(macdinh) == null)
            {
                cAPSO.STT = macdinh;
            }
            else
            {
                string st1 = db.CAPSO.Max(x => x.STT);
                string st3 = st1.Substring(9);
                int str2 = int.Parse(st3);
                cAPSO.STT = DateTime.Today.ToString("dd/MM/yyyy").Replace("/", "") + "-" + (str2 + 1).ToString();
            }
            cAPSO.ThoiGian = DateTime.Now;
            cAPSO.TrangThai = trangmd;
            if (string.IsNullOrEmpty(cAPSO.HoTen) == true)
            {
                ModelState.AddModelError("", "Chưa điền họ và tên nè bạn ơi!");
                return View(cAPSO);
            }
            if (string.IsNullOrEmpty(cAPSO.Sdt.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền số điện thoại nè bạn ơi!");
                return View(cAPSO);
            }
            if (string.IsNullOrEmpty(cAPSO.Email) == true)
            {
                ModelState.AddModelError("", "Chưa điền email nè bạn ơi!");
                return View(cAPSO);
            }
            if (string.IsNullOrEmpty(cAPSO.Khoa) == true)
            {
                ModelState.AddModelError("", "Chưa chọn khoa nè bạn ơi!");
                return View(cAPSO);
            }
            db.CAPSO.Add(cAPSO);
            db.SaveChanges();
            if (!string.IsNullOrEmpty(cAPSO.STT))
                {
                    return RedirectToAction("Numberday");
                }
                else
                {
                    ModelState.AddModelError("", "Cấp số không thành công");
                return View(cAPSO);
            }
            }    
        }
    }
