using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DAO
{
    public class BaoCaoNoDAO
    {
        public static List<BaoCaoNoDTO> GetDSN()
        {
            List<BaoCaoNoDTO> DSNo = new List<BaoCaoNoDTO>();

            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.KhachHangs select p;
                foreach (var row in query)
                {
                    BaoCaoNoDTO kh = new BaoCaoNoDTO();
                    kh.Makh = row.MaKh;
                    kh.Hoten = row.HoTen;
                    kh.Sdt = row.SDT;
                    kh.Email = row.Email;
                    kh.Nodau = row.NoDau;
                    kh.Phatsinh = row.PhatSinh;
                    kh.Nocuoi = row.TongNo.ToString();

                    DSNo.Add(kh);
                }
            }
            return DSNo;
        }
    }
}
