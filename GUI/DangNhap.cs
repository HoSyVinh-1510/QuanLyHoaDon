using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHoaDon.BLL;
using QuanLyHoaDon.DTO;
using QuanLyHoaDon.DAL;
using System.Data.SqlClient;
using QuanLyHoaDon.GUI;
namespace QuanLyHoaDon
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thoát ứng dụng!");
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn login = new  LogIn();
            login.Account(textBox1.Text, textBox2.Text);
            LogInBLL logInBLL = new LogInBLL();
            
            if(logInBLL.DangNhapBLL(login))
            {
                Account ac = new Account(textBox1.Text,textBox2.Text);
                MessageBox.Show("Đăng nhập thành công!");
                textBox1.Text = null;
                textBox2.Text = null;
                this.Hide();
                Home h = new Home();
                h.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại! Kiểm tra lại tài khoản hoặc mật khẩu!");
            }


        }

        // hàm hiển thị mật khẩu

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) 
            { 
                textBox2.UseSystemPasswordChar=false;
            }
            else
                textBox2.UseSystemPasswordChar = true;
            return;
        }
    }
}
