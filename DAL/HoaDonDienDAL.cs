using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyHoaDon.DTO;
using System.Collections;
using System.Windows.Forms;
namespace QuanLyHoaDon.DAL
{
    internal class HoaDonDienDAL
    {
        private static HoaDonDienDAL instance;
        public static HoaDonDienDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDonDienDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private HoaDonDienDAL() { }
       

        public int GetMaxIDHoaDonDien()
        {
            object kq = DataProvider.Instance.ExecuteScalar("select MAX(IDHoaDonDien) from HoaDonDien");
            if (kq == null)
                return 0;
            else
                return int.Parse(kq.ToString());        
        }

        public int? GetIDHoaDonDien(int IDSoDienNuoc)
        {
            DataRow row= DataProvider.Instance.ExecuteQuery("Select * from SoDienNuoc where IDSoDienNuoc= @a ",new object[] {IDSoDienNuoc}).Rows[0];
            int idKh = int.Parse(row["IDKhachHang"].ToString());
            string phong = row["Phong"].ToString();
            int nam = int.Parse(row["Nam"].ToString());
            int thang= int.Parse(row["Thang"].ToString()); 

            object kq= DataProvider.Instance.ExecuteScalar("select IDHoaDonDien from HoaDonDien where IDKhachHang= @id and Phong= @p and Nam= @n and Thang= @t", new object[] { idKh, phong, nam, thang });
            if (kq == null)
                return null;
            else return int.Parse(kq.ToString());
        }

        public void NewHoaDonDien(string phong,int idKH,int nam, int thang)
        {
            try
            {
                float DonGia= GetDonGia(thang, nam);
                int idSDN = SoDienNuocDAL.Instance.GetIDSoDienNuoc(phong, idKH, nam, thang);
                DataTable dataTable = DataProvider.Instance.ExecuteQuery("Select * from SoDienNuoc where IDSoDienNuoc= @id", new object[] { idSDN });
                DataRow row = dataTable.Rows[0];
                float sdc = float.Parse(row["SoDienCu"].ToString());
                float sdm = float.Parse(row["SoDienMoi"].ToString());
                int k= 
                    DataProvider.Instance.ExecuteNonQuery("insert into HoaDonDien (IDHoaDonDien,IDKhachHang,Phong,Thang,Nam,SoDienCu,SoDienMoi,DonGia)  values ( @id1 , @id2 , @p , @th , @n , @sdc , @sdm , @dg )", new object[] { GetMaxIDHoaDonDien() + 1, idKH, phong, thang, nam, sdc, sdm, DonGia });
                if (k < 0) 
                {
                    MessageBox.Show("Thêm Hóa Đơn Điện thất bại");
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo hóa đơn điện: "+ ex.Message);
            }           
        }

        float GetDonGia(int thang, int nam)
        {
            object kq= DataProvider.Instance.ExecuteScalar("Select DonGia from HoaDonDien where Thang= @t and Nam= @n", new object[] { thang, nam });
            if (kq == null)
                return 0;
            else return float.Parse(kq.ToString());
        }

        public void DongBoHoaDonDien()
        {
            DataTable table = DataProvider.Instance.ExecuteQuery("Select * from SoDienNuoc ");
            foreach (DataRow row in table.Rows)
            {
                if ( GetIDHoaDonDien( int.Parse( row["IDSoDienNuoc"].ToString() ) ) == null )
                {
                    string phong = row["Phong"].ToString();
                    int idKD = int.Parse(row["IDKhachHang"].ToString());
                    int nam = int.Parse(row["Nam"].ToString());
                    int thang= int.Parse(row["Thang"].ToString());
                    NewHoaDonDien(phong,idKD,nam,thang);
                }
            }
        }


    }
}
