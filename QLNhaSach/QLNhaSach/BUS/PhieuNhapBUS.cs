using QLNhaSach.DAO;
using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.BUS
{
    public class PhieuNhapBUS
    {
        public static List<PhieuNhapDTO> GetDSPN()
        {
            return PhieuNhapDAO.GetDSPN();
        }

        public static void InsertPhieuNhap(string mapn, DateTime ngaynhap)
        {
            PhieuNhapDAO.InsertPhieuNhap(mapn, ngaynhap);
        }
        public static void DeletePhieuNhap(string mapn)
        {
            PhieuNhapDAO.DeletePhieuNhap(mapn);
        }
        public static void UpdatePhieuNhap(string mapn, DateTime ngaynhap)
        {
            PhieuNhapDAO.UpdatePhieuNhap(mapn, ngaynhap);
        }
        public static void UpdateTongtien(string mapn, int soluong)
        {
            PhieuNhapDAO.UpdateTongtien(mapn, soluong);
        }
        public static PhieuNhap getThongTinPhieuNhap(string mapn)
        {
            return PhieuNhapDAO.getThongTinPhieuNhap(mapn);
        }
        public static bool checkTrung(string mapn)
        {
            return PhieuNhapDAO.checkTrung(mapn);
        }
    }
}
