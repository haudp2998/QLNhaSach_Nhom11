using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DAO
{
    public class BanSachDAO
    {
        public static List<BanSachDTO> GetDSHD(string maphieu)
        {
            List<BanSachDTO> DSHoaDon = new List<BanSachDTO>();

            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.PhieuBans where p.MaPhieuBan == maphieu select p;
                
                foreach (var row in query)
                {
                    BanSachDTO hd = new BanSachDTO();
                  
                    hd.Soluong = row.SoLuong.ToString();
                 
                    hd.Masach = row.MaSach;
                    var getSach = from d in dbMain.Saches where d.MaSach == row.MaSach select d;
                    foreach (var row3 in getSach) {
                        hd.Tensach = row3.TenSach;
                        hd.Dongia = row3.DonGia.ToString() ;
                    }
                    DSHoaDon.Add(hd);
                }
            }
            return DSHoaDon;
        }
        public static void InsertHoaDon(string mahd, string masach, int soluong)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                PhieuBan pb = new PhieuBan();
                pb.MaPhieuBan = mahd;
                pb.MaSach = masach;
                pb.SoLuong = soluong;
               
                dbMain.PhieuBans.InsertOnSubmit(pb);
                dbMain.SubmitChanges();

            }
        }
        public static void UpdateHoaDon(string mahd, string masach, int soluong)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {

                var query = from h in dbMain.PhieuBans where h.MaPhieuBan == mahd && h.MaSach == masach select h;

                PhieuBan pb = query.SingleOrDefault();

               // pb.MaPhieuBan = mahd;
            
                pb.MaSach = masach;
                pb.SoLuong = soluong;
                
                dbMain.SubmitChanges();



            }
        }
        public static bool checkTrung(string mahd,string masach)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from h in dbMain.PhieuBans where h.MaPhieuBan == mahd && h.MaSach == masach select h;
                if (query.Count() > 0)
                    return false;
            }
            return true;
        }

        public static void DeleteHoaDon(string mahd,string masach)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from h in dbMain.PhieuBans where h.MaPhieuBan == mahd && h.MaSach == masach select h;

                PhieuBan pb = query.SingleOrDefault();
                dbMain.PhieuBans.DeleteOnSubmit(pb);
                dbMain.SubmitChanges();


            }
        }
      /*  public static List<BanSachDTO> TimKiemTheoKH(string makh)
        {
            List<BanSachDTO> DSKH = new List<BanSachDTO>();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from s in dbMain.PhieuBans
                            where s.MaKH.Contains(makh) 
                            select s;
                foreach (var row in query)
                {
                    BanSachDTO hd = new BanSachDTO();
                    hd.Maphieu = row.MaPhieuBan;
                    hd.Soluong = row.SoLuong.ToString();
                    hd.Ngaylap = row.NgayBan.ToString();
                    var getKH = from h in dbMain.KhachHangs where h.MaKh == row.MaKH select h;
                    foreach (var row2 in getKH)
                        hd.Tenkh = row2.HoTen;
                    hd.Makh2 = row.MaKH;
                    hd.Masach = row.MaSach;
                    var getSach = from d in dbMain.Saches where d.MaSach == row.MaSach select d;
                    foreach (var row3 in getSach)
                    {
                        hd.Tensach = row3.TenSach;
                        hd.Dongia = row3.DonGia.ToString("###,###,###' 'VNĐ");
                    }
                    DSKH.Add(hd);
                }
            }
            return DSKH;
        }*/
    }
}
