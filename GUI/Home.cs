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
        {
            ChuHoBLL chuHoBLL = new ChuHoBLL();
            chuHoBLL.HienThiDanhSachChuHo(chuHoBLL.FullListChuHo(), listView1);
            this.SizeListView();
        }

        // Hàm chỉnh lại size của listview
        private void SizeListView()
        {
            int count=listView1.Columns.Count;  
            int totalWith=listView1.Width;
            int columnWith=totalWith/count;
            foreach(ColumnHeader c in listView1.Columns )
            {
                c.Width = columnWith;
            }
        }       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

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
            this.SizeListView();
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
            this.SizeListView();
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
    }
}
