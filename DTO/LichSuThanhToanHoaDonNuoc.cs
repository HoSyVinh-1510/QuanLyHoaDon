using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.DTO
{
    internal class LichSuThanhToanHoaDonNuoc
    {

        public int IDLichSu;
        public int IDHoaDonNuoc;
        public DateTime NgayThanhToan;
        public LichSuThanhToanHoaDonNuoc() { }

        public LichSuThanhToanHoaDonNuoc(int idLS, int idHD, DateTime dateTime)
        {
            this.IDLichSu = idLS;
            this.IDHoaDonNuoc = idHD;
            this.NgayThanhToan = dateTime;
        }
    }
}
