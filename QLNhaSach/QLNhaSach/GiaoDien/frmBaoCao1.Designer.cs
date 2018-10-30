namespace QLNhaSach
{
    partial class frmBaoCao1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao1));
            this.label62 = new System.Windows.Forms.Label();
            this.btnXuat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvBaoCaoTon = new System.Windows.Forms.DataGridView();
            this.MaSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phatsinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toncuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoTon)).BeginInit();
            this.SuspendLayout();
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label62.Location = new System.Drawing.Point(12, 124);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(108, 32);
            this.label62.TabIndex = 9;
            this.label62.Text = "Báo cáo tồn kho:\r\n\r\n";
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnXuat.Image")));
            this.btnXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXuat.Location = new System.Drawing.Point(495, 347);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(152, 42);
            this.btnXuat.TabIndex = 6;
            this.btnXuat.Text = "IN BÁO CÁO";
            this.btnXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXuat.UseVisualStyleBackColor = false;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(301, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "BÁO CÁO TỒN KHO";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 88);
            this.panel1.TabIndex = 33;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(660, 347);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(123, 42);
            this.btnThoat.TabIndex = 35;
            this.btnThoat.Text = "  THOÁT  ";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvBaoCaoTon
            // 
            this.dgvBaoCaoTon.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvBaoCaoTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoTon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSach,
            this.ts,
            this.ton,
            this.TongNhap,
            this.TongBan,
            this.phatsinh,
            this.toncuoi});
            this.dgvBaoCaoTon.Location = new System.Drawing.Point(12, 159);
            this.dgvBaoCaoTon.Name = "dgvBaoCaoTon";
            this.dgvBaoCaoTon.Size = new System.Drawing.Size(763, 182);
            this.dgvBaoCaoTon.TabIndex = 36;
            this.dgvBaoCaoTon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBaoCaoTon_CellContentClick);
            // 
            // MaSach
            // 
            this.MaSach.DataPropertyName = "MaSach";
            this.MaSach.HeaderText = "Mã sách";
            this.MaSach.Name = "MaSach";
            // 
            // ts
            // 
            this.ts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ts.DataPropertyName = "TenSach";
            this.ts.HeaderText = "Tên Sách";
            this.ts.Name = "ts";
            // 
            // ton
            // 
            this.ton.DataPropertyName = "TonDau";
            this.ton.HeaderText = "Tồn Đầu";
            this.ton.Name = "ton";
            // 
            // TongNhap
            // 
            this.TongNhap.DataPropertyName = "TongNhap";
            this.TongNhap.HeaderText = "Tổng nhập";
            this.TongNhap.Name = "TongNhap";
            // 
            // TongBan
            // 
            this.TongBan.DataPropertyName = "TongBan";
            this.TongBan.HeaderText = "Tổng bán";
            this.TongBan.Name = "TongBan";
            // 
            // phatsinh
            // 
            this.phatsinh.DataPropertyName = "PhatSinh";
            this.phatsinh.HeaderText = "Phát sinh";
            this.phatsinh.Name = "phatsinh";
            // 
            // toncuoi
            // 
            this.toncuoi.DataPropertyName = "TonCuoi";
            this.toncuoi.HeaderText = "Tồn cuối";
            this.toncuoi.Name = "toncuoi";
            // 
            // frmBaoCao1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 401);
            this.Controls.Add(this.dgvBaoCaoTon);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.btnXuat);
            this.Name = "frmBaoCao1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ - BÁO CÁO";
            this.Load += new System.EventHandler(this.frmBaoCao1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoTon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvBaoCaoTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn ts;
        private System.Windows.Forms.DataGridViewTextBoxColumn ton;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn phatsinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn toncuoi;
    }
}