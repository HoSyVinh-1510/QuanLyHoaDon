using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace QuanLyHoaDon.DAL
{
    internal class LichSuThanhToanHoaDonNuocDAL
    {

        private static LichSuThanhToanHoaDonNuocDAL instance;
        public static LichSuThanhToanHoaDonNuocDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LichSuThanhToanHoaDonNuocDAL();
                return instance;
            }
            private set { instance = value; }
        }
        private LichSuThanhToanHoaDonNuocDAL() { }

        public bool KiemTraThanhToan(int idHD)
        {
            return DataProvider.Instance.ExecuteNonQuery("Select * from LichSuNuoc where IDHoaDonNuoc= @a", new object[] { idHD }) > 0;
        }
        public DateTime? NgayThanhToan(int IdHoaDonNuoc)
        {
            if (KiemTraThanhToan(IdHoaDonNuoc) == false)
            {
                return null;
            }
            else return DateTime.Parse(DataProvider.Instance.ExecuteScalar("Select NgayThanhToan from LichSuNuoc where IDHoaDonNuoc= @a", new object[] { IdHoaDonNuoc }).ToString());
        }

        public int MaxIDLichSu()
        {
            object kq = DataProvider.Instance.ExecuteScalar("Select MAX(IDLichSuNuoc) from LichSuNuoc ");
            if (kq.ToString() == "" || kq == DBNull.Value)
                return 0;
            else return int.Parse(kq.ToString());
        }

        public void ThemLichSu(int idHD, DateTime dateTime)
        {
            int id = MaxIDLichSu();
            string query = "insert into LichSuNuoc(IDLichSu,IDHoaDonNuoc,NgayThanhToan) values ( @id  , @idHD , @dateTime )";
            if (DataProvider.Instance.ExecuteNonQuery(query, new object[] { id + 1, idHD, dateTime.Date }) == 0)
            {
                MessageBox.Show("Thêm lịch sử thanh toán không thành công!");
            }
        }
        public DateTime? NgayThanhToanHD(int idHDN)
        {
            object kq = DataProvider.Instance.ExecuteScalar("Select NgayThanhToan from LichSuNuoc where IDHoaDonNuoc= @a", new object[] { idHDN });
            if ( kq == DBNull.Value || kq==null) return null;
            else return DateTime.Parse(kq.ToString()).Date;
        }

    }
}
