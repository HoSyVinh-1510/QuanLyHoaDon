﻿using QuanLyHoaDon.DAL;
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
    public partial class BangSoDienNuoc : Form
    {
        private static BangSoDienNuoc instance;
        public static BangSoDienNuoc Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new BangSoDienNuoc();
                }
                return instance;
            }
        }

        private BangSoDienNuoc()
        {
            InitializeComponent();
        }

        private void Infor()
        {
            DataGridViewRow row = dataGridViewSoDienNuoc.CurrentRow;
            if (row == null) return;
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();
            textBox7.Text = row.Cells[6].Value.ToString();
            textBox8.Text = row.Cells[7].Value.ToString();
            textBox9.Text = row.Cells[8].Value.ToString();
        }
        private void SetUp()
        {
            dataGridViewSoDienNuoc.DataSource=DataProvider.Instance.ExecuteQuery("SELECT * FROM SoDienNuoc");
            dataGridViewSoDienNuoc.Columns["SoDienMoi"].DefaultCellStyle.Format = "N2";
            dataGridViewSoDienNuoc.Columns["SoNuocMoi"].DefaultCellStyle.Format = "N2";
            dataGridViewSoDienNuoc.Columns["SoDienCu"].DefaultCellStyle.Format = "N2";
            dataGridViewSoDienNuoc.Columns["SoNuocCu"].DefaultCellStyle.Format = "N2";

            Infor();
            textBox11.Text= SoDienNuocDAL.Instance.GetMaxIDSoDienNuoc().ToString();

            FormatTextInput.Instance.Interger(textBox12);
            FormatTextInput.Instance.Interger(textBox13);
            FormatTextInput.Instance.Float(textBox15);
            FormatTextInput.Instance.Float(textBox17);

            comboBox1.DataSource= DataProvider.Instance.ExecuteQuery("SELECT DISTINCT Phong FROM SoDienNuoc");
            comboBox1.DisplayMember = "Phong";
            comboBox1.ValueMember = "Phong";
            comboBox2.Enabled = false;
        }

        private void BangSoDienNuoc_Load(object sender, EventArgs e)
        {
            SetUp();
        }

        private void dataGridViewSoDienNuoc_SelectionChanged(object sender, EventArgs e)
        {
            Infor();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            
            comboBox2.DataSource = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT IDKhachHang FROM SoDienNuoc where Phong= @p ", new object[] { comboBox1.SelectedValue.ToString()});
            comboBox2.DisplayMember = "IDKhachHang";
            comboBox2.ValueMember = "IDKhachHang";

            object k= DataProvider.Instance.ExecuteScalar(" SELECT MAX(IDSoDienNuoc) FROM SoDienNuoc where Phong= @p ", new object[] { comboBox1.SelectedValue.ToString() });
            if (k == null) return;
            DataTable dt = DataProvider.Instance.ExecuteQuery(" Select * from SoDienNuoc where IDSoDienNuoc= @a ",new object[] {Convert.ToInt32(k)});

            DataRow row = dt.Rows[0];
            textBox14.Text = row["SoDienMoi"].ToString();
            textBox16.Text = row["SoNuocMoi"].ToString();
            DialogResult result = MessageBox.Show("Hóa đơn mới này của tháng mới phòng này hay không?", "Câu Hỏi?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int thang0 = int.Parse(row["Thang"].ToString());
                int nam0 = int.Parse(row["Nam"].ToString());
                if (thang0 == 12)
                {
                    thang0 = 1;
                    nam0 += 1;
                }
                else thang0 += 1;
                textBox13.Text = thang0.ToString();
                textBox12.Text = nam0.ToString();
            }
            else if (result == DialogResult.No)
            {
                textBox13.Text = row["Thang"].ToString();
                textBox12.Text = row["Nam"].ToString();
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Hủy bỏ thao tác!");
                comboBox2.Focus();
            }
            textBox15.Focus();
        }

        private bool Check()
        {
            if(textBox12.Text==null || textBox13.Text==null || textBox15.Text==null || textBox17.Text==null || comboBox1.SelectedItem==null || comboBox2.SelectedItem==null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }
            if ( int.Parse(textBox13.Text)>12 || int.Parse(textBox13.Text) < 0)
            {
                MessageBox.Show("Tháng không hợp lệ!");
                textBox13.Text = null;
                 textBox13.Focus();
                return false;
            }
            if (float.Parse(textBox15.Text) < float.Parse(textBox14.Text)  || float.Parse(textBox17.Text) < float.Parse(textBox16.Text))
            {
                 MessageBox.Show("Số điện mới và số nước mới phải lớn hơn số cũ!");
                textBox15.Text = null;
                textBox17.Text = null;
                textBox15.Focus();
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                SoDienNuocDAL.Instance.ThemSoDienNuoc(comboBox1.SelectedValue.ToString(), int.Parse(comboBox2.SelectedValue.ToString()), int.Parse(textBox12.Text), int.Parse(textBox13.Text), float.Parse(textBox14.Text), float.Parse(textBox16.Text), float.Parse(textBox15.Text), float.Parse(textBox17.Text));
            }
            else
            {
                MessageBox.Show("Có lỗi sai đầu vào!");
                return;
            }
            dataGridViewSoDienNuoc.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM SoDienNuoc");
            Infor();

        }
    }
}
