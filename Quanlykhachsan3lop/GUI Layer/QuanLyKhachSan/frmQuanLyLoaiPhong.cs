using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Quanlykhachsan3lop.Business_Logic_Layer;
using Quanlykhachsan3lop.Data_Transfer_Object;
using Quanlykhachsan3lop.Màn_Hình;
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
    public partial class frmQuanLyLoaiPhong : Form
    {
        DataTable dt = new DataTable();
        LoaiPhongBUS loaiPhongBUS = new LoaiPhongBUS();
        LoaiPhongDTO loaiPhongDTO = new LoaiPhongDTO();

        public frmQuanLyLoaiPhong()
        {
            InitializeComponent();

            //Định nghĩa cấu trúc bảng KhachHang
            dt.Columns.Add("MaLoaiPhong", typeof(int));
            dt.Columns.Add("TenLoaiPhong", typeof(string));
            dt.Columns.Add("MaBangGia", typeof(int));
            dt.Columns.Add("SoNguoiToiDa", typeof(int));

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

            LayDanhSachBangGia();
        }

        private void LoadDuLieu()
        {
            dt.Clear();
            dt = loaiPhongBUS.LayDanhSachLoaiPhong();
            gridControl1.DataSource = dt;
        }

        #region "Xử lý sự kiện button menu"
        private void ucMenu_Dong_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ucMenu_Xuat_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ExportXls(gridControl1, "DANH SÁCH LOẠI PHÒNG");
        }

        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridControl1, "DANH SÁCH LOẠI PHÒNG");
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
                if (col.FieldName != "MaLoaiPhong" || col.FieldName != "SoNguoiToiDa")
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
                if (loaiPhongBUS.Insert(GetKhachHang(newDr)))
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
                if (loaiPhongBUS.Update(GetKhachHang(dr)))
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
                int maKH = int.Parse(gridView1.GetRowCellValue(i, colMaLoaiPhong).ToString());
                loaiPhongBUS.Delete(maKH);
            }
            XtraMessageBox.Show("Xóa dữ liệu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDuLieu();
        }

        private LoaiPhongDTO GetKhachHang(DataRow dr)
        {
            if (dr == null)
                return null;
            LoaiPhongDTO _loaiPhong = new LoaiPhongDTO();
            _loaiPhong.MaLoaiPhong = string.IsNullOrEmpty(dr["MaLoaiPhong"].ToString())  ? -1 : int.Parse(dr["MaLoaiPhong"].ToString());
            _loaiPhong.TenLoaiPhong = string.IsNullOrEmpty(dr["TenLoaiPhong"].ToString()) ? "" : dr["TenLoaiPhong"].ToString();
            _loaiPhong.MaBangGia = int.Parse(dr["MaBangGia"].ToString());
            _loaiPhong.SoLuongNguoiToiDa = 0;
            return _loaiPhong;
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

        private void LayDanhSachBangGia()
        {
            BangGiaBUS bangGia = new BangGiaBUS();
            bangGia.LayDanhSachBangGia();

            lkupBangGia.DataSource = bangGia.LayDanhSachBangGia();
            lkupBangGia.DisplayMember = "TenBangGia";
            lkupBangGia.ValueMember = "MaBangGia";
        }
    }
}
