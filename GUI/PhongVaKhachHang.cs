using QuanLyHoaDon.DTO;
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
    public partial class PhongVaKhachHang : Form
    {
        private static PhongVaKhachHang instance;  

        public static PhongVaKhachHang Instance
        {
            get
            {
                if (instance == null)
                    instance= new PhongVaKhachHang();
                return instance;
            }

        }

    private PhongVaKhachHang()
    {
            InitializeComponent();
    }
        
        void CapNhatPhong() 
        {
            DataTable dataTable= DataProvider.Instance.ExecuteQuery("select Phong from Phong");
            foreach(DataRow row in dataTable.Rows)
            {
                string phong = row["Phong"].ToString();
                PhongDAL.Instance.UpdatePhong(phong);
            }
        }

        private void PhongVaKhachHang_Load(object sender, EventArgs e)
        {
            dataGridViewPhong.DataSource = DataProvider.Instance.ExecuteQuery("select * from Phong");
            dataGridViewKhachHang.DataSource = DataProvider.Instance.ExecuteQuery("select * from KhachHang");
            DataGridViewRow row1 = dataGridViewPhong.Rows[0];
            DataGridViewRow row2 = dataGridViewKhachHang.Rows[0];
            txtPhong1.Text = row1.Cells[0].Value.ToString();
            textBox1.Text = row1.Cells[1].Value.ToString();
            textBox2.Text=row2.Cells[0].Value.ToString();
            textBox3.Text=row2.Cells[1].Value.ToString();
            textBox4.Text = row2.Cells[2].Value.ToString();
            comboBox1.SelectedIndex = 0;
            textBox5.Text =(KhachHangDAL.Instance.GetMaxIDKhachHang()+1).ToString();
        }

        private void dataGridViewPhong_SelectionChanged(object sender, EventArgs e)
        {

            DataGridViewRow row= dataGridViewPhong.CurrentRow;
            if (row!=null)
            {
                txtPhong1.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
            }
            
            
          
        }

        private void dataGridViewKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row= dataGridViewKhachHang.CurrentRow;
            if (row==null) return;
            textBox2.Text = dataGridViewKhachHang.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridViewKhachHang.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridViewKhachHang.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (txtPhong.Text == null)
            {
                MessageBox.Show("Không để trống ô này!");
                txtPhong.Focus();
            }
            if (DataProvider.Instance.ExecuteQuery("Select * from Phong where Phong= @a ", new object[] { "P" + txtPhong.Text }).Rows.Count>0)
            {
                MessageBox.Show("Phòng đã tồn tại");
                return;
            }
            PhongDAL.Instance.ThemPhong("P"+txtPhong.Text,comboBox1.SelectedItem.ToString());
            dataGridViewPhong.DataSource = DataProvider.Instance.ExecuteQuery("select * from Phong");
        }

        private void txtPhong_Enter(object sender, EventArgs e)
        {
            FormatTextInput.Instance.SDT(txtPhong);
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            FormatTextInput.Instance.InputTextBox(textBox6);
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            FormatTextInput.Instance.SDT(textBox7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text==null)
            {
                MessageBox.Show("Không được để trống tên! ");
                textBox6.Focus();
            }
            else
            {
                 if (textBox7.Text == null)
                {
                    MessageBox.Show("Không được để trống SDT!");
                    textBox7.Focus();
                }
                else
                {
                    KhachHangDAL.Instance.ThemKhachHang(textBox6.Text,textBox7.Text);
                    dataGridViewKhachHang.DataSource = DataProvider.Instance.ExecuteQuery("select * from KhachHang");
                }
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            textBox6.Text= FormatTextInput.Instance.FormatName(textBox6.Text);
        }
    }
}
