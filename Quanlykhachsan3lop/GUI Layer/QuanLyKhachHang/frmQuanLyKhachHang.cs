using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyKhachHang
{
    public partial class frmQuanLyKhachHang : Form
    {
        DataTable dt = new DataTable();
        KhachHangBUS khachHangBUS = new KhachHangBUS();
        KhachHangDTO khachHangDTO = new KhachHangDTO();

        public frmQuanLyKhachHang()
        {
            InitializeComponent();

            //Định nghĩa cấu trúc bảng KhachHang
            dt.Columns.Add("MaKhachHang", typeof(int));
            dt.Columns.Add("TenKhachHang", typeof(string));
            dt.Columns.Add("GioiTinh", typeof(string));
            dt.Columns.Add("CMND", typeof(string));
            dt.Columns.Add("NgaySinh", typeof(DateTime));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("SDT", typeof(string));

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
        }

        private void LoadDuLieu()
        {
            dt.Clear();
            dt = khachHangBUS.LayDanhSachKhachHang();
            gridControl1.DataSource = dt;
        }

        #region "Xử lý sự kiện button menu"
        private void ucMenu_Dong_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ucMenu_Xuat_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ExportXls(gridControl1, "DANH SÁCH KHÁCH HÀNG");
        }

        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridControl1, "DANH SÁCH KHÁCH HÀNG");
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
        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            //Set icon thông báo lỗi về mặc định
            view.SetColumnError(view.FocusedColumn, "",DevExpress.XtraEditors.DXErrorProvider.ErrorType.None);
            //Lấy giá trị cần kiểm tra
            string value = Convert.ToString(e.Value);
            if (view.FocusedColumn.FieldName == "CMND")
            {   
                if (!IsNumber(value))
                {
                    e.Valid = false;
                    e.ErrorText =  "Số chứng minh nhân dân phải là số.";
                    view.SetColumnError(colCMND,e.ErrorText);
                }
            }
            if(view.FocusedColumn.FieldName == "SDT")
            {
                if (!IsNumber(value))
                {
                    e.Valid = false;
                    e.ErrorText = "Số điện thoại phải là số.";
                    view.SetColumnError(colSoDienThoai, e.ErrorText);
                }
            }
        }        

        public bool IsNumber(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsDigit(s[i]))
                    return false;
            }
            return true;
        }

        private void gridView1_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {           
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            XtraMessageBox.Show(e.ErrorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
  
        //Dữ liệu nhập không được để trống
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.ClearColumnErrors();
            foreach (GridColumn col in ((ColumnView)view).Columns)
            {
                if (col.FieldName != "MaKhachHang")
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
            XtraMessageBox.Show(e.ErrorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region "Thêm, Sữa dữ liệu"
        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (e.RowHandle == GridControl.NewItemRowHandle)
            {
                DataRow newDr = gridView1.GetDataRow(gridView1.DataRowCount - 1);
                if (khachHangBUS.Insert(GetKhachHang(newDr)))
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
                if (khachHangBUS.Update(GetKhachHang(dr)))
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
                int maKH = int.Parse(gridView1.GetRowCellValue(i, colMaKhachHang).ToString());
                khachHangBUS.Delete(maKH);
            }
            XtraMessageBox.Show("Xóa dữ liệu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDuLieu();
        }

        private KhachHangDTO GetKhachHang(DataRow dr)
        {
            if (dr == null)
                return null;
            KhachHangDTO _khachHang = new KhachHangDTO();
            _khachHang.MaKhachHang = string.IsNullOrEmpty(dr["MaKhachHang"].ToString())  ? -1 : int.Parse(dr["MaKhachHang"].ToString());
            _khachHang.TenKhachHang = string.IsNullOrEmpty(dr["TenKhachHang"].ToString()) ? "" : dr["TenKhachHang"].ToString();
            _khachHang.GioiTinh = string.IsNullOrEmpty(dr["GioiTinh"].ToString()) ? "" : dr["GioiTinh"].ToString();
            _khachHang.DiaChi = string.IsNullOrEmpty(dr["DiaChi"].ToString()) ? "" : dr["DiaChi"].ToString();
            _khachHang.SoDienThoai =string.IsNullOrEmpty(dr["SDT"].ToString()) ? "" : dr["SDT"].ToString();
            _khachHang.CMND = dr["CMND"].ToString();
            _khachHang.NgaySinh = DateTime.Parse(dr["NgaySinh"].ToString());
            return _khachHang;
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
    }
}
