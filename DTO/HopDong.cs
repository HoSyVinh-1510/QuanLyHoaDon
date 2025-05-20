using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace QuanLyHoaDon.DTO
{

    internal class HopDong
    {   
        public int IDHopDong;
        public int IDKhachHang; 
        public string Phong;
        public DateTime NgayBD;
        public DateTime? NgayKT;

        public HopDong(int IDHopdong, int IDKhachhang, string phong, DateTime ngayBD, DateTime? ngayKT)
        {
            this.IDHopDong = IDHopdong;
            this.Phong = phong;
            this.IDKhachHang = IDKhachhang;
            this.NgayBD = ngayBD;
            this.NgayKT = ngayKT;
        }
        public HopDong() { }
    }
}
