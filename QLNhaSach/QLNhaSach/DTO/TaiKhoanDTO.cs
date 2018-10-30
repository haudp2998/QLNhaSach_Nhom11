using QLNhaSach.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DTO
{
    class TaiKhoanDTO
    {
        string strUsername;
        public string Username
        {
            get { return strUsername; }
            set { strUsername = value; }
        }
        string strPassword;
        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }
    }
    
}
