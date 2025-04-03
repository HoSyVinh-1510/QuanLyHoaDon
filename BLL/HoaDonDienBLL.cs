using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.BLL
{
    internal class HoaDonDienBLL
    {
        public HoaDonDienBLL() { }

        // Hàm trả về hóa đơn điện
        public List<HoaDonDien> ShowAllHoaDonDien()
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            return hoaDonDienDAL.FullListHoaDonDien();
        }

        // Hàm trả về hóa đơn điện theo tên, và ngày lập hóa đơn
        public List<HoaDonDien> Find(string phong, DateTime date)
        {
            HoaDonDienDAL hoaDonDienDAL= new HoaDonDienDAL();
            return hoaDonDienDAL.Find(phong, date);
        }

        // Hàm xóa hóa đơn điện
        public List<HoaDonDien> DeleteHoaDonDien(string phong, DateTime date)
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            return hoaDonDienDAL.Find(phong, date);
        }

        // hàm cập nhật hóa đơn điện
        public void UpdateHoaDonDien(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            HoaDonDienDAL hoaDonDienDAL= new HoaDonDienDAL();
            hoaDonDienDAL.UpdateHoaDonDien(a0, a1, a2,a3, a4, a5,a6);
            return;
        }

        // Hàm thêm hóa đơn điện 
        public void AddHoaDonDien(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            HoaDonDienDAL hoaDonDienDAL=new HoaDonDienDAL();
            hoaDonDienDAL.AddHoaDonDien(a0,a1,a2,a3,a4,a5,a6);
            return;
        }
    }
}
