using QLNhaSach.DAO;
using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.BUS
{
    public class TimSachBUS
    {
        public static List<TimSachDTO> GetDsSach()
        {
            return TimSachDAO.GetDSSach();
        }
        public static List<TimSachDTO> GetDSSachTheoTheLoai(string strTheLoai)
        {
            return TimSachDAO.GetDSSachTheoTheLoai(strTheLoai);
        }
        public static List<TimSachDTO> GetDSSachTheoTacGia(string strTacGia)
        {
            return TimSachDAO.GetSachLikeTacGia(strTacGia);
        }
        public static List<TimSachDTO> GetDSSachTheoTenSach(string strTenSach)
        {
            return TimSachDAO.GetSachLikeTenSach(strTenSach);
        }
        public static Sach getThongTinSach(string masach)
        {
            return TimSachDAO.getThongTinSach(masach);
        }
        public static void UpdateSoLuongSach(string masach, int soluong, string tondau, string phatsinh, string tongnhap, string tongban)
        {
            TimSachDAO.UpdateSoLuongSach(masach,soluong,tondau,phatsinh,tongnhap,tongban);
        }
        public static void InsertSach(string masach, string tensach, string theloai, string tacgia, int dongia)
        {
            TimSachDAO.InsertSach(masach, tensach, theloai, tacgia, dongia);
        }
        public static void ChangeSach(string masach, string tensach, string theloai, string tacgia, int dongia)
        {
            TimSachDAO.ChangeSach(masach, tensach, theloai, tacgia, dongia);
        }
        public static void DeleteSach(string masach)
        {
            TimSachDAO.DeleteSach(masach);
        }
        public static bool checkTrung(string masach)
        {
            return TimSachDAO.checkTrung(masach);
        }
    }
}
