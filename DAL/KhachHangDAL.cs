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
    internal class KhachHangDAL
    {
        private static KhachHangDAL instance;
        public static KhachHangDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new KhachHangDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private KhachHangDAL() { }

        public DataTable FullKhachHang()
        { 
            return DataProvider.Instance.ExecuteQuery("Select * from KhachHang");
        }

        public int GetMaxIDKhachHang()
        {
            object kq = DataProvider.Instance.ExecuteScalar("Select MAX(IDKhachHang) from KhachHang");
            if (kq == null)
            {
                return 0;
            }
            else return int.Parse(kq.ToString());
        }

        public void ThemKhachHang(string ten, string sdt)
        {
            try
            {
                if (DataProvider.Instance.ExecuteQuery("Select * from KhachHang where Ten= @a and SDT= @b ",new object[] {ten,sdt}).Rows.Count>0  )
                {
                    MessageBox.Show("Khách hàng đã tồn tại!");
                    return;
                }
                int k = DataProvider.Instance.ExecuteNonQuery("insert into KhachHang (IDKhachHang,Ten,SDT) values( @a , @b , @c )", new object[] {GetMaxIDKhachHang()+1,ten,sdt });
                if (k <= 0)
                {
                    MessageBox.Show("Thêm khách hàng mới thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm khách hàng: " + ex.Message);
            }
        }
    }
}
