﻿using DevExpress.XtraEditors;
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

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyKhachSan
{
    public partial class frmQuanLyLoaiGia : Form
    {
        DataTable dt = new DataTable();
        LoaiGiaDTO _loaiGiaDTO = new LoaiGiaDTO();
        LoaiGiaBUS _loaiGiaBUS = new LoaiGiaBUS();

        public frmQuanLyLoaiGia()
        {
            InitializeComponent();

             // Định nghĩa Datatable tương thích với GridView.
            dt.Columns.Add("MaChinhSach", typeof(int));
            dt.Columns.Add("ThoiGianQuyDinh", typeof(DateTime));
            dt.Columns.Add("PhuThu", typeof(decimal));

            ucMenu.btnXoa.Enabled = false;
        }

        private void frmChinhSachTraPhong_Load(object sender, EventArgs e)
        {
            LamMoi();

            // Bắt sự kiện cho các button trong user control.
            ucMenu.btnChiDoc.ItemClick += ucMenu_ChiDoc_Clicked;
            ucMenu.btnXoa.ItemClick += ucMenu_Xoa_Clicked;
            ucMenu.btnLamMoi.ItemClick += ucMenu_LamMoi_Clicked;
            ucMenu.btnIn.ItemClick += ucMenu_In_Clicked;
            ucMenu.btnXuat.ItemClick += ucMenu_Xuat_Clicked;
            ucMenu.btnDong.ItemClick += ucMenu_Dong_Clicked;
        }

        private void ucMenu_Dong_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ucMenu_Xuat_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ExportXls(gridControl1, "DANH SÁCH LOẠI GIÁ PHÒNG");
        }

        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridControl1, "DANH SÁCH LOẠI GIÁ PHÒNG");
        }

        private void ucMenu_LamMoi_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));            
            LamMoi();
            Thread.Sleep(1000);
            SplashScreenManager.CloseForm();
        }

        private void LamMoi()
        {
            dt = _loaiGiaBUS.LayDanhSachLoaiGia();
            gridControl1.DataSource = dt;
        }

        private void ucMenu_Xoa_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa dòng này không? ", "Xóa dữ liệu", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.Cancel)
            {
                return;
            }
            _loaiGiaBUS.Delete(_loaiGiaDTO);
            LamMoi();
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
        // Bắt sự kiện RowUpdate để thực hiện thêm chỉnh sửa một hàng.
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.RowHandle == GridControl.NewItemRowHandle)
            {
                DataRow newDr = gridView1.GetDataRow(gridView1.DataRowCount - 1);
                try
                {
                    _loaiGiaDTO.TenLoaiGia = (string)newDr["TenLoaiGia"];
                    _loaiGiaDTO.GhiChu = (string)newDr["GhiChu"];
                }
                catch { }
                if (_loaiGiaBUS.TonTaiTenLoaiGia(_loaiGiaDTO.TenLoaiGia) == true)
                {
                    XtraMessageBox.Show("Tên loại giá bạn nhập đã tồn tại. Vui lòng nhập tên khác.","Thông Báo Lỗi");
                    LamMoi();
                    return;
                }
                _loaiGiaBUS.Insert(_loaiGiaDTO);
            }
            else
            {
                DialogResult dg = MessageBox.Show("Bạn có chắc muốn sửa dòng này không ? ", "Sửa dữ liệu", MessageBoxButtons.OKCancel);
                if (dg == DialogResult.Cancel)
                {
                    LamMoi();
                    return;                  
                }
                DataRow dr = gridView1.GetDataRow(e.RowHandle);
                _loaiGiaDTO.MaLoaiGia = (int)dr["MaLoaiGia"];
                _loaiGiaDTO.TenLoaiGia = (string)dr["TenLoaiGia"];
                if (_loaiGiaBUS.TonTaiTenLoaiGia(_loaiGiaDTO.TenLoaiGia) == true)
                {
                    XtraMessageBox.Show("Tên loại giá bạn nhập đã tồn tại. Vui lòng nhập tên khác.","Thông Báo Lỗi");
                    LamMoi();
                    return;
                }
                _loaiGiaDTO.GhiChu = (string)dr["GhiChu"];
                _loaiGiaBUS.Update(_loaiGiaDTO);
            }
            LamMoi();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle > 0)
            {
                DataRow dr = gridView1.GetDataRow(e.RowHandle);
                _loaiGiaDTO.MaLoaiGia = (int)dr["MaLoaiGia"];
                _loaiGiaDTO.TenLoaiGia = (string)dr["TenLoaiGia"];
                _loaiGiaDTO.GhiChu = (string)dr["GhiChu"];
                ucMenu.btnXoa.Enabled = true;
            }
        }
    }
}