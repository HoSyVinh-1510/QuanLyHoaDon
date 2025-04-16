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
        public SoDienNuocDAL() { }
        public DataTable FullSoDienNuoc(string Phong)
        {
            return DataProvider.Instance.ExecuteQuery("Select * from SoDienNuoc where Phong= @p", new object[] { Phong });           
        }

        public void AddSoDienNuoc(string Phong, int thang, int nam, float sodienmoi, float sonuocmoi)
        {
            
            int thang0, nam0;
            if (thang == 1) { thang0 = 12; nam0 = nam - 1; }
            else { thang0 = thang - 1; nam0 = nam; }
            string query = " select * from SoDienNuoc where Phong =@p and Thang= @t and Nam= @n ";
            DataTable dataTable= DataProvider.Instance.ExecuteQuery(query, new object[] { Phong, thang0, nam0 });
            if (dataTable.Rows.Count==0) 
            {
                MessageBox.Show("Không có hóa đơn của tháng trước") ; return;
            }
            
                 DataRow row = dataTable.Rows[0];               
                float sonuoccu = float.Parse(row["SoNuocMoi"].ToString());
                float sodiencu = float.Parse(row["SoDienMoi"].ToString());
              
            query = " Insert into SoDienNuoc (Phong,Thang,Nam,SoDienCu,SoNuocCu,SoDienMoi,SoNuocMoi) values ( @phong , @thang , @nam , @d1 , @n1 , @d2 , @n2 )";       
            
            if (DataProvider.Instance.ExecuteNonQuery(query,new object[] {Phong,thang,nam,sodiencu,sonuoccu,sodienmoi,sonuocmoi}) > 0)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }          
        }

        public SoDienNuoc TimSoDienNuocThang(string phong, int thang, int nam)
        {           
            string query = " select * from SoDienNuoc where Phong= @p and Thang= @t and Nam= @n ";
            DataTable dataTable= DataProvider.Instance.ExecuteQuery(query,new object[] {phong, thang, nam}); 
            if (dataTable.Rows.Count==0)
            {
                MessageBox.Show("Cann't Find");
                return null;
            }
            else
            {
                DataRow row = dataTable.Rows[0];
                SoDienNuoc soDienNuoc = new SoDienNuoc(phong, int.Parse(row["ID"].ToString()), thang, nam,
                float.Parse(row["SoDienCu"].ToString()), float.Parse(row["SoNuocCu"].ToString()), float.Parse(row["SoDienMoi"].ToString()), float.Parse(row["SoNuocMoi"].ToString()));                
                return soDienNuoc;
            }

        }

    }

}




