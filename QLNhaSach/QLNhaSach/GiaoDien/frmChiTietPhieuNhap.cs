using QLNhaSach.BUS;
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
using static QLNhaSach.frmPhieuNhap;
using static QLNhaSach.frmSach;

namespace QLNhaSach.GiaoDien
{
    public partial class frmChiTietPhieuNhap : Form
    {
        public frmChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        public static int TongTienNhap;
        int flag = -1;
        void loadCTPN()
        {
            txtMaPN.Text = GetMaPN.getMaPN;
            List<CTPhieuNhapDTO> CTPN = CTPhieuNhapBUS.GetCTPN(txtMaPN.Text);
            dgvCTPN.DataSource = CTPN;

            for (int i = 0; i < dgvCTPN.Rows.Count; i++)
            {
                dgvCTPN.Rows[i].Cells[0].Value = i + 1;
                
            }
            
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void frmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            loadCTPN();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                MessageBox.Show("Vui lòng lưu thông tin trước khi thoát.");
                return;
            }
            else this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtMaSach.Text == "")
            {
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá sách này ra khỏi phiếu nhập?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                CTPhieuNhapBUS.DeleteCTPhieuNhap(txtMaPN.Text,txtMaSach.Text);
                MessageBox.Show("Xoá thành công!");
                UpdateTongTien_Xoa_Sua();
                UpdateSoLuongTon_Xoa_Sua();
                loadCTPN();
            }
        }

        private void dgvCTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvCTPN.CurrentRow.Index; //dòng chọn

                txtMaPN.Text = dgvCTPN.Rows[index].Cells[1].Value.ToString();
                txtMaSach.Text = dgvCTPN.Rows[index].Cells[2].Value.ToString();//1
                txtDonGia.Text = dgvCTPN.Rows[index].Cells[4].Value.ToString();
                txtSLnhap.Text = dgvCTPN.Rows[index].Cells[3].Value.ToString();
                txtTongTien.Text = dgvCTPN.Rows[index].Cells[5].Value.ToString();
                txtTenSach.Text = dgvCTPN.Rows[index].Cells[6].Value.ToString();
            }
            catch
            {

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
        void UpdateSoLuongTon()
        {
           // txtMaSach.Text = GetMaSach.getMaSach;
            Sach s = TimSachBUS.getThongTinSach(txtMaSach.Text);
            int check = s.TonCuoi + Int32.Parse(txtSLnhap.Text);
            int tn = Int32.Parse(s.TongNhap) + Int32.Parse(txtSLnhap.Text);
            int tongban = Int32.Parse(s.TongBan);
            int phatsinh = tn - tongban;
            
            int tondau = check - phatsinh;
            TimSachBUS.UpdateSoLuongSach(txtMaSach.Text, check,tondau.ToString(),phatsinh.ToString(),tn.ToString(),tongban.ToString());

        }
        public void UpdateSoLuongTon_Xoa_Sua()
        {
            // txtMaSach.Text = GetMaSach.getMaSach;
            Sach s = TimSachBUS.getThongTinSach(txtMaSach.Text);
            int check = s.TonCuoi - Int32.Parse(txtSLnhap.Text);
            int tn = Int32.Parse(s.TongNhap) - Int32.Parse(txtSLnhap.Text);
            int tongban = Int32.Parse(s.TongBan);
            int phatsinh = tn - tongban;

            int tondau = check - phatsinh;
            TimSachBUS.UpdateSoLuongSach(txtMaSach.Text, check, tondau.ToString(), phatsinh.ToString(), tn.ToString(), tongban.ToString());


        }
        void InsertCT()
        {
            if (txtMaPN.Text == "" || txtMaSach.Text == "" || txtDonGia.Text == "" || txtSLnhap.Text == "" || txtTongTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (IsNumber(txtSLnhap.Text) == false)
            {
                MessageBox.Show("Số lượng phải là số và không được âm", "Thông báo");
                return;
            }
            if (IsNumber(txtDonGia.Text) == false)
            {
                MessageBox.Show("Đơn giá phải là số và không được âm", "Thông báo");
                return;
            }
           
            string mapn = txtMaPN.Text;
            string masach = txtMaSach.Text;
            int dongia = Int32.Parse(txtDonGia.Text);
            int soluong = Int32.Parse(txtSLnhap.Text);
            int tongtien = Int32.Parse(txtTongTien.Text);
            Sach s = TimSachBUS.getThongTinSach(masach);
            QuyDinh qd = QuyDinhBUS.GetQD();
            
            if (s.TonCuoi > Int32.Parse(qd.TonNhapToiThieu))
            {
                MessageBox.Show("Chỉ được nhập sách có số lượng tồn ít hơn " + qd.TonNhapToiThieu);
                return;
            }
            if(soluong < Int32.Parse(qd.NhapToiThieu))
            {
                MessageBox.Show("Số lượng nhập tối thiểu là " + qd.NhapToiThieu);
                return;
            }
            if (CTPhieuNhapBUS.checkTrung(txtMaPN.Text,txtMaSach.Text) == false)
            {
                MessageBox.Show("Sách này đã có trong phiếu nhập");
                return;
            }
            CTPhieuNhapBUS.InsertCTPhieuNhap(mapn, masach, soluong,dongia, tongtien);
            UpdateSoLuongTon();
            UpdateTongTien();
            MessageBox.Show("Thêm sách vào phiếu nhập thành công!");
        }
        public void hienthimaSach()
        {
            txtMaSach.Text = GetMaSach.getMaSach;
            Sach s = TimSachBUS.getThongTinSach(txtMaSach.Text);
            txtTenSach.Text = s.TenSach;
        }
        public void UpdateTongTien()
        {
           // txtMaPN.Text = GetMaPN.getMaPN;
            PhieuNhap pn = PhieuNhapBUS.getThongTinPhieuNhap(txtMaPN.Text);
            TongTienNhap = pn.TongTien + Int32.Parse( txtTongTien.Text);
            PhieuNhapBUS.UpdateTongtien(txtMaPN.Text, TongTienNhap);
        }
        private void btnMaSach_Click(object sender, EventArgs e)
        {
            frmSach frmS = new frmSach();
            frmS.ShowDialog();
            hienthimaSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            InsertCT();
            loadCTPN();
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (IsNumber(txtDonGia.Text) == false)
            {
                MessageBox.Show("Đơn giá phải là số và không được âm", "Thông báo");
                return;
            }
            if (txtDonGia.Text != "" && txtSLnhap.Text != "")
            {
                int tongtien = Int32.Parse(txtSLnhap.Text) * Int32.Parse(txtDonGia.Text);
                txtTongTien.Text = tongtien.ToString();
            }
        }

        private void txtSLnhap_TextChanged(object sender, EventArgs e)
        {
            if (IsNumber(txtSLnhap.Text) == false)
            {
                MessageBox.Show("Số lượng phải là số và không được âm", "Thông báo");
                return;
            }
            if (txtDonGia.Text != "" && txtSLnhap.Text != "")
            {
                int tongtien = Int32.Parse(txtSLnhap.Text) * Int32.Parse(txtDonGia.Text);
                txtTongTien.Text = tongtien.ToString();
            }
        }
        public void UpdateTongTien_Xoa_Sua()
        {
           // txtMaPN.Text = GetMaPN.getMaPN;
            PhieuNhap pn = PhieuNhapBUS.getThongTinPhieuNhap(txtMaPN.Text);
            TongTienNhap = pn.TongTien - Int32.Parse(txtTongTien.Text);
            PhieuNhapBUS.UpdateTongtien(txtMaPN.Text, TongTienNhap);
        }
        void UpdatePhieuNhap()
        {
            if (txtMaPN.Text == "" || txtMaSach.Text == "" || txtDonGia.Text == "" || txtSLnhap.Text == "" || txtTongTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (IsNumber(txtSLnhap.Text) == false)
            {
                MessageBox.Show("Số lượng phải là số và không được âm", "Thông báo");
                return;
            }
            if (IsNumber(txtDonGia.Text) == false)
            {
                MessageBox.Show("Đơn giá phải là số và không được âm", "Thông báo");
                return;
            }

            string mapn = txtMaPN.Text;
            string masach = txtMaSach.Text;
            int dongia = Int32.Parse(txtDonGia.Text);
            int soluong = Int32.Parse(txtSLnhap.Text);
            int tongtien = Int32.Parse(txtTongTien.Text);
            Sach s = TimSachBUS.getThongTinSach(masach);
            QuyDinh qd = QuyDinhBUS.GetQD();

            if (s.TonCuoi > Int32.Parse(qd.TonNhapToiThieu))
            {
                MessageBox.Show("Chỉ được nhập sách có số lượng ít hơn " + qd.TonNhapToiThieu);
                return;
            }
            if (soluong < Int32.Parse(qd.NhapToiThieu))
            {
                MessageBox.Show("Số lượng nhập tối thiểu là " + qd.NhapToiThieu);
                return;
            }
            CTPhieuNhapBUS.UpdateCTPhieuNhap(mapn, masach, soluong, dongia, tongtien);
            UpdateSoLuongTon();
            UpdateTongTien();
            MessageBox.Show("Cập nhật thông tin thành công!");

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text != "")
            {
                UpdateTongTien_Xoa_Sua();
                UpdateSoLuongTon_Xoa_Sua();
                flag = 1;
                txtMaPN.Enabled = false;
                btnThem.Enabled = false;
                btnLuu.Enabled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                UpdatePhieuNhap();
                loadCTPN();
                
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("PHIẾU NHẬP SÁCH", new Font("Times New Roman", 20), Brushes.Black, new Point(300, 25));
            e.Graphics.DrawString("Ngày nhập: " + DateTime.Now, new Font("Times New Roman", 15), Brushes.Black, new Point(275, 75));
            e.Graphics.DrawString("Mã phiếu nhập sách: " + txtMaPN.Text, new Font("Times New Roman", 15), Brushes.Black, new Point(300, 125));
            e.Graphics.DrawString("STT", new Font("Times New Roman", 15), Brushes.Black, new Point(25, 175));
            e.Graphics.DrawString("Mã Sách", new Font("Times New Roman", 15), Brushes.Black, new Point(75, 175));
            e.Graphics.DrawString("Tên Sách", new Font("Times New Roman", 15), Brushes.Black, new Point(200, 175));
           // e.Graphics.DrawString("Tác giả", new Font("Times New Roman", 15), Brushes.Black, new Point(400, 175));
            e.Graphics.DrawString("Số lượng", new Font("Times New Roman", 15), Brushes.Black, new Point(400, 175));
            e.Graphics.DrawString("Đơn giá nhập", new Font("Times New Roman", 15), Brushes.Black, new Point(600, 175));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------",
                new Font("Times New Roman", 15), Brushes.Black, new Point(25, 200));
            int h = 200;
            for (int i = 0; i < dgvCTPN.Rows.Count; i++)
            {
                h += 25;
                e.Graphics.DrawString((i + 1).ToString(), new Font("Times New Roman", 13), Brushes.Black, new Point(25, h));
                e.Graphics.DrawString(dgvCTPN.Rows[i].Cells[2].Value.ToString(), new Font("Times New Roman", 13), Brushes.Black, new Point(75, h));
                e.Graphics.DrawString(dgvCTPN.Rows[i].Cells[6].Value.ToString(), new Font("Times New Roman", 13), Brushes.Black, new Point(200, h));
             //   e.Graphics.DrawString(listSach[i].TacGia, new Font("Times New Roman", 13), Brushes.Black, new Point(400, h));
                e.Graphics.DrawString(dgvCTPN.Rows[i].Cells[3].Value.ToString(), new Font("Times New Roman", 13), Brushes.Black, new Point(400, h));
                e.Graphics.DrawString(dgvCTPN.Rows[i].Cells[4].Value.ToString(), new Font("Times New Roman", 13), Brushes.Black, new Point(600, h));
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------",
                new Font("Times New Roman", 15), Brushes.Black, new Point(25, h + 25));
            PhieuNhap pn = PhieuNhapBUS.getThongTinPhieuNhap(txtMaPN.Text);
            e.Graphics.DrawString("Tổng tiền: " + pn.TongTien.ToString("###,###,###' 'VNĐ"), new Font("Times New Roman", 15), Brushes.Black, new Point(25, h + 75));
            e.Graphics.DrawString("** Lưu ý: Phiếu nhập sách chỉ có giá trị trong ngày!", new Font("Times New Roman", 14, FontStyle.Italic), Brushes.Black, new Point(25, h + 125));

        }

        private void frmChiTietPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnLuu.Enabled == true)
            {
                MessageBox.Show("Vui lòng lưu thông tin trước khi thoát.");
                e.Cancel = true;
            }
         
        }
    }
}
