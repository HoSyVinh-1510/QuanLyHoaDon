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
           
        }


        private void NewDonGia()
        {
            int maxID = int.Parse(DataProvider.Instance.ExecuteScalar("SELECT MAX(IDDonGia) FROM DonGia").ToString());
            int thang = int.Parse(DataProvider.Instance.ExecuteScalar(" Select Thang From DonGia where IDDonGia= @a",new object[] {maxID}).ToString() );
            int nam = int.Parse(DataProvider.Instance.ExecuteScalar(" Select Nam From DonGia where IDDonGia= @a", new object[] { maxID }).ToString());
            if (thang == 12)
            {
                thang = 1;
                nam++;
            }
            else
            {
                thang++;
            }
            textBox10.Text= (maxID + 1).ToString();
            textBox8.Text = thang.ToString();
            textBox9.Text = nam.ToString();
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
            panel2.Visible = false;
            FormatTextInput.Instance.Float(textBox7);
            FormatTextInput.Instance.Float(textBox6);
            SetUp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            NewDonGia();
            if (MessageBox.Show("Tháng mới có thay đổi đơn giá với tháng cũ không?","Câu hỏi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                     textBox7.Focus();

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int k = DataProvider.Instance.ExecuteNonQuery("insert into DonGia (IDDonGia,Nam,Thang,DonGiaDien,DonGiaNuoc) values ( @a , @b , @c , @d , @e )"
                    ,new object[] {int.Parse(textBox10.Text), int.Parse(textBox9.Text), int.Parse(textBox8.Text),float.Parse(textBox7.Text), float.Parse(textBox6.Text) });
                if (k > 0)
                {
                    MessageBox.Show("Thêm đơn giá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DonGia_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm đơn giá thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:  " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            FormatTextInput.Instance.Interger(textBox12);
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            FormatTextInput.Instance.Interger(textBox11);
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Empty;
            if (!string.IsNullOrEmpty(textBox12.Text))
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("Nam = {0}", textBox12.Text);
            }
            if(!string.IsNullOrEmpty(textBox11.Text))
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("Thang = {0}", textBox11.Text);
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Empty;
            if (!string.IsNullOrEmpty(textBox12.Text))
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("Nam = {0}", textBox12.Text);
            }
            if(!string.IsNullOrEmpty(textBox11.Text))
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("Thang = {0}", textBox11.Text);
            }
        }
    }
}
