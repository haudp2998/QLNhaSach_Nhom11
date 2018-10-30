using QLNhaSach.DAO;
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
using QLNhaSach.DTO;

namespace QLNhaSach
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public class CheckQuyen
        {
            public static int flag;
        }
        public class GetTK
        {
            public static string getTK;
        }
        public void btnDangNhap_Click(object sender, EventArgs e)
        {

            if (cbbQuyen.Text == "Admin")
            {
                CheckQuyen.flag = 0;
                TaiKhoanDTO tk = new TaiKhoanDTO();
                tk.Username = txtTenDangNhap.Text;
                tk.Password = txtMatKhau.Text;
                bool isLogin = TaiKhoanDAO.KiemTraTaiKhoan(tk);
                GetTK.getTK = txtTenDangNhap.Text;
                if (isLogin == true)
                {
                    this.Hide();
                    frmChuongtrinh frmCT = new frmChuongtrinh();

                    frmCT.ShowDialog();

                    // this.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Bạn đã nhập sai tên tài khoản hoặc mật khẩu!", "Cảnh Báo");


                }

            }
            else if (cbbQuyen.Text == "User")
            {
                CheckQuyen.flag = 1;
                TaiKhoanDTO tk = new TaiKhoanDTO();
                tk.Username = txtTenDangNhap.Text;
                tk.Password = txtMatKhau.Text;
                bool isLogin = TaiKhoanDAO.KiemTraTaiKhoanUser(tk);
                GetTK.getTK = txtTenDangNhap.Text;
                if (isLogin == true)
                {
                    this.Hide();
                    frmChuongtrinh frmCT = new frmChuongtrinh();

                    frmCT.ShowDialog();

                    // this.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Bạn đã nhập sai tên tài khoản hoặc mật khẩu!", "Cảnh Báo");


                }

            }
            else { MessageBox.Show("Vui lòng chọn quyền"); }

        }
     
        private void cbHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThiMatKhau.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void cbGhiNhoTK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGhiNhoTK.Checked)
            {
                Properties.Settings.Default.TaiKhoan = txtTenDangNhap.Text;
                Properties.Settings.Default.MatKhau = txtMatKhau.Text;
                Properties.Settings.Default.Save();
              
            }
            else
            {
                Properties.Settings.Default.TaiKhoan = "";
                Properties.Settings.Default.MatKhau = "";
                Properties.Settings.Default.Save();
            }
          
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            cbbQuyen.Items.Add("Admin");
            cbbQuyen.Items.Add("User");
           // MessageBox.Show(check.ToString());
            

            txtTenDangNhap.Text = Properties.Settings.Default.TaiKhoan;
            txtMatKhau.Text = Properties.Settings.Default.MatKhau;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Visible == true)
            {

                if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK && this.Visible == true)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
