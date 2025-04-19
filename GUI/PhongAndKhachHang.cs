using DevExpress.XtraEditors;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QuanLyHoaDon.GUI
{
    public partial class PhongAndKhachHang : Form
    {
        private static PhongAndKhachHang instance;
        public static PhongAndKhachHang Instance
        {
            get
            {
                if (instance == null)
                    instance = new PhongAndKhachHang();
                return instance;
            }
            private set { instance = value; }
        }
        private PhongAndKhachHang()
        {
            InitializeComponent();
        }

        private void PhongAndKhachHang_Load(object sender, EventArgs e)
        {
            
            dataGridViewPhong.DataSource = PhongDAL.Instance.FullPhong();
            dataGridViewCustomer.DataSource = DataProvider.Instance.ExecuteQuery(" select * from KhachHang ");
 
            
        }

        private void dataGridViewPhong_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string CELL = dataGridViewPhong.CurrentCell.Selected.ToString();
            MessageBox.Show(CELL, "Nội dung Cell:");
        }

        private void dataGridViewPhong_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                comboBoxEdit2.SelectedItem = null;
                DataGridViewRow row = dataGridViewPhong.Rows[e.RowIndex];
                textEdit6.Text = row.Cells["Phong"].Value.ToString();
                comboBoxEdit2.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            comboBoxEdit2.SelectedItem = null;
            PhongDAL.Instance.ThemPhong(textEdit6.Text, "Trống");
            comboBoxEdit2.SelectedItem = textEdit6.Text;
            dataGridViewPhong.DataSource = PhongDAL.Instance.FullPhong();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit2.Text == "Đang SD")
            {
                MessageBox.Show("Phòng đang sử dụng không thể cho thuê");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridViewPhong.DataSource= DataProvider.Instance.ExecuteNonQuery(" Them_KhachHang @a , @b", new object[] { textEdit5.Text, textEdit4.Text });
           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Cursor = Cursors.Default;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Cursor = Cursors.Default;
        }

        
    }
}
