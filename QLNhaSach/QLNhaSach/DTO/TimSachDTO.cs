using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DTO
{
    public class TimSachDTO
    {
        private string maSach;
        private string tenSach;
        private string theLoai;
        private string tacGia;
        private string donGia;
        private string luongton;
        public string MaSach
        {
            get
            {
                return maSach;
            }

            set
            {
                maSach = value;
            }
        }

        public string TenSach
        {
            get
            {
                return tenSach;
            }

            set
            {
                tenSach = value;
            }
        }

        public string TheLoai
        {
            get
            {
                return theLoai;
            }

            set
            {
                theLoai = value;
            }
        }

        public string TacGia
        {
            get
            {
                return tacGia;
            }

            set
            {
                tacGia = value;
            }
        }

        public string DonGia
        {
            get
            {
                return donGia;
            }

            set
            {
                donGia = value;
            }
        }

        public string Luongton
        {
            get
            {
                return luongton;
            }

            set
            {
                luongton = value;
            }
        }
    }
}
