using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace QuanLyHoaDon.DTO
{
    internal class Account
    {
        public string TK;
        public string MK;
        public Account() {}
        public Account(string tk, string mk)
        {
            this.TK = tk;
            this.MK = mk;
        }
    }
}
