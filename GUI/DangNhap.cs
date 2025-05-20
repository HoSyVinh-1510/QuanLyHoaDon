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
using QuanLyHoaDon.BLL;
using QuanLyHoaDon.DAL;
using QuanLyHoaDon.GUI;


namespace QuanLyHoaDon.GUI
{
    public partial class DangNhap : Form
    {
        private static DangNhap instance;
        public static DangNhap Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DangNhap();
                }
                return instance;
            }
        }
        private DangNhap()
        {
            
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==null || textBox2.Text==null)
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!");
            }
            else
            {
                string tk = textBox2.Text;
                string mk = textBox1.Text;
                if (DAL.AccountDAL.Instance.CheckLogin(tk, mk))
                {
                    this.Hide();
                    HOME.Instance.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {    
                textBox1.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
                
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            FormatTextInput.Instance.InputTextBox(textBox2);
            FormatTextInput.Instance.InputTextBox(textBox1);
        }
    }
}
