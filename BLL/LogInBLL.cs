using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
namespace QuanLyHoaDon.BLL
{
    internal class LogInBLL
    {
        public bool DangNhapBLL(LogIn lg)
        {
            LogInDAL logInDAL = new LogInDAL();
            return logInDAL.CheckDangNhap(lg.taikhoan, lg.matkhau);
        }
    }
}
