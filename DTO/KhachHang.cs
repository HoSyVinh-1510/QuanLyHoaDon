using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace QuanLyHoaDon.DTO
{
    internal class KhachHang
    {
        public int IDKhachHang;
        public string Ten;
        public string SDT;
        public KhachHang() { }
        public KhachHang(int id, string ten, string sdt)
        {
            this.IDKhachHang = id;
            this.Ten = ten;
            this.SDT = sdt;
        }
    }
}
