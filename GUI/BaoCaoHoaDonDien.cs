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
    public partial class BaoCaoHoaDonDien : Form
    {
        private static BaoCaoHoaDonDien instance;

        public static BaoCaoHoaDonDien Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BaoCaoHoaDonDien();
                }
                return
                    instance;
            }
        }

        private BaoCaoHoaDonDien()
        {
            InitializeComponent();
        }

        private void BaoCaoHoaDon_Load(object sender, EventArgs e)
        {
            this.reportViewerDien.RefreshReport();
        }
    }
}
