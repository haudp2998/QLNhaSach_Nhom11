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
    public partial class frmReport1 : Form
    {
        public frmReport1()
        {
            InitializeComponent();
        }

        private void frmReport1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataBaoCaoTon.Sach' table. You can move, or remove it, as needed.
            this.SachTableAdapter.Fill(this.DataBaoCaoTon.Sach);

            this.reportViewer1.RefreshReport();
        }
    }
}
