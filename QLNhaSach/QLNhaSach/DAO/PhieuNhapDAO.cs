using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DAO
{
    public class PhieuNhapDAO
    {
        public static List<PhieuNhapDTO> GetDSPN()
        {
            List<PhieuNhapDTO> DSPN = new List<PhieuNhapDTO>();

            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.PhieuNhaps select p;

                foreach (var row in query)
                {
                    PhieuNhapDTO pn = new PhieuNhapDTO();
                    pn.Maphieunhap = row.MaPhieuNhap;
                    pn.Ngaynhap = row.NgayNhap.ToString();
                    if (row.TongTien == 0) pn.Tongtien = "0";
                    else
                    {
                        pn.Tongtien = row.TongTien.ToString("###,###,###' 'VNĐ");
                    }
                    DSPN.Add(pn);
                }
            }
            return DSPN;
        }
        public static void InsertPhieuNhap(string mapn, DateTime ngaynhap)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                PhieuNhap pn = new PhieuNhap();
                pn.MaPhieuNhap = mapn;
                pn.NgayNhap = ngaynhap;
                pn.TongTien = 0;
                dbMain.PhieuNhaps.InsertOnSubmit(pn);
                dbMain.SubmitChanges();

            }
        }
        public static void UpdatePhieuNhap(string mapn, DateTime ngaynhap)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {


                PhieuNhap pn = dbMain.PhieuNhaps.SingleOrDefault(p => p.MaPhieuNhap ==
                 mapn);
                pn.MaPhieuNhap = mapn;
                pn.NgayNhap = ngaynhap;
                dbMain.SubmitChanges();



            }
        }

        public static bool checkTrung(string mapn)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.PhieuNhaps where p.MaPhieuNhap == mapn select p;
                if (query.Count() > 0)
                    return false;
            }
            return true;
        }
        public static void DeletePhieuNhap(string mapn)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                PhieuNhap pn = dbMain.PhieuNhaps.SingleOrDefault(p => p.MaPhieuNhap ==
                mapn);

                dbMain.PhieuNhaps.DeleteOnSubmit(pn);
                dbMain.SubmitChanges();


            }
        }
        public static void UpdateTongtien(string mapn, int soluong)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                PhieuNhap pn = dbMain.PhieuNhaps.SingleOrDefault(p => p.MaPhieuNhap ==
                 mapn);
                pn.TongTien = soluong;
                dbMain.SubmitChanges();
            }
        }
        public static PhieuNhap getThongTinPhieuNhap(string mapn)
        {
            PhieuNhap pn = new PhieuNhap();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {

                var query = from p in dbMain.PhieuNhaps where p.MaPhieuNhap == mapn select p;
                foreach (var row in query)
                {
                    pn.TongTien = row.TongTien;
                   
                }

            }
            return pn;
        }
    }
}
