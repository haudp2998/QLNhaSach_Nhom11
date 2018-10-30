using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DTO
{
    public class PhieuNhapDTO
    {
        private string maphieunhap;
        private string ngaynhap;
        private string tongtien;

        public string Maphieunhap
        {
            get
            {
                return maphieunhap;
            }

            set
            {
                maphieunhap = value;
            }
        }

        public string Ngaynhap
        {
            get
            {
                return ngaynhap;
            }

            set
            {
                ngaynhap = value;
            }
        }

        public string Tongtien
        {
            get
            {
                return tongtien;
            }

            set
            {
                tongtien = value;
            }
        }
    }
}
