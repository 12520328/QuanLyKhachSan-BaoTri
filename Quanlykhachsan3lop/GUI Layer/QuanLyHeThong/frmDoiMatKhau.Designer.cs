namespace Quanlykhachsan3lop.GUI_Layer.QuanLyHeThong
{
    partial class frmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMatKhau));
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.checkHienThiMatKhau = new DevExpress.XtraEditors.CheckEdit();
            this.txtNhapLaiMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.txtMatKhauMoi = new DevExpress.XtraEditors.TextEdit();
            this.txtTenDangNhap = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMatKhauCu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnDoiMatKhau = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.checkHienThiMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhapLaiMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauCu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 161);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(89, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Nhập Lại Mật Khẩu";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 108);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Mật Khẩu Mới";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 56);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên Đăng Nhập";
            // 
            // btnDong
            // 
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.Location = new System.Drawing.Point(283, 192);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 23);
            this.btnDong.TabIndex = 7;
            this.btnDong.Text = "ĐÓNG";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // checkHienThiMatKhau
            // 
            this.checkHienThiMatKhau.Location = new System.Drawing.Point(123, 133);
            this.checkHienThiMatKhau.Name = "checkHienThiMatKhau";
            this.checkHienThiMatKhau.Properties.Caption = "Hiển Thị Mật Khẩu";
            this.checkHienThiMatKhau.Size = new System.Drawing.Size(270, 19);
            this.checkHienThiMatKhau.TabIndex = 4;
            this.checkHienThiMatKhau.CheckedChanged += new System.EventHandler(this.checkHienThiMatKhau_CheckedChanged);
            // 
            // txtNhapLaiMatKhau
            // 
            this.txtNhapLaiMatKhau.Location = new System.Drawing.Point(123, 158);
            this.txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            this.txtNhapLaiMatKhau.Properties.UseSystemPasswordChar = true;
            this.txtNhapLaiMatKhau.Size = new System.Drawing.Size(270, 20);
            this.txtNhapLaiMatKhau.TabIndex = 5;
            this.txtNhapLaiMatKhau.EditValueChanged += new System.EventHandler(this.txtNhapLaiMatKhau_EditValueChanged);
            this.txtNhapLaiMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressed);
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Location = new System.Drawing.Point(123, 105);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Properties.UseSystemPasswordChar = true;
            this.txtMatKhauMoi.Size = new System.Drawing.Size(270, 20);
            this.txtMatKhauMoi.TabIndex = 3;
            this.txtMatKhauMoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressed);
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(123, 53);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Properties.ReadOnly = true;
            this.txtTenDangNhap.Size = new System.Drawing.Size(270, 20);
            this.txtTenDangNhap.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(149, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(129, 23);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "ĐỔI MẬT KHẨU";
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Location = new System.Drawing.Point(123, 79);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Properties.UseSystemPasswordChar = true;
            this.txtMatKhauCu.Size = new System.Drawing.Size(270, 20);
            this.txtMatKhauCu.TabIndex = 2;
            this.txtMatKhauCu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterPressed);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(28, 82);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(61, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Mật Khẩu Cũ";
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Image = ((System.Drawing.Image)(resources.GetObject("btnDoiMatKhau.Image")));
            this.btnDoiMatKhau.Location = new System.Drawing.Point(123, 192);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(109, 23);
            this.btnDoiMatKhau.TabIndex = 6;
            this.btnDoiMatKhau.Text = "ĐỔI MẬT KHẨU";
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(424, 236);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtMatKhauCu);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnDoiMatKhau);
            this.Controls.Add(this.checkHienThiMatKhau);
            this.Controls.Add(this.txtNhapLaiMatKhau);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.labelControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(424, 236);
            this.MinimumSize = new System.Drawing.Size(424, 236);
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi Mật Khẩu";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkHienThiMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhapLaiMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhauCu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.CheckEdit checkHienThiMatKhau;
        private DevExpress.XtraEditors.TextEdit txtNhapLaiMatKhau;
        private DevExpress.XtraEditors.TextEdit txtMatKhauMoi;
        private DevExpress.XtraEditors.TextEdit txtTenDangNhap;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtMatKhauCu;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnDoiMatKhau;
    }
}