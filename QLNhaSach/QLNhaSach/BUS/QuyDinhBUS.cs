using QLNhaSach.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.BUS
{
    public class QuyDinhBUS
    {
        public static QuyDinh GetQD()
        {
            return QuyDinhDAO.GetQD();
        }
        }
}
