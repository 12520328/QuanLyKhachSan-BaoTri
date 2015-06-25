using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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

namespace Quanlykhachsan3lop.GUI_Layer
{
        public partial class frmQuanLyDichVu : Form
        {
           DataTable dt = new DataTable();
           DichVuBUS dvBUS = new DichVuBUS();

        public frmQuanLyDichVu()
        {
            InitializeComponent();

            ucMenu.btnXoa.Enabled = false;
        }

        private void frmQuanLyDichVu_Load(object sender, EventArgs e)
        {            
            dt = dvBUS.LayDanhSach();
            gridControl1.DataSource = dt;

            // Load danh sach nhom dich vu.
            NhomDichVuBUS nhomdvBUS = new NhomDichVuBUS();
            lkupNhomDichVu.DataSource = nhomdvBUS.LayDanhSachNhomDichVu();
            lkupNhomDichVu.ValueMember = "NhomDichVu";
            lkupNhomDichVu.DisplayMember = "TenNhomDichVu";

            // Load danh sách đơn vị tính.
            //DonViTinhBUS dvtBUS = new DonViTinhBUS();
            //lkupDonViTinh.DataSource = dvtBUS.LayDanhSach();
            //lkupDonViTinh.ValueMember = "MaDonViTinh";
            //lkupDonViTinh.DisplayMember = "TenDonViTinh";

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
            PrintAndExport.ExportXls(gridControl1, "DANH SÁCH DỊCH VỤ");
        }

        // In danh sách, cho phép xem trước.
        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridControl1, "DANH SÁCH DỊCH VỤ");
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
            dt = dvBUS.LayDanhSach();
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
            DichVuDTO dvDto = new DichVuDTO();
            for (int i = 0; i < selectedIndexs.Length; i++)
            {
                dvDto = convert_DataRow_To_DichVuDTO(gridView1.GetDataRow(selectedIndexs[i]));
                dvBUS.delete(dvDto);
            }

            LamMoi();
        }
        
        // Bắt sự kiện RowUpdate để thực hiện thêm chỉnh sửa một hàng.
        // Sự kiện này xảy ra khi việc chỉnh sửa một hàng vừa được lưu vào datasource của gridview.
        // Lợi dụng sự kiện này để thêm một dòng vào database khi thực hiện update trên NewItemRow.
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRow dr;
            DichVuDTO dvDto = new DichVuDTO();
            if (e.RowHandle == GridControl.NewItemRowHandle)
            {
                dr = gridView1.GetDataRow(gridView1.DataRowCount - 1);
                dvDto = convert_DataRow_To_DichVuDTO(dr);
                dvBUS.insert(dvDto);
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
                dvDto = convert_DataRow_To_DichVuDTO(dr);
                dvBUS.update(dvDto);
            }

            LamMoi();
        }

        // Chuyển đổi dữ liệu từ datarow sang DichVudto.
        private DichVuDTO convert_DataRow_To_DichVuDTO(DataRow dr)
        {
            DichVuDTO dvDto = new DichVuDTO();
            dvDto.MaDichVu = (dr["MaDichVu"] != System.DBNull.Value) ? (int)dr["MaDichVu"] : -1;
            dvDto.TenDichVu = string.IsNullOrEmpty((string)dr["TenDichVu"]) ? "" : (string)dr["TenDichVu"];
            dvDto.DonGia = (dr["DonGia"] != System.DBNull.Value) ? (decimal)dr["DonGia"] : 0;
            dvDto.MaDonViTinh = (dr["MaDonViTinh"] != System.DBNull.Value) ? (int)dr["MaDonViTinh"] : 1;
            dvDto.NhomDichVu = (dr["NhomDichVu"] != System.DBNull.Value) ? (int)dr["NhomDichVu"] : -1;

            return dvDto;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(e.RowHandle);
            // || dr["MaDonViTinh"] == System.DBNull.Value 
            if (dr["TenDichVu"] == System.DBNull.Value || dr["NhomDichVu"] == System.DBNull.Value || dr["DonGia"] == System.DBNull.Value)
            {
                e.Valid = false;
                e.ErrorText = "Dữ liệu không được để trống\n";
            }
        }

        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            XtraMessageBox.Show(e.ErrorText, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
    }
}
