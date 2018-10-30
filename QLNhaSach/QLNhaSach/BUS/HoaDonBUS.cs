using QLNhaSach.DAO;
using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.BUS
{
    public class HoaDonBUS
    {
        public static List<HoaDonDTO> GetDSHD()
        {
            return HoaDonDAO.GetDSHD();
        }

        public static void InsertHD(string mahd, string makh, string tenkh, DateTime ngaynhap, int tongtien)
        {
            HoaDonDAO.InsertHD(mahd, makh, tenkh, ngaynhap, tongtien);
        }
        public static void DeleteHD(string mahd)
        {
            HoaDonDAO.DeleteHoaDon(mahd);
        }
        public static void UpdateHD(string mahd, string makh, string tenkh, DateTime ngaynhap)
        {
            HoaDonDAO.UpdateHD(mahd, makh, tenkh, ngaynhap);
        }
        public static void UpdateTongtien(string mahd, int soluong)
        {
            HoaDonDAO.UpdateTongtien(mahd, soluong);
        }
        public static HoaDon getThongTinHD(string mahd)
        {
            return HoaDonDAO.getThongTinHD(mahd);
        }
        public static List<HoaDonDTO> TimKiem(string ten)
        {
            return HoaDonDAO.TimKiem(ten);
        }
        public static bool checkTrung(string mahd)
        {
            return HoaDonDAO.checkTrung(mahd);
        }
    }
}
