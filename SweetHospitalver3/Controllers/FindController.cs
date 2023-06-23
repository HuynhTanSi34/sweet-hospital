using PagedList;
using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Controllers
{
    public class FindController : Controller
    {
        // GET: Find
        HospitalDbContext db = new HospitalDbContext();
        public ActionResult Find(string searchString, string searchKhoa, string searchTrangthai, int page = 1, int pageSize = 10)
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
    }
}