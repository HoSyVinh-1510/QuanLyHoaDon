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
    public partial class HoaDonNuoc : Form
    {
        private static HoaDonNuoc instance;

        public static HoaDonNuoc Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new HoaDonNuoc();
                }
                return instance;
            }
        }

        private HoaDonNuoc()
        {
            InitializeComponent();
        }

        private void Output()
        {
            DataGridViewRow row = dataGridViewHoaDonNuoc.CurrentRow;
            if (row == null) return;
            HoaDonNuocDTO hoaDonNuocDTO = new HoaDonNuocDTO(
                int.Parse(row.Cells[0].Value.ToString()),
                int.Parse(row.Cells[1].Value.ToString()),
                row.Cells[2].Value.ToString(),
                int.Parse(row.Cells[3].Value.ToString()),
                int.Parse(row.Cells[4].Value.ToString()),
                float.Parse(row.Cells[5].Value.ToString()),
                float.Parse(row.Cells[6].Value.ToString()),
                float.Parse(row.Cells[7].Value.ToString())
            );

            textBox1.Text = hoaDonNuocDTO.IDHoaDonNuoc.ToString();
            textBox2.Text = hoaDonNuocDTO.IDKhachHang.ToString();
            textBox3.Text = hoaDonNuocDTO.SoPhong.ToString();
            textBox4.Text = hoaDonNuocDTO.Thang.ToString();
            textBox5.Text = hoaDonNuocDTO.Nam.ToString();
            textBox6.Text = hoaDonNuocDTO.SoNuocCu.ToString();
            textBox7.Text = hoaDonNuocDTO.SoNuocMoi.ToString();
            textBox8.Text = hoaDonNuocDTO.SoSuDung.ToString();
            textBox9.Text = hoaDonNuocDTO.DonGia.ToString();
            textBox11.Text = hoaDonNuocDTO.PhiDichVu.ToString();
            textBox12.Text = hoaDonNuocDTO.ThanhTien.ToString();

            if (LichSuThanhToanHoaDonNuocDAL.Instance.NgayThanhToanHD(hoaDonNuocDTO.IDHoaDonNuoc) == null)
            {
                textBox13.Text = "Chưa thanh toán";
            }
            else textBox13.Text = LichSuThanhToanHoaDonNuocDAL.Instance.NgayThanhToanHD(hoaDonNuocDTO.IDHoaDonNuoc).ToString();

            textBox10.Text = DataProvider.Instance.ExecuteScalar("Select Ten from KhachHang where IDKhachHang= @a ", new object[] { int.Parse(textBox2.Text) }).ToString();
            textBox14.Text = DataProvider.Instance.ExecuteScalar("Select SDT from KhachHang where IDKhachHang= @a ", new object[] { int.Parse(textBox2.Text) }).ToString();

        }


        private void SetUp()
        {
            HoaDonNuocDAL.Instance.DongBoHoaDonNuoc();
            dataGridViewHoaDonNuoc.DataSource = DataProvider.Instance.ExecuteQuery("Select * from HoaDonNuoc");
            Output();
            dataGridViewHoaDonNuoc.Columns["SoNuocCu"].DefaultCellStyle.Format = "N2";
            dataGridViewHoaDonNuoc.Columns["SoNuocMoi"].DefaultCellStyle.Format = "N2";
            dataGridViewHoaDonNuoc.Columns["DonGia"].DefaultCellStyle.Format = "N2";
        }

        private void dataGridViewHoaDonDien_SelectionChanged(object sender, EventArgs e)
        {   
            Output();
        }

        private void HoaDonNuoc_Load(object sender, EventArgs e)
        {
            SetUp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox13.Text== "Chưa thanh toán")
            {

            }
            else
            {
                MessageBox.Show("Hóa đơn đã thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
