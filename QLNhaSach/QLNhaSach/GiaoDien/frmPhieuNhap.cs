using QLNhaSach.BUS;
using QLNhaSach.DTO;
using QLNhaSach.GiaoDien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhaSach
{
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
        }
        public class GetMaPN
        {
            public static string getMaPN;
        }
        void LoadDS()
        {
            List<PhieuNhapDTO> dsPN = PhieuNhapBUS.GetDSPN();
            dgvDSPN.DataSource = dsPN;
           
            for (int i = 0; i < dgvDSPN.Rows.Count; i++)
            {
                dgvDSPN.Rows[i].Cells[0].Value = i + 1;
            }
            btnThem.Enabled = true;
            btnSua.Enabled = true;
           
            txtMaNhap.Enabled = true;
            btnLuu.Enabled = false;
        }
      
        
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadDS();
            txtTongTien.Text = "0";
        }
        void InsertPhieuNhap()
        {
            if (txtMaNhap.Text == "" || dtpNgay.Value.Date.ToString() == "" )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            string mapn = txtMaNhap.Text;
            DateTime ngaynhap = dtpNgay.Value.Date;
            
            if (PhieuNhapBUS.checkTrung(txtMaNhap.Text) == false)
            {
                MessageBox.Show("Mã phiếu nhập không được trùng");
                return;
            }
            PhieuNhapBUS.InsertPhieuNhap(mapn,ngaynhap);
            MessageBox.Show("Thêm phiếu nhập thành công");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            InsertPhieuNhap();
            frmPhieuNhap_Load(sender,e);
        }
        void UpdatePhieuNhap()
        {
            if (txtMaNhap.Text == "" || dtpNgay.Value.Date.ToString() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            string mapn = txtMaNhap.Text;
            DateTime ngaynhap = dtpNgay.Value.Date;
            PhieuNhapBUS.UpdatePhieuNhap(mapn, ngaynhap);
            MessageBox.Show("Sửa thông tin thành công");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //UpdatePhieuNhap();
            // LoadDS();
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaNhap.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            UpdatePhieuNhap();
            LoadDS();
        }

        private void btnbsct_Click(object sender, EventArgs e)
        {

            if (txtMaNhap.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập");
                return;
            }
            for (int i = 0; i < dgvDSPN.Rows.Count; i++)
            {
               if( (string) dgvDSPN.Rows[i].Cells[1].Value == (string) txtMaNhap.Text )
                {
                    GetMaPN.getMaPN = txtMaNhap.Text;
                    frmChiTietPhieuNhap frmCTPN = new frmChiTietPhieuNhap();
                    frmCTPN.ShowDialog();
                    LoadDS();
                }

            }
           
        }

        private void dgvDSPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvDSPN.CurrentRow.Index; //dòng chọn


                txtMaNhap.Text = dgvDSPN.Rows[index].Cells[1].Value.ToString();
                dtpNgay.Text = dgvDSPN.Rows[index].Cells[2].Value.ToString();//1
                txtTongTien.Text = dgvDSPN.Rows[index].Cells[3].Value.ToString();
               
               
            }
            catch
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtTongTien.Text == "0")
            {
                if (MessageBox.Show("Bạn có chắc muốn xoá phiếu nhập này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    PhieuNhapBUS.DeletePhieuNhap(txtMaNhap.Text);
                    MessageBox.Show("Xoá thành công!");
                    LoadDS();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng xoá hết sách ra khỏi phiếu nhập.");
            }
        }
    }
}
