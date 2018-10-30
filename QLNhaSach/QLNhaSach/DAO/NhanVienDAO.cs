using QLNhaSach.BUS;
using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DAO
{
    public class NhanVienDAO
    {
        public static List<NhanVienDTO> GetDSNV()
        {
            List<NhanVienDTO> DSNhanVien = new List<NhanVienDTO>();

            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.NhanViens select p;
                foreach (var row in query)
                {
                    NhanVienDTO nv = new NhanVienDTO();
                    nv.Email = row.Email;
                    nv.HoTen = row.HoTen;
                    nv.DiaChi = row.DiaChi;
                    nv.Sdt = row.SDT;
                    nv.PassWord = row.PassWord;
                    DSNhanVien.Add(nv);
                }
            }
            return DSNhanVien;
        }
        public static void InsertNhanVien(string email,string hoten,string diachi,string sdt,string password)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                NhanVien nv = new NhanVien();
                nv.Email = email;
                nv.HoTen = hoten;
                nv.DiaChi = diachi;
                nv.SDT = sdt;
                nv.PassWord = password;
                dbMain.NhanViens.InsertOnSubmit(nv);
                dbMain.SubmitChanges();
            }
        }
        public static void DeleteNhanVien(string email)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                NhanVien nv = dbMain.NhanViens.Where(p=>p.Email == email).FirstOrDefault();
                
                dbMain.NhanViens.DeleteOnSubmit(nv);
                dbMain.SubmitChanges();
            }
        }
        public static void UpdateNhanVien(string email, string hoten, string diachi, string sdt, string password)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var nv = (from h in dbMain.NhanViens where h.Email == email select h).FirstOrDefault();
                nv.Email = email; 
                nv.HoTen = hoten;
                nv.DiaChi = diachi;
                nv.SDT = sdt;
                nv.PassWord = password;
            
                dbMain.SubmitChanges();
            }

        }
        public static bool checkTrung(string email)
        {
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.NhanViens where p.Email == email select p;
                if (query.Count() > 0)
                    return false;
            }
            return true;
        }
    }       
}
