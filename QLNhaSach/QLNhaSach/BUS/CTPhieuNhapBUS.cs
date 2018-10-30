using QLNhaSach.DAO;
using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.BUS
{
    public class CTPhieuNhapBUS
    {
        public static List<CTPhieuNhapDTO> GetCTPN(string mapn)
        {
            return CTPhieuNhapDAO.GetCTPN( mapn);
        }
        public static void InsertCTPhieuNhap(string mapn, string masach, int soluong, int dongia, int tongtien)
        {
            CTPhieuNhapDAO.InsertCTPhieuNhap(mapn,masach,soluong,dongia,tongtien);
        }
        public static void DeleteCTPhieuNhap(string mapn,string masach)
        {
            CTPhieuNhapDAO.DeleteCTPhieuNhap(mapn,masach);
        }
        public static void UpdateCTPhieuNhap(string mapn, string masach, int soluong, int dongia, int tongtien)
        {
            CTPhieuNhapDAO.UpdateCTPhieuNhap(mapn, masach, soluong, dongia, tongtien);
        }
        public static bool checkTrung(string mapn,string masach)
        {
            return CTPhieuNhapDAO.checkTrung(mapn,masach);
        }
    }
}
