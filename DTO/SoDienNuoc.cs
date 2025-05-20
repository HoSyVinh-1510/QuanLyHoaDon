using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace QuanLyHoaDon.DTO
{
    internal class SoDienNuoc
    {
        public int IDSoDienNuoc;
        public string SoPhong;
        public int Thang, Nam;
        public float SoDienCu, SoDienMoi, SoNuocCu, SoNuocMoi; 
        public SoDienNuoc() { }

        public SoDienNuoc(int Id ,string soPhong,int thang, int nam, float soDienCu, float soDienMoi, float soNuocCu, float soNuocMoi)
        {
            IDSoDienNuoc = Id;
            SoPhong = soPhong;
            this.Thang = thang;
            this.Nam = nam;

            SoDienCu = soDienCu;
            SoDienMoi = soDienMoi;
            SoNuocCu = soNuocCu;
            SoNuocMoi = soNuocMoi;
        }
    }
}
