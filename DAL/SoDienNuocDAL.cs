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
    internal class SoDienNuocDAL
    {
        private static SoDienNuocDAL instance;
        public static SoDienNuocDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SoDienNuocDAL();
                return instance;
            }
            private set { instance = value; }
        }

        private SoDienNuocDAL() { }
        public DataTable FullSoDienNuoc(string Phong)
        {

            return DataProvider.Instance.ExecuteQuery("select * from SoDienNuoc where Phong= @p",new object[] { Phong });        
        }

        public void ThemSoDienNuoc(string phong, int IDKH , int nam , int thang,float sdc, float snc , float sdm, float snm)
        {
            try 
            {
                int id = GetMaxIDSoDienNuoc();

                string query = " Insert into SoDienNuoc (IDSoDienNuoc,Phong,IDKhachHang,Nam,Thang,SoDienCu,SoNuocCu,SoDienMoi,SoNuocMoi) values ( @id1 , @phong , @id2 , @nam  , @thang , @d1 , @n1 , @d2 , @n2 )";

                if (DataProvider.Instance.ExecuteNonQuery(query, new object[] { id + 1, phong, IDKH , nam, thang, sdc, snc, sdm, snm }) <= 0)
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Có lỗi xảy ra khi tạo bảng số điện nước: "+ex.Message);
            }
              
        }

        // Lấy ra id lớn nhất trong danh sách điện nước

        public int GetMaxIDSoDienNuoc()
        {
            object kq= DataProvider.Instance.ExecuteScalar("select MAX(IDSoDienNuoc) from SoDienNuoc");
            if (kq == null)
                return 0;
            else return int.Parse(kq.ToString());
        }

        //1 khách hàng có thể 1 tháng bị chuyển phòng nên sẽ có 2 số khác nhau
        public int GetIDSoDienNuoc(string phong, int idKhachHang, int nam, int thang)
        {
            return int.Parse(DataProvider.Instance.ExecuteScalar("select IDSoDienNuoc from SoDienNuoc where Phong= @p and IDKhachHang= @b and Nam= @n and Thang= @t", new object[] { phong, idKhachHang, nam, thang }).ToString());
        }

    }

}




