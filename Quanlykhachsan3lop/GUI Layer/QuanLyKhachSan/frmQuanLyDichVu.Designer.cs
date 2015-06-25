namespace Quanlykhachsan3lop.GUI_Layer
{
    partial class frmQuanLyDichVu
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhomDichVu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkupNhomDichVu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDonViTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkupDonViTinh = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colDonGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.calDonGia = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ucMenu = new Quanlykhachsan3lop.Màn_Hình.ucMenu();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupNhomDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupDonViTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 26);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(663, 437);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Location = new System.Drawing.Point(14, 33);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lkupNhomDichVu,
            this.lkupDonViTinh,
            this.calDonGia});
            this.gridControl1.Size = new System.Drawing.Size(635, 390);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaDichVu,
            this.colTenDichVu,
            this.colNhomDichVu,
            this.colDonViTinh,
            this.colDonGia});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
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
            // colMaDichVu
            // 
            this.colMaDichVu.Caption = "Mã Dịch Vụ";
            this.colMaDichVu.FieldName = "MaDichVu";
            this.colMaDichVu.Name = "colMaDichVu";
            this.colMaDichVu.OptionsColumn.ReadOnly = true;
            this.colMaDichVu.Visible = true;
            this.colMaDichVu.VisibleIndex = 1;
            this.colMaDichVu.Width = 65;
            // 
            // colTenDichVu
            // 
            this.colTenDichVu.Caption = "Tên Dịch Vụ";
            this.colTenDichVu.FieldName = "TenDichVu";
            this.colTenDichVu.Name = "colTenDichVu";
            this.colTenDichVu.Visible = true;
            this.colTenDichVu.VisibleIndex = 2;
            this.colTenDichVu.Width = 105;
            // 
            // colNhomDichVu
            // 
            this.colNhomDichVu.Caption = "Nhóm Dịch Vụ";
            this.colNhomDichVu.ColumnEdit = this.lkupNhomDichVu;
            this.colNhomDichVu.FieldName = "NhomDichVu";
            this.colNhomDichVu.Name = "colNhomDichVu";
            this.colNhomDichVu.Visible = true;
            this.colNhomDichVu.VisibleIndex = 3;
            this.colNhomDichVu.Width = 105;
            // 
            // lkupNhomDichVu
            // 
            this.lkupNhomDichVu.AutoHeight = false;
            this.lkupNhomDichVu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupNhomDichVu.Name = "lkupNhomDichVu";
            this.lkupNhomDichVu.NullText = "[Chọn Nhóm Dịch Vụ]";
            // 
            // colDonViTinh
            // 
            this.colDonViTinh.Caption = "Đơn Vị Tính";
            this.colDonViTinh.ColumnEdit = this.lkupDonViTinh;
            this.colDonViTinh.FieldName = "MaDonViTinh";
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.Visible = true;
            this.colDonViTinh.VisibleIndex = 4;
            this.colDonViTinh.Width = 125;
            // 
            // lkupDonViTinh
            // 
            this.lkupDonViTinh.AutoHeight = false;
            this.lkupDonViTinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupDonViTinh.Name = "lkupDonViTinh";
            this.lkupDonViTinh.NullText = "[Chọn Đơn Vị Tính]";
            // 
            // colDonGia
            // 
            this.colDonGia.Caption = "Đơn Giá";
            this.colDonGia.ColumnEdit = this.calDonGia;
            this.colDonGia.FieldName = "DonGia";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.Visible = true;
            this.colDonGia.VisibleIndex = 5;
            this.colDonGia.Width = 118;
            // 
            // calDonGia
            // 
            this.calDonGia.AutoHeight = false;
            this.calDonGia.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calDonGia.Name = "calDonGia";
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(663, 437);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "THÔNG TIN LOẠI GIÁ";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(663, 437);
            this.layoutControlGroup2.Text = "THÔNG TIN DỊCH VỤ";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(639, 394);
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
            this.ucMenu.Size = new System.Drawing.Size(663, 26);
            this.ucMenu.TabIndex = 2;
            // 
            // frmQuanLyDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 463);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ucMenu);
            this.Name = "frmQuanLyDichVu";
            this.Text = "Quản Lý Dịch Vụ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQuanLyDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupNhomDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupDonViTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDichVu;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Màn_Hình.ucMenu ucMenu;
        private DevExpress.XtraGrid.Columns.GridColumn colNhomDichVu;
        private DevExpress.XtraGrid.Columns.GridColumn colDonViTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colDonGia;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkupNhomDichVu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkupDonViTinh;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit calDonGia;
    }
}