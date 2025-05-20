using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyHoaDon.DAL;

namespace QuanLyHoaDon.GUI
{
    public partial class LichSuThanhToan : Form
    {
        private static LichSuThanhToan instance;

        public static LichSuThanhToan Instance
        {
            get
            {
                if (instance == null )
                {
                    instance = new LichSuThanhToan();
                }
                return instance;
            }
        }

        private LichSuThanhToan()
        {
            InitializeComponent();
        }
        
        private void SetUp1()
        {
            dataGridViewLichSuDien.DataSource = DataProvider.Instance.ExecuteQuery("Select * from LichSuDien");
            dataGridViewLichSuDien.Columns["NgayThanhToan"].DefaultCellStyle.Format = "dd/MM/yyyy";
            DataGridViewRow row = dataGridViewLichSuDien.CurrentRow;
            if (row == null) return; 
            textBox1.Text = row.Cells[0].Value.ToString(); // IDKhachHang
            textBox2.Text = row.Cells[1].Value.ToString(); // SoPhong
            textBox3.Text = row.Cells[2].Value.ToString(); // NgayThanhToan


        }
        private void SetUp2()
        {
            dataGridViewLichSuDien.DataSource = DataProvider.Instance.ExecuteQuery("Select * from LichSuNuoc");
            dataGridViewLichSuDien.Columns["NgayThanhToan"].DefaultCellStyle.Format = "dd/MM/yyyy";
            DataGridViewRow row1 = dataGridViewLichSuDien.CurrentRow;
            if (row1 == null) return;
            textBox6.Text = row1.Cells[0].Value.ToString(); // IDKhachHang
            textBox5.Text = row1.Cells[1].Value.ToString(); // SoPhong
            textBox4.Text = row1.Cells[2].Value.ToString(); // NgayThanhToan
        }


        private void LichSuDien_Load(object sender, EventArgs e)
        {
            SetUp1();
            SetUp2();
        }

        private void dataGridViewLichSuDien_SelectionChanged(object sender, EventArgs e)
        {
            SetUp1();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SetUp2();
        }
    }
}
