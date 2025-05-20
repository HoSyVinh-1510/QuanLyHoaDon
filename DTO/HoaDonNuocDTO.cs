using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace QuanLyHoaDon.DTO
{
    internal class HoaDonNuocDTO
    {

        public int IDHoaDonNuoc;
        public int IDKhachHang;
        public string SoPhong;
        public int Thang, Nam;
        public float SoNuocCu, SoNuocMoi, SoSuDung, DonGia, PhiDichVu, ThanhTien;
        public HoaDonNuocDTO() { }

        public HoaDonNuocDTO(int idHD, int idKH, string sp, int thang, int nam, float SDC, float SDM, float DG)
        {
            this.IDHoaDonNuoc = idHD;
            this.SoPhong = sp;
            this.IDKhachHang = idKH;
            this.Thang = thang;
            this.Nam = nam;
            this.SoNuocCu = SDC;
            this.SoNuocMoi = SDM;
            this.DonGia = DG;
            float SoSuDung = SDM - SDC;
            this.PhiDichVu = (float)(SoSuDung * DonGia * 0.1);
            this.ThanhTien = this.SoSuDung * DG + this.PhiDichVu;
        }
    }
}
