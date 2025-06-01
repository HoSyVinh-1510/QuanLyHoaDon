using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyHoaDon.DTO;


namespace QuanLyHoaDon.GUI
{
    public partial class BillNuoc : Form
    {
        private static HoaDonNuocDTO hoaDonNuoc;

        private static KhachHang khachHang;

        private DateTime ngayKhoiTao;   

        private static BillNuoc instance;

        public static BillNuoc Instance(KhachHang khachHang, HoaDonNuocDTO hoaDonNuoc, DateTime ngay )
        {          
                if (instance == null || instance.IsDisposed)
                {
                    instance = new BillNuoc(khachHang,hoaDonNuoc,ngay);
                }
                return instance;              
        }

        private BillNuoc(KhachHang kh,HoaDonNuocDTO hd, DateTime dt )
        {
            
            khachHang = kh;
            hoaDonNuoc = hd;
            ngayKhoiTao = dt;
            InitializeComponent();
        }
        private void Data()
        {
            reportViewerNuoc.LocalReport.DataSources.Clear();
            
            reportViewerNuoc.LocalReport.ReportEmbeddedResource = "QuanLyHoaDon.BillHoaDonNuoc.rdlc";
            List<ReportParameter> list1 = new List<ReportParameter>()
            {
                new ReportParameter("MaKhachHang", khachHang.IDKhachHang.ToString()),
                new ReportParameter("TenKhachHang", khachHang.Ten),
                new ReportParameter("SDT", khachHang.SDT),
                new ReportParameter("Phong", hoaDonNuoc.SoPhong),
                new ReportParameter("Nam", hoaDonNuoc.Nam.ToString()),
                new ReportParameter("Thang", hoaDonNuoc.Thang.ToString()),
                new ReportParameter("NgayKhoiTao", ngayKhoiTao.Date.ToString("dd/MM/yyyy")),
                new ReportParameter("MaHoaDon", hoaDonNuoc.IDHoaDonNuoc.ToString()),
                new ReportParameter("SoNuocCu", hoaDonNuoc.SoNuocCu.ToString()),
                new ReportParameter("SoNuocMoi", hoaDonNuoc.SoNuocMoi.ToString()),
                new ReportParameter("SoSuDung", hoaDonNuoc.SoSuDung.ToString()),
                new ReportParameter("DonGia", hoaDonNuoc.DonGia.ToString()),
                new ReportParameter("PhiDichVu", hoaDonNuoc.PhiDichVu.ToString()),
                new ReportParameter("ThanhTien", hoaDonNuoc.ThanhTien.ToString()),
            };

            DataTable listHD = new DataTable();
            listHD.Columns.Add("MaHoaDon", typeof(int));
            listHD.Columns.Add("SoNuocCu", typeof(float));
            listHD.Columns.Add("SoNuocMoi", typeof(float));
            listHD.Columns.Add("DonGia", typeof(float));
            listHD.Columns.Add("SoSuDung", typeof(float));   
            listHD.Columns.Add("PhiDichVu", typeof(float));
            listHD.Columns.Add("ThanhTien", typeof(float));
            listHD.Rows.Add(hoaDonNuoc.IDHoaDonNuoc, hoaDonNuoc.SoNuocCu, hoaDonNuoc.SoNuocMoi, hoaDonNuoc.DonGia, hoaDonNuoc.SoSuDung, hoaDonNuoc.PhiDichVu, hoaDonNuoc.ThanhTien);          
            
            reportViewerNuoc.LocalReport.DataSources.Add(new ReportDataSource("DataSetNuoc", listHD));
            reportViewerNuoc.LocalReport.SetParameters(list1);          
            reportViewerNuoc.RefreshReport();
        }
        private void BillNuoc_Load(object sender, EventArgs e)
        {
            if (hoaDonNuoc == null || khachHang == null || ngayKhoiTao == null)
            {
                MessageBox.Show("Dữ liệu đầu vào bị lỗi!");
                return;
            }   
                Data();
        }
    }
}
