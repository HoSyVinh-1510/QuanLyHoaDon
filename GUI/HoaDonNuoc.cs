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
            textBox6.Text = hoaDonNuocDTO.SoNuocCu.ToString("F2");
            textBox7.Text = hoaDonNuocDTO.SoNuocMoi.ToString("F2");
            textBox8.Text = hoaDonNuocDTO.SoSuDung.ToString("F2");
            textBox9.Text = hoaDonNuocDTO.DonGia.ToString("F2");
            textBox11.Text = hoaDonNuocDTO.PhiDichVu.ToString("F2");
            textBox12.Text = hoaDonNuocDTO.ThanhTien.ToString("F2");

            
           textBox13.Text = LichSuThanhToanHoaDonNuocDAL.Instance.NgayThanhToanHD(hoaDonNuocDTO.IDHoaDonNuoc);

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
                ThanhToanHoaDonNuoc.Instance(int.Parse(textBox1.Text)).ShowDialog();
            }
            else
            {
                MessageBox.Show("Hóa đơn đã thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox13.Text!="Chưa thanh toán")
            {
                HoaDonNuocDTO hoaDonNuocDTO = new HoaDonNuocDTO(
                int.Parse(textBox1.Text),
                int.Parse(textBox2.Text),
                textBox3.Text,
                int.Parse(textBox4.Text),
                int.Parse(textBox5.Text),
                float.Parse(textBox6.Text),
                float.Parse(textBox7.Text),
                float.Parse(textBox9.Text)
                );

                KhachHang khachHang = new KhachHang(int.Parse(textBox2.Text), textBox10.Text, textBox14.Text);
                DateTime dateTime = DateTime.Parse(textBox13.Text).Date;
                BillNuoc.Instance(khachHang, hoaDonNuocDTO, dateTime).ShowDialog(); 
            }
            else             
            {
                MessageBox.Show("Hóa đơn chưa thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ThanhToanHoaDonNuoc.Instance(int.Parse(textBox1.Text)).ShowDialog();
                return;
            }

        }
    }
}
