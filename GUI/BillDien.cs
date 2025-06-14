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

    public partial class BillDien : Form
    {
        private KhachHang khachHang;
        private HoaDonDienDTO hoaDonDien;
        private DateTime ngayKhoiTao;
        private static  BillDien instance;  
        public static BillDien Instance(KhachHang khachHang,HoaDonDienDTO hoaDonDien,DateTime ngayKhoiTao)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new BillDien(khachHang, hoaDonDien, ngayKhoiTao);
            }
            return instance;
        }
        
        private BillDien(KhachHang khachHang, HoaDonDienDTO hoaDonDien, DateTime ngayKhoiTao)
        {
            InitializeComponent();
            this.khachHang = khachHang;
            this.hoaDonDien = hoaDonDien;
            this.ngayKhoiTao = ngayKhoiTao;
        }

        private void Data()
        {
            reportViewerDien.LocalReport.ReportEmbeddedResource = "QuanLyHoaDon.BillHoaDonDien.rdlc";
            List<ReportParameter> list = new List<ReportParameter>()
            {
                new ReportParameter("MaKhachHang", khachHang.IDKhachHang.ToString()),
                new ReportParameter("TenKhachHang", khachHang.Ten),
                new ReportParameter("SDT", khachHang.SDT),
                new ReportParameter("Phong", hoaDonDien.SoPhong),
                new ReportParameter("Nam", hoaDonDien.Nam.ToString()),
                new ReportParameter("Thang", hoaDonDien.Thang.ToString()),
                new ReportParameter("NgayKhoiTao", ngayKhoiTao.Date.ToString("dd/MM/yyyy")),
                new ReportParameter("MaHoaDon", hoaDonDien.IDHoaDonDien.ToString()),
                new ReportParameter("SoDienCu", hoaDonDien.SoDienCu.ToString()),
                new ReportParameter("SoDienMoi", hoaDonDien.SoDienMoi.ToString()),
                new ReportParameter("SoSuDung", hoaDonDien.SoSuDung.ToString()),
                new ReportParameter("DonGia", hoaDonDien.DonGia.ToString()),
                new ReportParameter("PhiDichVu", hoaDonDien.PhiDichVu.ToString()),
                new ReportParameter("ThanhTien", hoaDonDien.ThanhTien.ToString()),
            };         

            DataTable listHD = new DataTable();
            listHD.Columns.Add("MaHoaDon", typeof(int));
            listHD.Columns.Add("SoDienCu", typeof(float));
            listHD.Columns.Add("SoDienMoi", typeof(float));
            listHD.Columns.Add("SoSuDung", typeof(float));
            listHD.Columns.Add("DonGia", typeof(float));
            listHD.Columns.Add("PhiDichVu", typeof(float));
            listHD.Columns.Add("ThanhTien", typeof(float));
            listHD.Rows.Add(hoaDonDien.IDHoaDonDien, hoaDonDien.SoDienCu, hoaDonDien.SoDienMoi, hoaDonDien.SoSuDung, hoaDonDien.DonGia, hoaDonDien.PhiDichVu, hoaDonDien.ThanhTien);
            
            reportViewerDien.LocalReport.DataSources.Add(new ReportDataSource("DataSet", listHD));
            reportViewerDien.LocalReport.SetParameters(list);
            reportViewerDien.RefreshReport();
        }

        private void BillDien_Load(object sender, EventArgs e)
        {
            if (khachHang == null || hoaDonDien == null)
            {
                MessageBox.Show("Dữ liệu chưa được khởi tạo");
                return;
            }
            reportViewerDien.LocalReport.DataSources.Clear();
            Data();
            
        }
    }
}
