using QuanLyHoaDon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace QuanLyHoaDon.DAL
{
    internal class AccountDAL
    {
        public AccountDAL() { }
        public bool CheckLogin(string tk, string mk)
        {
            string query= "DangNhap @tk , @mk";
             DataTable dataTable= DataProvider.Instance.ExecuteQuery(query, new Object[] { tk, mk });
             if (dataTable.Rows.Count > 0 ) { return true; }
             return false;
        }
    }
}
