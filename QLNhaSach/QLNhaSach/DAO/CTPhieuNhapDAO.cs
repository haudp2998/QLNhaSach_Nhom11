using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DAO
{
    public class CTPhieuNhapDAO
    {
        public static List<CTPhieuNhapDTO> GetCTPN(string mapn)
        {
            List<CTPhieuNhapDTO> CTPN = new List<CTPhieuNhapDTO>();

            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.ChiTietPhieuNhaps where p.MaPhieuNhap == mapn select p;

                foreach (var row in query)
                {
                    CTPhieuNhapDTO ctpn = new CTPhieuNhapDTO();
                    ctpn.Mapn = row.MaPhieuNhap;
                    ctpn.Masachnhap = row.MaSach;
                    var getSach = from d in dbMain.Saches where d.MaSach == row.MaSach select d;
                    foreach (var row3 in getSach)
                    {
                        ctpn.Tensach = row3.TenSach;
                     }
                    ctpn.Soluongnhap = row.SoLuong.ToString();
                    ctpn.Dongianhap = row.DonGia.ToString();
                    ctpn.Tongtien = row.TongTien.ToString();
                    CTPN.Add(ctpn);
                }
            }
            return CTPN;
        }
        public static void InsertCTPhieuNhap(string mapn, string masach, int soluong, int dongia, int tongtien)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
                ctpn.MaPhieuNhap = mapn;
                ctpn.MaSach = masach;
                ctpn.SoLuong = soluong;
                ctpn.DonGia = dongia;
                ctpn.TongTien = tongtien;
                dbMain.ChiTietPhieuNhaps.InsertOnSubmit(ctpn);
                dbMain.SubmitChanges();

            }
        }
        public static void UpdateCTPhieuNhap(string mapn, string masach, int soluong, int dongia, int tongtien)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from h in dbMain.ChiTietPhieuNhaps where h.MaPhieuNhap == mapn && h.MaSach == masach select h;
                
                ChiTietPhieuNhap ctpn = query.SingleOrDefault();
               // ctpn.MaPhieuNhap = mapn;
               // ctpn.MaSach = masach;
                ctpn.SoLuong = soluong;
                ctpn.DonGia = dongia;
                ctpn.TongTien = tongtien;
                dbMain.SubmitChanges();
            }
        }
        public static bool checkTrung(string mapn,string masach)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from h in dbMain.ChiTietPhieuNhaps where h.MaPhieuNhap == mapn && h.MaSach == masach select h;
                if (query.Count() > 0)
                    return false;
            }
            return true;
        }

        public static void DeleteCTPhieuNhap(string mapn, string masach)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {

                var query = from h in dbMain.ChiTietPhieuNhaps where h.MaPhieuNhap == mapn && h.MaSach == masach select h;
                //ChiTietPhieuNhap ctpn = dbMain.ChiTietPhieuNhaps.SingleOrDefault(p => p.MaPhieuNhap ==
                //mapn and p=> p.MaSach == masach);
                ChiTietPhieuNhap ctpn = query.SingleOrDefault();
                dbMain.ChiTietPhieuNhaps.DeleteOnSubmit(ctpn);
                dbMain.SubmitChanges();


            }
        }
    }
}
