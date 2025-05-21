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
    internal class PhongDAL
    {
        private static PhongDAL instance;
        public static PhongDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhongDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private PhongDAL() { }
        public DataTable FullPhong()
        {
            return DataProvider.Instance.ExecuteQuery(" select * from Phong");         
        }
        
        public void ThemPhong(string p, string tt)
        {
            string query = "select * from Phong where Phong= @phong ";
            DataTable dataTable= DataProvider.Instance.ExecuteQuery(query,new object[] { p });
            if (dataTable.Rows.Count >0) 
            {
                MessageBox.Show("Phòng đã tồn tại!");
                return;
            }
            else
            {
                try 
                {
                    query = "insert into Phong (Phong,TrangThai) values ( @a , @b ) ";
                    if (DataProvider.Instance.ExecuteNonQuery(query, new object[] { p, tt }) == 0)
                    {
                        MessageBox.Show("Them phong that bai!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm phòng: "+ex.Message);
                }                
            }
        }

        public bool KiemtraTrong(string p) 
        {
            DateTime dateTime = DateTime.Now.Date;
            return (DataProvider.Instance.ExecuteNonQuery("select * from HopDong where (NgayKT IS null OR  NgayKT > @a ) and NgayBD < @a ", new object[] { dateTime, dateTime }) > 0);
        }

        public void UpdatePhong(string phong)
        {
            if (KiemtraTrong(phong))
                DataProvider.Instance.ExecuteNonQuery("Update Phong set (TrangThai = N'Đang SD') where Phong = @p ",new object[] { phong });
            else DataProvider.Instance.ExecuteNonQuery("Update Phong set (TrangThai = N'Trống') where Phong = @p ", new object[] { phong });
        }

      
    }
}
