using QuanLyHoaDon.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QuanLyHoaDon.DAL
{
    internal class ChuHoDAL
    {
        public ChuHoDAL() { }

        public List<ChuHo> FullListChuHo()
        {
            List<ChuHo> listChuHo = new List<ChuHo>();
            Connect connect = new Connect();
            connect.OpenConnect();
            string query = "SELECT * FROM ChuHo";
            SqlCommand cmd = new SqlCommand(query, connect.connect);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
               ChuHo ho = new ChuHo();
                ho.MaChuHo=reader.GetString(0);
                ho.TenChuHo= reader.GetString(1);
                DateTime dateTime = reader.GetDateTime(2);
                ho.NgaySinh = dateTime;
                ho.GioiTinh=reader.GetString(3);
                ho.SDT=reader.GetString(4);
                listChuHo.Add(ho);
            }
            connect.CloseConnect();
            return listChuHo;
        }

        public List<ChuHo> FindForNameChuHo(string name)
        {
            List<ChuHo> listChuHo = new List<ChuHo>();
            Connect cn = new Connect();
            cn.OpenConnect();
            string query = "SELECT * FROM ChuHo WHERE MaChuHo= @name";
            SqlCommand cmd = new SqlCommand(query, cn.connect);
            cmd.Parameters.AddWithValue("@name", name);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ChuHo item = new ChuHo();
                item.MaChuHo = reader.GetString(0);
                item.TenChuHo = reader.GetString(1);
                if (DateTime.TryParse(reader.GetValue(2).ToString(), out DateTime ngay))
                {
                    item.NgaySinh = ngay;
                }
                item.GioiTinh = reader.GetValue(3).ToString();
                item.SDT = reader.GetValue(4).ToString();
                listChuHo.Add(item);
            }
            cn.CloseConnect();
            return listChuHo;
        }

        public void DeleteChuHo(string name)
        {
            Connect cn = new Connect(); 
            cn.OpenConnect();
            string query = "DELETE ChuHo WHERE MaChuHo= @name";
            SqlCommand cmd = new SqlCommand(query, cn.connect);
            cmd.Parameters.AddWithValue("@name",name);     
            cmd.ExecuteNonQuery();
            cn.CloseConnect();
            return;

        }

        public void UpdateChuHo(string id, string name, DateTime day, string sex, string sdt)
        {
            Connect connect = new Connect();
            connect.OpenConnect();
            string query = "UPDATE ChuHo SET (TenChuHo=@name, NgaySinh=@day,GioiTinh=@sex, SDT=@sdt) WHERE MaChuHo= @id";
            SqlCommand cmd = new SqlCommand(query, connect.connect);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@day", day);
            cmd.Parameters.AddWithValue("@sex", sex);
            cmd.Parameters.AddWithValue("@sdt", sdt);
            cmd.ExecuteNonQuery();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("Không tìm thấy đối tượng nào để cập nhật!");
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thành công!");
            }
            connect.CloseConnect();
            return;
        }

        public void AddChuHo(string id, string name, DateTime date, string sex, string sdt)
        {
            Connect connect = new Connect();
            connect.OpenConnect();
            string query = "SELECT * FROM ChuHo where MaChuHo=@id";
            SqlCommand cmd1 = new SqlCommand(query , connect.connect);
            cmd1.Parameters.AddWithValue("@id", id);
            int k = cmd1.ExecuteNonQuery();
            if (k > 0) 
            {
                MessageBox.Show("Đã tồn tại phòng cùng ID!");
                connect.CloseConnect();
                return;
            }
            else
            {
                query = "INSERT INTO ChuHo VALUES (@id,@name,@date,@sex,@sdt)";
                SqlCommand cmd= new SqlCommand(query, connect.connect);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name",name);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@sex",sex);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.ExecuteNonQuery();
                connect.CloseConnect();
            }
        }


    }        

}
