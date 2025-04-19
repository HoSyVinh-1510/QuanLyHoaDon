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
        public static AccountBLL instance;
        public static AccountBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountBLL();
                return instance;
            }
        }
        public AccountBLL() { }
        
        public bool CheckLogin(Account account)
        {
            AccountDAL accountDAL = new AccountDAL();
            return accountDAL.CheckLogin(account.TK,account.MK);
        }
    }
}
