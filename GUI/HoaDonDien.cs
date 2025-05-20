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

        void Output()
        {
            HoaDonDienDAL.Instance.DongBoHoaDonDien();
            dataGridViewHoaDonDien.DataSource = DataProvider.Instance.ExecuteQuery("Select * from HoaDonDien");
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
            textBox6.Text = hoaDonDienDTO.SoDienCu.ToString();
            textBox7.Text = hoaDonDienDTO.SoDienMoi.ToString();
            textBox8.Text = hoaDonDienDTO.SoSuDung.ToString();
            textBox9.Text = hoaDonDienDTO.DonGia.ToString();
            textBox11.Text = hoaDonDienDTO.PhiDichVu.ToString();
            textBox12.Text = hoaDonDienDTO.ThanhTien.ToString();
             if( LichSuThanhToanHoaDonDienDAL.Instance.NgayThanhToanHD(hoaDonDienDTO.IDHoaDonDien) ==null)
            {
                textBox13.Text ="Chưa thanh toán";
            }
            else textBox13.Text = LichSuThanhToanHoaDonDienDAL.Instance.NgayThanhToanHD(hoaDonDienDTO.IDHoaDonDien);


        }

        private void dataGridViewHoaDonDien_SelectionChanged(object sender, EventArgs e)
        {
            Output();
        }

        private void HoaDonDien_Load(object sender, EventArgs e)
        {
            Output();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox13.Text== "Chưa thanh toán")
            {
                // Chuyển đến trang thanh toán!
            }
            else
            {
                MessageBox.Show("Hóa đơn đã thanh toán không thể thanh toán lại!");
                return;
            }
        }
    }
}
