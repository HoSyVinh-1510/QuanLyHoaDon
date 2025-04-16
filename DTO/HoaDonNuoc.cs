using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.DTO
{
    internal class HoaDonNuoc
    {
        public string SoPhong;
        public int ID, Thang, Nam;
        public float SoNuocCu, SoNuocMoi, SoSuDung, DonGia, PhiDichVu, ThanhTien;
        public string TrangThai;
        // Trạng thái chỉ có thể là: Đã Thanh Toán   hoặc là: Chưa Thanh Toán
        public HoaDonNuoc() { }

        public HoaDonNuoc(string sp, int id, int thang, int nam, float SDC, float SDM, float DG, float PDV, string TrangThai)
        {
            this.SoPhong = sp;
            this.ID = id;
            this.Thang = thang;
            this.Nam = nam;
            this.SoNuocCu = SDC;
            this.SoNuocMoi = SDM;
            this.DonGia = DG;
            this.SoSuDung = SDM - SDC;
            this.PhiDichVu = PDV;
            this.ThanhTien = this.SoSuDung * DG + this.PhiDichVu;
            this.TrangThai = TrangThai;

        }
    }
}
