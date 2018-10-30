using QLNhaSach.DAO;
using QLNhaSach.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.BUS
{
    public class BaoCaoNoBUS
    {
        public static List<BaoCaoNoDTO> GetDSNo()
        {
            return BaoCaoNoDAO.GetDSN();
        }
    }
}
