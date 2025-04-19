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

namespace QuanLyHoaDon.GUI
{
    public partial class HopDong : Form
    {
        private static HopDong _instance;
        public static HopDong Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new HopDong();
                }
                return _instance;
            }
        }
        private HopDong()
        {
            InitializeComponent();
        }

        private DataTable Show(DateTimePicker d1, DateTimePicker d2)
        {
            if (!d1.Checked)
            {
                if (!d2.Checked) return DataProvider.Instance.ExecuteQuery("Select * from HopDong");
                else return DataProvider.Instance.ExecuteQuery("Select * from HopDong where NgayKT <= @d2 ", new object[] { d2.Value.Date });
            }
            else
            {
                if (!d2.Checked) return DataProvider.Instance.ExecuteQuery("Select * from HopDong where NgayBD >= @d1 ", new object[] { d1.Value.Date });
                else 
                    if (d1.Value.Date > d2.Value.Date)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc");
                    return null;
                }
                else return DataProvider.Instance.ExecuteQuery("Select * from HopDong where NgayBD >= @d1 and NgayKT <= @d2", new object[] { d1.Value.Date, d2.Value.Date });
            }
        }

        private void HopDong_Load(object sender, EventArgs e)
        {
            
            dataGridViewHopDong.DataSource = Show(dateTimePicker1, dateTimePicker2);
            
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            this.Cursor= Cursors.WaitCursor;
            cbBoxPhong.DataSource=DataProvider.Instance.ExecuteQuery("Select Phong from Phong");
            cbBoxPhong.DisplayMember = "Phong";
            this.Cursor = Cursors.Default;
        }

        private void btnLocHopDong_Click(object sender, EventArgs e)
        { 
           
           DataTable dt = Show(dateTimePicker1, dateTimePicker2);
            if (cbBoxTrangThai.SelectedItem==null|| cbBoxTrangThai.SelectedItem.ToString()=="Tất Cả")
            dt.DefaultView.RowFilter = " Phong like '%" + cbBoxPhong.Text + "%'";
            else dt.DefaultView.RowFilter = " Phong like '%" + cbBoxPhong.Text + "%' and TrangThai like '%" + cbBoxTrangThai.SelectedItem.ToString() + "%'";           
        }
    }
}
