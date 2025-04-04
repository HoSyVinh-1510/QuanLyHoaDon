using QuanLyHoaDon.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoaDon.DAL
{
    internal class HoaDonNuocDAL
    {
        public HoaDonNuocDAL() { }

        // Trả về toàn bộ danh sách hóa đơn điện trong sql
        public List<HoaDonNuoc> FullListHoaDonNuoc()
        {
            List<HoaDonNuoc> listChuHo = new List<HoaDonNuoc>();
            Connect connect = new Connect();
            connect.OpenConnect();
            string query = "SELECT * FROM HoaDonNuoc";
            SqlCommand cmd = new SqlCommand(query, connect.connect);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HoaDonNuoc hoaDon = new HoaDonNuoc(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), ((float)reader.GetDecimal(3)), ((float)reader.GetDecimal(4)), reader.GetString(6));

                listChuHo.Add(hoaDon);
            }
            connect.CloseConnect();
            return listChuHo;
        }

        // tìm kiếm hóa đơn theo phòng
        public List<HoaDonNuoc> Find(string phong)
        {
            List<HoaDonNuoc> listChuHo = new List<HoaDonNuoc>();
            Connect cn = new Connect();
            cn.OpenConnect();
            string query = "SELECT * FROM HoaDonNuoc WHERE Phong= @name";
            SqlCommand cmd = new SqlCommand(query, cn.connect);
            cmd.Parameters.AddWithValue("@name", phong);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HoaDonNuoc hd = new HoaDonNuoc(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), ((float)reader.GetDecimal(3)), ((float)reader.GetDecimal(4)), reader.GetString(6));
                listChuHo.Add(hd);
            }
            cn.CloseConnect();
            return listChuHo;
        }


        public List<HoaDonNuoc> FindState(string trangthai)
        {
            List<HoaDonNuoc> listChuHo = new List<HoaDonNuoc>();
            Connect cn = new Connect();
            cn.OpenConnect();
            string query = "SELECT * FROM HoaDonNuoc WHERE TrangThai= @trangthai";
            SqlCommand cmd = new SqlCommand(query, cn.connect);
            cmd.Parameters.AddWithValue("@trangthai", trangthai);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HoaDonNuoc hd = new HoaDonNuoc(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), ((float)reader.GetDecimal(3)), ((float)reader.GetDecimal(4)), reader.GetString(6));
                listChuHo.Add(hd);
            }
            cn.CloseConnect();
            return listChuHo;
        }
        // Hàm xóa hóa đơn điện
        public void DeleteHoaDonNuoc(string phong, DateTime date)
        {
            Connect cn = new Connect();
            cn.OpenConnect();
            string query = "DELETE HoaDonNuoc WHERE Phong=@phong AND NgayLapHoaDon=@date";
            SqlCommand cmd = new SqlCommand(query, cn.connect);
            cmd.Parameters.AddWithValue("@phong", phong);
            cmd.Parameters.AddWithValue("@date", date);
            if (cmd.ExecuteNonQuery() <= 0)
            {
                MessageBox.Show("Không thể xóa");
                return;
            }
            else
            {
                MessageBox.Show("Xóa hóa đơn thành công");
            }
            cn.CloseConnect();
            return;
        }
        // Hàm cập nhật hóa đơn điện

        public void UpdateHoaDonNuoc(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            Connect connect = new Connect();
            connect.OpenConnect();
                string query = "UPDATE HoaDonNuoc SET TenChuHo=@a1, SoDienCu=@a3, SoDienMoi=@a4, ThanhTien=@a5, TrangThai=@a6 WHERE (Phong=@a0 AND NgayLapHoaDon=@a2)";
                SqlCommand cmd = new SqlCommand(query, connect.connect);
                cmd.Parameters.AddWithValue("@a0", a0);
                cmd.Parameters.AddWithValue("@a1", a1);
                cmd.Parameters.AddWithValue("@a2", a2);
                cmd.Parameters.AddWithValue("@a3", a3);
                cmd.Parameters.AddWithValue("@a4", a4);
                cmd.Parameters.AddWithValue("@a5", a5);
                cmd.Parameters.AddWithValue("@a6", a6);

                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    MessageBox.Show("Không tìm thấy đối tượng nào để cập nhật!");
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                }           
                connect.CloseConnect();
            
        }

        // hàm thêm hóa đơn điện
        public void AddHoaDonNuoc(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            Connect connect = new Connect();
            connect.OpenConnect();
            string query = "SELECT * FROM HoaDonNuoc where (Phong=@a0 AND NgayLapHoaDon=@a2)";
            SqlCommand cmd1 = new SqlCommand(query, connect.connect);
            cmd1.Parameters.AddWithValue("@a0", a0);
            cmd1.Parameters.AddWithValue("@a2", a2);
            int k = cmd1.ExecuteNonQuery();
            if (k > 0)
            {
                MessageBox.Show("Đã tồn tại hóa đơn trùng!");
                connect.CloseConnect();
                return;
            }
            else
            {
                query = "INSERT INTO HoaDonNuoc VALUES (@a0,@a1,@a2,@a3,@a4,@a5,@a6)";
                SqlCommand cmd = new SqlCommand(query, connect.connect);
                cmd.Parameters.AddWithValue("@a0", a0);
                cmd.Parameters.AddWithValue("@a1", a1);
                cmd.Parameters.AddWithValue("@a2", a2);
                cmd.Parameters.AddWithValue("@a3", a3);
                cmd.Parameters.AddWithValue("@a4", a4);
                cmd.Parameters.AddWithValue("@a5", a5);
                cmd.Parameters.AddWithValue("@a6", a6);
                cmd.ExecuteNonQuery();
                connect.CloseConnect();
            }
        }

    }
}

