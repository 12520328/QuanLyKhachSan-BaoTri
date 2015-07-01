using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Quanlykhachsan3lop.Business_Logic_Layer;
using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyKhachSan
{
    public partial class frmQuanLySuDungVatTu : Form
    {
        DataTable dt = new DataTable();
        QuanLyVatTuBUS quanLyVatTuBUS = new QuanLyVatTuBUS();
        QuanLyVatTuDTO quanLyVatTuDTO = new QuanLyVatTuDTO();

        public frmQuanLySuDungVatTu()
        {
            InitializeComponent();

            //Định nghĩa cấu trúc bảng KhachHang
            dt.Columns.Add("MaQuanLyVatTu", typeof(int));
            dt.Columns.Add("MaLoaiPhong", typeof(int));
            dt.Columns.Add("MaVatTu", typeof(int));
            dt.Columns.Add("SoNguoi", typeof(int));
            dt.Columns.Add("GhiChu", typeof(string));

            ucMenu.btnXoa.Enabled = false;
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadDuLieu();

            // Bắt sự kiện cho các button trong user control.
            ucMenu.btnChiDoc.ItemClick += ucMenu_ChiDoc_Clicked;
            ucMenu.btnXoa.ItemClick += ucMenu_Xoa_Clicked;
            ucMenu.btnLamMoi.ItemClick += ucMenu_LamMoi_Clicked;
            ucMenu.btnIn.ItemClick += ucMenu_In_Clicked;
            ucMenu.btnXuat.ItemClick += ucMenu_Xuat_Clicked;
            ucMenu.btnDong.ItemClick += ucMenu_Dong_Clicked;

            LayDanhSachLoaiPhong();
            LayDanhSachVatTu();
        }

        private void LoadDuLieu()
        {
            dt.Clear();
            dt = quanLyVatTuBUS.LayDanhSachQuanLyVatTu();
            gridControl1.DataSource = dt;
        }

        #region "Xử lý sự kiện button menu"
        private void ucMenu_Dong_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ucMenu_Xuat_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ExportXls(gridControl1, "DANH SÁCH QUẢN LÝ SỬ DỤNG VẬT TƯ");
        }

        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridControl1, "DANH SÁCH QUẢN LÝ SỬ DỤNG VẬT TƯ");
        }

        private void ucMenu_LamMoi_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDuLieu();
        }

        private void ucMenu_ChiDoc_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.OptionsBehavior.ReadOnly == true)
            {
                ucMenu.btnChiDoc.Caption = "ĐANG Ở CHẾ ĐỘ CHỈNH SỬA";
                ucMenu.btnChiDoc.LargeGlyph = Quanlykhachsan3lop.Properties.Resources.edit;
                ucMenu.btnChiDoc.Glyph = Quanlykhachsan3lop.Properties.Resources.edit;
                gridView1.OptionsBehavior.ReadOnly = false;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            }
            else
            {
                ucMenu.btnChiDoc.Caption = "ĐANG Ở CHẾ ĐỘ CHỈ ĐỌC";
                ucMenu.btnChiDoc.LargeGlyph = Quanlykhachsan3lop.Properties.Resources.old_edit_find;
                ucMenu.btnChiDoc.Glyph = Quanlykhachsan3lop.Properties.Resources.old_edit_find;
                gridView1.OptionsBehavior.ReadOnly = true;
                gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
        }
        #endregion

        #region "Kiểm tra dữ liệu nhập"
        
        //Dữ liệu nhập không được để trống
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.ClearColumnErrors();
            foreach (GridColumn col in ((ColumnView)view).Columns)
            {
                if (col.FieldName != "MaQuanLyVatTu"  && col.FieldName != "GhiChu")
                {
                    if (view.GetRowCellValue(e.RowHandle, col) == null || string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, col).ToString()))
                    {
                        e.Valid = false;
                        e.ErrorText = "Giá trị không được để trống";
                        view.SetColumnError(col, e.ErrorText);
                    }
                }
            }

        }

        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            XtraMessageBox.Show(e.ErrorText, "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region "Thêm, Sữa dữ liệu"
        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (e.RowHandle == GridControl.NewItemRowHandle)
            {
                DataRow newDr = gridView1.GetDataRow(gridView1.DataRowCount - 1);
                if (quanLyVatTuBUS.Insert(GetKhachHang(newDr)))
                {
                    XtraMessageBox.Show("Thêm mới thành công.", "Thông Báo");
                }
            }
            else
            {
                DialogResult dg = MessageBox.Show("Bạn có chắc muốn sửa dòng này không ? ", "Sửa dữ liệu", MessageBoxButtons.OKCancel);
                if (dg == DialogResult.Cancel)
                {
                    LoadDuLieu();
                    return;
                }
                DataRow dr = gridView1.GetDataRow(e.RowHandle);
                if (quanLyVatTuBUS.Update(GetKhachHang(dr)))
                {
                    XtraMessageBox.Show("Cập nhật thành công.", "Thông Báo");
                }
            }
            LoadDuLieu();
        }

        private void ucMenu_Xoa_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa dòng này không? ", "Xóa dữ liệu", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.Cancel)
            {
                return;
            }
            int[] selectIndexs = gridView1.GetSelectedRows();
            for (int i = 0; i < selectIndexs.Length; i++)
            {
                int maKH = int.Parse(gridView1.GetRowCellValue(i, colMaQuanLyVatTu).ToString());
                quanLyVatTuBUS.Delete(maKH);
            }
            XtraMessageBox.Show("Xóa dữ liệu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDuLieu();
        }

        private QuanLyVatTuDTO GetKhachHang(DataRow dr)
        {
            if (dr == null)
                return null;
            QuanLyVatTuDTO _quanLyVatTu = new QuanLyVatTuDTO();
            _quanLyVatTu.MaQuanLyVatTu = string.IsNullOrEmpty(dr["MaQuanLyVatTu"].ToString())  ? -1 : int.Parse(dr["MaQuanLyVatTu"].ToString());
            _quanLyVatTu.MaLoaiPhong = int.Parse(dr["MaLoaiPhong"].ToString());
            _quanLyVatTu.MaVatTu = int.Parse(dr["MaVatTu"].ToString());
            _quanLyVatTu.SoLuong = int.Parse(dr["SoLuong"].ToString());
            _quanLyVatTu.GhiChu = dr["GhiChu"].ToString();
            return _quanLyVatTu;
        }
        #endregion

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridView1.GetSelectedRows().Length > 0)
            {
                ucMenu.btnXoa.Enabled = true;
            }
            else
            {
                ucMenu.btnXoa.Enabled = false;
            }
        }

        private void LayDanhSachLoaiPhong()
        {
            LoaiPhongBUS loaiPhong = new LoaiPhongBUS();

            lkupLoaiPhong.DataSource = loaiPhong.LayDanhSachLoaiPhong();
            lkupLoaiPhong.DisplayMember = "TenLoaiPhong";
            lkupLoaiPhong.ValueMember = "MaLoaiPhong";
        }

        private void LayDanhSachVatTu()
        {
            VatTuBUS vatTu = new VatTuBUS();

            lkupVatTu.DataSource = vatTu.LayDanhSachVatTu();
            lkupVatTu.DisplayMember = "TenVatTu";
            lkupVatTu.ValueMember = "MaVatTu";
        }
    }
}
