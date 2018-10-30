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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        int flag = -1;
        void LoadDSKhachHang()
        {
            List<KhachHangDTO> dsS = KhachHangBUS.GetDSKhachHang();
            dgvDSKH.DataSource = dsS;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
          //  btnLuuKhachHang.Enabled = false;
        }
        void InsertKhachHang()
        {
            string makh = txtMaKH.Text;
            string hoten = txtTen.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string tongno = txtTongNo.Text;
            long checkSDT,checkTongNo;
            try
            {
                checkSDT = Int64.Parse(txtSDT.Text);
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Điện thoại phải điền vào số", "Thông báo");
                return;
            }
            try
            {
                checkTongNo = Int64.Parse(txtTongNo.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("Tổng nợ phải điền vào số", "Thông báo");
                return;
            }
            if(makh == "" || hoten == "" || diachi == "" || sdt == "" || email == "" || tongno == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (KhachHangBUS.checkTrung(txtMaKH.Text) == false)
            {
                MessageBox.Show("Mã khách hàng không được trùng");
                return;
            }
            KhachHangBUS.InsertKhachHang(makh, hoten, sdt, diachi, email,tongno);
            MessageBox.Show("Thêm khách hàng thành công");
        }

        public class GetMaKH
        {
            public static string getMaKH;
        }

        void ChangeKhachHang()
        {
            string makh = txtMaKH.Text;
            string hoten = txtTen.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string tongno = txtTongNo.Text;
            long checkSDT, checkTongNo;
            try
            {
                checkSDT = Int64.Parse(txtSDT.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("Điện thoại phải điền vào số", "Thông báo");
                return;
            }
            try
            {
                checkTongNo = Int64.Parse(txtTongNo.Text);

            }
            catch (FormatException)
            {
                MessageBox.Show("Tổng nợ phải điền vào số", "Thông báo");
                return;
            }
             
            if (makh == "" || hoten == "" || diachi == "" || sdt == "" || email == "" || tongno == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            KhachHangBUS.ChangeKhachHang(makh, hoten, sdt, diachi, email,tongno);
            MessageBox.Show("Sửa thông tin khách hàng thành công!");
            
        }
        void timKiem(string tk)
        {
            List<KhachHangDTO> dsKH = KhachHangBUS.TimDSKH(tk);
            dgvDSKH.DataSource = dsKH;

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            InsertKhachHang();
            LoadDSKhachHang();
          
        }

        private void dgvDSKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvDSKH.CurrentRow.Index; //dòng chọn
                txtMaKH.Text = dgvDSKH.Rows[index].Cells[0].Value.ToString();
                txtTen.Text = dgvDSKH.Rows[index].Cells[1].Value.ToString();//1
                txtSDT.Text = dgvDSKH.Rows[index].Cells[2].Value.ToString();
                txtDiaChi.Text = dgvDSKH.Rows[index].Cells[3].Value.ToString();
                txtEmail.Text = dgvDSKH.Rows[index].Cells[4].Value.ToString();
                txtTongNo.Text = dgvDSKH.Rows[index].Cells[5].Value.ToString();

            }
            catch
            {

            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadDSKhachHang();
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xoá khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                KhachHangBUS.DeleteKhachHang(txtMaKH.Text);
                MessageBox.Show("Xoá khách hàng thành công!");
                LoadDSKhachHang();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //ChangeKhachHang();
            //LoadDSKhachHang();
            txtMaKH.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            btnLuuKhachHang.Enabled = true;
            flag = 1;
        }

      

        private void txtTenKhachHang_TextChanged(object sender, EventArgs e)
        {
            string thongtin = txtTenKhachHang.Text;
            timKiem(thongtin);
        }

        private void btnLuuKhachHang_Click(object sender, EventArgs e)
        {
         
             if(flag == 1)
            {
                ChangeKhachHang();
                LoadDSKhachHang();
                txtMaKH.Enabled = true;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnchon_Click(object sender, EventArgs e)
        {

            int index = dgvDSKH.CurrentRow.Index;
            GetMaKH.getMaKH = dgvDSKH.Rows[index].Cells[0].Value.ToString(); 

            this.Close();
        }
    }
}
