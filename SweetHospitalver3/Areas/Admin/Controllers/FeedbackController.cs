using PagedList;
using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetHospitalver3.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Admin/Feedback
        HospitalDbContext db = new HospitalDbContext();
        public ActionResult Feedback(string searchString, string searchTrangthai, int page = 1, int pageSize = 10)
        {
            IQueryable<PHANHOI> list = db.PHANHOI.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.HoTen.Contains(searchString) || x.Email.Contains(searchString) || x.NoiDung.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(searchTrangthai))
            {
                list = list.Where(x => x.TrangThai.Contains(searchTrangthai));
            }
            var model = list.OrderBy(x => x.Id).ToPagedList(page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Editfb(string Id)
        {
            var det = db.PHANHOI.SingleOrDefault(x => x.Id.ToString() == Id);
            return View(det);
        }
        [HttpPost]
        public ActionResult Editfb(PHANHOI pHANHOI)
        {
            if (ModelState.IsValid)
            {
                var up = db.PHANHOI.Find(pHANHOI.Id);
                up.TraLoi = pHANHOI.TraLoi;
                up.TrangThai = pHANHOI.TrangThai;
                db.SaveChanges();
                ModelState.AddModelError("", "Cập nhật thành công");
                return RedirectToAction("Feedback");
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string Id)
        {
            var user = db.PHANHOI.SingleOrDefault(x => x.Id.ToString() == Id);
            db.PHANHOI.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Feedback");
        }
    }
}