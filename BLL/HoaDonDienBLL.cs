﻿using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoaDon.BLL
{
    internal class HoaDonDienBLL
    {
        public HoaDonDienBLL() { }

        // Hàm trả về hóa đơn điện
        public List<HoaDonDien> AllHoaDonDien()
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            return hoaDonDienDAL.FullListHoaDonDien();
        }

        public void HienThiToanBoHoaDonDien(List<HoaDonDien> list0, ListView list1)
        {
            list1.Items.Clear();
            foreach (HoaDonDien hd in list0)
            {
                ListViewItem item = new ListViewItem(hd.Phong);
                item.SubItems.Add(hd.TenChuHo);
                item.SubItems.Add(hd.NgayLapHoaDon.ToString());
                item.SubItems.Add(hd.SoDienCu.ToString());
                item.SubItems.Add(hd.SoDienMoi.ToString());
                item.SubItems.Add(hd.ThanhTien.ToString());
                item.SubItems.Add(hd.TrangThai.ToString());

                list1.Items.Add(item);
            }
        }

        
        public void HienThiHoaDonDienTheoTrangThai(  string trangthai,ListView list1)
        {
            list1.Items.Clear();
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();

            foreach (HoaDonDien hd in hoaDonDienDAL.FindState(trangthai))
            { 
                    ListViewItem item = new ListViewItem(hd.Phong);
                    item.SubItems.Add(hd.NgayLapHoaDon.ToString());
                    item.SubItems.Add(hd.ThanhTien.ToString());
                    item.SubItems.Add(hd.TrangThai.ToString());
                    list1.Items.Add(item);         
            }
        }

        public List<HoaDonDien> FindState(string trangthai)
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            return hoaDonDienDAL.FindState(trangthai);
        }

        // Hàm trả về hóa đơn điện theo tên
        public List<HoaDonDien> Find(string phong)
        {
            HoaDonDienDAL hoaDonDienDAL= new HoaDonDienDAL();
            return hoaDonDienDAL.Find(phong);
        }

        // Hàm xóa hóa đơn điện
        public void DeleteHoaDonDien(string phong, DateTime date)
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            hoaDonDienDAL.DeleteHoaDonDien(phong, date);
            return;

        }

        // hàm cập nhật hóa đơn điện
        public void UpdateHoaDonDien(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            HoaDonDienDAL hoaDonDienDAL= new HoaDonDienDAL();
            hoaDonDienDAL.UpdateHoaDonDien(a0, a1, a2,a3, a4, a5, a6);
            return;
        }

        // Hàm thêm hóa đơn điện 
        public void AddHoaDonDien(string a0, string a1, DateTime a2, float a3, float a4, float a5, string a6)
        {
            HoaDonDienDAL hoaDonDienDAL=new HoaDonDienDAL();
            hoaDonDienDAL.AddHoaDonDien(a0,a1,a2,a3,a4,a5,a6);
            return;
        }

        // Hàm tính tiền điện chưa thanh toán
        public float TinhTien(string phong, List<HoaDonDien> list)
        {
            float tien = 0;
            foreach (HoaDonDien hd in list)
            {
                if (hd.Phong == phong)
                {
                    tien += hd.ThanhTien;
                }
            }
            return tien;
        }


        // hàm phòng sẽ bị cắt nước
        public int CountPhong(string phong)
        {
            HoaDonDienDAL hoaDonDienDAL = new HoaDonDienDAL();
            List<HoaDonDien> list = hoaDonDienDAL.FindState("Chưa thanh toán");
            int count = 0;
            foreach (HoaDonDien hd in list)
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
