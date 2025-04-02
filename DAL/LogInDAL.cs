using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QuanLyHoaDon.DTO;

namespace QuanLyHoaDon.DAL
{
    internal class LogInDAL
    {
        public bool CheckDangNhap(string a, string b) 
        {
            Connect connect = new Connect();
            connect.OpenConnect();
            int count = -1;
            string query = "SELECT COUNT(*) FROM Account WHERE TaiKhoan COLLATE SQL_Latin1_General_CP1_CS_AS = @tk AND MatKhau COLLATE SQL_Latin1_General_CP1_CS_AS  = @mk";
            SqlCommand cmd = new SqlCommand(query,connect.connect);
            cmd.Parameters.AddWithValue("@tk", a);
            cmd.Parameters.AddWithValue("@mk", b);       
            count=(int)cmd.ExecuteScalar();
            connect.CloseConnect();
            return count > 0;                         
        }


    }
}
