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
    public partial class frmReport2 : Form
    {
        public frmReport2()
        {
            InitializeComponent();
        }

        private void frmReport2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataBaoCaoNo.KhachHang' table. You can move, or remove it, as needed.
            this.KhachHangTableAdapter.Fill(this.DataBaoCaoNo.KhachHang);

            this.reportViewer1.RefreshReport();
        }
    }
}
