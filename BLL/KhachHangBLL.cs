using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
namespace QuanLyHoaDon.BLL
{
    internal class KhachHangBLL
    {
        public KhachHangBLL() { }
        public DataTable FullKhachHang()
        {
            KhachHangDAL khachhang = new KhachHangDAL();
            return khachhang.FullKhachHang();
        }
        public void ThemKhachHang(KhachHang kh)
        {
            KhachHangDAL khachhang = new KhachHangDAL();
            khachhang.ThemKhachHang(kh.ID, kh.Ten, kh.SDT);
        }
        public void SuaKhachHang(KhachHang kh)
        {
            KhachHangDAL khachhang = new KhachHangDAL();
            khachhang.SuaKhachHang(kh.ID, kh.Ten, kh.SDT);
        }
    }
}
