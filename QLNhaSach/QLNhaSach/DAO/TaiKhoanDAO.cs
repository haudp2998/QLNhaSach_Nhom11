using QLNhaSach.BUS;
using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaSach.DAO
{
     class TaiKhoanDAO
    {
        public static bool KiemTraTaiKhoan(TaiKhoanDTO user)
        {
            dbMainDataContext dbMain = new dbMainDataContext();

            
            var svt = (from a in dbMain.Accounts
                       where a.UserName == user.Username && a.PassWord == user.Password
                       select a);

            
            if (svt.Count() > 0)
            {
                return true;
            }
            else    return false;
        }
        public static bool KiemTraTaiKhoanUser(TaiKhoanDTO user)
        {

            dbMainDataContext dbMain = new dbMainDataContext();

            var svt = (from a in dbMain.NhanViens
                       where a.Email == user.Username && a.PassWord == user.Password
                       select a);
            if (svt.Count() > 0)
            {
                return true;
            }
            else return false;
        }
        // Đổi Mật khẩu
        public static void ChangeMK(string user, string mkcu, string mkmoi)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                Account doi = dbMain.Accounts.SingleOrDefault(p => p.UserName ==
                 user);
                if ((doi.PassWord == mkcu) && (doi.PassWord != mkmoi || doi.UserName != user))
                {
                    doi.PassWord = mkmoi;
                    dbMain.SubmitChanges();
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else if (doi.PassWord == mkmoi)
                {
                    MessageBox.Show("Mật khẩu mới không được trùng với mật khẩu cũ !", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không hợp lệ !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
