using QLNhaSach.DTO;
using QLNhaSach.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.BUS
{
    public class BanSachBUS
    {
        public static List<BanSachDTO> GetDSHoaDon(string mahd)
        {
            return BanSachDAO.GetDSHD(mahd);
        }
      /*  public static List<BanSachDTO> TimKiemTheoKH(string makh)
        {
            return BanSachDAO.TimKiemTheoKH(makh);
        }*/
        public static void InsertHoaDon(string mahd, string masach, int soluong)
        {
            BanSachDAO.InsertHoaDon(mahd, masach, soluong);
        }
        public static void DeleteHoaDon(string mahd,string masach)
        {
            BanSachDAO.DeleteHoaDon(mahd,masach);
        }
        public static void UpdateHoaDon(string mahd, string masach, int soluong)
        {
            BanSachDAO.UpdateHoaDon(mahd, masach, soluong);
        }
        public static bool checkTrung(string mahd,string masach)
        {
            return BanSachDAO.checkTrung(mahd,masach);
        }
    }
}
