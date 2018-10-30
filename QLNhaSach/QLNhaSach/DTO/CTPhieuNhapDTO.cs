using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DTO
{
    public class CTPhieuNhapDTO
    {
        private string mapn;
        private string masachnhap;
        private string soluongnhap;
        private string dongianhap;
        private string tongtien;
        private string tensach;
        public string Mapn
        {
            get
            {
                return mapn;
            }

            set
            {
                mapn = value;
            }
        }

        public string Masachnhap
        {
            get
            {
                return masachnhap;
            }

            set
            {
                masachnhap = value;
            }
        }

        public string Soluongnhap
        {
            get
            {
                return soluongnhap;
            }

            set
            {
                soluongnhap = value;
            }
        }

        public string Dongianhap
        {
            get
            {
                return dongianhap;
            }

            set
            {
                dongianhap = value;
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

        public string Tensach
        {
            get
            {
                return tensach;
            }

            set
            {
                tensach = value;
            }
        }
    }
}
