using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.DTO
{
    internal class HoaDonDien
    {
        public string Phong { get; set; }
        public string TenChuHo { get; set; }
        public DateTime NgayLapHoaDon { get; set; }
        public float SoDienCu { get; set; }
        public float SoDienMoi { get; set; }

        public float ThanhTien { get; set; }
        public string TrangThai { get; set; }

        public HoaDonDien() { }
         

         public HoaDonDien(string a1, string a2, DateTime a3, float a4, float a5, string a7)
         {
            this.Phong = a1;
            this.TenChuHo = a2;
            this.NgayLapHoaDon = a3;
            this.SoDienCu= a4 ;
            this.SoDienMoi = a5;
            this.TrangThai = a7;
            //Hàm tính tiền điện

            float c = a5 - a4;
            if (c <= 50) { this.ThanhTien = (float)(c * 1.8); return; }
            else if (c <= 100) { this.ThanhTien = (float)((c-50)*2+50*1.8); return; }
            else if (c<=200) { this.ThanhTien = (float)(50 * 1.8+50*2+(c-100)*2.5); return; }
            else { this.ThanhTien = (float)(50 * 1.8 + 50 * 2 + 100 * 2.5+(c-200)*3); return; }
         }



    }
}
