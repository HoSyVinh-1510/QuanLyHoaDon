using DevExpress.Utils.ScrollAnnotations;
using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
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
    
    private void TaoDanhSach()
    {
            DataTable dataTable = DataProvider.Instance.ExecuteQuery("Select * from Phong");
            panelPhong.Controls.Clear();

            int ngang = 70, rong = 60;
            int x = 10, y = 10;
            int khCach = 10;
            int count = 0;

            foreach(DataRow row in dataTable.Rows)
            {
                Button bt = new Button();
                bt.Text = row["Phong"].ToString();


                bt.Width = ngang;
                bt.Height = rong;
                if (row["TrangThai"].ToString()=="Đang SD")
                    bt.BackColor= Color.Red;
                else bt.BackColor= Color.Green; 

                bt.FlatStyle = FlatStyle.Flat;
                bt.ForeColor = Color.Black;

                bt.Left = x+(count%5)*(ngang+khCach);
                bt.Top = y+(count/5)*(rong+khCach);

                panelPhong.Controls.Add(bt);
                count++;
                bt.Click += bt_click;
            }            
    }


        private void bt_click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.BackColor==Color.Red)
            MessageBox.Show("Bạn chọn phòng: " + button.Text + ". Trạng thái: Đang Sử Dụng");
            if (button.BackColor == Color.Green)
            {
                MessageBox.Show("Bạn chọn phòng: " + button.Text + ". Trạng thái: Trống");
            }
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
            CapNhatPhong();
            TaoDanhSach();
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

            panel2.Visible = false; 
            panel3.Visible = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            FormatTextInput.Instance.SDT(textBox6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            FormatTextInput.Instance.SDT(textBox7);
        }
    }
}
