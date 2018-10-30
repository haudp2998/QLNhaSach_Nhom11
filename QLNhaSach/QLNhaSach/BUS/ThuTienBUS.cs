using QLNhaSach.DAO;
using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.BUS
{
    public class ThuTienBUS
    {
        public static List<ThuTienDTO> GetDS()
        {
            return ThuTienDAO.GetDS();
        }
        public static void InsertPhieuThu(string mapt, string makh, DateTime ngaythu, int sotien)
        {
            ThuTienDAO.InsertPhieuThu(mapt,  makh, ngaythu,sotien);
        }
        public static void DeletePhieuThu(string mapt)
        {
            ThuTienDAO.DeletePhieuThu(mapt);
        }
        public static void UpdatePhieuThu(string mapt, string makh, DateTime ngaythu, int sotien)
        {
            ThuTienDAO.UpdatePhieuThu(mapt, makh, ngaythu, sotien);
        }
        public static bool checkTrungPhieuThu(string mapt)
        {
            return ThuTienDAO.checkTrungPhieuThu(mapt);
        }
        }
}
