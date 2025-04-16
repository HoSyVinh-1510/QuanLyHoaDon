using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.DTO
{
    internal class HopDong
    {   
        public int IDHopDong;
        public string Phong;
        public int Name;
        public DateTime NgayBD;
        public DateTime NgayKT;
        public string TrangThai;
        public HopDong(int ID,string phong, int name, DateTime ngayBD, DateTime ngayKT)
        {
            IDHopDong = ID;
            Phong = phong;
            Name = name;
            NgayBD = ngayBD;
            NgayKT = ngayKT;
            if (ngayKT > DateTime.Now || ngayKT== null )
            {
                TrangThai = "Đang Thuê";
            }
            else
            {
                TrangThai = "Hết Hạn";
            }
        }
        public HopDong() { }
    }
}
