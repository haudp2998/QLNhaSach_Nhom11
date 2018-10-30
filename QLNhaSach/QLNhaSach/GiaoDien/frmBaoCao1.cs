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
    public partial class frmBaoCao1 : Form
    {
        public frmBaoCao1()
        {
            InitializeComponent();
        }
        void LoadDSTon()
        {
            List<BaoCaoTonDTO> dsT = BaoCaoTonBUS.GetDSTon();
            dgvBaoCaoTon.DataSource = dsT;
        }
        private void frmBaoCao1_Load(object sender, EventArgs e)
        {
            LoadDSTon();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            frmReport1 frmRP = new frmReport1();
            frmRP.Show();
        }

        private void dgvBaoCaoTon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
