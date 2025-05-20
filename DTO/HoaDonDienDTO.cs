using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace QuanLyHoaDon.DTO
{
    internal class HoaDonDienDTO
    {
        public int IDHoaDonDien;
        public int IDKhachHang;
        public string SoPhong;
        public int Thang, Nam;
        public float SoDienCu, SoDienMoi, SoSuDung ,DonGia, PhiDichVu, ThanhTien;
        public HoaDonDienDTO() { }

        public HoaDonDienDTO(int idHD,int idKH, string sp, int thang, int nam, float SDC, float SDM,float DG)
        {
            this.IDHoaDonDien = idHD;
            this.SoPhong = sp;
            this.IDKhachHang = idKH;
            this.Thang = thang;
            this.Nam = nam;
            this.SoDienCu = SDC;
            this.SoDienMoi = SDM;
            this.DonGia = DG;   
            this.SoSuDung = this.SoDienMoi - this.SoDienCu;
            this.PhiDichVu = (float)(SoSuDung*DonGia*0.1);
            this.ThanhTien= this.SoSuDung*DG+this.PhiDichVu;
        }
    }
}
