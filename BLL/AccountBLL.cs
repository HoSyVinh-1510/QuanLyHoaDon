using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHoaDon.DAL; 
using QuanLyHoaDon.DTO;
namespace QuanLyHoaDon.BLL
{
    internal class AccountBLL
    {
        public AccountBLL() { }
        
        public bool CheckLogin(Account account)
        {
            AccountDAL accountDAL = new AccountDAL();
            return accountDAL.CheckLogin(account.TK,account.MK);
        }
    }
}
