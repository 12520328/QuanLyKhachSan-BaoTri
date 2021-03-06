﻿namespace Quanlykhachsan3lop.GUI_Layer.QuanLyHeThong
{
    partial class frmDanhSachNguoiDung
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
            this.ucMenu = new Quanlykhachsan3lop.Màn_Hình.ucMenu();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaNguoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoVaTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNguoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatKhau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdmin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkQuanTriHeThong = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNhanVienLeTan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkNhanVienLeTan = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNguoiDungMoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkNguoiDungMoi = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkQuanTriHeThong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNhanVienLeTan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNguoiDungMoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // ucMenu
            // 
            this.ucMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucMenu.Location = new System.Drawing.Point(0, 0);
            this.ucMenu.Name = "ucMenu";
            this.ucMenu.Size = new System.Drawing.Size(913, 26);
            this.ucMenu.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 26);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(913, 463);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Location = new System.Drawing.Point(14, 33);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.checkQuanTriHeThong,
            this.checkNguoiDungMoi,
            this.checkNhanVienLeTan});
            this.gridControl1.Size = new System.Drawing.Size(885, 416);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaNguoiDung,
            this.colHoVaTen,
            this.colTenNguoiDung,
            this.colMatKhau,
            this.colAdmin,
            this.colNhanVienLeTan,
            this.colNguoiDungMoi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Thêm dòng mới tại đây...";
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colMaNguoiDung
            // 
            this.colMaNguoiDung.Caption = "Mã Người Dùng";
            this.colMaNguoiDung.FieldName = "MaNguoiDung";
            this.colMaNguoiDung.Name = "colMaNguoiDung";
            this.colMaNguoiDung.OptionsColumn.ReadOnly = true;
            this.colMaNguoiDung.Visible = true;
            this.colMaNguoiDung.VisibleIndex = 0;
            this.colMaNguoiDung.Width = 95;
            // 
            // colHoVaTen
            // 
            this.colHoVaTen.Caption = "Họ Và Tên";
            this.colHoVaTen.FieldName = "HoVaTen";
            this.colHoVaTen.Name = "colHoVaTen";
            this.colHoVaTen.Visible = true;
            this.colHoVaTen.VisibleIndex = 1;
            this.colHoVaTen.Width = 119;
            // 
            // colTenNguoiDung
            // 
            this.colTenNguoiDung.Caption = "Tên Người Dùng";
            this.colTenNguoiDung.FieldName = "TenNguoiDung";
            this.colTenNguoiDung.Name = "colTenNguoiDung";
            this.colTenNguoiDung.Visible = true;
            this.colTenNguoiDung.VisibleIndex = 2;
            this.colTenNguoiDung.Width = 117;
            // 
            // colMatKhau
            // 
            this.colMatKhau.Caption = "Mật Khẩu";
            this.colMatKhau.FieldName = "MatKhau";
            this.colMatKhau.Name = "colMatKhau";
            this.colMatKhau.Visible = true;
            this.colMatKhau.VisibleIndex = 3;
            this.colMatKhau.Width = 117;
            // 
            // colAdmin
            // 
            this.colAdmin.Caption = "Quản Trị Hệ Thống";
            this.colAdmin.ColumnEdit = this.checkQuanTriHeThong;
            this.colAdmin.FieldName = "QuanTriHeThong";
            this.colAdmin.Name = "colAdmin";
            this.colAdmin.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colAdmin.Visible = true;
            this.colAdmin.VisibleIndex = 4;
            this.colAdmin.Width = 118;
            // 
            // checkQuanTriHeThong
            // 
            this.checkQuanTriHeThong.AutoHeight = false;
            this.checkQuanTriHeThong.Name = "checkQuanTriHeThong";
            this.checkQuanTriHeThong.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkQuanTriHeThong.CheckedChanged += new System.EventHandler(this.checkQuanTriHeThong_CheckedChanged);
            // 
            // colNhanVienLeTan
            // 
            this.colNhanVienLeTan.Caption = "Nhân Viên Lễ Tân";
            this.colNhanVienLeTan.ColumnEdit = this.checkNhanVienLeTan;
            this.colNhanVienLeTan.FieldName = "NhanVienLeTan";
            this.colNhanVienLeTan.Name = "colNhanVienLeTan";
            this.colNhanVienLeTan.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colNhanVienLeTan.Visible = true;
            this.colNhanVienLeTan.VisibleIndex = 5;
            this.colNhanVienLeTan.Width = 118;
            // 
            // checkNhanVienLeTan
            // 
            this.checkNhanVienLeTan.AutoHeight = false;
            this.checkNhanVienLeTan.Name = "checkNhanVienLeTan";
            this.checkNhanVienLeTan.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkNhanVienLeTan.CheckedChanged += new System.EventHandler(this.checkNhanVienLeTan_CheckedChanged);
            // 
            // colNguoiDungMoi
            // 
            this.colNguoiDungMoi.Caption = "Người Dùng Mới";
            this.colNguoiDungMoi.ColumnEdit = this.checkNguoiDungMoi;
            this.colNguoiDungMoi.FieldName = "NguoiDungMoi";
            this.colNguoiDungMoi.Name = "colNguoiDungMoi";
            this.colNguoiDungMoi.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colNguoiDungMoi.Visible = true;
            this.colNguoiDungMoi.VisibleIndex = 6;
            this.colNguoiDungMoi.Width = 145;
            // 
            // checkNguoiDungMoi
            // 
            this.checkNguoiDungMoi.AutoHeight = false;
            this.checkNguoiDungMoi.Name = "checkNguoiDungMoi";
            this.checkNguoiDungMoi.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkNguoiDungMoi.CheckedChanged += new System.EventHandler(this.checkNguoiDungMoi_CheckedChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(913, 463);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AppearanceGroup.ForeColor = System.Drawing.Color.DodgerBlue;
            this.layoutControlGroup2.AppearanceGroup.Options.UseForeColor = true;
            this.layoutControlGroup2.CustomizationFormText = "Danh Sách Người Dùng";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(913, 463);
            this.layoutControlGroup2.Text = "Danh Sách Người Dùng";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(889, 420);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmDanhSachNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 489);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ucMenu);
            this.Name = "frmDanhSachNguoiDung";
            this.Text = "Danh Sách Người Dùng";
            this.Load += new System.EventHandler(this.frmDanhSachNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkQuanTriHeThong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNhanVienLeTan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkNguoiDungMoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Màn_Hình.ucMenu ucMenu;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNguoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colHoVaTen;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNguoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colMatKhau;
        private DevExpress.XtraGrid.Columns.GridColumn colAdmin;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkQuanTriHeThong;
        private DevExpress.XtraGrid.Columns.GridColumn colNhanVienLeTan;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkNhanVienLeTan;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiDungMoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkNguoiDungMoi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}