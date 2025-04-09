using QuanLyHoaDon.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoaDon.DAL
{
    internal class HoaDonDienDAL
    {
        public HoaDonDienDAL() { }

        // Trả về toàn bộ danh sách hóa đơn điện trong sql  
        public List<HoaDonDien> FullListHoaDonDien()
        {
            List<HoaDonDien> listChuHo = new List<HoaDonDien>();
            Connect connect = new Connect();
            connect.OpenConnect();
            string query = "SELECT * FROM HoaDonDien";
            SqlCommand cmd = new SqlCommand(query, connect.connect);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                MessageBox.Show("Không có hóa đơn nào trong danh sách");
                connect.CloseConnect();
                return null;
            }
            while (reader.Read())
            {
                HoaDonDien hoaDon = new HoaDonDien(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), ((float)reader.GetDecimal(3)), ((float)reader.GetDecimal(4)), reader.GetString(6));
                listChuHo.Add(hoaDon);
            }
            connect.CloseConnect();
            return listChuHo;
        }

        // tìm kiếm hóa đơn theo phòng
        public List<HoaDonDien> Find(string phong)
        {
            List<HoaDonDien> listChuHo = new List<HoaDonDien>();
            Connect cn = new Connect();
            cn.OpenConnect();
            string query = "SELECT * FROM HoaDonDien WHERE Phong= @name";
            SqlCommand cmd = new SqlCommand(query, cn.connect);
            cmd.Parameters.AddWithValue("@name", phong);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                MessageBox.Show("Không tìm thấy hóa đơn nào trong danh sách");
                cn.CloseConnect();
                return null;
            }
            while (reader.Read())
            {
                HoaDonDien hd = new HoaDonDien(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), ((float)reader.GetDecimal(3)), ((float)reader.GetDecimal(4)), reader.GetString(6));
                listChuHo.Add(hd);
            }
            cn.CloseConnect();
            return listChuHo;
        }

        public List<HoaDonDien> FindState(string trangthai)
        {
            List<HoaDonDien> listChuHo = new List<HoaDonDien>();
            Connect cn = new Connect();
            cn.OpenConnect();
            string query = "SELECT * FROM HoaDonDien WHERE TrangThai= @trangthai";
            SqlCommand cmd = new SqlCommand(query, cn.connect);
            cmd.Parameters.AddWithValue("@trangthai", trangthai);
            SqlDataReader reader = cmd.ExecuteReader();            
            if (!reader.HasRows)
            {
                MessageBox.Show("Không tìm thấy hóa đơn nào trong danh sách");
                cn.CloseConnect();
                return null;
            }
            while (reader.Read())
            {
                HoaDonDien hd = new HoaDonDien(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), ((float)reader.GetDecimal(3)), ((float)reader.GetDecimal(4)), reader.GetString(6));
                listChuHo.Add(hd);
            }
            cn.CloseConnect();
            return listChuHo;
        }


        // Hàm xóa hóa đơn điện
        public void DeleteHoaDonDien(string phong, DateTime date)
        {
            Connect cn = new Connect();
            cn.OpenConnect();
            string query = "DELETE HoaDonDien WHERE Phong=@phong AND NgayLapHoaDon=@date";
            SqlCommand cmd = new SqlCommand(query, cn.connect);
            cmd.Parameters.AddWithValue("@phong",phong);
            cmd.Parameters.AddWithValue("@date",date);
            cmd.ExecuteNonQuery();
            if (cmd.ExecuteNonQuery()==0)
            {
                MessageBox.Show("Không thể xóa Hóa đơn");
                return;
            }
            else {
                MessageBox.Show("Xóa hóa đơn thành công");
            }
            cn.CloseConnect();
            return;
        }
        // Hàm cập nhật hóa đơn điện

        public void UpdateHoaDonDien(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
                Connect connect = new Connect();
                connect.OpenConnect();    
                string query = "UPDATE HoaDonDien SET TenChuHo= @a1, SoDienCu= @a3, SoDienMoi= @a4, ThanhTien= @a5, TrangThai= @a6 WHERE (Phong= @a0 AND NgayLapHoaDon= @a2)";
                SqlCommand cmd = new SqlCommand(query, connect.connect);
                cmd.Parameters.AddWithValue("@a0", a0);
                cmd.Parameters.AddWithValue("@a1", a1);
                cmd.Parameters.AddWithValue("@a2", a2);
                cmd.Parameters.AddWithValue("@a3",((decimal)a3));
                cmd.Parameters.AddWithValue("@a4", ((decimal)a4));
                cmd.Parameters.AddWithValue("@a5", ((decimal)a5));
                cmd.Parameters.AddWithValue("@a6", a6);
                int k=cmd.ExecuteNonQuery();
            if (k==0)
                {
                    MessageBox.Show("Không đối tượng nào được cập nhật!");
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!");
                }
                connect.CloseConnect();
           
        }

        // Hàm hoàn thành thanh toán hóa đơn điện
        public void PayAllHoaDonDien(string phong) 
        {
            Connect cn=new Connect();
            cn.OpenConnect();
            string query = "UPDATE HoaDonDien SET TrangThai= @trangthai WHERE TrangThai= @trangthai2 AND Phong= @phong ";
            SqlCommand cmd = new SqlCommand(query, cn.connect);
            cmd.Parameters.AddWithValue("@phong", phong);
            cmd.Parameters.AddWithValue("@trangthai", "Đã thanh toán");
            cmd.Parameters.AddWithValue("@trangthai2", "Chưa thanh toán");
            if (cmd.ExecuteNonQuery() != 0) 
            {
                MessageBox.Show("Thanh toán toàn bộ hóa đơn thành công");
            }
            else
            {
                MessageBox.Show("Không thành công!");
            }
            
            cn.CloseConnect();
            return;
        }

        // Hàm thanh toán hóa đơn điện theo tháng
        public void PayHoaDonDien(string phong, DateTime date)
        {
            Connect cn= new Connect();
            cn.OpenConnect();
            string query = "UPDATE HoaDonDien SET TrangThai= @trangthai Where NgayLapHoaDon= @date AND Phong= @phong";
            SqlCommand cmd = new SqlCommand(query, cn.connect);
            cmd.Parameters.AddWithValue("@trangthai", "Đã thanh toán");
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@phong", phong);
            if(cmd.ExecuteNonQuery()==0)
            {
                MessageBox.Show("Không thể thanh toán hóa đơn này");
                return;
            }
            else
            {
                MessageBox.Show("Thanh toán hóa đơn thành công");
            }
            cn.CloseConnect();
        }

        // hàm thêm hóa đơn điện
        public void AddHoaDonDien(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            Connect connect = new Connect();
            connect.OpenConnect();
            string query = "SELECT * FROM HoaDonDien where (Phong=@a0 AND NgayLapHoaDon=@a2)";
            SqlCommand cmd1 = new SqlCommand(query, connect.connect);
            cmd1.Parameters.AddWithValue("@a0", a0);
            cmd1.Parameters.AddWithValue("@a2", a2);
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show(" Đã tồn tại hóa đơn này !");
                connect.CloseConnect();
                return;
            }
            else
            {
                reader.Close();
                query = "INSERT INTO HoaDonDien VALUES (@a0,@a1,@a2,@a3,@a4,@a5,@a6)";
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

