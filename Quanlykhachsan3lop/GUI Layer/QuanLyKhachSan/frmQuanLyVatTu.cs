using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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
    public partial class frmQuanLyVatTu : Form
    {
        DataTable dt = new DataTable();
        VatTuDTO vtDTO = new VatTuDTO();
        VatTuBUS vtBUS = new VatTuBUS();

        public frmQuanLyVatTu()
        {
            InitializeComponent();

            // Định nghĩa Datatable tương thích với GridView.
            dt.Columns.Add("MaVatTu", typeof(int));
            dt.Columns.Add("TenVatTu", typeof(string));
            dt.Columns.Add("HinhAnh", typeof(int));
            dt.Columns.Add("GhiChu", typeof(string));

            ucMenu.btnXoa.Enabled = false;
        }

        private void frmQuanLyVatTu_Load(object sender, EventArgs e)
        {            
            dt = vtBUS.LayDanhSachVatTu();
            gridControl1.DataSource = dt;

            // Bắt sự kiện cho các button trong user control.
            ucMenu.btnChiDoc.ItemClick += ucMenu_ChiDoc_Clicked;
            ucMenu.btnXoa.ItemClick += ucMenu_Xoa_Clicked;
            ucMenu.btnLamMoi.ItemClick += ucMenu_LamMoi_Clicked;
            ucMenu.btnIn.ItemClick += ucMenu_In_Clicked;
            ucMenu.btnXuat.ItemClick += ucMenu_Xuat_Clicked;
            ucMenu.btnDong.ItemClick += ucMenu_Dong_Clicked;
        }

        // Đóng form.
        private void ucMenu_Dong_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        // Xuất danh sách ra file excel.
        private void ucMenu_Xuat_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ExportXls(gridControl1, "DANH SÁCH VẬT TƯ");
        }

        // In danh sách, cho phép xem trước.
        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridControl1, "DANH SÁCH VẬT TƯ");
        }

        // Load lại database lên gridview.
        private void ucMenu_LamMoi_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            Thread.Sleep(1000);
            SplashScreenManager.CloseForm();
            LamMoi();
        }

        // Làm mới gridview bằng cách load lại cơ sở dữ liệu.
        private void LamMoi()
        {
            dt = vtBUS.LayDanhSachVatTu();
            gridControl1.DataSource = dt;
        }

        // chuyển đổi trạng thái chỉ đọc và chỉnh sửa.
        private void ucMenu_ChiDoc_Clicked(object sender, EventArgs e)
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

        //Xóa dữ liệu.
        private void ucMenu_Xoa_Clicked(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu này không? ", "Xóa dữ liệu", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.Cancel)
            {
                return;
            }

            int[] selectedIndexs = gridView1.GetSelectedRows();
            for (int i = 0; i < selectedIndexs.Length; i++)
            {
                vtDTO = convert_DataRow_To_VatTuDTO(gridView1.GetDataRow(selectedIndexs[i]));
                vtBUS.XoaVatTu(vtDTO);
            }

            LamMoi();
        }
        
        // Bắt sự kiện RowUpdate để thực hiện thêm chỉnh sửa một hàng.
        // Sự kiện này xảy ra khi việc chỉnh sửa một hàng vừa được lưu vào datasource của gridview.
        // Lợi dụng sự kiện này để thêm một dòng vào database khi thực hiện update trên NewItemRow.
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRow dr;
            if (e.RowHandle == GridControl.NewItemRowHandle)
            {
                dr = gridView1.GetDataRow(gridView1.DataRowCount - 1);
                vtDTO = convert_DataRow_To_VatTuDTO(dr);
                vtBUS.ThemVatTu(vtDTO);
            }
            else
            {
                DialogResult dg = MessageBox.Show("Bạn có chắc muốn sửa dòng này không ? ", "Sửa dữ liệu", MessageBoxButtons.OKCancel);
                if (dg == DialogResult.Cancel)
                {
                    LamMoi();
                    return;
                }

                dr = gridView1.GetDataRow(e.RowHandle);
                vtDTO = convert_DataRow_To_VatTuDTO(dr);    
                vtBUS.SuaVatTu(vtDTO);
            }

            LamMoi();
        }

        // Chuyển đổi dữ liệu từ datarow sang VatTudto.
        private VatTuDTO convert_DataRow_To_VatTuDTO(DataRow dr)
        {
            VatTuDTO vtDto = new VatTuDTO();
            vtDto.TenVatTu = (string)dr["TenVatTu"];
            vtDto.SoLuong = (int)dr["SoLuong"];
            vtDto.GhiChu = (string)dr["GhiChu"];

            if (dr["MaVatTu"] != System.DBNull.Value)
            {
                vtDto.MaVatTu = (int)dr["MaVatTu"];
            }
            else
            {
                vtDto.MaVatTu = -1;
            }

            return vtDto;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(e.RowHandle);
            if (dr["TenVatTu"] == System.DBNull.Value || dr["SoLuong"] == System.DBNull.Value || dr["GhiChu"] == System.DBNull.Value)
            {
                e.Valid = false;
                e.ErrorText = "Dữ liệu không được để trống";
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

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            XtraMessageBox.Show(e.ErrorText);
        }
    }
}
