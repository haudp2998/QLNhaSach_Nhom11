using QLNhaSach.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.BUS
{
    public class TaiKhoanBUS
    {
        public static void ChangeMK(string user, string mkcu, string mkmoi)
        {
            TaiKhoanDAO.ChangeMK(user, mkcu, mkmoi);
        }
    }
}
