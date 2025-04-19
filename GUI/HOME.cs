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

namespace QuanLyHoaDon
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

        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild == childForm)
            {
                return;
            }
            if (currentFormChild != null) 
            {
                currentFormChild.Close();
            }
            currentFormChild = null;
            currentFormChild = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelHome.Controls.Add(childForm);
            panelHome.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void HOME_Load(object sender, EventArgs e)
        {
            time=0;
        }

        private void btnPhongAndKhachHang_Click(object sender, EventArgs e)
        {
            time = 0;
            OpenChildForm(PhongAndKhachHang.Instance);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            time = 0;
            OpenChildForm(PhongAndKhachHang.Instance);
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time < 100)
            {
                this.Enabled = false;
                prgrBarHome.Visible = true;
                prgrBarHome.Value = time;
                lbLoading.Text = "Loading: " + time.ToString() + "%";
            }
            else
            {
                this.Enabled = true;
                prgrBarHome.Visible = false;
                lbLoading.Text = null;
                lbLoading.Enabled = false;
            }
        }

        private void panelHome_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string str = "CommonAppDataPath: " + Application.CommonAppDataPath;
        //    str += "\r\n";
        //    //str += "CommonAppDataRegistry: " + Application.CommonAppDataRegistry.ToString();
        //    //str += "\r\n";
        //    str += "ExecutablePath: " + Application.ExecutablePath;
        //    str += "\r\n";
        //    str += "LocalUserAppDataPath: " + Application.LocalUserAppDataPath;
        //    str += "\r\n";
        //    str += "LocalUserAppDataPath: " + Application.StartupPath;
        //    str += "\r\n";
        //    str += "UserAppDataPath: " + Application.UserAppDataPath;

        //}
    }
}
