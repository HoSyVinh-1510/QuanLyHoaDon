using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.DTO
{
    internal class HoaDonNuoc
    {
        public string Phong { get; set; }
        public string TenChuHo { get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public float SoNuocCu { get; set; }
        public float SoNuocMoi { get; set; }

        public float ThanhTien { get; set; }
        public string TrangThai { get; set; }

        public HoaDonNuoc() { }


        public HoaDonNuoc(string a1, string a2, DateTime a3, float a4, float a5, string a7)
        {
            this.Phong = a1;
            this.TenChuHo = a2;
            this.NgayLapHoaDon = a3;
            this.SoNuocCu = a4;
            this.SoNuocMoi = a5;
            this.TrangThai = a7;
            //Hàm tính tiền điện

            float c = a5 - a4;
            if (c <= 50) { this.ThanhTien = (float)(c * 4.5); return; }
            else if (c <= 100) { this.ThanhTien = (float)((c - 50) * 5.0 + 50 * 4.5); return; }
            else if (c <= 200) { this.ThanhTien = (float)(50 * 4.5 + 50 * 5.0 + (c - 200) * 5.5); return; }
            else { this.ThanhTien = (float)(50 * 4.5 + 50 * 5.0 + 100 * 5.5 + (c - 200) * 6); return; }
        }
    }
}
