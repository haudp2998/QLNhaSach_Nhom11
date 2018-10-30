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
    public partial class frmBaoCao2 : Form
    {
        public frmBaoCao2()
        {
            InitializeComponent();
        }
        void LoadDSNo()
        {
            List<BaoCaoNoDTO> dsN = BaoCaoNoBUS.GetDSNo();
            dgvBaoCaoNo.DataSource = dsN;
        }
        private void frmBaoCao2_Load(object sender, EventArgs e)
        {
            LoadDSNo();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            frmReport2 frmRP = new frmReport2();
            frmRP.Show();
        }
    }
}
