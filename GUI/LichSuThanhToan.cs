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
            dG1.DataSource = DataProvider.Instance.ExecuteQuery("Select * from LichSuDien");
            dG2.DataSource = DataProvider.Instance.ExecuteQuery("Select * from LichSuNuoc");
        }
        
        private void SetUp1()
        {            
            dG1.Columns["NgayThanhToan"].DefaultCellStyle.Format = "dd/MM/yyyy";
            Infor1();
            comboBox1.DataSource = DataProvider.Instance.ExecuteQuery("select distinct HoaDonDien.Phong from LichSuDien,HoaDonDien where LichSuDien.IDHoaDonDien=HoaDonDien.IDHoaDonDien");
            comboBox1.DisplayMember = "Phong";
            comboBox1.ValueMember= "Phong";
            comboBox1.SelectedIndex = -1;

        }

        private void Infor1()
        {
            DataGridViewRow row = dG1.CurrentRow;
            if (row == null) return;
            tB1.Text = row.Cells[0].Value.ToString(); // IDLichSuDien
            tB2.Text = row.Cells[1].Value.ToString(); // IDKhachHang
            tB3.Text = DateTime.Parse(row.Cells[2].Value.ToString()).ToString("dd/MM/yyyy");
            DataRow row1 = DataProvider.Instance.ExecuteQuery("Select * from HoaDonDien where IDHoaDonDien = @a ", new object[] { int.Parse(tB2.Text) }).Rows[0];
            tB4.Text = row1["Phong"].ToString(); // Phong
            tB5.Text = row1["Nam"].ToString();
            tB6.Text = row1["Thang"].ToString();
            
            int id = int.Parse(row1["IDKhachHang"].ToString());
            DataRow row2 = DataProvider.Instance.ExecuteQuery("Select * from KhachHang where IDKhachHang = @a ", new object[] { id }).Rows[0];
            tB7.Text = row2["Ten"].ToString();
            tB8.Text = row2["SDT"].ToString();
        }

        private void SetUp2()
        {          
            dG2.Columns["NgayThanhToan"].DefaultCellStyle.Format = "dd/MM/yyyy";
            Infor2();
            comboBox2.DataSource = DataProvider.Instance.ExecuteQuery("select distinct HoaDonNuoc.Phong from LichSuNuoc,HoaDonNuoc where LichSuNuoc.IDHoaDonNuoc=HoaDonNuoc.IDHoaDonNuoc");
            comboBox2.DisplayMember = "Phong";
            comboBox2.ValueMember = "Phong";
            comboBox2.SelectedIndex = -1;         
            
        }

        private void Infor2()
        {
            DataGridViewRow row = dG2.CurrentRow;
            if (row == null) return;
            tB9.Text = row.Cells[0].Value.ToString(); // IDLichSu
            tB10.Text = row.Cells[1].Value.ToString(); // IDHoaDon
            tB11.Text = DateTime.Parse( row.Cells[2].Value.ToString()).ToString("dd/MM/yyyy"); 
            DataRow row1 = DataProvider.Instance.ExecuteQuery("Select * from HoaDonNuoc where IDHoaDonNuoc = @a ", new object[] { int.Parse(tB10.Text) }).Rows[0];
            tB12.Text = row1["Phong"].ToString();
            tB13.Text = row1["Nam"].ToString();
            tB14.Text = row1["Thang"].ToString();
            int id = int.Parse(row1["IDKhachHang"].ToString());
            
            DataRow row2 = DataProvider.Instance.ExecuteQuery("Select * from KhachHang where IDKhachHang = @a ", new object[] { id }).Rows[0];
            tB15.Text = row2["Ten"].ToString();
            tB16.Text = row2["SDT"].ToString();
            
        }

        private void LichSuDien_Load(object sender, EventArgs e)
        {
            SetUp1();
            SetUp2();
        }

        private void dG1_SelectionChanged(object sender, EventArgs e)
        {
            Infor1();
        }

        private void dG2_SelectionChanged(object sender, EventArgs e)
        {
            Infor2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((DataTable)dG1.DataSource).DefaultView.RowFilter= string.Empty;
            ((DataTable)dG2.DataSource).DefaultView.RowFilter = string.Empty;
            comboBox1.SelectedValue = null;
        }
    }
}
