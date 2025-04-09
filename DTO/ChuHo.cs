using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.DTO
{
    public class ChuHo
    {
        public string MaChuHo { get; set; }
        public string TenChuHo { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }

        public ChuHo() { }
        public ChuHo(string maChuHo, string tenChuHo, DateTime ngaySinh, string gioiTinh, string sDT)
        {
            MaChuHo = maChuHo;
            TenChuHo = tenChuHo;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            SDT = sDT;
        }
    }
}
