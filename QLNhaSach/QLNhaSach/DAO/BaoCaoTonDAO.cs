using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DAO
{
    public class BaoCaoTonDAO
    {
        public static List<BaoCaoTonDTO> GetDST()
        {
            List<BaoCaoTonDTO> DSTon = new List<BaoCaoTonDTO>();

            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                var query = from p in dbMain.Saches select p;
                foreach (var row in query)
                {
                    BaoCaoTonDTO s = new BaoCaoTonDTO();
                    s.Masach = row.MaSach;
                    s.Tensach = row.TenSach;
                    s.Tondau = row.TonDau;
                    s.Tongnhap = row.TongNhap;
                    s.Tongban = row.TongBan;
                    s.Phatsinh = row.PhatSinh;
                    s.Toncuoi = row.TonCuoi.ToString();
                    DSTon.Add(s);
                }
            }
            return DSTon;
        }
    }
}
