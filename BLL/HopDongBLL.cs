using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
namespace QuanLyHoaDon.BLL
{
    internal class HopDongBLL
    {
        public HopDongBLL() { }
        public DataTable HopDongPhong(string p)
        {
            HopDongDAL hopDongDAL  = new HopDongDAL();
            return hopDongDAL.HopDongPhong(p);
        }

        public void UpdateHopDong(int id, DateTime kthuc)
        {
            HopDongDAL hopDongDAL=new HopDongDAL();
            hopDongDAL.UpdateHopDong(id, kthuc);
        }

        public void StopHopDong(int id)
        {
            HopDongDAL hopDongDAL= new HopDongDAL();
            hopDongDAL.StopHopDong(id);
        }



    }
}
