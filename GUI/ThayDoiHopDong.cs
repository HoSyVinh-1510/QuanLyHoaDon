using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHoaDon.DTO;
using QuanLyHoaDon.DAL;

namespace QuanLyHoaDon.GUI
{
    public partial class ThayDoiHopDong : Form
    {
        private int ID;

        private static ThayDoiHopDong instance;

        public static ThayDoiHopDong Instance(int id)
        {        
                if (instance == null|| instance.IsDisposed)
                {
                    instance = new ThayDoiHopDong(id);
                }
                return instance;         
        }

        private ThayDoiHopDong(int id)
        {
            this.ID = id;
            InitializeComponent();
        }

        private void SetUp()
        {
           
            DataRow row = DataProvider.Instance.ExecuteQuery("Select * from HopDong where IDHopDong= @a", new object[] { ID }).Rows[0];
            textBox1.Text=ID.ToString(); ;textBox13.Text=ID.ToString();
            textBox3.Text = row["Phong"].ToString(); textBox11.Text = row["Phong"].ToString();
            textBox2.Text = row["IDKhachHang"].ToString(); textBox12.Text = row["IDKhachHang"].ToString();
            textBox8.Text=DataProvider.Instance.ExecuteScalar("select Ten from KhachHang where IDKhachHang= @a ",new object[] { int.Parse(textBox2.Text) }).ToString();
            textBox7.Text=textBox8.Text;
            textBox9.Text= DataProvider.Instance.ExecuteScalar("select SDT from KhachHang where IDKhachHang= @a ", new object[] { int.Parse(textBox2.Text) }).ToString();
            textBox6.Text=textBox9.Text;
            textBox4.Text = (DateTime.Parse(row["NgayBD"].ToString())).ToString("dd/MM/yyyy");
            if (row["NgayKT"] == DBNull.Value || row["NgayKT"] == null)
            textBox5.Text = "";
            else textBox5.Text = (DateTime.Parse(row["NgayKT"].ToString())).ToString("dd/MM/yyyy"); 
            dateTimePicker1.Value=DateTime.Now;
            dateTimePicker1.Checked = false;
            dateTimePicker2.Value= DateTime.Parse(row["NgayBD"].ToString()).Date;

            dataGridViewHD.DataSource = DataProvider.Instance.ExecuteQuery("select * from SoDienNuoc where Phong= @p and IDKhachHang= @id ",new object[] {textBox3.Text, int.Parse(textBox2.Text) });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thay đổi hợp đồng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (Kiemtra())
                {
                    int k;
                    if (dateTimePicker1.Checked == true)
                    {
                        k = DataProvider.Instance.ExecuteNonQuery("Update HopDong SET NgayKT= @a where IDHopDong= @id", new object[] { dateTimePicker1.Value.Date, ID });
                    }
                    else
                    {
                        k = DataProvider.Instance.ExecuteNonQuery("Update HopDong SET NgayKT= @a where IDHopDong= @id", new object[] { DBNull.Value, ID });
                    }
                    if (k > 0)
                    {
                        MessageBox.Show("Thay đổi hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        HopDong.Instance.HopDong_Load(sender, e);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thay đổi hợp đồng thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            else             
            {
                MessageBox.Show("Bạn đã hủy thay đổi hợp đồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void ThayDoiHopDong_Load(object sender, EventArgs e)
        {
            SetUp();
        }

        private bool Kiemtra()
        {

            if (dateTimePicker1.Checked==false)
            return true;
            else
            {
                if (dateTimePicker1.Value.Date < DateTime.Parse(textBox4.Text))
                {
                    MessageBox.Show("Ngày kết thúc hợp đồng không được nhỏ hơn ngày bắt đầu hợp đồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }               
                else return true;
                
            }
        }

    }
}
