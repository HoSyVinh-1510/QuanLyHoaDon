using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.DAL
{
    internal class Connect
    {
        public SqlConnection connect = new SqlConnection(@"Server=OHMYGOD\HOSYVINH1510;Database=QuanLyHoaDon;User Id=sa;Password=vinh1510");
        public void  OpenConnect()
        {    
            connect.Open();
        }

        public void CloseConnect()
        {
            connect.Close();         
        }


    }
}
