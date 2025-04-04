using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoaDon.BLL
{
    internal class HoaDonNuocBLL
    {
        public HoaDonNuocBLL() { }

        // Hàm trả về hóa đơn nước
        public List<HoaDonNuoc> AllHoaDonNuoc()
        {
            HoaDonNuocDAL hoaDonNuocDAL = new HoaDonNuocDAL();
            return hoaDonNuocDAL.FullListHoaDonNuoc();
        }

        public void HienThiToanBoHoaDonNuoc(List<HoaDonNuoc> list0, ListView list1)
        {   
            list1.Items.Clear();
            foreach (HoaDonNuoc hd in list0)
            {
                ListViewItem item = new ListViewItem(hd.Phong);
                item.SubItems.Add(hd.TenChuHo);
                item.SubItems.Add(hd.NgayLapHoaDon.ToString());
                item.SubItems.Add(hd.SoNuocCu.ToString());
                item.SubItems.Add(hd.SoNuocMoi.ToString());
                item.SubItems.Add(hd.ThanhTien.ToString());
                item.SubItems.Add(hd.TrangThai.ToString());

                list1.Items.Add(item);
            }
        }

        // Hàm trả về hóa đơn nước theo tên, và ngày lập hóa đơn
        public List<HoaDonNuoc> Find(string phong)
        {
            HoaDonNuocDAL hoaDonDienDAL = new HoaDonNuocDAL();
            return hoaDonDienDAL.Find(phong);
        }

        public List<HoaDonNuoc> FindState(string trangthai)
        {
            List<HoaDonNuoc> listChuHo = new List<HoaDonNuoc>();
            Connect cn = new Connect();
            cn.OpenConnect();
            string query = "SELECT * FROM HoaDonNuoc WHERE TrangThai= @trangthai";
            SqlCommand cmd = new SqlCommand(query, cn.connect);
            cmd.Parameters.AddWithValue("@trangthai", trangthai);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HoaDonNuoc hd = new HoaDonNuoc(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), ((float)reader.GetDecimal(3)), ((float)reader.GetDecimal(4)), reader.GetString(6));
                listChuHo.Add(hd);
            }
            cn.CloseConnect();
            return listChuHo;
        }

        // Hàm xóa hóa đơn nước
        public void DeleteHoaDonNuoc(string phong, DateTime date)
        {
            HoaDonNuocDAL hoaDonDienDAL = new HoaDonNuocDAL();
            hoaDonDienDAL.DeleteHoaDonNuoc(phong, date);
            return;

        }

        // hàm cập nhật hóa đơn nước
        public void UpdateHoaDonNuoc(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            HoaDonNuocDAL hoaDonDienDAL = new HoaDonNuocDAL();
            hoaDonDienDAL.UpdateHoaDonNuoc(a0, a1, a2, a3, a4, a5, a6);
            return;
        }

        // Hàm thêm hóa đơn nước
        public void AddHoaDonNuoc(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            HoaDonNuocDAL hoaDonDienDAL = new HoaDonNuocDAL();
            hoaDonDienDAL.AddHoaDonNuoc(a0, a1, a2, a3, a4, a5, a6);
            return;
        }
    }
}
