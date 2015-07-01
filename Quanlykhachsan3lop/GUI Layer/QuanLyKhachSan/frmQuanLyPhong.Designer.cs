namespace Quanlykhachsan3lop.Màn_Hình
{
    partial class frmQuanLyPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyPhong));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSoPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkupTangLau = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSoGiuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkupTinhTrangPhong = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMaLoaiPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkupLoaiPhong = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoNguoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkTinhTrangDatPhong = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnXemChiTiet = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ucMenu = new Quanlykhachsan3lop.Màn_Hình.ucMenu();
            this.colGiaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.calSoGiuong = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.calSoNguoi = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.calThongTinPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupTangLau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupTinhTrangPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupLoaiPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkTinhTrangDatPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXemChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSoGiuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSoNguoi)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Location = new System.Drawing.Point(14, 33);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lkupTangLau,
            this.lkupTinhTrangPhong,
            this.lkupLoaiPhong,
            this.btnXemChiTiet,
            this.lkTinhTrangDatPhong,
            this.calSoGiuong,
            this.calSoNguoi});
            this.gridControl1.Size = new System.Drawing.Size(730, 289);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSoPhong,
            this.colTang,
            this.colSoGiuong,
            this.colMaLoaiPhong,
            this.colMaPhong,
            this.colSoNguoi,
            this.calThongTinPhong});
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
            // colSoPhong
            // 
            this.colSoPhong.Caption = "Số Phòng";
            this.colSoPhong.FieldName = "SoPhong";
            this.colSoPhong.Name = "colSoPhong";
            this.colSoPhong.Visible = true;
            this.colSoPhong.VisibleIndex = 2;
            this.colSoPhong.Width = 79;
            // 
            // colTang
            // 
            this.colTang.Caption = "Tầng Lầu";
            this.colTang.ColumnEdit = this.lkupTangLau;
            this.colTang.FieldName = "MaTang";
            this.colTang.Name = "colTang";
            this.colTang.Visible = true;
            this.colTang.VisibleIndex = 4;
            this.colTang.Width = 100;
            // 
            // lkupTangLau
            // 
            this.lkupTangLau.AutoHeight = false;
            this.lkupTangLau.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupTangLau.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaTangLau", "MÃ TẦNG LẦU"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTangLau", "TÊN TẦNG LẦU")});
            this.lkupTangLau.Name = "lkupTangLau";
            this.lkupTangLau.NullText = "[Chọn Tầng Lầu]";
            // 
            // colSoGiuong
            // 
            this.colSoGiuong.Caption = "Số Giường";
            this.colSoGiuong.ColumnEdit = this.calSoGiuong;
            this.colSoGiuong.FieldName = "SoGiuong";
            this.colSoGiuong.Name = "colSoGiuong";
            this.colSoGiuong.Visible = true;
            this.colSoGiuong.VisibleIndex = 5;
            this.colSoGiuong.Width = 124;
            // 
            // lkupTinhTrangPhong
            // 
            this.lkupTinhTrangPhong.AutoHeight = false;
            this.lkupTinhTrangPhong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupTinhTrangPhong.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaTinhTrangPhong", "MÃ TÌNH TRẠNG PHÒNG"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTinhTrangPhong", "TÊN TÌNH TRẠNG PHÒNG")});
            this.lkupTinhTrangPhong.Name = "lkupTinhTrangPhong";
            this.lkupTinhTrangPhong.NullText = "[Chọn tình trạng phòng]";
            // 
            // colMaLoaiPhong
            // 
            this.colMaLoaiPhong.Caption = "Loại Phòng";
            this.colMaLoaiPhong.ColumnEdit = this.lkupLoaiPhong;
            this.colMaLoaiPhong.FieldName = "MaLoaiPhong";
            this.colMaLoaiPhong.Name = "colMaLoaiPhong";
            this.colMaLoaiPhong.Visible = true;
            this.colMaLoaiPhong.VisibleIndex = 3;
            this.colMaLoaiPhong.Width = 143;
            // 
            // lkupLoaiPhong
            // 
            this.lkupLoaiPhong.AutoHeight = false;
            this.lkupLoaiPhong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkupLoaiPhong.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaLoaiPhong", "MÃ LOẠI PHÒNG"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoaiPhong", "TÊN LOẠI PHÒNG")});
            this.lkupLoaiPhong.Name = "lkupLoaiPhong";
            this.lkupLoaiPhong.NullText = "[Chọn loại phòng]";
            // 
            // colMaPhong
            // 
            this.colMaPhong.Caption = "Mã Phòng";
            this.colMaPhong.FieldName = "MaPhong";
            this.colMaPhong.Name = "colMaPhong";
            this.colMaPhong.OptionsColumn.ReadOnly = true;
            this.colMaPhong.Visible = true;
            this.colMaPhong.VisibleIndex = 1;
            this.colMaPhong.Width = 73;
            // 
            // colSoNguoi
            // 
            this.colSoNguoi.Caption = "Số Người";
            this.colSoNguoi.ColumnEdit = this.calSoNguoi;
            this.colSoNguoi.FieldName = "SoNguoi";
            this.colSoNguoi.Name = "colSoNguoi";
            this.colSoNguoi.Visible = true;
            this.colSoNguoi.VisibleIndex = 6;
            this.colSoNguoi.Width = 118;
            // 
            // lkTinhTrangDatPhong
            // 
            this.lkTinhTrangDatPhong.AutoHeight = false;
            this.lkTinhTrangDatPhong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkTinhTrangDatPhong.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaTinhTrangDatPhong", "MÃ TÌNH TRẠNG ĐẶT PHÒNG"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTinhTrangDatPhong", "TÊN TÌNH TRẠNG ĐẶT PHÒNG")});
            this.lkTinhTrangDatPhong.Name = "lkTinhTrangDatPhong";
            this.lkTinhTrangDatPhong.NullText = "[Tình trạng đặt phòng]";
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.AutoHeight = false;
            this.btnXemChiTiet.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Chi Tiết", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnXemChiTiet.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 26);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(758, 336);
            this.layoutControl1.TabIndex = 7;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(758, 336);
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(758, 336);
            this.layoutControlGroup2.Text = "THÔNG TIN PHÒNG";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(734, 293);
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
            this.ucMenu.Size = new System.Drawing.Size(758, 26);
            this.ucMenu.TabIndex = 6;
            // 
            // colGiaPhong
            // 
            this.colGiaPhong.Caption = "Giá Phòng";
            this.colGiaPhong.FieldName = "GiaPhong";
            this.colGiaPhong.Name = "colGiaPhong";
            this.colGiaPhong.Visible = true;
            this.colGiaPhong.VisibleIndex = 4;
            this.colGiaPhong.Width = 90;
            // 
            // calSoGiuong
            // 
            this.calSoGiuong.AutoHeight = false;
            this.calSoGiuong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calSoGiuong.Name = "calSoGiuong";
            // 
            // calSoNguoi
            // 
            this.calSoNguoi.AutoHeight = false;
            this.calSoNguoi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calSoNguoi.Name = "calSoNguoi";
            // 
            // calThongTinPhong
            // 
            this.calThongTinPhong.Caption = "Thông Tin Phòng";
            this.calThongTinPhong.FieldName = "ThongTinPhong";
            this.calThongTinPhong.Name = "calThongTinPhong";
            this.calThongTinPhong.Visible = true;
            this.calThongTinPhong.VisibleIndex = 7;
            // 
            // frmQuanLyPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 362);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ucMenu);
            this.Name = "frmQuanLyPhong";
            this.Text = "Quản Lý Phòng";
            this.Load += new System.EventHandler(this.frmPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupTangLau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupTinhTrangPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkupLoaiPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkTinhTrangDatPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXemChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSoGiuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSoNguoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPhong;
        private DevExpress.XtraGrid.Columns.GridColumn colTang;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkupTangLau;
        private DevExpress.XtraGrid.Columns.GridColumn colSoGiuong;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkupTinhTrangPhong;
        private DevExpress.XtraGrid.Columns.GridColumn colMaLoaiPhong;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkupLoaiPhong;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private ucMenu ucMenu;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnXemChiTiet;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn colMaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn colSoNguoi;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkTinhTrangDatPhong;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit calSoGiuong;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit calSoNguoi;
        private DevExpress.XtraGrid.Columns.GridColumn calThongTinPhong;




    }
}