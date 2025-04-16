using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
namespace QuanLyHoaDon.BLL
{
    internal class PhongBLL
    {
        public PhongBLL() { }
        public void ThemPhong(Phong p)
        {
            PhongDAL phongDAL = new PhongDAL();
            phongDAL.ThemPhong(p.SoPhong,p.TrangThai);
            return;
        }
        public List<Phong> FullPhong()
        {
            PhongDAL phong=new PhongDAL();
            return phong.FullPhong();
        }

        public List<Phong> TimPhongTrong()
        {
            PhongDAL phong = new PhongDAL();
            return phong.TimPhongTheoTrangThai("Trống");
        }
        public List<Phong> PhongUsed()
        {
            PhongDAL phong = new PhongDAL();
            return phong.TimPhongTheoTrangThai("Đang SD");
        }

        public void SuaTrangThaiPhong(Phong p)
        {
            PhongDAL phongDAL = new PhongDAL();
            phongDAL.SuaTrangThaiPhong(p.SoPhong, p.TrangThai);

        }
    }
}
