using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DAO
{
    public class KhachHangDAO
    {
        public static List<KhachHangDTO> GetDSKH()
        {
            List<KhachHangDTO> DSKhachHang = new List<KhachHangDTO>();

            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.KhachHangs select p;
                foreach (var row in query)
                {
                    KhachHangDTO kh = new KhachHangDTO();
                    long check =Int64.Parse(row.TongNo);
                    kh.Makh = row.MaKh;
                    kh.Hoten = row.HoTen;
                    kh.Sdt = row.SDT;
                    kh.Diachi = row.DiaChi;
                    kh.Email = row.Email;
                    kh.Tongno = check.ToString("###,###,###' 'VNĐ");
                    DSKhachHang.Add(kh);
                }
            }
            return DSKhachHang;
        }
        public static void InsertKhachHang(string makh, string hoten, string sdt, string diachi, string email, string tongno)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                KhachHang kh = new KhachHang();
                kh.MaKh = makh;
                kh.HoTen = hoten;
                kh.SDT = sdt;
                kh.DiaChi = diachi;
                kh.Email = email;
                kh.TongNo = tongno;
                kh.NoDau = tongno;
                kh.PhatSinh = "0";
                
                dbMain.KhachHangs.InsertOnSubmit(kh);
                dbMain.SubmitChanges();
                
            }
        }
        public static KhachHang GetTenKH(string makh)
        {
            KhachHang kh = new KhachHang();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {

                var query = from p in dbMain.KhachHangs where p.MaKh==makh select p;
                foreach (var row in query)
                {
                    kh.HoTen = row.HoTen;
                    kh.DiaChi = row.DiaChi;
                    kh.Email = row.Email;
                    kh.SDT = row.SDT;
                    kh.NoDau = row.NoDau;
                    kh.PhatSinh = row.PhatSinh;
                    kh.TongNo = row.TongNo;
                }

            }
            return kh;
        }
        public static void ChangeKhachHang(string makh, string hoten, string sdt, string diachi, string email, string tongno)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {

            
                 KhachHang kh = dbMain.KhachHangs.SingleOrDefault(p => p.MaKh ==
                  makh);

                      kh.MaKh = makh; 
                      kh.HoTen = hoten;
                      kh.SDT = sdt;
                      kh.DiaChi = diachi;
                      kh.Email = email;
                      kh.TongNo = tongno;
                      dbMain.SubmitChanges();
                    


            }
        }
        public static bool checkTrung(string makh)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.KhachHangs where p.MaKh == makh select p;
                if (query.Count() > 0)
                    return false;
            }
            return true;
        }
        public static void UpdateTongNoKH(string makh, string tongno,string nodau, string phatsinh)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {


                KhachHang kh = dbMain.KhachHangs.SingleOrDefault(p => p.MaKh ==
                 makh);

                kh.MaKh = makh;
                kh.NoDau = nodau;
                kh.PhatSinh = phatsinh;
                kh.TongNo = tongno;
                dbMain.SubmitChanges();



            }
        }

        public static void DeleteKhachHang(string makh)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                KhachHang kh = dbMain.KhachHangs.SingleOrDefault(p => p.MaKh ==
                makh);
                
                    dbMain.KhachHangs.DeleteOnSubmit(kh);
                    dbMain.SubmitChanges();
                
                
            }
        }
        public static List<KhachHangDTO> TimKiem(string ten)
        {
            List<KhachHangDTO> ListKH = new List<KhachHangDTO>();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from s in dbMain.KhachHangs
                            where s.MaKh.Contains(ten) || s.HoTen.Contains(ten)//Chọn những thành viên nào có tên gần giống 
                            select s;
                foreach (var row in query)
                {
                    KhachHangDTO kh = new KhachHangDTO();
                    long check = Int64.Parse(row.TongNo);
                    kh.Makh = row.MaKh;
                    kh.Hoten = row.HoTen;
                    kh.Sdt = row.SDT.ToString();
                    kh.Diachi = row.DiaChi;
                    kh.Email = row.Email;
                    kh.Tongno = kh.Tongno = check.ToString("###,###,###' 'VNĐ"); ;
                    ListKH.Add(kh);
                }
            }
            return ListKH;
        }
    }
    

}
