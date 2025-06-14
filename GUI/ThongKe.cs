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
using System.Windows.Forms.DataVisualization.Charting;


namespace QuanLyHoaDon.GUI
{
    public partial class ThongKe : Form
    {
        private static ThongKe instance;
        public static ThongKe Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new ThongKe();
                }
                return instance;
            }
        }

        private ThongKe()
        {
            InitializeComponent();
        }
        
        private void SetUp()
        {
            comboBox1.DataSource=DataProvider.Instance.ExecuteQuery("SELECT DISTINCT Phong FROM HoaDonDien"); 
            comboBox1.DisplayMember = "Phong";
            comboBox1.ValueMember = "Phong";
            comboBox1.SelectedIndex = -1;
            
            comboBox4.DataSource = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT Phong FROM HoaDonNuoc");
            comboBox4.DisplayMember = "Phong";
            comboBox4.ValueMember = "Phong";
            comboBox4.SelectedIndex = -1;

            comboBox2.DataSource= DataProvider.Instance.ExecuteQuery("SELECT DISTINCT Nam FROM HoaDonDien");
            comboBox2.DisplayMember = "Nam";
            comboBox2.ValueMember = "Nam";
            comboBox2.SelectedIndex = -1;

            comboBox3.DataSource = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT Nam FROM HoaDonNuoc");
            comboBox3.DisplayMember = "Nam";
            comboBox3.ValueMember = "Nam";
            comboBox3.SelectedIndex = -1;
        }

        private void VeBieuDo()
        {  

            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from HoaDonDien where Nam= @a And Phong= @b ",new object[] {comboBox2.SelectedValue.ToString(), comboBox1.SelectedValue.ToString()} );
            chart1.Series[0].LabelFormat = "F2";
            chart1.Series[1].LabelFormat = "F2";


            for (int i=0;i < dt.Rows.Count; i++)
            {
                ///int idHD,int idKH, string sp, int thang, int nam, float SDC, float SDM,float DG
                HoaDonDienDTO hd = new HoaDonDienDTO(int.Parse(dt.Rows[i]["IDHoaDonDien"].ToString()), int.Parse(dt.Rows[i]["IDKhachHang"].ToString()), dt.Rows[i]["Phong"].ToString(), Convert.ToInt32(dt.Rows[i]["Thang"].ToString()), Convert.ToInt32(dt.Rows[i]["Nam"].ToString()), float.Parse(dt.Rows[i]["SoDienCu"].ToString()), float.Parse(dt.Rows[i]["SoDienMoi"].ToString()) , float.Parse(dt.Rows[i]["DonGia"].ToString()) );
                chart1.Series[0].Points.AddXY("Thang "+(i+1).ToString(),hd.ThanhTien);
                chart1.Series[1].Points.AddXY("Thang " + (i + 1).ToString(), hd.SoSuDung);
            }   
        }

        private void VeBieuDo2()
        {

            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from HoaDonNuoc where Nam= @a And Phong= @b ", new object[] { comboBox3.SelectedValue.ToString(), comboBox4.SelectedValue.ToString() });
            chart2.Series[0].LabelFormat = "F2";
            chart2.Series[1].LabelFormat = "F2";


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ///int idHD,int idKH, string sp, int thang, int nam, float SDC, float SDM,float DG
                HoaDonNuocDTO hd = new HoaDonNuocDTO(int.Parse(dt.Rows[i]["IDHoaDonNuoc"].ToString()), int.Parse(dt.Rows[i]["IDKhachHang"].ToString()), dt.Rows[i]["Phong"].ToString(), Convert.ToInt32(dt.Rows[i]["Thang"].ToString()), 
                                   Convert.ToInt32(dt.Rows[i]["Nam"].ToString()), float.Parse(dt.Rows[i]["SoNuocCu"].ToString()), float.Parse(dt.Rows[i]["SoNuocMoi"].ToString()), float.Parse(dt.Rows[i]["DonGia"].ToString()));
                chart2.Series[0].Points.AddXY("Thang " + (i + 1).ToString(), hd.ThanhTien);
                chart2.Series[1].Points.AddXY("Thang " + (i + 1).ToString(), hd.SoSuDung);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng và năm để thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            VeBieuDo();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            SetUp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex==-1|| comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng và năm để thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }   
            VeBieuDo2();
        }
    }
}
