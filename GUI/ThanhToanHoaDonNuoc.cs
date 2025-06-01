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
using QuanLyHoaDon.DAL;


namespace QuanLyHoaDon.GUI
{
    public partial class ThanhToanHoaDonNuoc : Form
    {
        private int IDHoaDonNuoc;

        private static ThanhToanHoaDonNuoc instance;
        public static ThanhToanHoaDonNuoc Instance(int id)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ThanhToanHoaDonNuoc(id);
            }
            return instance;
        }

        private ThanhToanHoaDonNuoc(int id)
        {
            InitializeComponent();
            this.IDHoaDonNuoc = id;
        }

        private void SetUp()
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            DataRow dataRow = DataProvider.Instance.ExecuteQuery("Select * from HoaDonNuoc where IDHoaDonNuoc= @a ", new object[] { IDHoaDonNuoc }).Rows[0];
            textBox4.Text = IDHoaDonNuoc.ToString();
            textBox1.Text = dataRow["IDKhachHang"].ToString();
            textBox5.Text = dataRow["Phong"].ToString();
            textBox6.Text = dataRow["Nam"].ToString();
            textBox7.Text = dataRow["Thang"].ToString();
            textBox8.Text = dataRow["SoNuocCu"].ToString();
            textBox9.Text = dataRow["SoNuocMoi"].ToString();
            textBox10.Text = dataRow["DonGia"].ToString();
            textBox10.Text = Convert.ToSingle(textBox10.Text).ToString("F2");
            textBox9.Text = Convert.ToSingle(textBox9.Text).ToString("F2");
            textBox8.Text = Convert.ToSingle(textBox8.Text).ToString("F2");
            DataRow dt1 = DataProvider.Instance.ExecuteQuery("Select * from KhachHang where IDKhachHang= @a ", new object[] { int.Parse(textBox1.Text) }).Rows[0];
            textBox2.Text = dt1["Ten"].ToString();
            textBox3.Text = dt1["SDT"].ToString();

            HoaDonNuocDTO hoaDonNuocDTO = new HoaDonNuocDTO(IDHoaDonNuoc, int.Parse(textBox1.Text), textBox5.Text, int.Parse(textBox7.Text), int.Parse(textBox6.Text), float.Parse(textBox8.Text), float.Parse(textBox9.Text), float.Parse(textBox10.Text));
            textBox11.Text = hoaDonNuocDTO.SoSuDung.ToString("F2");
            textBox12.Text = hoaDonNuocDTO.PhiDichVu.ToString("F2");
            textBox13.Text = hoaDonNuocDTO.ThanhTien.ToString("F2");

        }

        private void ThanhToanHoaDonNuoc_Load(object sender, EventArgs e)
        {
            SetUp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn thanh toán hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HoaDonNuocDTO hoaDonNuocDTO = new HoaDonNuocDTO(IDHoaDonNuoc, int.Parse(textBox1.Text), textBox5.Text, int.Parse(textBox7.Text), int.Parse(textBox6.Text), float.Parse(textBox8.Text), float.Parse(textBox9.Text), float.Parse(textBox10.Text));
                KhachHang khachHang = new KhachHang(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text);
                DateTime ngayThanhToan = dateTimePicker1.Value.Date;
                BillNuoc.Instance(khachHang, hoaDonNuocDTO, ngayThanhToan).ShowDialog();
                if (LichSuThanhToanHoaDonNuocDAL.Instance.ThemLichSu(hoaDonNuocDTO.IDHoaDonNuoc, ngayThanhToan) > 0)
                {
                    MessageBox.Show("Thanh toán hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
               
            }
        }
    }
}
