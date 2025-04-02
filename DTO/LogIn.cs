using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.DTO
{
    internal class LogIn
    {
        string Taikhoan;
        string Matkhau;
        public string taikhoan { get => Taikhoan; set => Taikhoan = value; }
        public string matkhau { get => Matkhau; set => Matkhau = value; }

        public void Account(string taikhoan, string matkhau)
        {
            this.Taikhoan = taikhoan;
            this.Matkhau = matkhau;
        }
        public LogIn()  { }
    }
}
