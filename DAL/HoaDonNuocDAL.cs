using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHoaDon.DTO;
using System.Windows.Forms;
using DevExpress.CodeParser;
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

            object kq = DataProvider.Instance.ExecuteScalar("select MAX(IDHoaDonNuoc) from HoaDonNuoc");            
            if (kq.ToString() == "")
                return 0;
            return int.Parse( kq.ToString() );
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
            if (kq==null|| kq == DBNull.Value)
                return null;
            else return int.Parse(kq.ToString());
        }

        public void NewHoaDonNuoc(string phong, int idKH, int nam, int thang, float snc, float snm)
        {            
            {
                if (DonGiaDAL.Instance.GetDonGiaNuoc(nam,thang) == null|| DonGiaDAL.Instance.GetDonGiaNuoc(nam,thang)==DBNull.Value)
                {
                    MessageBox.Show("Chưa có đơn giá nước cho tháng này. Vui lòng thêm đơn giá nước trước khi tạo hóa đơn.");
                    return;
                }
                float DonGia= float.Parse(DonGiaDAL.Instance.GetDonGiaNuoc(nam,thang).ToString());
                int k = DataProvider.Instance.ExecuteNonQuery("insert into HoaDonNuoc (IDHoaDonNuoc,IDKhachHang,Phong,Thang,Nam,SoNuocCu,SoNuocMoi,DonGia)  values ( @id1 , @id2 , @p , @th , @n , @snc , @snm , @dg )", new object[] { GetMaxIDHoaDonNuoc() + 1, idKH, phong, thang, nam, snc, snm, DonGia });
                if (k <= 0)
                {
                    MessageBox.Show("Thêm Hóa Đơn Nước thất bại");
                }
            }
            
        }

        public void DongBoHoaDonNuoc()
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("Select * from SoDienNuoc");
            foreach (DataRow row in table.Rows)
            {                
                {
                    if (GetIDHoaDonNuoc(int.Parse(row["IDSoDienNuoc"].ToString())) == null)
                    {
                        string phong = row["Phong"].ToString();
                        int idKD = int.Parse(row["IDKhachHang"].ToString());
                        int nam = int.Parse(row["Nam"].ToString());
                        int thang = int.Parse(row["Thang"].ToString());
                        float snc = float.Parse(row["SoNuocCu"].ToString());
                        float snm = float.Parse(row["SoNuocMoi"].ToString());
                        NewHoaDonNuoc(phong, idKD, nam, thang, snc, snm);
                    }
                }
                             
            }
        }
    }
}
