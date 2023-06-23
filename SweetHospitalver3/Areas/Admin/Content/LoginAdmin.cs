using SweetHospitalver3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SweetHospitalver3.Areas.Admin.Content
{
    public class LoginAdmin
    {
        HospitalDbContext context = null;
        public LoginAdmin()
        {
            context = new HospitalDbContext();
        }
        public TAIKHOAN GetById(string TK)
        {
            return context.TAIKHOAN.SingleOrDefault(x => x.TK == TK);
        }
        public int Login(string TK, string Pass, string chucDanh)
        {
            var res = context.TAIKHOAN.SingleOrDefault(x => x.TK == TK);
            if (res == null)
            {
                return 0;
            }
            else
            {
                if (res.TrangThai == "Đã nghỉ việc")
                {
                    return -1;
                }
                else
                {
                    if (res.Pass == Pass)
                        return 1;
                    else
                        return -2;

                }
            }
        }
    }
}