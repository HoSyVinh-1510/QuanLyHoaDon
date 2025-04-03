using QuanLyHoaDon.BLL;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {   //Tab thông tin chủ hộ
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            chuHoBLL.HienThiDanhSachChuHo(chuHoBLL.FullListChuHo(), listView1);
            this.SizeListView(listView1);
            // Tab Hóa đơn điện
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            hoaDonDienBLL.HienThiToanBoHoaDonDien(hoaDonDienBLL.AllHoaDonDien(), listView2);
            this.SizeListView(listView2);
        }

        // Hàm chỉnh lại size của listview
        private void SizeListView(ListView l)
        {
            int count=l.Columns.Count;  
            int totalWith=l.Width;
            int columnWith=totalWith/ count;
            foreach (ColumnHeader c in l.Columns)
            {
                c.Width = columnWith;
            }
            return;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // THÔNG TIN CHỦ HỘ TAB
        // THÔNG TIN CHỦ HỘ TAB

        private void button1_Click(object sender, EventArgs e)
        {
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            DateTime date;
            if (tBoxID.Text == null || tBoxName.Text == null || tBoxDate.Text == null || tBoxSex.Text == null || SDT.Text == null) 
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!"); return;
            }

            if (!DateTime.TryParse(tBoxDate.Text, out date))
            { MessageBox.Show("Định dạng ngày tháng dd/mm/yyyy!"); return; }

            chuHoBLL.AddChuHo(tBoxID.Text, tBoxName.Text, date, tBoxSex.Text, SDT.Text);
            listView1.Items.Clear();    
            chuHoBLL.HienThiDanhSachChuHo(chuHoBLL.FullListChuHo(), listView1);
            this.SizeListView(listView1);
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tBoxID.Text == null || tBoxName.Text == null || tBoxDate.Text == null || tBoxSex.Text == null || SDT.Text == null)
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin!"); return;
            }
            ChuHoBLL chuHoBLL=new ChuHoBLL();
            DateTime date;
            if(!DateTime.TryParse(tBoxDate.Text,out date))
            {
                MessageBox.Show("Định dạng ngày tháng dd/mm/yyyy!");return;
            }
            chuHoBLL.UpdateChuHo(tBoxID.Text,tBoxName.Text,date, tBoxSex.Text,SDT.Text);
            listView1.Items.Clear();
            chuHoBLL.HienThiDanhSachChuHo(chuHoBLL.FullListChuHo(),listView1);
            this.SizeListView(listView1);
            return;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            ChuHoBLL chbll=new ChuHoBLL();
            chbll.DeleteChuHo(comboBox1.SelectedItem.ToString());
            listView1.Items.Clear();
            chbll.HienThiDanhSachChuHo(chbll.FullListChuHo(), listView1);
            return;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            ChuHoBLL chuHoBLL=new ChuHoBLL();
            foreach (ListViewItem item in listView1.Items)
            {
                comboBox1.Items.Add(item.SubItems[0].Text);
            }
            return;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            string id=comboBox1.SelectedItem.ToString();
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            listView1.Items.Clear();
            chuHoBLL.HienThiDanhSachChuHo(chuHoBLL.FindForNameChuHo(id) , listView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            chuHoBLL.HienThiDanhSachChuHo(chuHoBLL.FullListChuHo(),listView1);
        }

        private void thôngTinĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            this.Hide();
            account.ShowDialog();
            this.Show();
        }

        private void sửaTàiKhoảnĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            this.Hide();
            account.ShowDialog();
            this.Show();
        }

        //HÓA ĐƠN ĐIỆN
        //HÓA ĐƠN ĐIỆN


        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null || comboBox2.SelectedItem == null ||comboBox3.SelectedItem==null )
            {
                MessageBox.Show("Không được để trống thông tin"); return;
            }                   
            HoaDonDien hoaDonDien = new HoaDonDien(comboBox2.SelectedItem.ToString(), textBox4.Text, DateTime.Parse(textBox3.Text),float.Parse( textBox2.Text), float.Parse(textBox1.Text), comboBox3.SelectedItem.ToString());
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            hoaDonDienDAL.AddHoaDonDien(hoaDonDien.Phong, hoaDonDien.TenChuHo, hoaDonDien.NgayLapHoaDon, hoaDonDien.SoDienCu, hoaDonDien.SoDienMoi, hoaDonDien.ThanhTien, hoaDonDien.TrangThai);
            listView2.Items.Clear();
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            hoaDonDienBLL.HienThiToanBoHoaDonDien(hoaDonDienBLL.AllHoaDonDien(),listView2);
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            return;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            foreach (ListViewItem item in listView1.Items)
            {
                comboBox2.Items.Add(item.SubItems[0].Text);
            }
            return;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if (comboBox2.SelectedItem == null) return;
            foreach (ListViewItem item in listView1.Items)
            {             
                if ( item.SubItems[0].Text == comboBox2.SelectedItem.ToString())
                { textBox4.Text = item.SubItems[1].Text; break;  }
                return;
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear ();
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            hoaDonDienBLL.HienThiToanBoHoaDonDien(hoaDonDienBLL.AllHoaDonDien(),listView2);
            return;
        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
        }

        private void listView2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            MessageBox.Show("thuộc tính check của item!");
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1) return;
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text.Equals(comboBox2.SelectedItem.ToString())) { textBox4.Text = item.SubItems[1].Text; return; }
            }
        }

        // Sửa bằng double click vào row trong listview
        private void button9_Click(object sender, EventArgs e)
        {         
            HoaDonDien hoaDonDien = new HoaDonDien(comboBox2.SelectedItem.ToString(), textBox4.Text, DateTime.Parse(textBox3.Text), float.Parse(textBox2.Text), float.Parse(textBox1.Text), comboBox3.SelectedItem.ToString());
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            hoaDonDienDAL.UpdateHoaDonDien(hoaDonDien.Phong, hoaDonDien.TenChuHo, hoaDonDien.NgayLapHoaDon, hoaDonDien.SoDienCu, hoaDonDien.SoDienMoi, hoaDonDien.ThanhTien, hoaDonDien.TrangThai);
            listView2.Items.Clear();
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            hoaDonDienBLL.HienThiToanBoHoaDonDien(hoaDonDienBLL.AllHoaDonDien(), listView2);           
            return;
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem item = listView2.SelectedItems[0];
                comboBox2.SelectedItem = item.SubItems[0].Text;               
                textBox3.Text = item.SubItems[2].Text;
                textBox2.Text= item.SubItems[3].Text;
                textBox1.Text = item.SubItems[4].Text;
                comboBox3.SelectedItem = item.SubItems[6].Text;

                textBox5.Text = item.SubItems[0].Text;
                textBox6.Text = item.SubItems[2].Text;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            hoaDonDienBLL.DeleteHoaDonDien(textBox5.Text,DateTime.Parse(textBox6.Text));
            listView2.Items.Clear();    
            hoaDonDienBLL.HienThiToanBoHoaDonDien(hoaDonDienBLL.AllHoaDonDien(),listView2);
            return;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;

        }
    }
}
