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
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.DonGia");
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
            int thang = int.Parse(DataProvider.Instance.ExecuteScalar(" Select Thang From DonGia where IDDonGia= @a", new object[] { maxID }).ToString());
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
            textBox10.Text = (maxID + 1).ToString();
            textBox8.Text = thang.ToString();
            textBox9.Text = nam.ToString();
        }

        private void SetUp()
        {

            dataGridView1.Columns["DonGiaDien"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["DonGiaNuoc"].DefaultCellStyle.Format = "N2";
            Infor();

            comboBox1.DataSource = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT Nam FROM DonGia");
            comboBox1.DisplayMember = "Nam";
            comboBox1.ValueMember = "Nam";
            comboBox1.SelectedIndex = -1;
        }

        private void DonGia_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            FormatTextInput.Instance.Float(textBox7);
            FormatTextInput.Instance.Float(textBox6);
            SetUp();
        }

        private void VeBieuDo()
        {
            chart1.Series[0].LabelFormat = "F2";
            chart1.Series[1].LabelFormat = "F2";

            var row = comboBox1.SelectedItem as DataRowView;
            if (row == null) return;

            int nam = Convert.ToInt32(row["Nam"]);
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select DonGiaDien, DonGiaNuoc from DonGia where Nam = @a", new object[] { nam });

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chart1.Series[0].Points.AddXY("Thang " + (i + 1).ToString(), float.Parse(dt.Rows[i][0].ToString()));
                chart1.Series[1].Points.AddXY("Thang " + (i + 1).ToString(), float.Parse(dt.Rows[i][1].ToString()));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            NewDonGia();
            if (MessageBox.Show("Tháng mới có thay đổi đơn giá với tháng cũ không?", "Câu hỏi?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                    , new object[] { int.Parse(textBox10.Text), int.Parse(textBox9.Text), int.Parse(textBox8.Text), float.Parse(textBox7.Text), float.Parse(textBox6.Text) });
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
            string chuoiLoc= string.Empty;
            if (!string.IsNullOrEmpty(textBox12.Text))
            {
                chuoiLoc = $"Nam = {textBox12.Text}";
            }

            if (!string.IsNullOrEmpty(textBox11.Text))
            {
                if (!string.IsNullOrEmpty(chuoiLoc))
                {
                    chuoiLoc += " AND ";
                }
                chuoiLoc += $"Thang = {textBox11.Text}";
            }

            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = chuoiLoc;
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Empty;
            if (!string.IsNullOrEmpty(textBox12.Text))
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("Nam = {0}", textBox12.Text);
            }
            if (!string.IsNullOrEmpty(textBox11.Text))
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = string.Format("Thang = {0}", textBox11.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            if (comboBox1.SelectedIndex != -1)
            {
                VeBieuDo();
            }
           
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
