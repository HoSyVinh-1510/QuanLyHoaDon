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
namespace QuanLyHoaDon
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void checkEdit1_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)       
                textBox2.UseSystemPasswordChar = true;
            else
                textBox2.UseSystemPasswordChar = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null)
            { MessageBox.Show("Vui lòng nhập đủ tài khoản và mật khẩu");
                return;
            }
           if (AccountDAL.Instance.CheckLogin(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Đăng nhập thành công"); 
                this.Hide();
                HOME.Instance.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            }
        }
    }
}
