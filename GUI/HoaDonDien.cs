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
using QuanLyHoaDon.DTO;

namespace QuanLyHoaDon.GUI
{
    public partial class HoaDonDien : Form
    {
        private static HoaDonDien instance;

        public static HoaDonDien Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new HoaDonDien();
                }
                return instance;
            }
        }

        private HoaDonDien()
        {
            InitializeComponent();
        }

        void SetUp()
        {
            HoaDonDienDAL.Instance.DongBoHoaDonDien();
            Output();
            dataGridViewHoaDonDien.DataSource = DataProvider.Instance.ExecuteQuery("Select * from HoaDonDien");
            dataGridViewHoaDonDien.Columns["SoDienCu"].DefaultCellStyle.Format = "N2";
            dataGridViewHoaDonDien.Columns["SoDienMoi"].DefaultCellStyle.Format = "N2";
            dataGridViewHoaDonDien.Columns["DonGia"].DefaultCellStyle.Format = "N2";
        }

        void Output()
        {
            DataGridViewRow row = dataGridViewHoaDonDien.CurrentRow;
            if (row == null) return;
            //int idHD,int idKH, string sp, int thang, int nam, float SDC, float SDM,float DG
            HoaDonDienDTO hoaDonDienDTO = new HoaDonDienDTO
            (
                int.Parse(row.Cells[0].Value.ToString()),
                int.Parse(row.Cells[1].Value.ToString()),
                row.Cells[2].Value.ToString(),
                int.Parse(row.Cells[3].Value.ToString()),
                int.Parse(row.Cells[4].Value.ToString()),
                float.Parse(row.Cells[5].Value.ToString()),
                float.Parse(row.Cells[6].Value.ToString()),
                float.Parse(row.Cells[7].Value.ToString())
            );

            textBox1.Text = hoaDonDienDTO.IDHoaDonDien.ToString();
            textBox2.Text = hoaDonDienDTO.IDKhachHang.ToString();
            textBox3.Text = hoaDonDienDTO.SoPhong.ToString();
            textBox4.Text = hoaDonDienDTO.Thang.ToString();
            textBox5.Text = hoaDonDienDTO.Nam.ToString();
            textBox6.Text = hoaDonDienDTO.SoDienCu.ToString("F2");
            textBox7.Text = hoaDonDienDTO.SoDienMoi.ToString("F2");
            textBox8.Text = hoaDonDienDTO.SoSuDung.ToString("F2");
            textBox9.Text = hoaDonDienDTO.DonGia.ToString("F2");
            textBox11.Text = hoaDonDienDTO.PhiDichVu.ToString("F2");
            textBox12.Text = hoaDonDienDTO.ThanhTien.ToString("F2");
            if (LichSuThanhToanHoaDonDienDAL.Instance.NgayThanhToanHD(hoaDonDienDTO.IDHoaDonDien) == null)
            {
                textBox13.Text = "Chưa thanh toán";
            }
            else textBox13.Text = LichSuThanhToanHoaDonDienDAL.Instance.NgayThanhToanHD(hoaDonDienDTO.IDHoaDonDien);

            textBox10.Text = DataProvider.Instance.ExecuteScalar("Select Ten from KhachHang where IDKhachHang= @a ", new object[] {int.Parse(textBox2.Text) }).ToString();
            textBox14.Text = DataProvider.Instance.ExecuteScalar("Select SDT from KhachHang where IDKhachHang= @a ", new object[] { int.Parse(textBox2.Text) }).ToString();

        }

        

        private void dataGridViewHoaDonDien_SelectionChanged(object sender, EventArgs e)
        {
            Output();
        }

        private void HoaDonDien_Load(object sender, EventArgs e)
        {
            SetUp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox13.Text== "Chưa thanh toán")
            {
                
                ThanhToanHoaDonDien.Instance(int.Parse(textBox1.Text)).ShowDialog();
            }
            else
            {
                MessageBox.Show("Hóa đơn đã thanh toán không thể thanh toán lại!");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != "Chưa thanh toán")
            {
                KhachHang khachHang= new KhachHang(int.Parse(textBox2.Text), textBox10.Text, textBox14.Text);
                HoaDonDienDTO hoaDonDienDTO = new HoaDonDienDTO
                (
                    int.Parse(textBox1.Text),
                    int.Parse(textBox2.Text),
                    textBox3.Text,
                    int.Parse(textBox4.Text),
                    int.Parse(textBox5.Text),
                    float.Parse(textBox6.Text),
                    float.Parse(textBox7.Text),
                    float.Parse(textBox9.Text)
                );
                DateTime dt=DateTime.Parse(textBox13.Text).Date;
                BillDien.Instance(khachHang, hoaDonDienDTO, dt).ShowDialog();
            }
            else
            {
                MessageBox.Show("Hóa đơn chưa thanh toán. Chuyển đến trang thanh toán","Thông báo");
                ThanhToanHoaDonDien.Instance(int.Parse(textBox1.Text)).ShowDialog();
                button1_Click(sender, e);
                return;
            }
        }
    }
}
