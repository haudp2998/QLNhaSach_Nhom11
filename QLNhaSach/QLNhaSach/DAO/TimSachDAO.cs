using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLNhaSach.DAO
{
    public class TimSachDAO
    {
        
        public static List<TimSachDTO> GetDSSach()
        {
            List<TimSachDTO> DsSach = new List<TimSachDTO>();
         
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.Saches select p;
                
                foreach (var row in query)
                {
                    TimSachDTO sach = new TimSachDTO();
                    
                    sach.MaSach = row.MaSach;
                    sach.TenSach = row.TenSach;
                    sach.TheLoai = row.TheLoai;
                    sach.TacGia = row.TacGia;
                    sach.DonGia = row.DonGia.ToString("###,###,###' 'VNĐ");
                    sach.Luongton = row.TonCuoi.ToString();
                    DsSach.Add(sach);
                }
            }
            return DsSach;
        }
        public static List<TimSachDTO> GetDSSachTheoTheLoai(string strTheLoai)
        {
            List<TimSachDTO> DsSachTTL = new List<TimSachDTO>();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
               // var timKiem = dbMain.Saches.Where(p => p.TheLoai == (strTheLoai)).ToList(); ;
                var lst = from tk in dbMain.Saches where tk.TheLoai.Contains(strTheLoai) select tk;
                //from tk in dbMain.Saches where tk.TheLoai.Contains(strTheLoai) select tk;
                foreach (var row in lst)
                {
                    TimSachDTO sach = new TimSachDTO();

                    sach.MaSach = row.MaSach;
                    sach.TenSach = row.TenSach;
                    sach.TheLoai = row.TheLoai;
                    sach.TacGia = row.TacGia;
                    sach.DonGia = row.DonGia.ToString("###,###,###' 'VNĐ");
                    sach.Luongton = row.TonCuoi.ToString();
                    DsSachTTL.Add(sach);
                }
            }
        
            return DsSachTTL;
        }
     
        public static List<TimSachDTO> GetSachLikeTacGia(string strTacGia)
        {
            List<TimSachDTO> DsSachTTG = new List<TimSachDTO>();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var tk = from p in dbMain.Saches where p.TacGia.Contains(strTacGia)   select p;
                foreach (var row in tk)
                {
                    TimSachDTO sach = new TimSachDTO();

                    sach.MaSach = row.MaSach;
                    sach.TenSach = row.TenSach;
                    sach.TheLoai = row.TheLoai;
                    sach.TacGia = row.TacGia;
                    sach.DonGia = row.DonGia.ToString("###,###,###' 'VNĐ");
                    sach.Luongton = row.TonCuoi.ToString();
                    DsSachTTG.Add(sach);
                }
            }
            return DsSachTTG;
        }
        public static List<TimSachDTO> GetSachLikeTenSach(string strTenSach)
        {
            List<TimSachDTO> DsSachTTS = new List<TimSachDTO>();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var tk = from p in dbMain.Saches where p.TenSach.Contains(strTenSach) select p;
                foreach (var row in tk)
                {
                    TimSachDTO sach = new TimSachDTO();

                    sach.MaSach = row.MaSach;
                    sach.TenSach = row.TenSach;
                    sach.TheLoai = row.TheLoai;
                    sach.TacGia = row.TacGia;
                    sach.DonGia = row.DonGia.ToString("###,###,###' 'VNĐ");
                    sach.Luongton = row.TonCuoi.ToString();
                    DsSachTTS.Add(sach);
                }
            }
            return DsSachTTS;
        }
        public static Sach getThongTinSach(string masach)
        {
            Sach s = new Sach();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {

                var query = from p in dbMain.Saches where p.MaSach == masach select p;
                foreach (var row in query)
                {
                    s.TenSach = row.TenSach;
                    s.DonGia = row.DonGia;
                    s.TonCuoi = row.TonCuoi;
                    s.TonDau = row.TonDau;
                    s.TongBan = row.TongBan;
                    s.TongNhap = row.TongNhap;
                }

            }
            return s;
        }
        public static void UpdateSoLuongSach(string masach, int soluong, string tondau, string phatsinh,string tongnhap,string tongban)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                Sach s = dbMain.Saches.SingleOrDefault(p => p.MaSach ==
                 masach);
                s.TonCuoi = soluong;
                s.TonDau = tondau;
                s.TongNhap = tongnhap;
                s.TongBan = tongban;
                s.PhatSinh = phatsinh;
                dbMain.SubmitChanges();
            }
        }
        public static void InsertSach(string masach, string tensach, string theloai, string tacgia, int dongia)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                Sach s = new Sach();
                s.MaSach = masach;
                s.TenSach = tensach;
                s.TheLoai = theloai;
                s.TacGia = tacgia;
                s.DonGia = dongia;
                s.TonDau = "0";
                s.TongBan = "0";
                s.TongNhap = "0";
                s.PhatSinh = "0";
             //   s.TonCuoi = luongton;
                dbMain.Saches.InsertOnSubmit(s);
                dbMain.SubmitChanges();

            }

        }
        public static void ChangeSach(string masach, string tensach, string theloai, string tacgia, int dongia)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {


                Sach s = dbMain.Saches.SingleOrDefault(p => p.MaSach ==
                 masach);
                s.MaSach = masach;
                s.TenSach = tensach;
                s.TheLoai = theloai;
                s.TacGia = tacgia;
                s.DonGia = dongia;
            //    s.TonCuoi = luongton;
                dbMain.SubmitChanges();



            }
        }
        public static void DeleteSach(string masach)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                Sach s = dbMain.Saches.SingleOrDefault(p => p.MaSach ==
                masach);

                dbMain.Saches.DeleteOnSubmit(s);
                dbMain.SubmitChanges();


            }
        }
        public static bool checkTrung(string masach)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.Saches where p.MaSach == masach select p;
                if (query.Count() > 0)
                    return false;
            }
            return true;
        }
    }
}
