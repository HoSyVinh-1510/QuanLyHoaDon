using QuanLyHoaDon.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoaDon.GUI
{
    public partial class HopDong : Form
    {
        private static HopDong instance;

        public static HopDong Instance
        {
            get {
                if (instance == null)
                {
                    instance = new HopDong();
                }
                return 
                    instance; 
                }
        }

        private HopDong()
        {
            InitializeComponent();
        }

        public void SetUp()
        {
            dataGridViewHopDong.DataSource = DataProvider.Instance.ExecuteQuery("Select * from HopDong");
            dataGridViewHopDong.Columns["NgayBD"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewHopDong.Columns["NgayKT"].DefaultCellStyle.Format = "dd/MM/yyyy";
            DataGridViewRow row = dataGridViewHopDong.CurrentRow;
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = DateTime.Parse(row.Cells[3].Value.ToString()).Date.ToString(); //"dd/MM/yyyy"
            if (row.Cells[4].Value.ToString() == "") textBox5.Text = "";
            else textBox5.Text = DateTime.Parse(row.Cells[4].Value.ToString()).Date.ToString();//"dd/MM/yyyy"
            txtIDHopDongMoi.Text=(HopDongDAL.Instance.GetMaxIDHopDong()+1).ToString();

            comboBox1.DataSource = DataProvider.Instance.ExecuteQuery("Select IDKhachHang from KhachHang");
            comboBox1.DisplayMember = "IDKhachHang";
            comboBox1.ValueMember = "IDKhachHang";
            comboBox1.SelectedItem=null;
            comboBox2.DataSource=DataProvider.Instance.ExecuteQuery("Select Phong from Phong");
            comboBox2.DisplayMember = "Phong";
            comboBox2.ValueMember = "Phong";
            comboBox2.SelectedItem=null;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Checked = true;
            dateTimePicker2.Checked = false;
        }


        private void HopDong_Load(object sender, EventArgs e)
        {
            SetUp();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox6.Text = DataProvider.Instance.ExecuteScalar("Select Ten from KhachHang where IDKhachHang= @a ",new object[]{ int.Parse( comboBox1.SelectedItem.ToString() ) }) .ToString();
            textBox7.Text = DataProvider.Instance.ExecuteScalar("Select SDT from KhachHang where IDKhachHang= @a ", new object[] { int.Parse( comboBox1.SelectedItem.ToString() ) } ) .ToString();
        }

        private void dataGridViewHopDong_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row= dataGridViewHopDong.CurrentRow;
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = DateTime.Parse(row.Cells[3].Value.ToString()).Date.ToString(); //"dd/MM/yyyy"
            if (row.Cells[4].Value.ToString() == "") textBox5.Text = "";
            else textBox5.Text = DateTime.Parse(row.Cells[4].Value.ToString()).Date.ToString();//"dd/MM/yyyy"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HOME.Instance.OpenChildForm(PhongVaKhachHang.Instance);
        }

        private bool Check()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Bạn hãy chọn ID Khách Hàng:");
                comboBox1.Focus();
                return false;
            }
            else if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Bạn hãy chọn Phòng:");
                comboBox2.Focus();
                return false;
            }
            else if (dateTimePicker1.Checked == false)
            {
                MessageBox.Show("Bạn hãy chọn Ngày Bắt Đầu:");
                dateTimePicker1.Focus();
                return false;
            }
            if (dateTimePicker2.Checked == true && dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("Ngày Kết Thúc phải lớn hơn Ngày Bắt Đầu:");
                dateTimePicker2.Focus();
                return false;
            }
             
            string phong = comboBox2.SelectedValue.ToString();

            if (dateTimePicker2.Checked == false)
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery(" Select * from HopDong  where Phong= @a and NgayKT IS NULL ", new object[] { comboBox2.SelectedValue.ToString() });
                if (dt.Rows.Count > 0) return false;
                dt = DataProvider.Instance.ExecuteQuery("Select * from HopDong  where Phong= @a and NgayKT> @b ", new object[] { comboBox2.SelectedValue.ToString(), dateTimePicker1.Value.Date });
                if (dt.Rows.Count > 0) return false;
                else return true;
            }
            else
            {                
                    DataTable dt1= DataProvider.Instance.ExecuteQuery("Select * from HopDong  where Phong= @a and NgayKT IS NULL and NgayBD< @b ", new object[] { phong, dateTimePicker2.Value.Date });                             
                    DataTable dt2= DataProvider.Instance.ExecuteQuery("Select * from HopDong  where Phong= @a and  NgayKT> @d1 and NgayBD< @d2 ", new object[] { phong, dateTimePicker1.Value.Date,dateTimePicker2.Value.Date });
                    if (dt1.Rows.Count+dt2.Rows.Count > 0) return false;
                    else return true;                
            }  
            
        }

        private void btnTaoHopDong_Click(object sender, EventArgs e)
        {
            if ( !Check() )
            {
                MessageBox.Show("Bạn nhập sai thông tin đầu vào hoặc hợp đồng bị trùng ngày! ", "Thông báo LỖI");
                return;
            }
            else
            {
                if (dateTimePicker2.Checked==true)
                HopDongDAL.Instance.ThemHopDong(int.Parse(txtIDHopDongMoi.Text),int.Parse(comboBox1.SelectedValue.ToString()),comboBox2.SelectedValue.ToString(),dateTimePicker1.Value.Date,dateTimePicker2.Value.Date);
                else HopDongDAL.Instance.ThemHopDong(int.Parse(txtIDHopDongMoi.Text),int.Parse(comboBox1.SelectedValue.ToString()), comboBox2.SelectedValue.ToString(), dateTimePicker1.Value.Date, null);
            }
        }

        private void dataGridViewHopDong_SelectionChanged_1(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridViewHopDong.CurrentRow;
            if (row == null) return;
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = DateTime.Parse(row.Cells[3].Value.ToString()).Date.ToString("dd/MM/yyyy");
            if (row.Cells[4].Value.ToString() == "") textBox5.Text = "";
            else textBox5.Text = DateTime.Parse(row.Cells[4].Value.ToString()).Date.ToString("dd/MM/yyyy");
        }

        private void comboBox1_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            textBox6.Text = DataProvider.Instance.ExecuteScalar(" Select Ten from KhachHang where IDKhachHang= @a ", new object[] { comboBox1.SelectedValue.ToString() }) .ToString();
            textBox7.Text = DataProvider.Instance.ExecuteScalar(" Select SDT from KhachHang where IDKhachHang= @a ", new object[] { comboBox1.SelectedValue.ToString() }) .ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn thay đổi dịch vụ?", "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            {
                
            }
          
        }
    }
}
