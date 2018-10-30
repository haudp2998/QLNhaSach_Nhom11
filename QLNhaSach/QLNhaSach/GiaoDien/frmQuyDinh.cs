using QLNhaSach.DAO;
using QLNhaSach.DTO;
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

namespace QLNhaSach
{
    public partial class frmQuyDinh : Form
    {
        public frmQuyDinh()
        {
            InitializeComponent();
        }
        
        void loadQD()
        {
            QuyDinh qd = QuyDinhDAO.loadQuyDinh();
            txtLuongSach.Text = qd.NhapToiThieu;
            txtNo.Text = qd.KHNoToiThieu.ToString("###,###,###' 'VNĐ");
            txtTon1.Text = qd.TonNhapToiThieu;
            txtTon2.Text = qd.TonBanToiThieu;
        }
        
        private void frmQuyDinh_Load(object sender, EventArgs e)
        {
            loadQD();
            int flag = CheckQuyen.flag;
            if (flag == 1)
            {

                btnCapNhat.Visible = false;
            }
        }
        
       
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string luongsach = txtLuongSach.Text;
                int KHno = Convert.ToInt32(txtNo.Text);
                string tonNhap = txtTon1.Text;
                string tonBan = txtTon2.Text;
                QuyDinhDAO.UpdateQuyDinh(luongsach, KHno, tonNhap, tonBan);
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn phải nhập vào kiểu số.");
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Số không được âm");
                return;
            }
            
            MessageBox.Show("Thay đổi thành công");
            loadQD();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
