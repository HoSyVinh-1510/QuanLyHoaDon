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
    }
}
