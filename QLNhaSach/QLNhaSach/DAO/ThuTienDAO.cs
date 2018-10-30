using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DAO
{
    public class ThuTienDAO
    {
        public static List<ThuTienDTO> GetDS()
        {
            List<ThuTienDTO> DS = new List<ThuTienDTO>();

            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.PhieuThus select p;

                foreach (var row in query)
                {
                    ThuTienDTO tt = new ThuTienDTO();
                    tt.Maphieu = row.MaPhieuThu;
                    tt.Ngaythu = row.NgayThu.ToString();
                    tt.Sotienthu = row.SoTienThu.ToString();
                    tt.Makh = row.MaKH;
                    var getKH = from h in dbMain.KhachHangs where h.MaKh == row.MaKH select h;
                    foreach (var row2 in getKH) {
                        tt.Tenkh = row2.HoTen;
                        tt.Email = row2.Email;
                        tt.Diachi = row2.DiaChi;
                        tt.Sdt = row2.SDT;
                      //  tt.Sotienno = row2.TongNo;
                    }
    
                    DS.Add(tt);
                }
            }
            return DS;
        }
        public static void InsertPhieuThu(string mapt, string makh, DateTime ngaythu, int sotien)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                PhieuThu pt = new PhieuThu();
                pt.MaPhieuThu = mapt;
                pt.MaKH = makh;
                pt.SoTienThu = sotien;
               
                pt.NgayThu = ngaythu;
                dbMain.PhieuThus.InsertOnSubmit(pt);
                dbMain.SubmitChanges();

            }
        }
        public static bool checkTrungPhieuThu(string mapt)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query =  from p in  dbMain.PhieuThus where  p.MaPhieuThu == mapt select p;
                if (query.Count() > 0)
                    return false;
            }
            return true;
       }
        public static void UpdatePhieuThu(string mapt, string makh, DateTime ngaythu, int sotien)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {


                PhieuThu pt = dbMain.PhieuThus.SingleOrDefault(p => p.MaPhieuThu ==
                 mapt);
               // pt.MaPhieuThu = mapt;
                pt.MaKH = makh;
                pt.SoTienThu = sotien;

                pt.NgayThu = ngaythu;
                dbMain.SubmitChanges();



            }
        }


        public static void DeletePhieuThu(string mapt)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                PhieuThu pt = dbMain.PhieuThus.SingleOrDefault(p => p.MaPhieuThu ==
                mapt);

                dbMain.PhieuThus.DeleteOnSubmit(pt);
                dbMain.SubmitChanges();


            }
        }
    }
}
