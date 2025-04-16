using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHoaDon.DTO;
using QuanLyHoaDon.DAL;
namespace QuanLyHoaDon.BLL
{
    internal class HoaDonDienBLL
    {
        HoaDonDienBLL() { }
        public DataTable FullHoaDonDien(string phong)
        {
            HoaDonDienDAL   hoaDonDienDAL = new HoaDonDienDAL();    
            return hoaDonDienDAL.FullHoaDonDien(phong);
        }

        public void ThanhToanHoaDonDien(string phong, int thang, int nam)
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            hoaDonDienDAL.ThanhToanHoaDonDien(phong, thang, nam);
        }

        public void TaoHoaDonDien(string phong, int thang, int nam, float SDM, float DG, float PDV)
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            hoaDonDienDAL.TaoHoaDonDien(phong,thang,nam,SDM,DG,PDV);
        }

        public DataTable HoaDonDienChuaThanhToan()
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            return hoaDonDienDAL.HoaDonDienChuaThanhToan();
        }
        public List<string> PhongCoSoThangChuaThanhToanNhieuHonK(int k)
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            return hoaDonDienDAL.PhongCoSoThangChuaThanhToanNhieuHonK(k);
        }

    }
}
