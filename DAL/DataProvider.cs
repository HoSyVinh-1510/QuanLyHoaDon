using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLyHoaDon.DAL
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
        }

        private string connectionString = @"Server=.\HOSYVINHSQL;Database=QuanLyHoaDon;User Id=sa;Password=vinh1510";

        private DataProvider() { }

        
        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                AddParameters(command, parameters);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                AddParameters( command, parameters );
                result = command.ExecuteNonQuery();
            }

            return result;
        }


        // Chú ý: Hàm ExecuteScalar trả về giá trị null là giá trị NULL trong SQL khác với null trong C#.
        // Vì vậy ta có thể dùng result==null để kiểm tra giá trị trả về. Hoặc là result == DBNull.Value.
        // Ta dùng như sau: if (kq == DBNull.Value || kq==null) return value;
        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                AddParameters(command, parameters);
                result = command.ExecuteScalar();
            }
            return result;
        }

        private void AddParameters(SqlCommand command, object[] parameters)
        {
            if (parameters != null)
            {
                string[] tokens = command.CommandText.Split(' ');
                int index = 0;

                foreach (string token in tokens)
                {
                    if (token.StartsWith("@"))
                    {
                        command.Parameters.AddWithValue(token, parameters[index]);
                        index++;
                    }
                }
            }
        }

    }
}
