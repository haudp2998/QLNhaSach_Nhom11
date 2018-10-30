using QLNhaSach.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QLNhaSach.frmLogin;

namespace QLNhaSach.GiaoDien
{
    public partial class frmDoiMatKhau : Form
    {
        

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        void ChangeMatKhau()
        {
            
            string user = txtUser.Text;
            string mkcu = txtMKcu.Text;
            string mkmoi = txtMKmoi.Text;
            string mkremoi = txtReMKmoi.Text;
            if (user == "" || mkcu == "" || mkmoi == "" || mkremoi == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (mkmoi != mkremoi)
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                TaiKhoanBUS.ChangeMK(user, mkcu, mkmoi);
            }
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            ChangeMatKhau();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtUser.Text = GetTK.getTK;
        }
    }
}
