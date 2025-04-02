﻿using QuanLyHoaDon.DAL;
using QuanLyHoaDon.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHoaDon.BLL
{
    internal class ChuHoBLL
    {
        public ChuHoBLL() { }

        public void HienThiDanhSachChuHo(List<ChuHo> list, ListView listView1)
        {

            foreach (ChuHo ch in list)
            {
                ListViewItem item = new ListViewItem(ch.MaChuHo);
                item.SubItems.Add(ch.TenChuHo);
                item.SubItems.Add(ch.NgaySinh.ToString());
                item.SubItems.Add(ch.GioiTinh);
                item.SubItems.Add(ch.SDT);
                listView1.Items.Add(item);
            }
            return;
        }

        public void HideDanhSachChuHo(ListView list)
        {
            list.Items.Clear();
        } 

        public List<ChuHo> FullListChuHo() 
        {
            ChuHoDAL chuHoDAL = new ChuHoDAL();
            return chuHoDAL.FullListChuHo();
        }
        public List<ChuHo> FindForNameChuHo(string name) 
        {
            ChuHoDAL chuHoDAL=new ChuHoDAL();
            return chuHoDAL.FindForNameChuHo(name);
        }

        public void DeleteChuHo(string name)
        {
            ChuHoDAL chuhodal=new ChuHoDAL();
            chuhodal.DeleteChuHo(name);
            return;
        }

        public void AddChuHo(string id, string name, DateTime day, string sex, string sdt)
        {
            ChuHoDAL chdal=new ChuHoDAL();
            chdal.AddChuHo(id,name,day,sex,sdt);
            return;
        }

        public void UpdateChuHo(string id,string name, DateTime day,string sex,string sdt)
        {
            ChuHoDAL dAL = new ChuHoDAL();  
            dAL.UpdateChuHo(id,name,day,sex,sdt);
            return;
        }
        
    }
}
