using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.DTO
{
    internal class KhachHang
    {
        public int ID;
        public string Ten;
        public string SDT;
        public KhachHang() { }
        public KhachHang(int id, string ten, string sdt)
        {
            this.ID = id;
            this.Ten = ten;
            this.SDT = sdt;
        }
    }
}
