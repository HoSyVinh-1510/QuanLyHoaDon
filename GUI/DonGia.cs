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
    public partial class DonGia : Form
    {
        private static DonGia instance;
        public static DonGia Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new DonGia();
                }
                return instance;
            }
        }
        private DonGia()
        {
            InitializeComponent();
        }

        private void Infor()
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row == null) return;
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            panel2.Visible = false;

        }

        private void SetUp()
        {
            dataGridView1.DataSource=DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.DonGia");
            dataGridView1.Columns["DonGiaDien"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["DonGiaNuoc"].DefaultCellStyle.Format = "N2";
            Infor();
        }

        private void DonGia_Load(object sender, EventArgs e)
        {
            SetUp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Tháng mới có thay đổi đơn giá với tháng cũ không?","Câu hỏi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                panel2.Visible = true;
            }
            else
            {
                DonGiaDAL.Instance.NewDonGiaKhongDoi();
                DonGia_Load(sender, e);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Infor();
        }
    }
}
