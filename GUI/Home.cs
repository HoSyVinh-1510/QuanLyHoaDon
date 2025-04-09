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
            HoaDonNuocBLL hoaDonNuocBLL = new HoaDonNuocBLL();
            hoaDonNuocBLL.HienThiToanBoHoaDonNuoc(hoaDonNuocBLL.AllHoaDonNuoc(),listView3);
                this.SizeListView(listView3);
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
            chuHoBLL.HienThiDanhSachChuHo(chuHoBLL.FullListChuHo(),listView1);
            this.SizeListView(listView1);
            return;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            ChuHoBLL chbll=new ChuHoBLL();
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show(" Hãy chọn phòng để tìm kiếm! ");
                return;
            }
            chbll.DeleteChuHo(comboBox1.SelectedItem.ToString());            
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
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn phòng!");return;
            }
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            chuHoBLL.HienThiDanhSachChuHo(chuHoBLL.FindForNameChuHo(comboBox1.SelectedItem.ToString()) , listView1);

        }

        private void button5_Click(object sender, EventArgs e)
        {
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

        //hàm thêm
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null || comboBox2.Text == null ||comboBox3.Text==null )
            {
                MessageBox.Show("Không được để trống thông tin"); return;
            }                   
            HoaDonDien hoaDonDien = new HoaDonDien(comboBox2.Text, textBox4.Text, DateTime.Parse(textBox3.Text),float.Parse( textBox2.Text), float.Parse(textBox1.Text), comboBox3.Text);
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            hoaDonDienDAL.AddHoaDonDien(hoaDonDien.Phong, hoaDonDien.TenChuHo, hoaDonDien.NgayLapHoaDon, hoaDonDien.SoDienCu, hoaDonDien.SoDienMoi, hoaDonDien.ThanhTien, hoaDonDien.TrangThai);
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            hoaDonDienBLL.HienThiToanBoHoaDonDien(hoaDonDienBLL.AllHoaDonDien(),listView2);
            return;
        }

        // Hàm hiển thị comboBox Phòng
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

        // Button showfullagain
        private void button6_Click(object sender, EventArgs e)
        {
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            hoaDonDienBLL.HienThiToanBoHoaDonDien(hoaDonDienBLL.AllHoaDonDien(),listView2);
            return;
        }
     
        // Hàm hiên thị tên chủ phòng theo lựa chọn của comboBox
        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text==null)
            {
                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("Chọn phòng để hiển thị");
                    return;
                }
                else comboBox2.Text = comboBox2.SelectedItem.ToString();
            }
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text.Equals(comboBox2.Text)) textBox4.Text = item.SubItems[1].Text;               
            }
            return;
        }
       
        // Hàm hiên thị phòng theo lựa chọn của comboBox
        private void comboBox4_Click_1(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            foreach (ListViewItem item in listView1.Items)
            {
                comboBox4.Items.Add(item.SubItems[0].Text);
            }
            return;
        }
        private void comboBox6_Click(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            foreach (ListViewItem item in listView1.Items)
            {
                comboBox6.Items.Add(item.SubItems[0].Text);
            }
            return;
        }
        // Hàm sửa hóa đơn điện
        private void button9_Click(object sender, EventArgs e)
        {         
            HoaDonDien hoaDonDien = new HoaDonDien(comboBox2.Text, textBox4.Text, DateTime.Parse(textBox3.Text), float.Parse(textBox2.Text), float.Parse(textBox1.Text), comboBox3.Text);
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            hoaDonDienDAL.UpdateHoaDonDien(hoaDonDien.Phong, hoaDonDien.TenChuHo, hoaDonDien.NgayLapHoaDon, hoaDonDien.SoDienCu, hoaDonDien.SoDienMoi, hoaDonDien.ThanhTien, hoaDonDien.TrangThai);
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            hoaDonDienBLL.HienThiToanBoHoaDonDien(hoaDonDienBLL.AllHoaDonDien(), listView2);           
            return;
        }

        // Ấn 2 lần vào list 2 để lấy thông tin
        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem item = listView2.SelectedItems[0];
                comboBox2.Text = item.SubItems[0].Text;               
                textBox3.Text = item.SubItems[2].Text;
                textBox2.Text= item.SubItems[3].Text;
                textBox1.Text = item.SubItems[4].Text;
                comboBox3.Text = item.SubItems[6].Text;               
                textBox4.Text = item.SubItems[1].Text;
                comboBox4.Text = item.SubItems[0].Text;
                textBox6.Text = item.SubItems[2].Text;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        // hàm xóa
        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == null || textBox6.Text == null)
            {
                if (comboBox4.SelectedItem == null)
                {
                    MessageBox.Show("Chọn phòng để hiển thị");
                    return;
                }
                else comboBox4.Text=comboBox4.SelectedItem.ToString();
            }
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            hoaDonDienBLL.DeleteHoaDonDien(comboBox4.Text, DateTime.Parse(textBox6.Text));  
            hoaDonDienBLL.HienThiToanBoHoaDonDien(hoaDonDienBLL.AllHoaDonDien(),listView2);
            return;
        }

        // Button Xóa bộ lọc tìm kiếm
        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            comboBox4.Text = null; comboBox4.SelectedItem = null;
            textBox6.Text = null;
            comboBox2.Text = null; comboBox2.SelectedItem = null;
            comboBox3.Text = null; comboBox3.SelectedItem = null;
        }

        // Hàm tìm kiếm
        private void button7_Click(object sender, EventArgs e)
        {
            
            if (comboBox4.Text==null)
            {
                if (comboBox4.SelectedItem == null)
                {
                    MessageBox.Show("Chọn phòng để Tìm Kiếm");
                    return;
                }
                else comboBox4.Text=comboBox4.SelectedItem.ToString();
            }
            HoaDonDienBLL hoaDonDienBLL=new HoaDonDienBLL();
            hoaDonDienBLL.HienThiToanBoHoaDonDien(hoaDonDienBLL.Find(comboBox4.Text),listView2);
            return ;
        }

        // Hàm hiển thị trạng thái của thanh toán
        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn phân loại!");
                 return;
            }
        
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            hoaDonDienBLL.HienThiHoaDonDienTheoTrangThai(comboBox5.SelectedItem.ToString(), listView4);
            this.SizeListView(listView4);
            return;
        }

        // Tính tiền Điện
        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn phân loại!");
                ; return;
            }
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            hoaDonDienBLL.HienThiHoaDonDienTheoTrangThai(comboBox5.SelectedItem.ToString(), listView4);
            this.SizeListView(listView4);
            if (comboBox6.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn phòng!");
                return;
            }
            textBox5.Text = hoaDonDienBLL.TinhTien(comboBox6.SelectedItem.ToString(), hoaDonDienBLL.FindState(comboBox5.SelectedItem.ToString())).ToString();

            return;
        }
        // Hàm hiển thị những hộ có thể bị dừng dịch vụ
        private void comboBox10_Click(object sender, EventArgs e)
        {
          
            comboBox10.Items.Clear();
            HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
            foreach (ListViewItem item in listView1.Items)
            {             
                    if (hoaDonDienBLL.CountPhong(item.SubItems[0].Text)>=2)
                    comboBox10.Items.Add(item.SubItems[0].Text);

            }
        }


        // HÓA ĐƠN NƯỚC
        // HÓA ĐƠN NƯỚC

        // Hàm thêm
        private void button17_Click(object sender, EventArgs e)
        {
            if (textBoxchuHo.Text==null || textBoxNgayLap.Text == null || textBoxSoCu.Text == null || textBoxSoMoi.Text == null || comboBoxPhong.Text == null ||comboBoxState.Text==null )
            {
                MessageBox.Show("Không được để trống thông tin");
                if (comboBoxPhong.SelectedItem == null)
                {
                    MessageBox.Show("Chọn phòng để hiển thị");
                    return;
                }
                else comboBoxPhong.Text = comboBoxPhong.SelectedItem.ToString();
                if (comboBoxState.SelectedItem == null)
                {
                    MessageBox.Show("Chọn trạng thái để hiển thị");
                    return;
                }
                else comboBoxState.Text = comboBoxState.SelectedItem.ToString();
            }                   
            HoaDonNuoc hoaDonNuoc = new HoaDonNuoc(comboBoxPhong.Text, textBoxchuHo.Text, DateTime.Parse(textBoxNgayLap.Text),float.Parse( textBoxSoCu.Text), float.Parse(textBoxSoMoi.Text), comboBoxState.Text);
            HoaDonNuocDAL hoaDonNuocDAL = new HoaDonNuocDAL();
            hoaDonNuocDAL.AddHoaDonNuoc(hoaDonNuoc.Phong, hoaDonNuoc.TenChuHo, hoaDonNuoc.NgayLapHoaDon, hoaDonNuoc.SoNuocCu, hoaDonNuoc.SoNuocMoi, hoaDonNuoc.ThanhTien, hoaDonNuoc.TrangThai);
            HoaDonNuocBLL hoaDonNuocBLL = new HoaDonNuocBLL();
            hoaDonNuocBLL.HienThiToanBoHoaDonNuoc(hoaDonNuocBLL.AllHoaDonNuoc(),listView3);
            return;
        }

        // Hàm sửa hóa đơn nước
        private void button16_Click(object sender, EventArgs e)
        {
            HoaDonNuoc hoaDonNuoc = new HoaDonNuoc(comboBoxPhong.Text, textBoxchuHo.Text, DateTime.Parse(textBoxNgayLap.Text), float.Parse(textBoxSoCu.Text), float.Parse(textBoxSoMoi.Text), comboBoxState.Text);
            HoaDonNuocDAL hoaDonNuocDAL = new HoaDonNuocDAL();
            hoaDonNuocDAL.UpdateHoaDonNuoc(hoaDonNuoc.Phong, hoaDonNuoc.TenChuHo, hoaDonNuoc.NgayLapHoaDon, hoaDonNuoc.SoNuocCu, hoaDonNuoc.SoNuocMoi, hoaDonNuoc.ThanhTien, hoaDonNuoc.TrangThai);
            HoaDonNuocBLL hoaDonNuocBLL = new HoaDonNuocBLL();
            hoaDonNuocBLL.HienThiToanBoHoaDonNuoc(hoaDonNuocBLL.AllHoaDonNuoc(), listView3);
            return;
        }


        // Hàm xóa hóa đơn nước
        private void button15_Click(object sender, EventArgs e)
        {
            HoaDonNuocBLL hoaDonNuocBLL = new HoaDonNuocBLL();
            hoaDonNuocBLL.DeleteHoaDonNuoc(comboBoxPhong1.Text, DateTime.Parse(textBoxNgayLap1.Text));
            hoaDonNuocBLL.HienThiToanBoHoaDonNuoc(hoaDonNuocBLL.AllHoaDonNuoc(), listView3);
            return;
        }

        // Hàm tìm kiếm hóa đơn nước
        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBoxPhong1.Text == null)
            {
                if (comboBoxPhong1.SelectedItem == null)
                { MessageBox.Show("Chọn phòng để hiển thị"); return; }
                else comboBoxPhong1.Text = comboBoxPhong1.SelectedItem.ToString();
            }
            HoaDonNuocBLL hoaDonNuocBLL = new HoaDonNuocBLL();
            hoaDonNuocBLL.HienThiToanBoHoaDonNuoc(hoaDonNuocBLL.Find(comboBoxPhong1.Text), listView3);
            return;
        }


        // hàm show lại listview3
        private void button13_Click(object sender, EventArgs e)
        {
            HoaDonNuocBLL hoaDonNuocBLL = new HoaDonNuocBLL();
            hoaDonNuocBLL.HienThiToanBoHoaDonNuoc(hoaDonNuocBLL.AllHoaDonNuoc(),listView3);
            return;
        }

        // hàm xóa bộ lọc tìm kiếm
        private void button12_Click(object sender, EventArgs e)
        {
            textBoxchuHo.Text = null;
            textBoxSoCu.Text = null;
            textBoxSoMoi.Text = null;
            textBoxNgayLap.Text = null; 
            textBoxNgayLap1.Text = null;
            comboBoxState.Text = null; comboBoxState.SelectedItem = null;
            comboBoxPhong.Text = null; comboBoxPhong.SelectedItem = null;
            comboBoxPhong1.Text = null; comboBoxPhong1.SelectedItem = null;
        }

        // Ấn vào comboBox hiện ra số phòng
        private void comboBoxPhong1_Click(object sender, EventArgs e)
        {
            comboBoxPhong1.Items.Clear();
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            foreach (ListViewItem item in listView1.Items)
            {
                comboBoxPhong1.Items.Add(item.SubItems[0].Text);
            }
            return;
        }
        // Ấn vào comboBox hiện ra số phòng
        private void comboBoxPhong_Click(object sender, EventArgs e)
        {
            comboBoxPhong.Items.Clear();
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            foreach (ListViewItem item in listView1.Items)
            {
                comboBoxPhong.Items.Add(item.SubItems[0].Text);
            }
            return;
        }
       
        // hàm lấy thông tin từ double click from listview HoaDonNuoc
        private void listView3_DoubleClick(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                ListViewItem item = listView3.SelectedItems[0];
                comboBoxPhong.Text = item.SubItems[0].Text;
                textBoxNgayLap.Text = item.SubItems[2].Text;
                textBoxSoCu.Text = item.SubItems[3].Text;
                textBoxSoMoi.Text = item.SubItems[4].Text;
                comboBoxState.Text = item.SubItems[6].Text;
                textBoxchuHo.Text = item.SubItems[1].Text;
                comboBoxPhong1.Text = item.SubItems[0].Text;
                textBoxNgayLap1.Text = item.SubItems[2].Text;
            }
        }
       

        // hàm lấy ra tên của chủ phòng từ combobox
        private void comboBoxPhong_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxPhong.Text == null)
            {
                if (comboBoxPhong.SelectedItem == null)
                {
                    MessageBox.Show("Chọn phòng để hiển thị");
                    return;
                }
                else comboBoxPhong.Text = comboBoxPhong.SelectedItem.ToString();
            }
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[0].Text.Equals(comboBoxPhong.Text)) { textBoxchuHo.Text = item.SubItems[1].Text; return; }
            }
        }

        private void comboBox7_Click(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            foreach (ListViewItem item in listView1.Items)
            {
                comboBox7.Items.Add(item.SubItems[0].Text);
            }
            return;
        }


        // Hàm thanh toán
        private void button20_Click(object sender, EventArgs e)
        {
            if (comboBox8.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn phân loại!");
                return;
            }

            HoaDonNuocBLL hoaDonNuocBLL = new HoaDonNuocBLL();
            hoaDonNuocBLL.HienThiHoaDonNuocTheoTrangThai(comboBox8.SelectedItem.ToString(), listView5);
            if (comboBox7.SelectedItem == null) return;
             textBox7.Text = hoaDonNuocBLL.TinhTien(comboBox7.SelectedItem.ToString(), hoaDonNuocBLL.FindState(comboBox8.SelectedItem.ToString())).ToString();
            this.SizeListView(listView4);
            return;
        }
        // hàm tìm kiếm trạng thái thanh toán
        private void button21_Click(object sender, EventArgs e)
        {
            if (comboBox8.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn phân loại!");
                return;
            }

            HoaDonNuocBLL hoaDonNuocBLL = new HoaDonNuocBLL();
            hoaDonNuocBLL.HienThiHoaDonNuocTheoTrangThai(comboBox8.SelectedItem.ToString(), listView5);
            this.SizeListView(listView4);
            return;
        }
        private void comboBox9_Click_1(object sender, EventArgs e)
        {
            comboBox9.Items.Clear();
            foreach (ListViewItem item in listView1.Items)
            {
                comboBox9.Items.Add(item.SubItems[0].Text);
            }
            HoaDonNuocBLL hoaDonNuocBLL = new HoaDonNuocBLL();
            for (int i = 1; i <= comboBox9.Items.Count; i++)
            {
                if (hoaDonNuocBLL.CountPhong(comboBox9.Items[i].ToString()) < 2)
                    comboBox9.Items.RemoveAt(i);
            }
        }

        private void button22_Click_1(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            if( comboBox10.SelectedItem != null)
            {
                ChuHoBLL chuHoBLL = new ChuHoBLL();
                ChuHo ch=chuHoBLL.FindChuHo(comboBox10.SelectedItem.ToString());
                HoaDonDienBLL hoaDonDienBLL = new HoaDonDienBLL();
                ThanhToan tt= new ThanhToan(ch, hoaDonDienBLL.FindState("Chưa thanh toán"));
                this.Hide();
                tt.ShowDialog();
                this.Show();
            }
        }
    }
}
