using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHoaDon.DTO;
using System.Windows.Forms;
namespace QuanLyHoaDon.DAL
{
    internal class HoaDonNuocDAL
    {
        private static HoaDonNuocDAL instance;
        public static HoaDonNuocDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonNuocDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private HoaDonNuocDAL() { }

        public DataTable FullHoaDonNuoc(string phong)
        {
            string query = " Select * from HoaDonNuoc where Phong= @p  ";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { phong });
            return dt;
        }


        public void ThanhToanHoaDonNuoc(string phong, int thang, int nam)
        {
            string query = " Update HoaDonNuoc Set  TrangThai= @tt Where Phong= @p and Thang= @t and Nam= @n  ";
            string k = "Đã Thanh Toán";
            if (DataProvider.Instance.ExecuteNonQuery(query, new object[] { k, phong, thang, nam }) == 0)
            {
                MessageBox.Show("Failed!");
                return;
            }
            MessageBox.Show("Successful!");
            return;
        }

        public void TaoHoaDonNuoc(string phong, int thang, int nam, float SDM, float DG, float PDV)
        {
            string query = " Tim_ID_KhachHang @thang , @nam ";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { thang, nam });
            int Id = int.Parse(dataTable.Rows[0]["ID"].ToString());
            int thang0, nam0;
            if (thang == 1) { thang0 = 12; nam0 = nam - 1; }
            else { thang0 = thang - 1; nam0 = nam; }

            query = " Select SoNuocMoi from HoaDonNuoc where Phong= @phong and Thang= @thang and Nam= @nam ";
            dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { phong, thang0, nam0 });
            int SDC = int.Parse(dataTable.Rows[0]["SoNuocMoi"].ToString());
            if (SDC > SDM) return;

            HoaDonNuoc hoaDonNuoc = new HoaDonNuoc(phong, Id, thang, nam, SDC, SDM, DG, PDV, "Chưa Thanh Toán");
            query = " Insert_HoaDonNuoc @phong , @id , @thang , @nam, @sdc , @sdm , @ssd , @db , @pdv , @tt  ";
            int k = DataProvider.Instance.ExecuteNonQuery(query, new object[] { phong, Id, thang, nam, SDC, SDM, DG, PDV, hoaDonNuoc.ThanhTien });
            if (k > 0)
            {
                MessageBox.Show(" Them Hoa Don Thanh Cong!"); return;
            }
            else { return; }
        }


        public DataTable HoaDonNuocChuaThanhToan()
        {
            string query = "HoaDonNuoc_ChuaThanhToan";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            return dataTable;
        }

        public List<string> PhongCoSoThangChuaThanhToanNhieuHonK(int k)
        {

            string query = "Phong_ChuaThanhToanNuoc @k";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query, new object[] { k });
            List<string> list = new List<string>();
            foreach (DataRow item in dataTable.Rows)
            {
                list.Add(item["Phong"].ToString());
            }
            return list;
        }

    }
}
