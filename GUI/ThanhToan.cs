using QuanLyHoaDon.BLL;
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
    public partial class ThanhToan : Form
    {
        public ThanhToan()
        {
            InitializeComponent();
        }
        public ThanhToan(ChuHo CH, List<HoaDonDien> list)
        {
            InitializeComponent();
            textBox1.Text = "Hóa đơn điện";
            textBox2.Text = CH.MaChuHo;
            textBox3.Text = CH.TenChuHo;
            textBox4.Text = CH.NgaySinh.ToString();
            textBox5.Text = CH.GioiTinh;
            textBox7.Text = CH.SDT;
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            textBox11.Text = hoaDonDienBLL.TinhTien(textBox2.Text, hoaDonDienBLL.FindState("Chưa thanh toán")).ToString();
            foreach (HoaDonDien hd in list)
            {
                if (hd.Phong == textBox2.Text)
                {
                    ListViewItem item2 = new ListViewItem();
                    item2.SubItems[0].Text = hd.NgayLapHoaDon.ToString();
                    item2.SubItems.Add(hd.SoDienCu.ToString());
                    item2.SubItems.Add(hd.SoDienMoi.ToString());
                    item2.SubItems.Add(hd.ThanhTien.ToString());
                    listView1.Items.Add(item2);
                }
            }
            this.Resize(listView1);
            return;

        }

        public ThanhToan(ChuHo CH, List<HoaDonNuoc> list)
        {
            InitializeComponent();
            textBox1.Text = "Hóa đơn nước";
            textBox2.Text = CH.MaChuHo;
            textBox3.Text = CH.TenChuHo;
            textBox4.Text = CH.NgaySinh.ToString();
            textBox5.Text = CH.GioiTinh;
            textBox7.Text = CH.SDT;
            HoaDonNuocBLL hoaDonNuocBLL = new HoaDonNuocBLL();
            textBox11.Text = hoaDonNuocBLL.TinhTien(textBox2.Text, hoaDonNuocBLL.FindState("Chưa thanh toán")).ToString();
            foreach (HoaDonNuoc hd in list)
            {
                if (hd.Phong == textBox2.Text)
                {
                    ListViewItem item2 = new ListViewItem();
                    item2.SubItems[0].Text = hd.NgayLapHoaDon.ToString();
                    item2.SubItems.Add(hd.SoNuocCu.ToString());
                    item2.SubItems.Add(hd.SoNuocMoi.ToString());
                    item2.SubItems.Add(hd.ThanhTien.ToString());
                    listView1.Items.Add(item2);
                }
            }
            this.Resize(listView1);
            return;

        }

        // Hàm resize của Listview
        private void Resize(ListView list)
        {
            float width = list.Width;
            float height = width / 4;
            list.Columns[0].Width = (int)height;
            list.Columns[1].Width = (int)height;
            list.Columns[2].Width = (int)height;
            list.Columns[3].Width = (int)height;
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Xác nhận thanh toán toàn bộ phần dư nợ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                if(textBox1.Text == "Hóa đơn điện")
                {
                    HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
                    hoaDonDienBLL.PayAllHoaDonDien(textBox2.Text);
                }
                else
                {
                    HoaDonNuocBLL hoaDonNuocBLL = new HoaDonNuocBLL();
                    hoaDonNuocBLL.PayAllHoaDonNuoc(textBox2.Text);
                }
            }
            else
            {
                MessageBox.Show("Bạn vừa hủy thanh toán", "Thông báo");
                this.Close();   
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
