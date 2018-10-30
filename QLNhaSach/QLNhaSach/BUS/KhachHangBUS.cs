using QLNhaSach.DAO;
using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.BUS
{
    public class KhachHangBUS
    {
        public static List<KhachHangDTO> GetDSKhachHang()
        {
            return KhachHangDAO.GetDSKH();
        }
        public static List<KhachHangDTO> TimDSKH(string ten)
        {
            return KhachHangDAO.TimKiem(ten);
        }
        public static void InsertKhachHang(string makh, string hoten, string sdt, string diachi, string email, string tongno)
        {
            KhachHangDAO.InsertKhachHang(makh, hoten, sdt, diachi, email,tongno);
        }
        public static void DeleteKhachHang(string makh)
        {
            KhachHangDAO.DeleteKhachHang(makh);
        }
        public static void ChangeKhachHang(string makh, string hoten, string sdt, string diachi, string email, string tongno)
        {
            KhachHangDAO.ChangeKhachHang(makh, hoten, sdt, diachi, email, tongno);
        }
        public static KhachHang GetTenKH(string makh)
        {
            return KhachHangDAO.GetTenKH(makh);
        }
        public static void UpdateTongNoKH(string makh, string tongno, string nodau, string phatsinh)
        {
            KhachHangDAO.UpdateTongNoKH(makh,tongno,nodau,phatsinh);
        }
        public static bool checkTrung(string makh)
        {
            return KhachHangDAO.checkTrung(makh);
        }
    }
}
