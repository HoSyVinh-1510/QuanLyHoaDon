using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHoaDon.DTO;

namespace QuanLyHoaDon.DAL
{
    internal class LogInDAL
    {
        public bool CheckDangNhap(string a, string b) 
        {
            if (b == null) { MessageBox.Show("Cập nhật mật khẩu không thành công!"); return false; }
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

        public void SuaDangNhap(string tk, string mk)
        {
            Connect connect = new Connect();
            connect.OpenConnect();
            string query = "Update Account SET (MatKhau= @mk) WHERE TaiKhoan= @tk";
            SqlCommand cmd= new SqlCommand(query,connect.connect);
            cmd.Parameters.AddWithValue("@mk",mk);
            cmd.Parameters.AddWithValue("@tk", tk);
            cmd.ExecuteNonQuery();
            connect.CloseConnect();
            return;
        }


    }
}
