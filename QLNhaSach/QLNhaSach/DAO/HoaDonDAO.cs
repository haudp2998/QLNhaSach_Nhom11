using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DAO
{
    public class HoaDonDAO
    {
        public static List<HoaDonDTO> GetDSHD()
        {
            List<HoaDonDTO> DSHD = new List<HoaDonDTO>();

            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.HoaDons select p;

                foreach (var row in query)
                {
                    HoaDonDTO hd = new HoaDonDTO();
                    
                    hd.Mahd = row.MaHD;
                    hd.Makh = row.MaKH;
                    hd.Tenkh = row.TenKH;
                    hd.Ngaylap = row.Ngaylap.ToString();
                    hd.Tongtien =  row.TongTien.ToString();
                    DSHD.Add(hd);
                }
            }
            return DSHD;
        }
        public static void InsertHD(string mahd,string makh, string tenkh, DateTime ngaynhap,int tongtien)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                HoaDon hd = new HoaDon();
                hd.MaHD = mahd;
                hd.MaKH = makh;
                hd.TenKH = tenkh;
                hd.Ngaylap = ngaynhap;
                hd.TongTien = tongtien;
                dbMain.HoaDons.InsertOnSubmit(hd);
                dbMain.SubmitChanges();

            }
        }
        public static void UpdateHD(string mahd, string makh, string tenkh, DateTime ngaynhap)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {


                HoaDon hd = dbMain.HoaDons.SingleOrDefault(p => p.MaHD ==
                 mahd);
                hd.MaKH = makh;
                hd.TenKH = tenkh;
                hd.Ngaylap = ngaynhap;
                
                dbMain.SubmitChanges();



            }
        }

        public static bool checkTrung(string mahd)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.HoaDons where p.MaHD == mahd select p;
                if (query.Count() > 0)
                    return false;
            }
            return true;
        }
        public static void DeleteHoaDon(string mahd)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                HoaDon hd = dbMain.HoaDons.SingleOrDefault(p => p.MaHD ==
                mahd);

                dbMain.HoaDons.DeleteOnSubmit(hd);
                dbMain.SubmitChanges();


            }
        }
        public static void UpdateTongtien(string mahd, int soluong)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                HoaDon hd = dbMain.HoaDons.SingleOrDefault(p => p.MaHD ==
                 mahd);
                hd.TongTien = soluong;
                dbMain.SubmitChanges();
            }
        }
        public static HoaDon getThongTinHD(string mahd)
        {
            HoaDon hd = new HoaDon();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {

                var query = from p in dbMain.HoaDons where p.MaHD == mahd select p;
                foreach (var row in query)
                {
                    hd.TongTien = row.TongTien;

                }

            }
            return hd;
        }
        public static List<HoaDonDTO> TimKiem(string ten)
        {
            List<HoaDonDTO> ListKH = new List<HoaDonDTO>();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from s in dbMain.HoaDons
                            where s.MaKH.Contains(ten) || s.TenKH.Contains(ten)//Chọn những thành viên nào có tên gần giống 
                            select s;
                foreach (var row in query)
                {
                    HoaDonDTO kh = new HoaDonDTO();
                   
                    kh.Mahd = row.MaHD;
                    kh.Makh = row.MaKH;
                    kh.Tenkh = row.TenKH;
                    kh.Tongtien = row.TongTien.ToString();
                    kh.Ngaylap = row.Ngaylap.ToString();
                   
                    ListKH.Add(kh);
                }
            }
            return ListKH;
        }

    }
}
