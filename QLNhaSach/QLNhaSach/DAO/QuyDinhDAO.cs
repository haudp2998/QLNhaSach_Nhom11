using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DAO
{
    public class QuyDinhDAO
    {
        public static QuyDinh loadQuyDinh()
        {
            QuyDinh qd = new QuyDinh();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {
                
                var query = from p in dbMain.QuyDinhs select p;
                foreach (var row in query)
                {

                    qd.KHNoToiThieu = row.KHNoToiThieu;
                    qd.NhapToiThieu = row.NhapToiThieu;
                    qd.TonBanToiThieu = row.TonBanToiThieu;
                    qd.TonNhapToiThieu = row.TonNhapToiThieu;
                }

            }
            return qd;
        }
        public static void UpdateQuyDinh(string luongsach, int KHno, string tonNhap, string tonBan)
        {

            dbMainDataContext dbMain = new dbMainDataContext();
            QuyDinh qd = dbMain.QuyDinhs.Where(p => p.MaQuyDinh == "1").FirstOrDefault();
            qd.NhapToiThieu = luongsach;
            qd.KHNoToiThieu = KHno;
            qd.TonBanToiThieu = tonBan;
            qd.TonNhapToiThieu = tonNhap;
            dbMain.SubmitChanges();
         
        }
        public static QuyDinh GetQD()
        {
            QuyDinh qd = new QuyDinh();
            using (dbMainDataContext dbMain = new dbMainDataContext())
            {

                var query = from p in dbMain.QuyDinhs where p.MaQuyDinh == "1" select p;
                foreach (var row in query)
                {
                    qd.KHNoToiThieu = row.KHNoToiThieu;
                    qd.NhapToiThieu = row.NhapToiThieu;
                    qd.TonBanToiThieu = row.TonBanToiThieu;
                    qd.TonNhapToiThieu = row.TonNhapToiThieu;
                }

            }
            return qd;
        }
    }
}
