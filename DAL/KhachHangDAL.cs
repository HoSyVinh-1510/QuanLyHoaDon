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
        public static KhachHangDAL instance;
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
        public void ThemKhachHang(int id, string ten, string sdt)
        {
            //string query = "Them_KhachHang @id,@ten,@sdt";
             
            
            if ( DataProvider.Instance.ExecuteNonQuery(" select * from KhachHang where ID= @id ") > 0 )
            {
                MessageBox.Show("Khach hang da ton tai");
                return;
            }
            DataProvider.Instance.ExecuteNonQuery("Them_KhachHang @id , @ten , @sdt ", new object[] { id, ten, sdt });
        }

        public void SuaKhachHang(int id, string ten, string sdt)
        {
           
            string query = "Sua_KhachHang @id , @ten , @sdt ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, ten,sdt });
        }

    }
}
