using QLNhaSach.BUS;
using QLNhaSach.DTO;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QLNhaSach.frmKhachHang;
using static QLNhaSach.frmSach;
using static QLNhaSach.frmHoaDon;

namespace QLNhaSach
{
    public partial class frmBanSach : Form
    {
        public frmBanSach()
        {
            InitializeComponent();
        }
        int flag = -1;
        public static string makh;
        public static int TongTienNhap;
        void LoadDS()
        {
           
            List<BanSachDTO> dsHD = BanSachBUS.GetDSHoaDon(txtMaMoi.Text);
            dgvDSHD.DataSource = dsHD;
            
            for (int i = 0; i < dgvDSHD.Rows.Count; i++)
            {
                dgvDSHD.Rows[i].Cells[0].Value = i + 1;
            }
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }
     
        private void frmBanSach_Load(object sender, EventArgs e)
        {
            txtMaKH2.Text = GetMaKH.getMaKH;
            txtMaMoi.Text = GetMaHD.getMaHD;
            KhachHang kh = KhachHangBUS.GetTenKH(txtMaKH2.Text);
            txtTenKH2.Text = kh.HoTen;

            LoadDS();
           
        }
        void UpdateSoLuongTon()
        {
           // txtMaSach.Text = GetMaSach.getMaSach;
            Sach s = TimSachBUS.getThongTinSach(txtMaSach.Text);
            int check = s.TonCuoi - Int32.Parse(txtSoLuong.Text);
            int tb = Int32.Parse(s.TongBan) + Int32.Parse(txtSoLuong.Text);
            int tn = Int32.Parse(s.TongNhap);
            int phatsinh = tn - tb;
            int tondau = check - phatsinh;

            TimSachBUS.UpdateSoLuongSach(txtMaSach.Text, check, tondau.ToString(), phatsinh.ToString(), tn.ToString(), tb.ToString());

        }


        public void hienthimaSach()
        {
            txtMaSach.Text = GetMaSach.getMaSach;
            Sach s = TimSachBUS.getThongTinSach(txtMaSach.Text);
            txtTenSach.Text = s.TenSach;
            txtDonGia.Text = s.DonGia.ToString();
        }
        private void btnMaSach_Click(object sender, EventArgs e)
        {
            frmSach frmS = new frmSach();
            frmS.ShowDialog();
            hienthimaSach();
        }
        void InsertHoaDon()
        {
            if (txtMaKH2.Text == "" || txtMaMoi.Text == "" || txtMaSach.Text == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (IsNumber(txtSoLuong.Text) == false)
            {
                MessageBox.Show("Số lượng phải là số và không được âm", "Thông báo");
                return;
            }
            string mahd = txtMaMoi.Text;
            
            string masach = txtMaSach.Text;
            int soluong = Int32.Parse(txtSoLuong.Text);
           
            Sach s = TimSachBUS.getThongTinSach(masach);
            QuyDinh qd = QuyDinhBUS.GetQD();
            int check = s.TonCuoi - soluong;
            if (check < Int32.Parse( qd.TonBanToiThieu))
            {
                MessageBox.Show("Số lượng tồn của sách này sau khi bán đã nhỏ hơn quy định");
                return;
            }
            KhachHang kh = KhachHangBUS.GetTenKH(txtMaKH2.Text);
            if (Int32.Parse(kh.TongNo) > qd.KHNoToiThieu)
            {
                MessageBox.Show("Tiền nợ của khách hàng đã vượt quá quy định");
                return;
            }
            if (BanSachBUS.checkTrung(txtMaMoi.Text,txtMaSach.Text) == false)
            {
                MessageBox.Show("Sách này đã có trong hoá đơn");
                return;
            }
            BanSachBUS.InsertHoaDon(mahd, masach, soluong);
            UpdateSoLuongTon();
            UpdateTongTien();
            MessageBox.Show("Thêm hoá đơn thành công!");
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
             InsertHoaDon(); 
             LoadDS();
        
        }
        void UpdateSoLuongTon_Xoa_Sua()
        {
            Sach s = TimSachBUS.getThongTinSach(txtMaSach.Text);
            int check = s.TonCuoi + Int32.Parse(txtSoLuong.Text);
            int tb = Int32.Parse(s.TongBan) - Int32.Parse(txtSoLuong.Text);
            int tn = Int32.Parse(s.TongNhap);
            int phatsinh = tn-tb;
            int tondau = check - phatsinh;
            
            TimSachBUS.UpdateSoLuongSach(txtMaSach.Text, check,tondau.ToString(),phatsinh.ToString(),tn.ToString(),tb.ToString());
            
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtMaSach.Text == "")
            {
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá hoá đơn này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                BanSachBUS.DeleteHoaDon(txtMaMoi.Text,txtMaSach.Text);
                MessageBox.Show("Xoá hoá đơn thành công!");
                UpdateSoLuongTon_Xoa_Sua();
                UpdateTongTien_Xoa_Sua();
                LoadDS();
            }
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvDSHD.CurrentRow.Index; //dòng chọn
               
                txtMaSach.Text = dgvDSHD.Rows[index].Cells[1].Value.ToString();//1
                txtTenSach.Text = dgvDSHD.Rows[index].Cells[2].Value.ToString();
                txtDonGia.Text = dgvDSHD.Rows[index].Cells[3].Value.ToString();
                txtSoLuong.Text = dgvDSHD.Rows[index].Cells[4].Value.ToString();
                int tongtien = Int32.Parse(txtSoLuong.Text) * Int32.Parse(txtDonGia.Text);
                txtTongTien.Text = tongtien.ToString("###,###,###' 'VNĐ");
            }
            catch
            {

            }
        }
        void UpdateHoaDon()
        {
            if (txtMaKH2.Text == "" || txtMaMoi.Text == "" || txtMaSach.Text == "" || txtSoLuong.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (IsNumber(txtSoLuong.Text) == false)
            {
                MessageBox.Show("Số lượng phải là số và không được âm", "Thông báo");
                return;
            }
            string mahd = txtMaMoi.Text;
           // string makh = txtMaKH2.Text;
            string masach = txtMaSach.Text;
            int soluong = Int32.Parse(txtSoLuong.Text);
           
            Sach s = TimSachBUS.getThongTinSach(masach);
            QuyDinh qd = QuyDinhBUS.GetQD();
            int check = s.TonCuoi - soluong;
            if (check < Int32.Parse(qd.TonBanToiThieu))
            {
                MessageBox.Show("Số lượng tồn của sách này sau khi bán đã nhỏ hơn quy định");
                return;
            }
            KhachHang kh = KhachHangBUS.GetTenKH(txtMaKH2.Text);
            if (Int32.Parse(kh.TongNo) > qd.KHNoToiThieu)
            {
                MessageBox.Show("Tiền nợ của khách hàng đã vượt quá quy định");
                return;
            }
            BanSachBUS.UpdateHoaDon(mahd, masach, soluong);
            UpdateSoLuongTon();
            UpdateTongTien();
            MessageBox.Show("Sửa hoá đơn thành công");
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            //UpdateHoaDon();
            //LoadDS();
            if (txtMaSach.Text != "")
            {
                UpdateSoLuongTon_Xoa_Sua();
                UpdateTongTien_Xoa_Sua();
                flag = 1;
                txtMaMoi.Enabled = false;
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
            }
        }
      
     

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
             if (flag == 1)
            {
                
                UpdateHoaDon();
               
                LoadDS();
                txtMaMoi.Enabled = true;
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
           
            if (txtSoLuong.Text != "")
            {
                int tongtien = Int32.Parse(txtSoLuong.Text) * Int32.Parse(txtDonGia.Text);
                txtTongTien.Text = tongtien.ToString("###,###,###' 'VNĐ");
            }
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
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (IsNumber(txtSoLuong.Text) == false)
            {
                MessageBox.Show("Số lượng phải là số và không được âm", "Thông báo");
                return;
            }
            if (txtSoLuong.Text != "")
            {
                int tongtien = Int32.Parse(txtSoLuong.Text) * Int32.Parse(txtDonGia.Text);
                txtTongTien.Text = tongtien.ToString("###,###,###' 'VNĐ");
            }
        }
        public void UpdateTongTien()
        {
            // txtMaPN.Text = GetMaPN.getMaPN;
            HoaDon hd = HoaDonBUS.getThongTinHD(txtMaMoi.Text);
            TongTienNhap = (int) hd.TongTien + (Int32.Parse(txtDonGia.Text) * Int32.Parse(txtSoLuong.Text));
            HoaDonBUS.UpdateTongtien(txtMaMoi.Text, TongTienNhap);
        }
        public void UpdateTongTien_Xoa_Sua()
        {
            // txtMaPN.Text = GetMaPN.getMaPN;
            HoaDon hd = HoaDonBUS.getThongTinHD(txtMaMoi.Text);
            TongTienNhap = (int)hd.TongTien - (Int32.Parse(txtDonGia.Text) * Int32.Parse(txtSoLuong.Text));
            HoaDonBUS.UpdateTongtien(txtMaMoi.Text, TongTienNhap);
        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        { 
            e.Graphics.DrawString("HÓA ĐƠN", new Font("Times New Roman", 20), Brushes.Black, new Point(325, 25));
            e.Graphics.DrawString("Họ tên khách hàng: " + txtTenKH2.Text, new Font("Times New Roman", 15), Brushes.Black, new Point(25, 75));
            e.Graphics.DrawString("Ngày nhập: " + DateTime.Now, new Font("Times New Roman", 15), Brushes.Black, new Point(500, 75));
            e.Graphics.DrawString("Mã hóa đơn: " + txtMaMoi.Text, new Font("Times New Roman", 15), Brushes.Black, new Point(300, 125));
            e.Graphics.DrawString("STT", new Font("Times New Roman", 15), Brushes.Black, new Point(25, 175));
            e.Graphics.DrawString("Tên Sách", new Font("Times New Roman", 15), Brushes.Black, new Point(100, 175));
          //  e.Graphics.DrawString("Thể loại", new Font("Times New Roman", 15), Brushes.Black, new Point(350, 175));
            e.Graphics.DrawString("Số lượng", new Font("Times New Roman", 15), Brushes.Black, new Point(550, 175));
            e.Graphics.DrawString("Đơn giá bán", new Font("Times New Roman", 15), Brushes.Black, new Point(700, 175));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------",
                new Font("Times New Roman", 15), Brushes.Black, new Point(25, 200));
            int h = 200;
            for (int i = 0; i < dgvDSHD.Rows.Count; i++)
            {
                h += 25;
                e.Graphics.DrawString((i + 1).ToString(), new Font("Times New Roman", 15), Brushes.Black, new Point(25, h));
                e.Graphics.DrawString(dgvDSHD.Rows[i].Cells[2].Value.ToString(), new Font("Times New Roman", 15), Brushes.Black, new Point(100, h));
              //  e.Graphics.DrawString(listSach[i].TheLoai, new Font("Times New Roman", 15), Brushes.Black, new Point(350, h));
                e.Graphics.DrawString(dgvDSHD.Rows[i].Cells[4].Value.ToString(), new Font("Times New Roman", 15), Brushes.Black, new Point(550, h));
                e.Graphics.DrawString(dgvDSHD.Rows[i].Cells[3].Value.ToString(), new Font("Times New Roman", 15), Brushes.Black, new Point(700, h));
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------",
                new Font("Times New Roman", 15), Brushes.Black, new Point(25, h + 25));
            HoaDon hd = HoaDonBUS.getThongTinHD(txtMaMoi.Text);
            int hh = (int) hd.TongTien;
            e.Graphics.DrawString("Tổng tiền: " + hh.ToString("###,###,###' 'VNĐ"), new Font("Times New Roman", 15), Brushes.Black, new Point(25, h + 75));
            
            e.Graphics.DrawString("** Lưu ý: Hóa đơn chỉ có giá trị trong ngày!", new Font("Times New Roman", 14, FontStyle.Italic), Brushes.Black, new Point(25, h + 225));
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                MessageBox.Show("Vui lòng lưu thông tin trước khi thoát.");
                return;
            }
        }

        private void frmBanSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(btnLuu.Enabled == true)
            {
                MessageBox.Show("Vui lòng lưu thông tin trước khi thoát.");
                e.Cancel = true;
            }
        }
    }
}
