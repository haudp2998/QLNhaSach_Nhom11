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
using static QLNhaSach.frmKhachHang;

namespace QLNhaSach
{
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public class GetMaHD
        {
            public static string getMaHD;
        }
        public void hienthimaKH()
        {
            txtMaKH2.Text = GetMaKH.getMaKH;
            KhachHang kh = KhachHangBUS.GetTenKH(txtMaKH2.Text);
            txtTenKH2.Text = kh.HoTen;
        }
        private void btnMaKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frmKH = new frmKhachHang();
            frmKH.ShowDialog();
            hienthimaKH();
        }

        private void btnbsct_Click(object sender, EventArgs e)
        {
            if (txtMaMoi.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập");
                return;
            }
            for (int i = 0; i < dgvDSHD.Rows.Count; i++)
            {
                if ((string)dgvDSHD.Rows[i].Cells[1].Value == (string)txtMaMoi.Text)
                {
                    GetMaHD.getMaHD = txtMaMoi.Text;
                    GetMaKH.getMaKH = txtMaKH2.Text;
                    frmBanSach frmBS = new frmBanSach();
                    frmBS.ShowDialog();
                    loadDS();
                }
            }
        }
        void loadDS()
        {
            List<HoaDonDTO> dsHD = HoaDonBUS.GetDSHD();
            dgvDSHD.DataSource = dsHD;

            for (int i = 0; i < dgvDSHD.Rows.Count; i++)
            {
                dgvDSHD.Rows[i].Cells[0].Value = i + 1;
            }
            btnThem.Enabled = true;
            btnSua.Enabled = true;

            txtMaMoi.Enabled = true;
            btnLuu.Enabled = false;
        }
        void InsertHD()
        {
            if (txtMaMoi.Text == "" || txtMaKH2.Text == "" || dtpNgayLapHD.Value.Date.ToString() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            string mahd = txtMaMoi.Text;
            string makh = txtMaKH2.Text;
            string tenkh = txtTenKH2.Text;
            int tongtien = 0;
            DateTime ngaynhap = dtpNgayLapHD.Value.Date;
            HoaDonBUS.InsertHD(mahd,makh,tenkh, ngaynhap,tongtien);
            MessageBox.Show("Thêm hoá đơn thành công");

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            InsertHD();
            frmHoaDon_Load(sender,e);
        }
        
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            loadDS();
            txtTongTien.Text = "0";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void timKiem(string tk)
        {
            List<HoaDonDTO> dsKH = HoaDonBUS.TimKiem(tk);
            dgvDSHD.DataSource = dsKH;
            for (int i = 0; i < dgvDSHD.Rows.Count; i++)
            {
                dgvDSHD.Rows[i].Cells[0].Value = i + 1;
            }

        }
        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            string thongtin = txtMaKH.Text;
            timKiem(thongtin);
        }
        void UpdateHD()
        {
            if (txtMaMoi.Text == "" || txtMaKH2.Text == "" || dtpNgayLapHD.Value.Date.ToString() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            string mahd = txtMaMoi.Text;
            string makh = txtMaKH2.Text;
            string tenkh = txtTenKH2.Text;
           
            DateTime ngaynhap = dtpNgayLapHD.Value.Date;
            HoaDonBUS.UpdateHD(mahd,makh,tenkh, ngaynhap);
            MessageBox.Show("Sửa thông tin thành công");
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaMoi.Enabled = false;
        }

        private void dgvDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvDSHD.CurrentRow.Index; //dòng chọn
                
                txtMaMoi.Text = dgvDSHD.Rows[index].Cells[1].Value.ToString();
                txtMaKH2.Text = dgvDSHD.Rows[index].Cells[2].Value.ToString();//1
                txtTenKH2.Text = dgvDSHD.Rows[index].Cells[4].Value.ToString();
                txtTongTien.Text = dgvDSHD.Rows[index].Cells[5].Value.ToString();
                dtpNgayLapHD.Text = dgvDSHD.Rows[index].Cells[3].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            UpdateHD();
            loadDS();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTongTien.Text == "0")
            {
                if (MessageBox.Show("Bạn có chắc muốn xoá hoá đơn này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    HoaDonBUS.DeleteHD(txtMaMoi.Text);
                    MessageBox.Show("Xoá thành công!");
                    loadDS();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng xoá hết sách ra khỏi hoá đơn.");
            }
        }
    }
}
