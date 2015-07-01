using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
using Quanlykhachsan3lop.Business_Logic_Layer;
using Quanlykhachsan3lop.Data_Transfer_Object;
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

namespace Quanlykhachsan3lop.Màn_Hình
{
    public partial class frmQuanLyPhong : Form
    {
        DataTable dt = new DataTable();
        PhongBUS pBUS = new PhongBUS();

        public frmQuanLyPhong()
        {
            InitializeComponent();

            ucMenu.btnXoa.Enabled = false;
        }

        private void frmPhong_Load(object sender, EventArgs e)
        {
            dt = pBUS.LayDanhSach();
            gridControl1.DataSource = dt;

            // Bắt sự kiện cho các button trong user control.
            ucMenu.btnChiDoc.ItemClick += ucMenu_ChiDoc_Clicked;
            ucMenu.btnXoa.ItemClick += ucMenu_Xoa_Clicked;
            ucMenu.btnLamMoi.ItemClick += ucMenu_LamMoi_Clicked;
            ucMenu.btnIn.ItemClick += ucMenu_In_Clicked;
            ucMenu.btnXuat.ItemClick += ucMenu_Xuat_Clicked;
            ucMenu.btnDong.ItemClick += ucMenu_Dong_Clicked;

            // Load danh sách tầng lầu.
            TangLauBUS tlBUS = new TangLauBUS();
            lkupTangLau.DataSource = tlBUS.LayDanhSachTangLau();
            lkupTangLau.ValueMember = "MaTangLau";
            lkupTangLau.DisplayMember = "TenTangLau";

            // Load danh sách tình trạng phòng.
            TinhTrangPhongBUS ttpBUS = new TinhTrangPhongBUS();
            lkupTinhTrangPhong.DataSource = ttpBUS.LayDanhSach();
            lkupTinhTrangPhong.ValueMember = "MaTinhTrangPhong";
            lkupTinhTrangPhong.DisplayMember = "TenTinhTrangPhong";

            // Load danh sách tình trạng đặt phòng.
            TinhTrangDatPhongBUS ttdpBUS = new TinhTrangDatPhongBUS();
            lkTinhTrangDatPhong.DataSource = ttdpBUS.LayDanhSachTinhTrangDatPhong();
            lkTinhTrangDatPhong.ValueMember = "MaTinhTrangDatPhong";
            lkTinhTrangDatPhong.DisplayMember = "TenTinhTrangDatPhong";

            // Load danh sách loại phòng.
            LoaiPhongBUS lpBUS = new LoaiPhongBUS();
            lkupLoaiPhong.DataSource = lpBUS.LayDanhSachLoaiPhong();
            lkupLoaiPhong.ValueMember = "MaLoaiPhong";
            lkupLoaiPhong.DisplayMember = "TenLoaiPhong";
        }

        // Đóng form.
        private void ucMenu_Dong_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        // Xuất danh sách ra file excel.
        private void ucMenu_Xuat_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ExportXls(gridControl1, "DANH SÁCH PHÒNG");
        }

        // In danh sách, cho phép xem trước.
        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridControl1, "DANH SÁCH PHÒNG");
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
            dt.Clear();
            dt = pBUS.LayDanhSach();
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
            PhongDTO pDto = new PhongDTO();
            for (int i = 0; i < selectedIndexs.Length; i++)
            {
                pDto = convert_DataRow_To_PhongDTO(gridView1.GetDataRow(selectedIndexs[i]));
                pBUS.delete(pDto.MaPhong);
            }

            LamMoi();
        }

        // Bắt sự kiện RowUpdate để thực hiện thêm chỉnh sửa một hàng.
        // Sự kiện này xảy ra khi việc chỉnh sửa một hàng vừa được lưu vào datasource của gridview.
        // Lợi dụng sự kiện này để thêm một dòng vào database khi thực hiện update trên NewItemRow.
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRow dr;
            PhongDTO ttpDto = new PhongDTO();
            if (e.RowHandle == GridControl.NewItemRowHandle)
            {
                dr = gridView1.GetDataRow(gridView1.DataRowCount - 1);
                ttpDto = convert_DataRow_To_PhongDTO(dr);
                pBUS.Insert(ttpDto);
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
                ttpDto = convert_DataRow_To_PhongDTO(dr);
                pBUS.Update(ttpDto);
            }

            LamMoi();
        }

        // Chuyển đổi dữ liệu từ datarow sang Phongdto.
        private PhongDTO convert_DataRow_To_PhongDTO(DataRow dr)
        {
            PhongDTO ttpDto = new PhongDTO();
            ttpDto.MaPhong = (dr["MaPhong"] != System.DBNull.Value) ? (int)dr["MaPhong"] : -1;
            ttpDto.SoPhong = (dr["SoPhong"] != System.DBNull.Value) ? (string)dr["SoPhong"] : "";
            ttpDto.SoGiuong = (dr["SoGiuong"] != System.DBNull.Value) ? (int)dr["SoGiuong"] : -1;
            ttpDto.MaLoaiPhong = (dr["MaLoaiPhong"] != System.DBNull.Value) ? (int)dr["MaLoaiPhong"] : -1;
            ttpDto.MaTang = (dr["MaTang"] != System.DBNull.Value) ? (int)dr["MaTang"] : -1;
            ttpDto.SoNguoi = (dr["SoNguoi"] != System.DBNull.Value) ? (int)dr["SoNguoi"] : -1;
            ttpDto.ThongTinPhong = dr["ThongTinPhong"].ToString();
            return ttpDto;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(e.RowHandle);
            // 
            if (dr["SoPhong"] == System.DBNull.Value || dr["MaTang"] == System.DBNull.Value|| dr["SoGiuong"] == System.DBNull.Value 
                || dr["SoNguoi"] == System.DBNull.Value || dr["ThongTinPhong"] == System.DBNull.Value|| dr["MaLoaiPhong"] == System.DBNull.Value)
            {
                e.Valid = false;
                e.ErrorText = "Dữ liệu không được để trống";
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
