using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHoaDon.DTO
{
    internal class DonGiaDTO
    {
        private int IDDonGia;
        private int Nam;
        private int Thang;
        private float DonGiaDien;
        private float DonGiaNuoc;

        public DonGiaDTO(int id, int nam, int thang, float dgDien, float dgNuoc)
        {
            this.IDDonGia = id;
            this.Nam = nam;
            this.Thang = thang;
            this.DonGiaDien = dgDien;
            this.DonGiaNuoc = dgNuoc;
        }

        public DonGiaDTO() { }


    }
}
