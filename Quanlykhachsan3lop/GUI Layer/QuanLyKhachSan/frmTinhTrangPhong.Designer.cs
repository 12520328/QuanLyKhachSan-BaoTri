﻿namespace Quanlykhachsan3lop.GUI_Layer.QuanLyKhachSan
{
    partial class frmTinhTrangPhong
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaTinhTrangPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenTinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHinhAnh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.picEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colMauSac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colorTinhTrang = new DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ucMenu = new Quanlykhachsan3lop.Màn_Hình.ucMenu();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorTinhTrang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Location = new System.Drawing.Point(14, 33);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colorTinhTrang,
            this.picEdit});
            this.gridControl1.Size = new System.Drawing.Size(708, 389);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaTinhTrangPhong,
            this.colTenTinhTrang,
            this.colHinhAnh,
            this.colMauSac});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colMaTinhTrangPhong
            // 
            this.colMaTinhTrangPhong.Caption = "Mã Tình Trạng Phòng";
            this.colMaTinhTrangPhong.FieldName = "MaTinhTrangPhong";
            this.colMaTinhTrangPhong.Name = "colMaTinhTrangPhong";
            this.colMaTinhTrangPhong.OptionsColumn.ReadOnly = true;
            this.colMaTinhTrangPhong.Visible = true;
            this.colMaTinhTrangPhong.VisibleIndex = 1;
            this.colMaTinhTrangPhong.Width = 130;
            // 
            // colTenTinhTrang
            // 
            this.colTenTinhTrang.Caption = "Tên Tình Trạng";
            this.colTenTinhTrang.FieldName = "TenTinhTrangPhong";
            this.colTenTinhTrang.Name = "colTenTinhTrang";
            this.colTenTinhTrang.Visible = true;
            this.colTenTinhTrang.VisibleIndex = 2;
            this.colTenTinhTrang.Width = 241;
            // 
            // colHinhAnh
            // 
            this.colHinhAnh.Caption = "Hình Ảnh";
            this.colHinhAnh.ColumnEdit = this.picEdit;
            this.colHinhAnh.FieldName = "HinhAnh";
            this.colHinhAnh.Name = "colHinhAnh";
            this.colHinhAnh.Width = 162;
            // 
            // picEdit
            // 
            this.picEdit.Name = "picEdit";
            this.picEdit.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            this.picEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // colMauSac
            // 
            this.colMauSac.Caption = "Màu Sắc";
            this.colMauSac.ColumnEdit = this.colorTinhTrang;
            this.colMauSac.FieldName = "MauSac";
            this.colMauSac.Name = "colMauSac";
            this.colMauSac.Width = 157;
            // 
            // colorTinhTrang
            // 
            this.colorTinhTrang.AutoHeight = false;
            this.colorTinhTrang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorTinhTrang.Name = "colorTinhTrang";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 26);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(736, 436);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(736, 436);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "THÔNG TIN VẬT TƯ";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(736, 436);
            this.layoutControlGroup2.Text = "THÔNG TIN TÌNH TRẠNG PHÒNG";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(712, 393);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // ucMenu
            // 
            this.ucMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucMenu.Location = new System.Drawing.Point(0, 0);
            this.ucMenu.Name = "ucMenu";
            this.ucMenu.Size = new System.Drawing.Size(736, 26);
            this.ucMenu.TabIndex = 4;
            // 
            // frmTinhTrangPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 462);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ucMenu);
            this.Name = "frmTinhTrangPhong";
            this.Text = "Tình Trạng Phòng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTinhTrangPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorTinhTrang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaTinhTrangPhong;
        private DevExpress.XtraGrid.Columns.GridColumn colTenTinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn colHinhAnh;
        private DevExpress.XtraGrid.Columns.GridColumn colMauSac;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorPickEdit colorTinhTrang;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Màn_Hình.ucMenu ucMenu;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit picEdit;
    }
}