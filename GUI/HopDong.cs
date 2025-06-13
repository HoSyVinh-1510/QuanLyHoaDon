using DevExpress.Accessibility;
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
    public partial class HopDong : Form
    {
        private static HopDong instance;

        public static HopDong Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HopDong();
                }
                return
                    instance;
            }
        }

         private DataTable dt= DataProvider.Instance.ExecuteQuery("Select HopDong.IDHopDong,KhachHang.IDKhachHang,HopDong.Phong,HopDong.NgayBD,HopDong.NgayKT,KhachHang.Ten," +
            "KhachHang.SDT from HopDong,KhachHang where HopDong.IDHopDong=KhachHang.IDKhachHang ");
        private HopDong()
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
        }

        public void SetUp()
        {
            dataGridView1.Columns["NgayBD"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["NgayKT"].DefaultCellStyle.Format = "dd/MM/yyyy";
            infor();

            cB1.DataSource = DataProvider.Instance.ExecuteQuery("Select IDKhachHang from KhachHang");
            cB1.DisplayMember = "IDKhachHang";
            cB1.ValueMember = "IDKhachHang";
            cB2.DataSource=DataProvider.Instance.ExecuteQuery("Select distinct Phong from Phong");
            cB2.DisplayMember = "Phong";
            cB2.ValueMember = "Phong";
            dT1.Value = DateTime.Now;
            dT1.Checked = true;
            dT2.Checked = false;
        }

        private void infor()
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row == null) return;
            txtHD.Text = row.Cells[0].Value.ToString();
            txtKH.Text = row.Cells[1].Value.ToString();
            txtPhong.Text = row.Cells[2].Value.ToString();
            txtNgayBD.Text = DateTime.Parse(row.Cells[3].Value.ToString()).Date.ToString("dd/MM/yyyy");
            if (row.Cells[4].Value.ToString() == "") txtNgayKT.Text = "";
            else txtNgayKT.Text = DateTime.Parse(row.Cells[4].Value.ToString()).Date.ToString("dd/MM/yyyy");
            txtTenKH.Text = DataProvider.Instance.ExecuteScalar(" Select Ten from KhachHang where IDKhachHang= @a ", new object[] { int.Parse(txtHD.Text) }).ToString();
            txtSDT.Text = DataProvider.Instance.ExecuteScalar(" Select SDT from KhachHang where IDKhachHang= @a ", new object[] { int.Parse(txtHD.Text) }).ToString();

        }
        public void HopDong_Load(object sender, EventArgs e)
        {
            pn2.Visible = false;       
            SetUp();
        }

        private bool Check()
        {
            if (cB1.SelectedValue == null)
            {
                MessageBox.Show("Bạn hãy chọn ID Khách Hàng:");
                cB1.Focus();
                return false;
            }
            else if (cB2.SelectedValue == null)
            {
                MessageBox.Show("Bạn hãy chọn Phòng:");
                cB2.Focus();
                return false;
            }
            else if (dT1.Checked == false)
            {
                MessageBox.Show("Bạn hãy chọn Ngày Bắt Đầu:");
                dT1.Focus();
                return false;
            }
            if (dT1.Checked == true && dT1.Value >= dT2.Value)
            {
                MessageBox.Show("Ngày Kết Thúc phải lớn hơn Ngày Bắt Đầu:");
                dT2.Focus();
                return false;
            }
             
            string phong = cB2.SelectedValue.ToString();

            if (dT2.Checked == false)
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery(" Select * from HopDong  where Phong= @a and NgayKT IS NULL ", new object[] { cB2.SelectedValue.ToString() });
                if (dt.Rows.Count > 0) return false;
                dt = DataProvider.Instance.ExecuteQuery("Select * from HopDong  where Phong= @a and NgayKT> @b ", new object[] { cB2.SelectedValue.ToString(), dT1.Value.Date });
                if (dt.Rows.Count > 0) return false;
                else return true;
            }
            else
            {                
                    DataTable dt1= DataProvider.Instance.ExecuteQuery("Select * from HopDong  where Phong= @a and NgayKT IS NULL and NgayBD< @b ", new object[] { phong, dT2.Value.Date });                             
                    DataTable dt2= DataProvider.Instance.ExecuteQuery("Select * from HopDong  where Phong= @a and  NgayKT> @d1 and NgayBD< @d2 ", new object[] { phong, dT1.Value.Date,dT2.Value.Date });
                    if (dt1.Rows.Count+dt2.Rows.Count > 0) return false;
                    else return true;                
            }  
            
        }

        private bool KtraHopDongCoTheThayDoi(int idHD)
        {
            DataRow row= DataProvider.Instance.ExecuteQuery("Select * from HopDong where IDHopDong= @a ",new object[] { idHD }).Rows[0];
            if (DateTime.Parse(row["NgayBD"].ToString()) > DateTime.Now.Date )
            {
                return true;
            }
            if (row["NgayKT"]==null || row["NgayKT"]==DBNull.Value)
                return true;
            DateTime dt= DateTime.Parse(row["NgayKT"].ToString());
            return dt>DateTime.Now.Date;           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HOME.Instance.OpenChildForm(PhongVaKhachHang.Instance);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            infor();
        }

        private void cB1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtTenKH1.Text = DataProvider.Instance.ExecuteScalar("Select Ten from KhachHang where IDKhachHang= @a ", new object[] { int.Parse(cB1.SelectedValue.ToString()) }).ToString();
            txtSDT1.Text = DataProvider.Instance.ExecuteScalar("Select SDT from KhachHang where IDKhachHang= @a ", new object[] { int.Parse(cB1.SelectedValue.ToString()) }).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn thay đổi dịch vụ?", "Question?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (KtraHopDongCoTheThayDoi(int.Parse(txtHD.Text)))
                {
                    ThayDoiHopDong.Instance(int.Parse(txtHD.Text)).ShowDialog();
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            pn2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Check())
            {
                MessageBox.Show("Bạn nhập sai thông tin đầu vào hoặc hợp đồng bị trùng ngày! ", "Thông báo LỖI");
                return;
            }
            else
            {
                if (dT2.Checked == true)
                    HopDongDAL.Instance.ThemHopDong(int.Parse(txtHD1.Text), int.Parse(cB1.SelectedValue.ToString()), cB2.SelectedValue.ToString(), dT1.Value.Date, dT2.Value.Date);
                else HopDongDAL.Instance.ThemHopDong(int.Parse(txtHD1.Text), int.Parse(cB1.SelectedValue.ToString()), cB2.SelectedValue.ToString(), dT1.Value.Date, null);
            }
        }

        // hàm cho người dùng tìm tên khách hàng.
        private void timTenKH_Enter(object sender, EventArgs e)
        {
            FormatTextInput.Instance.InputTextBox(timTenKH);
            
        }

        private void timTenKH_Leave(object sender, EventArgs e)
        {
            if (timTenKH.Text == "" && timTenKH.Text == null)
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter=string.Empty;
            }
            else
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("Ten LIKE '%{0}%'", timTenKH.Text);
            }
        }
    }
}
