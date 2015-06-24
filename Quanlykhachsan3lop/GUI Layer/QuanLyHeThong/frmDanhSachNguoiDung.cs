using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Quanlykhachsan3lop.Business_Logic_Layer;
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

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyHeThong
{
    public partial class frmDanhSachNguoiDung : Form
    {
        DataTable dt = new DataTable();
        NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
        NguoiDungDTO nguoiDungDTO = new NguoiDungDTO();
        int rowHandle = -1;


        public frmDanhSachNguoiDung()
        {
            InitializeComponent();

            // Định nghĩa Datatable tương thích với GridView.
            dt.Columns.Add("MaNguoiDung", typeof(int));
            dt.Columns.Add("HoVaTen", typeof(string));
            dt.Columns.Add("TenNguoiDung", typeof(string));
            dt.Columns.Add("MatKhau", typeof(string));
            dt.Columns.Add("QuanTriHeThong", typeof(bool));
            dt.Columns.Add("NhanVienLeTan", typeof(bool));
            dt.Columns.Add("NguoiDungMoi", typeof(bool));

            ucMenu.btnXoa.Enabled = false;
        }      

        private void frmDanhSachNguoiDung_Load(object sender, EventArgs e)
        {
            DanhSachNguoiDung();

            // Bắt sự kiện cho các button trong user control.
            ucMenu.btnChiDoc.ItemClick += ucMenu_ChiDoc_Clicked;
            ucMenu.btnXoa.ItemClick += ucMenu_Xoa_Clicked;
            ucMenu.btnLamMoi.ItemClick += ucMenu_LamMoi_Clicked;
            ucMenu.btnIn.ItemClick += ucMenu_In_Clicked;
            ucMenu.btnXuat.ItemClick += ucMenu_Xuat_Clicked;
            ucMenu.btnDong.ItemClick += ucMenu_Dong_Clicked;
        }

        private void DanhSachNguoiDung()
        {
            dt.Clear();
            DataTable temp = nguoiDungBUS.LayDanhSachNguoiDung();
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                bool isQuanTriHeThong = true;
                bool isNhanVienLeTan = true;
                bool isNguoiDungMoi = true;
                switch (temp.Rows[i]["LoaiNguoiDung"].ToString())//Load giá trị cho checkbox
                {
                    case "NguoiDungMoi":
                        isQuanTriHeThong = false;
                        isNhanVienLeTan = false;
                        isNguoiDungMoi = true;
                        break;
                    case "QuanTriHeThong":
                        isQuanTriHeThong = true;
                        isNhanVienLeTan = false;
                        isNguoiDungMoi = false;
                        break;
                    case "NhanVienLeTan":
                        isQuanTriHeThong = false;
                        isNhanVienLeTan = true;
                        isNguoiDungMoi = false;
                        break;
                }
                dt.Rows.Add(int.Parse(temp.Rows[i]["MaNguoiDung"].ToString()), temp.Rows[i]["HoVaTen"].ToString(),
                    temp.Rows[i]["TenNguoiDung"].ToString(), temp.Rows[i]["MatKhau"], isQuanTriHeThong, isNhanVienLeTan, isNguoiDungMoi);
            }           
            gridControl1.DataSource = dt;
        }

        #region "Xử lý sự kiện button"
        private void ucMenu_Dong_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ucMenu_Xuat_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ExportXls(gridControl1, "DANH SÁCH NGƯỜI DÙNG");
        }

        private void ucMenu_In_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridControl1, "DANH SÁCH NGƯỜI DÙNG");
        }

        private void ucMenu_LamMoi_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DanhSachNguoiDung();
        }

        private void ucMenu_Xoa_Clicked(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa dòng này không? ", "Xóa dữ liệu", MessageBoxButtons.OKCancel);
            if (dg == DialogResult.Cancel)
            {
                return;
            }
            nguoiDungBUS.Delete(nguoiDungDTO);       
            gridView1.DeleteRow(rowHandle);
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

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
       {
           rowHandle = e.RowHandle;
        //    if (rowHandle >= 0)
        //    {                
        //        ucMenu.btnXoa.Enabled = true;
        //        GetDataRow(rowHandle);
        //    }
        }


        private void GetDataRow(int rowHandle)
        {
            nguoiDungDTO.MaNguoiDung =int.Parse(gridView1.GetRowCellValue(rowHandle, colMaNguoiDung).ToString());
            nguoiDungDTO.HoVaTen = gridView1.GetRowCellValue(rowHandle, colHoVaTen).ToString();
            nguoiDungDTO.TenNguoiDung = gridView1.GetRowCellValue(rowHandle, colTenNguoiDung).ToString();
            nguoiDungDTO.MatKhau = gridView1.GetRowCellValue(rowHandle, colMatKhau).ToString();
        }

        #region "Thêm, sữa thông tin người dùng"
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRow newDr;
            #region "Thêm một ngừoi dùng"
            //Thêm một người dùng mới      
            if (e.RowHandle == GridControl.NewItemRowHandle)
            {
                newDr = gridView1.GetDataRow(gridView1.DataRowCount - 1);
                nguoiDungDTO.HoVaTen = newDr["HoVaTen"].ToString();
                nguoiDungDTO.TenNguoiDung = newDr["TenNguoiDung"].ToString();
                nguoiDungDTO.MatKhau = newDr["MatKhau"].ToString();
                //Convert loại người dùng
                try
                {
                    if (bool.Parse(newDr["QuanTriHeThong"].ToString()))
                    {
                        nguoiDungDTO.LoaiNguoiDung = "QuanTriHeThong";
                    }
                    else
                    {
                        if (bool.Parse(newDr["NhanVienLeTan"].ToString()))
                        {
                            nguoiDungDTO.LoaiNguoiDung = "NhanVienLeTan";
                        }
                        else
                        {
                            nguoiDungDTO.LoaiNguoiDung = "NguoiDungMoi";
                        }
                    }
                    if (nguoiDungBUS.Insert(nguoiDungDTO))
                    {
                        XtraMessageBox.Show("Thêm mới thành công.", "Thông Báo");
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng chọn quyền đăng nhập.", "Thông Báo");
                }
            }
            #endregion

            #region "Cập nhật thông tin ngừoi dùng"
            else
            {                
                DialogResult dg = MessageBox.Show("Bạn có chắc muốn sửa dòng này không ? ", "Sửa dữ liệu", MessageBoxButtons.OKCancel);
                if (dg == DialogResult.Cancel)
                {
                    DanhSachNguoiDung();
                    return;
                }
                newDr = gridView1.GetDataRow(e.RowHandle);
                nguoiDungDTO.MaNguoiDung = int.Parse(newDr["MaNguoiDung"].ToString());
                nguoiDungDTO.HoVaTen = newDr["HoVaTen"].ToString();
                nguoiDungDTO.TenNguoiDung = newDr["TenNguoiDung"].ToString();
                nguoiDungDTO.MatKhau = newDr["MatKhau"].ToString();
                //Convert loại người dùng
                try
                {
                    if (bool.Parse(newDr["QuanTriHeThong"].ToString()))
                    {
                        nguoiDungDTO.LoaiNguoiDung = "QuanTriHeThong";
                    }
                    else
                    {
                        if (bool.Parse(newDr["NhanVienLeTan"].ToString()))
                        {
                            nguoiDungDTO.LoaiNguoiDung = "NhanVienLeTan";
                        }
                        else
                        {
                            nguoiDungDTO.LoaiNguoiDung = "NguoiDungMoi";
                        }
                    }
                    if (nguoiDungBUS.Update(nguoiDungDTO))
                    {
                        XtraMessageBox.Show("Cập nhật thành công.", "Thông Báo");
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng chọn quyền đăng nhập.", "Thông Báo");
                }                
                #endregion
            }
            DanhSachNguoiDung();
        }
        #endregion

        #region "Chỉ chọn 1 trong 3 loại người dùng"
        private void checkQuanTriHeThong_CheckedChanged(object sender, EventArgs e)
        {
            if (bool.Parse(checkQuanTriHeThong.ValueChecked.ToString()) == true)
            {
                gridView1.SetRowCellValue(rowHandle, colNguoiDungMoi, false);
                gridView1.SetRowCellValue(rowHandle, colNhanVienLeTan, false);
            }
        }

        private void checkNhanVienLeTan_CheckedChanged(object sender, EventArgs e)
        {
            if (bool.Parse(checkNhanVienLeTan.ValueChecked.ToString()) == true)
            {
                gridView1.SetRowCellValue(rowHandle, colAdmin, false);
                gridView1.SetRowCellValue(rowHandle, colNguoiDungMoi, false);
            }
        }

        private void checkNguoiDungMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (bool.Parse(checkNguoiDungMoi.ValueChecked.ToString()) == true)
            {
                gridView1.SetRowCellValue(rowHandle, colAdmin, false);
                gridView1.SetRowCellValue(rowHandle, colNhanVienLeTan, false);
            }
        }
        #endregion
    }

}
