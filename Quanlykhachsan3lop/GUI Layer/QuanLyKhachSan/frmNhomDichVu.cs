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

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyKhachSan
{
    public partial class frmNhomDichVu : Form
    {
       DataTable dt = new DataTable();
       NhomDichVuBUS ndvBUS = new NhomDichVuBUS();

       public frmNhomDichVu()
        {
            InitializeComponent();

            // Định nghĩa Datatable tương thích với GridView.
            dt.Columns.Add("NhomDichVu", typeof(int));
            dt.Columns.Add("TenNhomDichVu", typeof(string));

            ucMenu.btnXoa.Enabled = false;
        }

       private void frmNhomDichVu_Load(object sender, EventArgs e)
        {            
            dt = ndvBUS.LayDanhSachNhomDichVu();
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
            PrintAndExport.ExportXls(gridControl1, "DANH SÁCH NHÓM DỊCH VỤ");
        }

        // In danh sách, cho phép xem trước.
        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridControl1, "DANH SÁCH NHÓM DỊCH VỤ");
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
            dt = ndvBUS.LayDanhSachNhomDichVu();
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
            NhomDichVuDTO ndvDTO = new NhomDichVuDTO();
            for (int i = 0; i < selectedIndexs.Length; i++)
            {
                ndvDTO = convert_DataRow_To_NhomDichVuDTO(gridView1.GetDataRow(selectedIndexs[i]));
                ndvBUS.XoaNhomDichvu(ndvDTO);
            }

            LamMoi();
        }
        
        // Bắt sự kiện RowUpdate để thực hiện thêm chỉnh sửa một hàng.
        // Sự kiện này xảy ra khi việc chỉnh sửa một hàng vừa được lưu vào datasource của gridview.
        // Lợi dụng sự kiện này để thêm một dòng vào database khi thực hiện update trên NewItemRow.
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRow dr;
            NhomDichVuDTO ndvDTO = new NhomDichVuDTO();
            if (e.RowHandle == GridControl.NewItemRowHandle)
            {
                dr = gridView1.GetDataRow(gridView1.DataRowCount - 1);
                ndvDTO = convert_DataRow_To_NhomDichVuDTO(dr);
                ndvBUS.ThemNhomDichVu(ndvDTO);
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
                ndvDTO = convert_DataRow_To_NhomDichVuDTO(dr);    
                ndvBUS.SuaNhomDichVu(ndvDTO);
            }

            LamMoi();
        }

        // Set EditorShowMode = MouseUp để bắt được sự kiện.
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            // Chỗ này cần thêm vài logic liên quan đến dữ liệu được chọn.
            // Ví dụ: khi dữ liệu được chọn null thì ẩn nút xóa...
            if (e.RowHandle >= 0)
            {
                ucMenu.btnXoa.Enabled = true;
            }
            else
            {
                ucMenu.btnXoa.Enabled = false;
            }
        }

        // Chuyển đổi dữ liệu từ datarow sang VatTudto.
        private NhomDichVuDTO convert_DataRow_To_NhomDichVuDTO(DataRow dr)
        {
            NhomDichVuDTO ndvDto = new NhomDichVuDTO();
            ndvDto.TenNhomDichVu = (string)dr["TenNhomDichVu"];

            if (dr["NhomDichVu"] != System.DBNull.Value)
            {
                ndvDto.NhomDichVu = (int)dr["NhomDichVu"];
            }
            else
            {
                ndvDto.NhomDichVu = -1;
            }

            return ndvDto;
        }

        private void gridView1_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(e.RowHandle);
            if (dr["TenNhomDichVu"] == System.DBNull.Value)
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
