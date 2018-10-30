using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DTO
{
    public class QuyDinhDTO
    {
        private string maQuyDinh;
        private string nhapToiThieu;
        private string tonNhapToiThieu;
        private string KhNoToiThieu;
        private string tonBanToiThieu;

        public string MaQuyDinh
        {
            get
            {
                return maQuyDinh;
            }

            set
            {
                maQuyDinh = value;
            }
        }

        public string NhapToiThieu
        {
            get
            {
                return nhapToiThieu;
            }

            set
            {
                nhapToiThieu = value;
            }
        }

        public string TonNhapToiThieu
        {
            get
            {
                return tonNhapToiThieu;
            }

            set
            {
                tonNhapToiThieu = value;
            }
        }

        public string KhNoToiThieu1
        {
            get
            {
                return KhNoToiThieu;
            }

            set
            {
                KhNoToiThieu = value;
            }
        }

        public string TonBanToiThieu
        {
            get
            {
                return tonBanToiThieu;
            }

            set
            {
                tonBanToiThieu = value;
            }
        }
    }
}
