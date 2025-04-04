﻿using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoaDon.BLL
{
    internal class HoaDonNuocBLL
    {
        public HoaDonNuocBLL() { }

        // Hàm trả về hóa đơn nước
        public List<HoaDonNuoc> AllHoaDonNuoc()
        {
            HoaDonNuocDAL hoaDonNuocDAL = new HoaDonNuocDAL();
            return hoaDonNuocDAL.FullListHoaDonNuoc();
        }

        public void HienThiToanBoHoaDonNuoc(List<HoaDonNuoc> list0, ListView list1)
        {   
            list1.Items.Clear();
            foreach (HoaDonNuoc hd in list0)
            {
                ListViewItem item = new ListViewItem(hd.Phong);
                item.SubItems.Add(hd.TenChuHo);
                item.SubItems.Add(hd.NgayLapHoaDon.ToString());
                item.SubItems.Add(hd.SoNuocCu.ToString());
                item.SubItems.Add(hd.SoNuocMoi.ToString());
                item.SubItems.Add(hd.ThanhTien.ToString());
                item.SubItems.Add(hd.TrangThai.ToString());

                list1.Items.Add(item);
            }
        }

        // Hàm trả về hóa đơn nước theo tên, và ngày lập hóa đơn
        public List<HoaDonNuoc> Find(string phong)
        {
            HoaDonNuocDAL hoaDonDienDAL = new HoaDonNuocDAL();
            return hoaDonDienDAL.Find(phong);
        }
        public List<HoaDonNuoc> FindState(string trangthai)
        {
            HoaDonNuocDAL hoaDonDienDAL = new HoaDonNuocDAL();
            return hoaDonDienDAL.FindState(trangthai);
        }
        public void HienThiHoaDonNuocTheoTrangThai(string trangthai, ListView list1)
        {
            list1.Items.Clear();
            HoaDonNuocDAL hoaDonNuocDAL = new HoaDonNuocDAL();

            foreach (HoaDonNuoc hd in hoaDonNuocDAL.FindState(trangthai))
            {
                ListViewItem item = new ListViewItem(hd.Phong);
                item.SubItems.Add(hd.NgayLapHoaDon.ToString());
                item.SubItems.Add(hd.ThanhTien.ToString());
                item.SubItems.Add(hd.TrangThai.ToString());
                list1.Items.Add(item);
            }
        }




        // Hàm xóa hóa đơn nước
        public void DeleteHoaDonNuoc(string phong, DateTime date)
        {
            HoaDonNuocDAL hoaDonDienDAL = new HoaDonNuocDAL();
            hoaDonDienDAL.DeleteHoaDonNuoc(phong, date);
            return;

        }

        // hàm cập nhật hóa đơn nước
        public void UpdateHoaDonNuoc(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            HoaDonNuocDAL hoaDonDienDAL = new HoaDonNuocDAL();
            hoaDonDienDAL.UpdateHoaDonNuoc(a0, a1, a2, a3, a4, a5, a6);
            return;
        }

        // Hàm thêm hóa đơn nước
        public void AddHoaDonNuoc(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            HoaDonNuocDAL hoaDonDienDAL = new HoaDonNuocDAL();
            hoaDonDienDAL.AddHoaDonNuoc(a0, a1, a2, a3, a4, a5, a6);
            return;
        }
        // Tính tiền
        public float TinhTien(string phong, List<HoaDonNuoc> list)
        {
            float tien = 0;
            foreach (HoaDonNuoc hd in list)
            {
                if (hd.Phong == phong)
                {
                    tien += hd.ThanhTien;
                }
            }
            return tien;
        }

         // Đếm phòng
         public int CountPhong(string phong)
        {
            HoaDonNuocDAL hoaDonNuocDAL = new HoaDonNuocDAL();
            List<HoaDonNuoc> list= hoaDonNuocDAL.FindState("Chưa thanh toán");
            int count = 0;
            foreach (HoaDonNuoc hd in list)
            {
                if (hd.Phong == phong)
                {
                    count++;
                }
            }         
           return count;
        }
    }
}
