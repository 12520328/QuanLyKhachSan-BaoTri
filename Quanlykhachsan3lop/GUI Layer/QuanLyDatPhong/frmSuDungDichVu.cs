using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Quanlykhachsan3lop.Business_Logic_Layer;
using Quanlykhachsan3lop.Data_Access_Layer;
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

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyDatPhong
{
    public partial class frmSuDungDichVu : Form
    {

        DataTable dt = new DataTable();
        ChiTietSuDungDichVuBUS ctBUS = new ChiTietSuDungDichVuBUS();
        PhongBUS p = new PhongBUS();
        int MaPhong;
        string tenPhong;
        int MathuePhong;

       public frmSuDungDichVu()
        {
             InitializeComponent();
        }
       public frmSuDungDichVu(string TenPhong, int MaPhong)
       {
           InitializeComponent();
           lblTile.Text += ": " + TenPhong;
           tenPhong = TenPhong;
           this.MaPhong = MaPhong;
       }
        private void frmSuDungDichVu_Load(object sender, EventArgs e)
        {
            MathuePhong = p.LayMaThamChieu(MaPhong);
            LoadDuLieu();

            // Bắt sự kiện cho các button trong user control.
            ucMenu.btnChiDoc.ItemClick += ucMenu_ChiDoc_Clicked;
            ucMenu.btnXoa.ItemClick += ucMenu_Xoa_Clicked;
            ucMenu.btnLamMoi.ItemClick += ucMenu_LamMoi_Clicked;
            ucMenu.btnIn.ItemClick += ucMenu_In_Clicked;
            ucMenu.btnXuat.ItemClick += ucMenu_Xuat_Clicked;
            ucMenu.btnDong.ItemClick += ucMenu_Dong_Clicked;


            DichVuBUS dv = new DichVuBUS();
            lkupDichVu.DataSource = dv.LayDanhSach();
            lkupDichVu.DisplayMember = "TenDichVu";
            lkupDichVu.ValueMember = "MaDichVu";

        }

        private void LoadDuLieu()
        {
                dt.Clear();
                dt = ctBUS.LayDanhSachChiTietSuDungDichVu(MathuePhong);
                gridControl1.DataSource = dt;            
        }

        #region "Xử lý sự kiện button menu"
        private void ucMenu_Dong_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ucMenu_Xuat_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string text = "DANH SÁCH SỬ DỤNG DỊCH VỤ " + tenPhong;  
            PrintAndExport.ExportXls(gridControl1,text);
        }

        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string text = "DANH SÁCH SỬ DỤNG DỊCH VỤ " + tenPhong;
            PrintAndExport.ShowGridPreview(gridControl1, text);
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
                if (col.Visible != false)
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
                ctBUS.Insert(GetSuDungDichVu(newDr));

                XtraMessageBox.Show("Thêm mới thành công.", "Thông Báo");

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
                ctBUS.Update(GetSuDungDichVu(dr));
                XtraMessageBox.Show("Cập nhật thành công.", "Thông Báo");

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
                int maSuDungDV = int.Parse(gridView1.GetRowCellValue(i, colMaSuDungDichVu).ToString());
                ctBUS.Delete(maSuDungDV);
            }
            XtraMessageBox.Show("Xóa dữ liệu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDuLieu();
        }

        private ChiTietSuDungDichVuDTO GetSuDungDichVu(DataRow dr)
        {
            if (dr == null)
                return null;        
                ChiTietSuDungDichVuDTO ct = new ChiTietSuDungDichVuDTO();
                ct.MaChiTietSuDungDichVu = dr["MaChiTietSuDungDichVu"] == System.DBNull.Value ? -1 : int.Parse(dr["MaChiTietSuDungDichVu"].ToString());
                ct.MaThuePhong = MathuePhong;
                ct.MaDichVu = int.Parse(dr["MaDichVu"].ToString());
                ct.SoLuong = int.Parse(dr["SoLuong"].ToString());
                ct.DonGia = decimal.Parse(dr["DonGia"].ToString());
                ct.ThanhTien = decimal.Parse(dr["ThanhTien"].ToString());
                ct.NgaySuDung = DateTime.Parse(dr["NgaySuDung"].ToString());
            return ct;
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

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SoLuong")
            {
                if (gridView1.GetRowCellValue(e.RowHandle, e.Column) != null)
                {
                    try
                    {
                        decimal thanhTien = int.Parse(gridView1.GetRowCellValue(e.RowHandle, e.Column).ToString()) * decimal.Parse(gridView1.GetRowCellValue(e.RowHandle, colDonGia).ToString());
                        gridView1.SetRowCellValue(e.RowHandle, colThanhTien, thanhTien);
                    }
                    catch
                    {

                    }
                }
            }
            if(e.Column.FieldName == "MaDichVu")
            {
                if (gridView1.GetRowCellValue(e.RowHandle, e.Column) != null)
                {
                    try
                    {
                        DichVuBUS dv = new DichVuBUS();
                        DataTable dt = dv.LayDanhSachTheoMaDichVu(int.Parse(gridView1.GetRowCellValue(e.RowHandle,colMaDichVu).ToString()));
                        if (dt.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(e.RowHandle, colDonGia, dt.Rows[0]["DonGia"].ToString());
                            gridView1.SetRowCellValue(e.RowHandle, colNgaySuDung, DateTime.Now);
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
       
     

    }
}
