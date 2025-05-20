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
        public static AccountDAL instance;
        public static AccountDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAL();
                return instance;
            }
        }
        public AccountDAL() { }
        public bool CheckLogin(string tk, string mk)
        {
             DataTable dataTable= DataProvider.Instance.ExecuteQuery("select * from Account where TaiKhoan= @a and MatKhau= @b", new Object[] { tk, mk });
             if (dataTable.Rows.Count > 0 )  return true; 
             return false;
        }
    }
}
