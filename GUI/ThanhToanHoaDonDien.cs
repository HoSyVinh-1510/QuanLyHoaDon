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
    public partial class ThanhToanHoaDonDien : Form
    {
        private int IDHoaDonDien;

        private static ThanhToanHoaDonDien instance;
        public static ThanhToanHoaDonDien Instance(int id)
        {         
                if (instance == null || instance.IsDisposed)
                {
                    instance = new ThanhToanHoaDonDien(id);
                }
                return instance;          
        }

        private ThanhToanHoaDonDien(int idHoaDonDien)
        {
            this.IDHoaDonDien = idHoaDonDien;
            InitializeComponent();
        }

        private void SetUp()
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            DataRow dt = DataProvider.Instance.ExecuteQuery("Select * from HoaDonDien where IDHoaDonDien= @a ",new object[] {IDHoaDonDien}).Rows[0];
            textBox4.Text = dt["IDHoaDonDien"].ToString();
            textBox1.Text = dt["IDKhachHang"].ToString();
            textBox5.Text = dt["Phong"].ToString();
            textBox6.Text = dt["Nam"].ToString();
            textBox7.Text = dt["Thang"].ToString();
            textBox8.Text = dt["SoDienCu"].ToString();
            textBox9.Text = dt["SoDienMoi"].ToString();
            textBox10.Text = dt["DonGia"].ToString();
            textBox10.Text = Convert.ToSingle(textBox10.Text).ToString("F2");
            
            //int idHD,int idKH, string sp, int thang, int nam, float SDC, float SDM,float DG

            HoaDonDienDTO hoaDonDienDTO = new HoaDonDienDTO(IDHoaDonDien,int.Parse(textBox1.Text),textBox5.Text,int.Parse(textBox7.Text),int.Parse(textBox6.Text),float.Parse(textBox8.Text),float.Parse(textBox9.Text),float.Parse(textBox10.Text));
            textBox11.Text = hoaDonDienDTO.SoSuDung.ToString(); 
            textBox12.Text = hoaDonDienDTO.PhiDichVu.ToString();
            textBox13.Text = hoaDonDienDTO.ThanhTien.ToString();

            DataRow dt1=DataProvider.Instance.ExecuteQuery("Select * from KhachHang where IDKhachHang= @a ", new object[] { int.Parse(textBox1.Text) }).Rows[0];
            textBox2.Text = dt1["Ten"].ToString();
            textBox3.Text = dt1["SDT"].ToString();
        }

        private void ThanhToanHoaDonDien_Load(object sender, EventArgs e)
        {
            SetUp();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã chắc chắn thanh toán chưa?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
             
                {
                    
                    if (DialogResult.Yes==MessageBox.Show("Bạn muốn xuất hóa đơn không?","Thông báo!", MessageBoxButtons.YesNo))
                    {
                        KhachHang kh=new KhachHang(int.Parse(textBox1.Text),textBox2.Text,textBox3.Text);
                        HoaDonDienDTO hoaDonDienDTO = new HoaDonDienDTO(int.Parse(textBox4.Text), int.Parse(textBox1.Text), textBox5.Text, int.Parse(textBox7.Text), int.Parse(textBox6.Text), float.Parse(textBox8.Text), float.Parse(textBox9.Text), float.Parse(textBox10.Text));
                        BillDien.Instance(kh,hoaDonDienDTO,dateTimePicker1.Value.Date).ShowDialog();
                        LichSuThanhToanHoaDonDienDAL.Instance.ThemLichSu(IDHoaDonDien, dateTimePicker1.Value.Date);
                        MessageBox.Show("Thanh toán thành công!");
                    }
                    
                }
              
            }
        }
    }
}
