using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SweetHospitalver3.Areas.Admin.Data
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập tên tài khoản")]
        public string TK { set; get; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string Pass { set; get; }
        public string ChucDanh { set; get; }
        public string TrangThai { set; get; }
        public bool RememberMe { set; get; }
    }
}