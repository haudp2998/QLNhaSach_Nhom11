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

namespace QLNhaSach
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        int flag = -1;
        void LoadDSNhanVien()
        {
            List<NhanVienDTO> dsNV = NhanVienBUS.GetDSNhanVien();
            dgvDSNV.DataSource = dsNV;
            btnLuuNhanVien.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true; 
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            
            LoadDSNhanVien();
           
        }
        void InsertNhanVien()
        {
            string email = txtEmailNV.Text;
            string hoten = txtHoTenNV.Text;
            string diachi = txtDiaChiNV.Text;
            string sdt = txtSDTNV.Text;
            string password = txtMatKhau.Text;
            long check ;
            try
            {
                check = Int64.Parse(txtSDTNV.Text); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Điện thoại phải điền vào số", "Thông báo");
                return;
            }
            if(email == "" || hoten == "" || diachi == "" || sdt == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy dủ thông tin.");
                return;
            }
            if (NhanVienBUS.checkTrung(txtEmailNV.Text) == false)
            {
                MessageBox.Show("Email nhân viên không được trùng");
                return;
            }
            NhanVienBUS.InsertNhanVien(email, hoten, diachi, sdt, password);
            MessageBox.Show("Thêm nhân viên thành công");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            InsertNhanVien();
            LoadDSNhanVien();
        }

        private void dgvDSNV_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDSNV.SelectedRows.Count > 0)
            {
                txtEmailNV.Text = dgvDSNV.SelectedRows[0].Cells[0].Value.ToString();
                txtHoTenNV.Text = dgvDSNV.SelectedRows[0].Cells[1].Value.ToString();
                txtDiaChiNV.Text = dgvDSNV.SelectedRows[0].Cells[2].Value.ToString();
                txtSDTNV.Text = dgvDSNV.SelectedRows[0].Cells[3].Value.ToString();
                txtMatKhau.Text = dgvDSNV.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá nhân viên này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {

                NhanVienBUS.DeleteNhanVien(txtEmailNV.Text);
                MessageBox.Show("Xoá nhân viên thành công!");
                LoadDSNhanVien();
            }
        }
        void UpdateNhanVien()
        {
            string email = txtEmailNV.Text;
            string hoten = txtHoTenNV.Text;
            string diachi = txtDiaChiNV.Text;
            string sdt = txtSDTNV.Text;
            string password = txtMatKhau.Text;
            long check;
            try
            {
                check = Int64.Parse(txtSDTNV.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Điện thoại phải điền vào số", "Thông báo");
                return;
            }
            if (email == "" || hoten == "" || diachi == "" || sdt == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy dủ thông tin.");
                return;
            }
            NhanVienBUS.UpdateNhanVien(email, hoten, diachi, sdt, password);
            MessageBox.Show("Sửa thông tin nhân viên thành công");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtEmailNV.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            flag = 1;
            btnLuuNhanVien.Enabled = true;
            //UpdateNhanVien();
            //LoadDSNhanVien();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvDSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLuuNhanVien_Click(object sender, EventArgs e)
        {
           
            if(flag == 1)
            {
                UpdateNhanVien();
                LoadDSNhanVien();
                txtEmailNV.Enabled = true;
            }
        }
    }
}
