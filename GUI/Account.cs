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
    public partial class Account : Form
    {
        static string tk;
        static string mk;
        public Account(string a, string b)
        { 
            tk= a;mk= b;
        }
        public Account()
        {
            InitializeComponent();
            textBox1.Text = tk;
            textBox2.Text = mk;
        }
        private void Account_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else  textBox2.UseSystemPasswordChar= true;
            return;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else textBox3.UseSystemPasswordChar = true;
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogInDAL logInDAL = new LogInDAL();
            logInDAL.SuaDangNhap(textBox1.Text,textBox3.Text);
            return;
        }
    }
}
