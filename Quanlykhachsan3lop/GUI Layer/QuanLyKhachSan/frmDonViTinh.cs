using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyKhachSan
{
    public partial class frmDonViTinh : Form
    {
        DataTable dt = new DataTable();
        DonViTinhBUS _donViTinhBUS = new DonViTinhBUS();

        public frmDonViTinh()
        {
            InitializeComponent();
        
            ucMenu.btnXoa.Enabled = false;
        }

        private void frmDonViTinh_Load(object sender, EventArgs e)
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
            dt = _donViTinhBUS.LayDanhSachDonViTinh();
            gridControl1.DataSource = dt;
         }   

        #region "Xử lý sự kiện các Button trong Menu"
        private void ucMenu_Dong_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ucMenu_Xuat_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ExportXls(gridControl1, "DANH SÁCH ĐƠN VỊ TÍNH");
        }

        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridControl1, "DANH SÁCH ĐƠN VỊ TÍNH");
        }

        private void ucMenu_LamMoi_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));            
            LoadDuLieu();
            Thread.Sleep(1000);
            SplashScreenManager.CloseForm();
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


        #endregion                

        #region "Thêm, Xóa, Sửa"
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
                int maLoaiGia = int.Parse(gridView1.GetRowCellValue(i, colMaDonViTinh).ToString());
                _donViTinhBUS.Delete(maLoaiGia);
            }
            XtraMessageBox.Show("Xóa dữ liệu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDuLieu();
        }

        // Bắt sự kiện RowUpdate để thực hiện thêm chỉnh sửa một hàng.
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.RowHandle == GridControl.NewItemRowHandle)
            {
                DataRow newDr = gridView1.GetDataRow(gridView1.DataRowCount - 1);                          
                if(_donViTinhBUS.Insert(GetLoaiGia(newDr)))
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
                if (_donViTinhBUS.Update(GetLoaiGia(dr)))
                {
                    XtraMessageBox.Show("Cập nhật thành công.", "Thông Báo");
                }
            }
            LoadDuLieu();
        }

        private DonViTinhDTO GetLoaiGia(DataRow dr)
        {
            if(dr == null)
            {
                return null;
            }
            DonViTinhDTO  _donViTinh = new DonViTinhDTO();
            _donViTinh.MaDonVi = string.IsNullOrEmpty(dr["MaDonViTinh"].ToString()) ? -1 : int.Parse(dr["MaDonViTinh"].ToString());          
            _donViTinh.TenDonVi = string.IsNullOrEmpty(dr["TenDonViTinh"].ToString()) ? "" : (string)dr["TenDonViTinh"];
            _donViTinh.GhiChu = string.IsNullOrEmpty(dr["GhiChu"].ToString()) ? "" : (string)dr["GhiChu"];
            return _donViTinh;
        }
        #endregion

        #region "Kiểm tra dữ liệu hợp lệ"
        private void gridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            XtraMessageBox.Show(e.ErrorText, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void gridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.ClearColumnErrors();
            foreach (GridColumn col in ((ColumnView)view).Columns)
            {
                if (col.FieldName == "TenDonViTinh")
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
        #endregion
    }
}
