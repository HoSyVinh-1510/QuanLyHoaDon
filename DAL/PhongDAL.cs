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
        public List<Phong> FullPhong()
        {
            List<Phong> listPhong = new List<Phong>();
            DataTable dataTable= DataProvider.Instance.ExecuteQuery("select * from Phong");
            foreach (DataRow row in dataTable.Rows) 
            {
                listPhong.Add( new Phong( row["Phong"].ToString(), row["TrangThai"].ToString() ) );
            }
            return listPhong;
        }
        
        // "Đang SD" hoặc là "Trống"
        public List<Phong> TimPhongTheoTrangThai(string tt)
        {
            
            List<Phong> listPhong = new List<Phong>();
            DataTable dataTable = DataProvider.Instance.ExecuteQuery("Tim_Phong @tt", new object[] {tt});
            foreach (DataRow row in dataTable.Rows)
            {
                listPhong.Add(new Phong(row["Phong"].ToString(), row["TrangThai"].ToString()));
            }
            return listPhong;
        }

        public void ThemPhong(string p, string tt)
        {
            string query = "Them_Phong @p , @tt ";
            int k= DataProvider.Instance.ExecuteNonQuery(query, new object[] { p, tt });
            if (k==0)
            {
                //MessageBox.Show("Thêm phòng không thành công");
            }
            else if (k > 0)
            {
                //MessageBox.Show("Thêm phòng thành công");
            }
        }

        public void SuaTrangThaiPhong(string sp, string tt)
        {           
            string query = "Sua_TrangThai_Phong @sp, @tt";
            int k = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sp, tt });
            if (k == 0) 
            {
                MessageBox.Show("Sửa trạng thái phòng không thành công");
            }
            else if (k > 0)
            {
                MessageBox.Show("Sửa trạng thái phòng thành công");
            }
            return;
        }

      
    }
}
