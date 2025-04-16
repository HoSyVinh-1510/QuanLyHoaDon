using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
namespace QuanLyHoaDon.BLL
{
    internal class SoDienNuocBLL
    {
        public SoDienNuocBLL() { }
        public DataTable FullSoDienNuoc(string Phong)
        {
            SoDienNuocDAL soDienNuocDAL = new SoDienNuocDAL();
            return soDienNuocDAL.FullSoDienNuoc(Phong);
        }

        public void AddSoDienNuoc(string Phong, int thang, int nam, float sodienmoi, float sonuocmoi)
        {
            SoDienNuocDAL soDienNuocDAL=new SoDienNuocDAL();    
            soDienNuocDAL.AddSoDienNuoc(Phong,thang,nam,sodienmoi,sonuocmoi);
        }

        public SoDienNuoc TimSoDienNuocThang(string phong, int thang, int nam)
        {
            SoDienNuocDAL soDienNuocDAL= new SoDienNuocDAL();
            return soDienNuocDAL.TimSoDienNuocThang(phong,thang,nam);
        }


    }
}
