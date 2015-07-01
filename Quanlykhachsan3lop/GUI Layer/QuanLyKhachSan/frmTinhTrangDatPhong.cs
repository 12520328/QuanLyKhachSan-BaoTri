using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quanlykhachsan3lop.Business_Logic_Layer;
using Quanlykhachsan3lop.Data_Transfer_Object;
using DevExpress.XtraSplashScreen;
using System.Threading;
using Quanlykhachsan3lop.Màn_Hình;
using DevExpress.XtraGrid;

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyKhachSan
{
    public partial class frmTinhTrangDatPhong : Form
    {
        DataTable dt = new DataTable();
        TinhTrangDatPhongDTO ttdpDTO= new TinhTrangDatPhongDTO();
        TinhTrangDatPhongBUS ttdpBUS = new TinhTrangDatPhongBUS();

        public frmTinhTrangDatPhong()
        {
            InitializeComponent();

            // Định nghĩa Datatable tương thích với GridView.
            dt.Columns.Add("MaTinhTrangDatPhong", typeof(int));
            dt.Columns.Add("TenTinhTrangDatPhong", typeof(string));
            dt.Columns.Add("MauSac", typeof(Color));
           

            ucMenu.btnXoa.Enabled = false;
        }

        private void frmQuanLyTinhTrangDatPhong_Load(object sender, EventArgs e)
        {            
            dt = ttdpBUS.LayDanhSachTinhTrangDatPhong();
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
            PrintAndExport.ExportXls(gridControl1, "DANH SÁCH TÌNH TRẠNG ĐẶT PHÒNG");
        }

        // In danh sách, cho phép xem trước.
        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridControl1, "DANH SÁCH TÌNH TRẠNG ĐẶT PHÒNG");
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
            dt = ttdpBUS.LayDanhSachTinhTrangDatPhong();

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
            TinhTrangDatPhongDTO ttdpDto = new TinhTrangDatPhongDTO();
            for (int i = 0; i < selectedIndexs.Length; i++)
            {
                ttdpDto = convert_DataRow_To_TinhTrangDatPhongDTO(gridView1.GetDataRow(selectedIndexs[i]));
                ttdpBUS.XoaTinhTrangDatPhong(ttdpDto);
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
                if (!KiemTraDuLieu(dr))
                {
                    LamMoi();
                    return;
                }
                ttdpDTO = convert_DataRow_To_TinhTrangDatPhongDTO(dr);
                ttdpBUS.ThemTinhTrangDatPhong(ttdpDTO);
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
                if (!KiemTraDuLieu(dr))
                {
                    LamMoi();
                    return;
                }
                ttdpDTO = convert_DataRow_To_TinhTrangDatPhongDTO(dr);    
                ttdpBUS.SuaTinhTrangDatPhong(ttdpDTO);
            }

            LamMoi();
        }

        // Chuyển đổi dữ liệu từ datarow sang TinhTrangDatPhongdto.
        private TinhTrangDatPhongDTO convert_DataRow_To_TinhTrangDatPhongDTO(DataRow dr)
        {
            TinhTrangDatPhongDTO ttdpDto = new TinhTrangDatPhongDTO();
            ttdpDto.TenTinhTrangDatPhong = (string)dr["TenTinhTrangDatPhong"];

            if (dr["HinhAnh"] != System.DBNull.Value)
            {
                ttdpDto.HinhAnh = (byte[])dr["HinhAnh"];
            }
            else
            {
                ttdpDto.HinhAnh = null;
            }

            if (dr["MaTinhTrangDatPhong"] != System.DBNull.Value)
            {
                ttdpDto.MaTinhTrangDatPhong = (int)dr["MaTinhTrangDatPhong"];
            }
            else
            {
                ttdpDto.MaTinhTrangDatPhong = -1;
            }
            ttdpDto.MauSac = (int)dr["MauSac"];
            return ttdpDto;
        }

        // Kiểm tra dữ liệu trước khi lưu xuống database.
        private bool KiemTraDuLieu(DataRow dr)
        {
            if (string.IsNullOrEmpty((string)dr["TenTinhTrangDatPhong"]))
            {
                MessageBox.Show("Chưa điền tên tình trạng đặt phòng", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                if (dr["MauSac"] == System.DBNull.Value)
                {
                    MessageBox.Show("Chưa màu sắc cho tình trạng đặt phòng", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    return true;
                }

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
    }
}
