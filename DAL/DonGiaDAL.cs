using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoaDon.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyHoaDon.DAL
{
    internal class DonGiaDAL
    {
        private static DonGiaDAL instance;
        public static DonGiaDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DonGiaDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private DonGiaDAL() { }
        
        public object GetDonGiaDien(int nam, int thang)
        {
            return DataProvider.Instance.ExecuteScalar("select DonGiaDien from DonGia where Nam= @a and Thang= @b ",new object[] {nam,thang});            
        }

        public object GetDonGiaNuoc(int nam, int thang)
        {
            return DataProvider.Instance.ExecuteScalar("select DonGiaNuoc from DonGia where Nam= @a and Thang= @b ", new object[] { nam, thang });
        }

        public void NewDonGiaKhongDoi()
        {
            object kq = DataProvider.Instance.ExecuteScalar("SELECT MAX(IDDonGia) FROM DonGia");
            if (kq == null || kq == DBNull.Value) return;
            int id = Convert.ToInt32(kq);
            DataTable dataTable = DataProvider.Instance.ExecuteQuery("SELECT * FROM DonGia WHERE IDDonGia = @a", new object[] { id});
            int nam= Convert.ToInt32(dataTable.Rows[0]["Nam"]);
            int thang= Convert.ToInt32(dataTable.Rows[0]["Thang"]);

            if(thang == 12)
            {
                thang = 1;
                nam += 1;
            }
            else thang += 1;


            float donGiaDien = Convert.ToSingle(dataTable.Rows[0]["DonGiaDien"]);
            float donGiaNuoc = Convert.ToSingle(dataTable.Rows[0]["DonGiaNuoc"]);
            if(DataProvider.Instance.ExecuteNonQuery("Insert into DonGia (IDDonGia,Nam,Thang,DonGiaDien,DonGiaNuoc) values ( @a , @b , @c , @d , @e )",new object[] {id+1,nam,thang,donGiaDien,donGiaNuoc}) > 0)
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
