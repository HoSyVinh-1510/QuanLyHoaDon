using QuanLyHoaDon.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QuanLyHoaDon.DAL
{
    internal class HopDongDAL
    {
        private static HopDongDAL instance;
        public static HopDongDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new HopDongDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private HopDongDAL() { }
        public DataTable HopDongPhong(string phong)
        {
            
            string query = " select * from HopDong where Phong= @p";
            return DataProvider.Instance.ExecuteQuery(query, new object[] {phong});
           
        }

        public void UpdateHopDong(int id, DateTime kthuc)
        {
            
            string tt;
            if (kthuc > DateTime.Now || kthuc == null) tt = "Đang Thuê";
            else tt = "Hết Hạn";
            
            string query = "update HopDong set NgayKT= @kthuc , TrangThai= @tt  where IDHopDong=@id";           
            if (DataProvider.Instance.ExecuteNonQuery(query, new object[] {kthuc,tt,id}) > 0)
            {
                MessageBox.Show("Cập nhật thành công");               
            }
            else {
                MessageBox.Show("Cập nhật thất bại");
            }
            DataProvider.Instance.ExecuteQuery("Update_Phong");            
        }


        public void StopHopDong(int id)
        {

            DateTime kt = DateTime.Now;
            string query = " Sua_HopDong @id , @kt , @tt ";

            if (DataProvider.Instance.ExecuteNonQuery(query, new object[] { id, kt, "Hết Hạn" }) == 0)
            {
                MessageBox.Show("Error!");
                return;
            }
            query = "Update_Phong";
            DataProvider.Instance.ExecuteNonQuery(query);

        }
    }
}
