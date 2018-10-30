namespace QLNhaSach
{
    partial class frmReport1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataBaoCaoTon = new QLNhaSach.DataBaoCaoTon();
            this.SachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SachTableAdapter = new QLNhaSach.DataBaoCaoTonTableAdapters.SachTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataBaoCaoTon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SachBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SachBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNhaSach.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(646, 418);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataBaoCaoTon
            // 
            this.DataBaoCaoTon.DataSetName = "DataBaoCaoTon";
            this.DataBaoCaoTon.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SachBindingSource
            // 
            this.SachBindingSource.DataMember = "Sach";
            this.SachBindingSource.DataSource = this.DataBaoCaoTon;
            // 
            // SachTableAdapter
            // 
            this.SachTableAdapter.ClearBeforeFill = true;
            // 
            // frmReport1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 418);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReport1";
            this.Text = "frmReport1";
            this.Load += new System.EventHandler(this.frmReport1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataBaoCaoTon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SachBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SachBindingSource;
        private DataBaoCaoTon DataBaoCaoTon;
        private DataBaoCaoTonTableAdapters.SachTableAdapter SachTableAdapter;
    }
}