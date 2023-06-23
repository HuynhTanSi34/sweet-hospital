

using SweetHospitalver3.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SweetHospitalver3.Controllers
{
    public class AppointmentController : Controller
    {

        // GET: Appointment
        HospitalDbContext  db = new HospitalDbContext();
        
        public ActionResult Appointment()
        {
            return View();
        }
        public ActionResult AppDoctor()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AppRecord(/*string hs*/)
        {
            Console.WriteLine(db.BACSI.GetType());
            System.Diagnostics.Debug.WriteLine(db.BACSI.GetType());

            return View();
        }

        [HttpPost]
        public Microsoft.AspNetCore.Mvc.IActionResult AppRecord([Microsoft.AspNetCore.Mvc.FromBody] Answer datas)

        {
            return (Microsoft.AspNetCore.Mvc.IActionResult)(db.BACSI);
        }
        [HttpGet]
        public ActionResult AppDay()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AppDay(CAPSO tAIKHOAN)
        {
            if (string.IsNullOrEmpty(tAIKHOAN.HoTen) == true)
            {
                ModelState.AddModelError("", "Chưa điền họ và tên nè bạn ơi!");
                return View(tAIKHOAN);
            }
            if (string.IsNullOrEmpty(tAIKHOAN.Sdt.ToString()) == true)
            {
                ModelState.AddModelError("", "Chưa điền số điện thoại nè bạn ơi!");
                return View(tAIKHOAN);
            }
            if (string.IsNullOrEmpty(tAIKHOAN.Email) == true)
            {
                ModelState.AddModelError("", "Chưa điền Email nè bạn ơi!");
                return View(tAIKHOAN);
            }
            if (tAIKHOAN.Khoa == "Chọn khoa")
            {
                ModelState.AddModelError("", "Chưa chọn khoa nè bạn ơi!");
                return View(tAIKHOAN);
            }
            string macdinh = DateTime.Today.ToString("dd/MM/yyyy").Replace("/", "") + "-" + "1";
            string trangmd = "Đang chờ";
               if (db.CAPSO.Find(macdinh) == null)
                {
                    tAIKHOAN.STT = macdinh;
                }
                else
                {
                    string st1 = db.CAPSO.Max(x => x.STT);
                    string st3 = st1.Substring(9);
                    int str2 = int.Parse(st3);
                    tAIKHOAN.STT = DateTime.Today.ToString("dd/MM/yyyy").Replace("/", "") + "-" + (str2 + 1).ToString();
                }
                tAIKHOAN.ThoiGian = DateTime.Now;
                tAIKHOAN.TrangThai = trangmd;
                db.CAPSO.Add(tAIKHOAN);
                db.SaveChanges();
            if (!string.IsNullOrEmpty(tAIKHOAN.STT))
            {
                return RedirectToAction("Appointment");
            }
            else
            {
                ModelState.AddModelError("","Cấp số thất bại");
                return View(tAIKHOAN);
            }
        }
    }
}