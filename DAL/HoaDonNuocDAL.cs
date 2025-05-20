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

        public int GetMaxIDHoaDonNuoc()
        {
            object kq= DataProvider.Instance.ExecuteScalar("select MAX(IDHoaDonNuoc) from HoaDonNuoc");
            if (kq == null)
            return 0;
            else return int.Parse(kq.ToString());
        }

        public int? GetIDHoaDonNuoc(int IDSoDienNuoc)
        {
            // Lấy ra ID của bảng số điện nước. Check Xem nó đã có ở trong bảng Hóa Đơn Điện chưa?
            DataRow row = DataProvider.Instance.ExecuteQuery("Select * from SoDienNuoc where IDSoDienNuoc= @a ", new object[] { IDSoDienNuoc }).Rows[0];
            int idKh = int.Parse(row["IDKhachHang"].ToString());
            string phong = row["Phong"].ToString();
            int nam = int.Parse(row["Nam"].ToString());
            int thang = int.Parse(row["Thang"].ToString());

            object kq = DataProvider.Instance.ExecuteScalar("select IDHoaDonNuoc from HoaDonNuoc where IDKhachHang= @id and Phong= @p and Nam= @n and Thang= @t", new object[] { idKh, phong, nam, thang });
            if (kq == null)
                return null;
            else return int.Parse(kq.ToString());
        }

        public void NewHoaDonNuoc(string phong, int idKH, int nam, int thang, int DonGia)
        {
            try
            {
                int idSDN = SoDienNuocDAL.Instance.GetIDSoDienNuoc(phong, idKH, nam, thang);
                DataTable dataTable = DataProvider.Instance.ExecuteQuery("Select * from SoDienNuoc where IDSoDienNuoc= @id", new object[] { idSDN });
                DataRow row = dataTable.Rows[0];
                int snc = int.Parse(row["SoNuocCu"].ToString());
                int snm = int.Parse(row["SoNuocMoi"].ToString());
                int k = DataProvider.Instance.ExecuteNonQuery("insert into HoaDonNuoc (IDHoaDonNuoc,IDKhachHang,Phong,Thang,Nam,SoNuocCu,SoNuocMoi,DonGia)  values ( @id1 , @id2 , @p , @th , @n , @sdc , @sdm , @dg)", new object[] { GetMaxIDHoaDonNuoc() + 1, idKH, phong, thang, nam, snc, snm, DonGia });
                if (k < 0)
                {
                    MessageBox.Show("Thêm Hóa Đơn Điện thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo hóa đơn điện: " + ex.Message);
            }
        }

        public void DongBoHoaDonNuoc()
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("Select * from SoDienNuoc ");
            foreach (DataRow row in table.Rows)
            {
                if (GetIDHoaDonNuoc(int.Parse(row["IDSoDienNuoc"].ToString())) == null)
                {
                    string phong = row["Phong"].ToString();
                    int idKD = int.Parse(row["IDKhachHang"].ToString());
                    int nam = int.Parse(row["Nam"].ToString());
                    int thang = int.Parse(row["Thang"].ToString());
                    int dongia = int.Parse(row["DonGia"].ToString());
                    //string phong,int idKH,int nam, int thang, int DonGia
                    NewHoaDonNuoc(phong, idKD, nam, thang, dongia);
                }
            }
        }



    }
}
