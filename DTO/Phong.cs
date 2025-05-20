using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace QuanLyHoaDon.DTO
{
    internal class Phong
    {
        public string SoPhong;
        public string TrangThai; // "Trống" hoặc "Đang SD"
        public Phong() { }
        public Phong(string soPhong, string trangThai)
        {
            this.SoPhong = soPhong;
            this.TrangThai = trangThai;
        }
    }
}
