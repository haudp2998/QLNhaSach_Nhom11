using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNhaSach.DAO;
using QLNhaSach.DTO;

namespace QLNhaSach.BUS
{
    public class NhanVienBUS
    {
        public static List<NhanVienDTO> GetDSNhanVien()
        {
            return NhanVienDAO.GetDSNV();
        }
        public static void InsertNhanVien(string email, string hoten, string diachi, string sdt, string password)
        {
            NhanVienDAO.InsertNhanVien(email, hoten, diachi, sdt, password);
        }
        public static void DeleteNhanVien(string email)
        {
            NhanVienDAO.DeleteNhanVien(email);
        }
        public static void UpdateNhanVien(string email, string hoten, string diachi, string sdt, string password)
        {
            NhanVienDAO.UpdateNhanVien(email, hoten, diachi, sdt, password);
        }
        public static bool checkTrung(string manv)
        {
            return NhanVienDAO.checkTrung(manv);
        }
    }
}
