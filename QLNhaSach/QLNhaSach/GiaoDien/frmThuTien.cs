using QLNhaSach.BUS;
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
using static QLNhaSach.frmKhachHang;

namespace QLNhaSach
{
    public partial class frmThuTien : Form
    {
        public frmThuTien()
        {
            InitializeComponent();
        }
        int flag = -1;
        void LoadPhieuThu()
        {
            List<ThuTienDTO> dsTT = ThuTienBUS.GetDS();
            dgvDSHD.DataSource = dsTT;

            for (int i = 0; i < dgvDSHD.Rows.Count; i++)
            {
                dgvDSHD.Rows[i].Cells[0].Value = i + 1;
            }
        }
        private void frmThuTien_Load(object sender, EventArgs e)
        {
            LoadPhieuThu();
        }
      
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvDSHD.CurrentRow.Index; //dòng chọn
                
                txtMaKH.Text = dgvDSHD.Rows[index].Cells[1].Value.ToString();
                txtTenKH.Text = dgvDSHD.Rows[index].Cells[2].Value.ToString();//1
                txtMaThu.Text = dgvDSHD.Rows[index].Cells[3].Value.ToString();
                
                dtpNgayThu.Text = dgvDSHD.Rows[index].Cells[4].Value.ToString();
                txtSDT.Text = dgvDSHD.Rows[index].Cells[5].Value.ToString();
                txtEmail.Text = dgvDSHD.Rows[index].Cells[6].Value.ToString(); 
                txtDiaChi.Text = dgvDSHD.Rows[index].Cells[7].Value.ToString();
                
                txtTienThu.Text = dgvDSHD.Rows[index].Cells[8].Value.ToString();
               // txtMaKH.Text = GetMaKH.getMaKH;
                KhachHang kh = KhachHangBUS.GetTenKH(txtMaKH.Text);
                txtTienNo.Text = kh.TongNo;
            }
            catch
            {

            }
        }
        public void LoadThongTinTheoMaKH()
        {
            txtMaKH.Text = GetMaKH.getMaKH;
            KhachHang kh = KhachHangBUS.GetTenKH(txtMaKH.Text);
            txtTenKH.Text = kh.HoTen;
            txtDiaChi.Text = kh.DiaChi;
            txtEmail.Text = kh.Email;
            txtSDT.Text = kh.SDT;
            txtTienNo.Text = kh.TongNo;
            btnLuu.Enabled = false;
        }
        private void btnMaKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frmKH = new frmKhachHang();
            frmKH.ShowDialog();
            LoadThongTinTheoMaKH();
        }
        void UpdateTienNoKH()
        {
           // txtMaKH.Text = GetMaKH.getMaKH;
            KhachHang kh = KhachHangBUS.GetTenKH(txtMaKH.Text);
            int check = Int32.Parse(kh.TongNo) - Int32.Parse(txtTienThu.Text);
            int phatsinh = Int32.Parse(kh.PhatSinh) + Int32.Parse(txtTienThu.Text);
            int nodau = phatsinh + check;
            
            KhachHangBUS.UpdateTongNoKH(txtMaKH.Text,check.ToString(),nodau.ToString(),phatsinh.ToString());
            txtTienNo.Text = kh.TongNo;
        }
        void InsertPhieuThu()
        {
            if (txtMaKH.Text == "" || txtMaThu.Text == "" || txtTienThu.Text == "" ||  dtpNgayThu.Value.Date.ToString() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
         
            if (IsNumber(txtTienThu.Text)== false)
            {
                MessageBox.Show("Số tiền thu phải là số và không được âm", "Thông báo");
                return;
            }
            string mapt = txtMaThu.Text;
            string makh = txtMaKH.Text;
            
            int sotien = Int32.Parse(txtTienThu.Text) ;

            DateTime ngaythu = dtpNgayThu.Value.Date;

           
            KhachHang kh = KhachHangBUS.GetTenKH(txtMaKH.Text);

            int check = Int32.Parse( kh.TongNo) - sotien  ;
            if( check < 0)
            {
                MessageBox.Show("Số tiền thu không được vượt quá tiền nợ của khách hàng");
                return;
            }
            if(ThuTienBUS.checkTrungPhieuThu(txtMaThu.Text) == false)
            {
                MessageBox.Show("Mã phiếu thu không được trùng");
                return;
            }
            ThuTienBUS.InsertPhieuThu(mapt,  makh, ngaythu, sotien);
            UpdateTienNoKH();
            MessageBox.Show("Thêm phiếu thu thành công!");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            InsertPhieuThu();
            
            LoadPhieuThu();
        }
        void UpdateTongNoKH_Xoa_Sua()
        {
            KhachHang kh = KhachHangBUS.GetTenKH(txtMaKH.Text);
            int check = Int32.Parse(kh.TongNo) + Int32.Parse(txtTienThu.Text);
            
            int phatsinh = Int32.Parse(kh.PhatSinh) - Int32.Parse(txtTienThu.Text);
            int nodau = phatsinh + check;

            KhachHangBUS.UpdateTongNoKH(txtMaKH.Text, check.ToString(),nodau.ToString(),phatsinh.ToString());
            txtTienNo.Text = kh.TongNo;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá phiếu thu này đồng thời cập nhật lại số tiền nợ của khách hàng?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                
                ThuTienBUS.DeletePhieuThu(txtMaThu.Text);
                MessageBox.Show("Xoá phiếu thu thành công!");
                UpdateTongNoKH_Xoa_Sua();

                LoadPhieuThu();
            }
        }
        void UpdatePhieuThu()
        {
            if (txtMaKH.Text == "" || txtMaThu.Text == "" || txtTienThu.Text == "" || dtpNgayThu.Value.Date.ToString() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
          
            if (IsNumber(txtTienThu.Text) == false)
            {
                MessageBox.Show("Số tiền thu phải là số và không được âm", "Thông báo");
                return;
            }
            string mapt = txtMaThu.Text;
            string makh = txtMaKH.Text;

            int sotien = Int32.Parse(txtTienThu.Text);
            DateTime ngaythu = dtpNgayThu.Value.Date;
         
            KhachHang kh = KhachHangBUS.GetTenKH(txtMaKH.Text);

            int check = Int32.Parse(kh.TongNo) - sotien;
            if (check < 0)
            {
                MessageBox.Show("Số tiền thu không được vượt quá tiền nợ của khách hàng");
                return;
            }
            UpdateTienNoKH();
            ThuTienBUS.UpdatePhieuThu(mapt, makh, ngaythu, sotien);
            MessageBox.Show("Cập nhật phiếu thu thành công");
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            UpdateTongNoKH_Xoa_Sua();
            flag = 1;
            txtMaThu.Enabled = false;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnLuuNhanVien_Click(object sender, EventArgs e)
        {
           
             if( flag == 1)
            {
                UpdatePhieuThu();
                LoadPhieuThu();
                txtMaThu.Enabled = true;
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Phiếu thu tiền", new Font("Times New Roman", 20), Brushes.Black, new Point(300, 25));
            e.Graphics.DrawString("Họ tên khách hàng: " + txtTenKH.Text, new Font("Times New Roman", 15), Brushes.Black, new Point(25, 75));
            e.Graphics.DrawString("Ngày nhập: " + DateTime.Now, new Font("Times New Roman", 15), Brushes.Black, new Point(500, 75));
            e.Graphics.DrawString("Mã phiếu thu: " + txtMaThu.Text, new Font("Times New Roman", 15), Brushes.Black, new Point(300, 125));
            e.Graphics.DrawString("Địa chỉ: \t" + txtDiaChi.Text, new Font("Times New Roman", 15), Brushes.Black, new Point(50, 175));
            e.Graphics.DrawString("Điện thoại: \t" + txtSDT.Text, new Font("Times New Roman", 15), Brushes.Black, new Point(50, 200));
            e.Graphics.DrawString("Email: \t" + txtEmail.Text, new Font("Times New Roman", 15), Brushes.Black, new Point(50, 225));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------",
                new Font("Times New Roman", 15), Brushes.Black, new Point(25, 250));
            e.Graphics.DrawString("Số tiền thu: " + Convert.ToUInt64(txtTienThu.Text).ToString("###,###,###' 'VNĐ"), new Font("Times New Roman", 15), Brushes.Black, new Point(25, 275));
            e.Graphics.DrawString("** Lưu ý: Phiếu thu tiền chỉ có giá trị trong ngày!", new Font("Times New Roman", 14, FontStyle.Italic), Brushes.Black, new Point(25, 325));

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if(txtMaThu.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phiếu thu.");
                return;
            }
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
