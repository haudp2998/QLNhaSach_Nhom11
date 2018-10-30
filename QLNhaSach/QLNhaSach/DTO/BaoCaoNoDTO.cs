using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaSach.DTO
{
    public class BaoCaoNoDTO
    {
        private string makh,hoten,sdt,email,nodau,phatsinh,nocuoi;

        

        public string Hoten
        {
            get
            {
                return hoten;
            }

            set
            {
                hoten = value;
            }
        }

        public string Makh
        {
            get
            {
                return makh;
            }

            set
            {
                makh = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        public string Nodau
        {
            get
            {
                return nodau;
            }

            set
            {
                nodau = value;
            }
        }

        public string Phatsinh
        {
            get
            {
                return phatsinh;
            }

            set
            {
                phatsinh = value;
            }
        }
        public string Nocuoi
        {
            get
            {
                return nocuoi;
            }

            set
            {
                nocuoi = value;
            }
        }

        public string Sdt
        {
            get
            {
                return sdt;
            }

            set
            {
                sdt = value;
            }
        }
    }
}
