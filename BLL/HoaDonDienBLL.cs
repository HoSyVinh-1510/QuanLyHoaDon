using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoaDon.BLL
{
    internal class HoaDonDienBLL
    {
        public HoaDonDienBLL() { }

        // Hàm trả về hóa đơn điện
        public List<HoaDonDien> AllHoaDonDien()
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            return hoaDonDienDAL.FullListHoaDonDien();
        }

        public void HienThiToanBoHoaDonDien(List<HoaDonDien> list0, ListView list1)
        {
            foreach (HoaDonDien hd in list0)
            {
                ListViewItem item = new ListViewItem();
                hd.Phong=item.SubItems[0].ToString();
                hd.TenChuHo=item.SubItems[1].ToString();
                hd.NgayLapHoaDon = DateTime.Parse(item.SubItems[2].ToString());
                hd.SoDienCu = float.Parse( item.SubItems[3].ToString());
                hd.SoDienMoi = float.Parse(item.SubItems[4].ToString());
                hd.ThanhTien= float.Parse(item.SubItems[5].ToString());
                hd.TrangThai= item.SubItems[6].ToString();
                list1.Items.Add(item);
            }
        }

        // Hàm trả về hóa đơn điện theo tên, và ngày lập hóa đơn
        public List<HoaDonDien> Find(string phong, DateTime date)
        {
            HoaDonDienDAL hoaDonDienDAL= new HoaDonDienDAL();
            return hoaDonDienDAL.Find(phong, date);
        }

        // Hàm xóa hóa đơn điện
        public List<HoaDonDien> DeleteHoaDonDien(string phong, DateTime date)
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            return hoaDonDienDAL.Find(phong, date);
        }

        // hàm cập nhật hóa đơn điện
        public void UpdateHoaDonDien(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            HoaDonDienDAL hoaDonDienDAL= new HoaDonDienDAL();
            hoaDonDienDAL.UpdateHoaDonDien(a0, a1, a2,a3, a4, a5, a6);
            return;
        }

        // Hàm thêm hóa đơn điện 
        public void AddHoaDonDien(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            HoaDonDienDAL hoaDonDienDAL=new HoaDonDienDAL();
            hoaDonDienDAL.AddHoaDonDien(a0,a1,a2,a3,a4,a5,a6);
            return;
        }


    }
}
