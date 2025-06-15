using QuanLyHoaDon.GUI;
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
     
    public partial class HOME : Form
    {
        private static HOME instance;
        private int time = 0;
        public static HOME Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HOME();
                }
                return instance;
            }
        }
        private HOME()
        {
            InitializeComponent();
        }

        public Form currentFormChild;
        public void OpenChildForm(Form childForm)
        {
            if (currentFormChild == childForm)
            {
                return; // đang mở rồi
            }

            if (currentFormChild != null)
            {
                currentFormChild.Hide();  // ẩn form cũ thay vì đóng
            }

            currentFormChild = childForm;

            if (!panelHome.Controls.Contains(childForm))
            {
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelHome.Controls.Add(childForm);
                panelHome.Tag = childForm;
            }

            childForm.BringToFront();
            childForm.Show();
        }


        private void HOME_Load(object sender, EventArgs e)
        {
            time=0;
            timer2.Interval = 1000; // 100 milliseconds
            timer2.Start();
        }

        private void btnPhongAndKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(PhongVaKhachHang.Instance);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(HopDong.Instance);
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time < 100)
            {
                this.Enabled = false;
                prgrBarHome.Visible = true;
                prgrBarHome.Value = time;
            }
            else
            {
                this.Enabled = true;
                prgrBarHome.Visible = false;
 
            }
        }

        private void btnHoaDonDien_Click(object sender, EventArgs e)
        {
            OpenChildForm(HoaDonDien.Instance);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(HoaDonNuoc.Instance);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(LichSuThanhToan.Instance);
        }

        private void btnSoDienNuoc_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(BangSoDienNuoc.Instance);
        }

        private void btnDonGia_Click(object sender, EventArgs e)
        {
            OpenChildForm(DonGia.Instance);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(ThongKe.Instance);    
        }
    }
}
