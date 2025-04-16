using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHoaDon.DTO;
using QuanLyHoaDon.BLL;
using QuanLyHoaDon.DAL;
namespace QuanLyHoaDon.BLL
{
    internal class HoaDonNuocBLL
    {

        HoaDonNuocBLL() { }
        public DataTable FullHoaDonNuoc(string phong)
        {
            HoaDonNuocDAL hoaDonNuocDAL = new HoaDonNuocDAL();
            return hoaDonNuocDAL.FullHoaDonNuoc(phong);
        }

        public void ThanhToanHoaDonNuoc(string phong, int thang, int nam)
        {
            HoaDonNuocDAL hoaDonNuocDAL = new HoaDonNuocDAL();
            hoaDonNuocDAL.ThanhToanHoaDonNuoc(phong, thang, nam);
        }

        public void TaoHoaDonNuoc(string phong, int thang, int nam, float SDM, float DG, float PDV)
        {
            HoaDonNuocDAL hoaDonNuocDAL = new HoaDonNuocDAL();
            hoaDonNuocDAL.TaoHoaDonNuoc(phong, thang, nam, SDM , DG, PDV);
        }

        public DataTable HoaDonNuocChuaThanhToan()
        {
            HoaDonNuocDAL hoaDonNuocDAL = new HoaDonNuocDAL();
            return hoaDonNuocDAL.HoaDonNuocChuaThanhToan();
        }
        public List<string> PhongCoSoThangChuaThanhToanNhieuHonK(int k)
        {
            HoaDonNuocDAL hoaDonNuocDAL = new HoaDonNuocDAL();
            return hoaDonNuocDAL.PhongCoSoThangChuaThanhToanNhieuHonK(k);
        }
    }
}
