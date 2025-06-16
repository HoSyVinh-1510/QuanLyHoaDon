using QuanLyHoaDon.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Common.CommandTrees.ExpressionBuilder;
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
        


        public int GetMaxIDHopDong()
        {
            object kq = DataProvider.Instance.ExecuteScalar("select MAX(IDHopDong) from HopDong");
            if (kq.ToString() == "" || kq == DBNull.Value)
            {
                return 0;
            }
            else return int.Parse(kq.ToString());
        }

        public int GetIDHopDong(int idKH, string phong)
        {
            object kq = DataProvider.Instance.ExecuteScalar(" select MAX(IDHopDong) from HopDong where IDKhachHang= @a and Phong= @b", new object[] { idKH, phong });
            if (kq.ToString() == "" || kq == DBNull.Value)
            {
                return 0;
            }
            else return int.Parse(kq.ToString());
        }


    }
}
