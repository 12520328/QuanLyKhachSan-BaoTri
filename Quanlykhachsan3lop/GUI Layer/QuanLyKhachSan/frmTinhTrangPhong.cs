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
    public partial class frmTinhTrangPhong : Form
    {
        DataTable dt = new DataTable();
        TinhTrangPhongDTO _tinhTrangPhongDTO = new TinhTrangPhongDTO();
        TinhTrangPhongBUS _tinhTrangPhongBUS = new TinhTrangPhongBUS();

        public frmTinhTrangPhong()
        {
            InitializeComponent();
            // Định nghĩa Datatable tương thích với GridView.
            dt.Columns.Add("MaTinhTrangPhong", typeof(int));
            dt.Columns.Add("TenTinhTrangPhong", typeof(string));
            dt.Columns.Add("HinhAnh", typeof(Image));
            dt.Columns.Add("MauSac", typeof(int));

            ucMenu.btnXoa.Enabled = false;
        }


        private void frmTinhTrangPhong_Load(object sender, EventArgs e)
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
            dt = _tinhTrangPhongBUS.LayDanhSachTinhTrangPhong();
            gridControl1.DataSource = dt;
        }

        private void ucMenu_Xoa_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa dòng này không? ", "Xóa dữ liệu", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.Cancel)
            {
                return;
            }
            _tinhTrangPhongBUS.Delete(_tinhTrangPhongDTO);
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
                //DataRow newDr = gridView1.GetDataRow(gridView1.DataRowCount - 1);
                //try
                //{
                //    _tinhTrangPhongDTO.TenTinhTrangPhong = (string)newDr["TenTinhTrangPhong"];
                //    _tinhTrangPhongDTO.GhiChu = (string)newDr["GhiChu"];
                //}
                //catch { }
                //if (_tinhTrangPhongBUS.TonTaiTenTinhTrangPhong(_tinhTrangPhongDTO.TenTinhTrangPhong) == true)
                //{
                //    XtraMessageBox.Show("Tên loại giá bạn nhập đã tồn tại. Vui lòng nhập tên khác.","Thông Báo Lỗi");
                //    LamMoi();
                //    return;
                //}
                //if(_tinhTrangPhongBUS.Insert(_tinhTrangPhongDTO))
                //{
                //    XtraMessageBox.Show("Thêm mới thành công.", "Thông Báo");
                //}
            }
            else
            {
                //DialogResult dg = MessageBox.Show("Bạn có chắc muốn sửa dòng này không ? ", "Sửa dữ liệu", MessageBoxButtons.OKCancel);
                //if (dg == DialogResult.Cancel)
                //{
                //    LamMoi();
                //    return;                  
                //}
                //DataRow dr = gridView1.GetDataRow(e.RowHandle);
                //_tinhTrangPhongDTO.MaTinhTrangPhong = (int)dr["MaTinhTrangPhong"];
                //_tinhTrangPhongDTO.TenTinhTrangPhong = (string)dr["TenTinhTrangPhong"];                
                //_tinhTrangPhongDTO.GhiChu = (string)dr["GhiChu"];
                //if (_tinhTrangPhongBUS.Update(_tinhTrangPhongDTO))
                //{
                //    XtraMessageBox.Show("Cập nhật thành công.", "Thông Báo");
                //}
            }
            LamMoi();
        }
    }

}
