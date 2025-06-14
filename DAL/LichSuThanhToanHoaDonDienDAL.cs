using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoaDon.DAL
{
    internal class LichSuThanhToanHoaDonDienDAL
    {
        private static LichSuThanhToanHoaDonDienDAL instance;
        public static LichSuThanhToanHoaDonDienDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LichSuThanhToanHoaDonDienDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private LichSuThanhToanHoaDonDienDAL() { }

        public bool KiemTraThanhToan(int idHD)
        {
            return DataProvider.Instance.ExecuteNonQuery("Select * from LichSuDien where IDHoaDonDien= @a", new object[] { idHD }) > 0;
        }

       
        public int MaxIDLichSu()
        {
            object kq= DataProvider.Instance.ExecuteScalar("Select MAX( IDLichSu ) from LichSuDien ");
            if (kq.ToString() == "" || kq == DBNull.Value)
                return 0;
            else return int.Parse(kq.ToString());
        }

        public void ThemLichSu(int idHD, DateTime dateTime)
        {
            int id= MaxIDLichSu();
            string query = "insert into LichSuDien (IDLichSu,IDHoaDonDien,NgayThanhToan) values ( @id , @idHD , @ngay )";
            if ( DataProvider.Instance.ExecuteNonQuery(query, new object[] { id+1, idHD, dateTime }) == 0)
            {
                MessageBox.Show("Thêm lịch sử thanh toán không thành công!");
            }
        }

        public string NgayThanhToanHD(int idHDD)
        {
            object kq= DataProvider.Instance.ExecuteScalar("Select NgayThanhToan from LichSuDien where IDHoaDonDien= @a", new object[] { idHDD });
            if(kq==null) 
                return null;
            else return DateTime.Parse(kq.ToString()).Date.ToString("dd/MM/yyyy");
        }

    }
}
