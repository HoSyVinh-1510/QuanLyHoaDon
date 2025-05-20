using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.DTO
{
    internal class LichSuThanhToanHoaDonDien
    {
        public int IDLichSu;
        public int IDHoaDonNuoc;
        public DateTime NgayThanhToan;
        public LichSuThanhToanHoaDonDien() { }

        public LichSuThanhToanHoaDonDien(int idLS,int idHD,DateTime dateTime) 
        {
            this.IDLichSu = idLS;
            this.IDHoaDonNuoc = idHD;
            this.NgayThanhToan = dateTime;
        }

    }
}
