using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
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

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyKhachSan
{
    public partial class frmQuanLyBangGia : Form
    {
        BangGiaBUS bangGiaBUS = new BangGiaBUS();
        LoaiGiaBUS loaiGiaBUS = new LoaiGiaBUS();
        ErrorProvider er = new ErrorProvider();
        DataTable dtChiTietBangGia = new DataTable();
        int rowHandleDS = -1;


        public frmQuanLyBangGia()
        {
            InitializeComponent();
            dtChiTietBangGia.Columns.Add("MaChiTietBangGia", typeof(int));
            dtChiTietBangGia.Columns.Add("MaLoaiGia", typeof(int));
            dtChiTietBangGia.Columns.Add("DonGia", typeof(decimal));

            gridChiTietBangGia.DataSource = dtChiTietBangGia;
        }

        private void frmQuanLyBangGia_Load(object sender, EventArgs e)
        {
            LoadData_lkupLoaiGia(loaiGiaBUS.LayDanhSachTenLoaiGia());

            LayDanhSachBangGia();
        }

        //Load dữ liệu lên lkupLoaiGia
        private void LoadData_lkupLoaiGia(DataTable dt)
        {
            lkupLoaiGia.DataSource = dt;// Lấy dữ liệu lên lkupLoaiGia
            lkupLoaiGia.ValueMember = "MaLoaiGia";
            lkupLoaiGia.DisplayMember = "TenLoaiGia";
        }


        #region "Xử lý button"
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaBangGia.Text))
            {
                DialogResult dg = MessageBox.Show("Bạn có chắc muốn xóa dòng này không ? ", "Sửa dữ liệu", MessageBoxButtons.OKCancel);
                if (dg == DialogResult.Cancel)
                {                    
                    return;
                }
                bangGiaBUS.Delete(int.Parse(txtMaBangGia.Text));
                XtraMessageBox.Show("Xóa thành công.", "Thông Báo");
                RestoreDefaultValue();
                LayDanhSachBangGia();
            }                  
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                if (!string.IsNullOrEmpty(txtMaBangGia.Text))
                {
                    if (bangGiaBUS.Update(GetBangGia()))
                    {
                        XtraMessageBox.Show("Cập nhật thành công.", "Thông Báo");
                        RestoreDefaultValue();
                        LayDanhSachBangGia();
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Dữ liệu nhập không lệ.", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if(IsValidate())
            {
                //Thêm mới 1 bảng giá
                if (bangGiaBUS.Insert(GetBangGia()))
                {
                    XtraMessageBox.Show("Thêm mới thành công.", "Thông Báo");
                    RestoreDefaultValue();
                    LayDanhSachBangGia();
                }
            }
            else
            {
                XtraMessageBox.Show("Dữ liệu nhập không lệ.", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            PrintAndExport.ExportXls(gridDanhSachBangGia, "DANH SÁCH BẢNG GIÁ");
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            PrintAndExport.ShowGridPreview(gridDanhSachBangGia, "DANH SÁCH BẢNG GIÁ");
        }
        #endregion
        private BangGiaDTO GetBangGia()
        {
            BangGiaDTO temp = new BangGiaDTO();
            temp.MaBangGia = string.IsNullOrEmpty(txtMaBangGia.Text) ? -1 : int.Parse(txtMaBangGia.Text);
            temp.TenBangGia = txtTenBangGia.Text;
            temp.NgayBatDau = DateTime.Parse(dtNgayApDung.EditValue.ToString());
            temp.NgayKetThuc = DateTime.Parse(dtNgayKetThuc.EditValue.ToString());
            
            //Chi tiết bảng giá
            for (int i = 0; i < gridViewChiTietBangGia.RowCount; i++)
            {
                ChiTietBangGiaDTO ctBangGia = new ChiTietBangGiaDTO();
                ctBangGia.MaChiTietBangGia = !string.IsNullOrEmpty(gridViewChiTietBangGia.GetRowCellValue(i, colMaChiTietBangGia).ToString()) ? 
                                            int.Parse(gridViewChiTietBangGia.GetRowCellValue(i, colMaChiTietBangGia).ToString()) : - 1;//Không lấy được mà chi tiết bảng giá
                ctBangGia.MaBangGia = temp.MaBangGia;
                ctBangGia.MaLoaiGia = int.Parse(gridViewChiTietBangGia.GetRowCellValue(i, colLoaiGia).ToString());
                ctBangGia.DonGia = decimal.Parse(gridViewChiTietBangGia.GetRowCellValue(i, colDonGia).ToString());
                temp.ChiTietBangGia.Add(ctBangGia);
            }
            return temp;
        }

        #region "Kiểm tra hợp lệ dữ liệu"
        private void dtNgayApDung_EditValueChanged(object sender, EventArgs e)
        {
            dtNgayKetThuc.EditValue = dtNgayApDung.EditValue;//Set ngày kết thúc bằng ngày áp dụng
        }
        private bool IsValidate()
        {
            er.Clear();
            bool flag = true;
            if (txtTenBangGia.Text == string.Empty)//Tên bảng giá không được trống
            {
                er.SetError(txtTenBangGia, "Bạn chưa nhập tên bảng giá.");
                flag = false;
            }
            if (string.IsNullOrEmpty(dtNgayApDung.Text))//Ngày áp dụng không được để trống
            {
                er.SetError(dtNgayApDung, "Bạn chưa nhập ngày áp dụng.");
                flag = false;
            }
            if (string.IsNullOrEmpty(dtNgayKetThuc.Text))//Ngày kết thúc không được rỗng
            {
                er.SetError(dtNgayKetThuc, "Bạn chưa nhập ngày kết thúc.");
                flag = false;
            }
            if(gridViewChiTietBangGia.RowCount == 0)
            {
                er.SetError(gridChiTietBangGia, "Bạn chưa nhập nội dung bảng giá.");
                flag = false;
            }
            return flag;
        }

        private void RestoreDefaultValue()
        {
            txtMaBangGia.Text = string.Empty;
            txtTenBangGia.Text = string.Empty;
            dtNgayApDung.EditValue = null;
            dtNgayKetThuc.EditValue = null;
            dtChiTietBangGia.Clear();
            gridChiTietBangGia.DataSource = dtChiTietBangGia;
            er.Clear();
        }

        //Kiểm tra việc nhập thông tin Chi tiết bảng giá
        private void gridViewChiTietBangGia_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            XtraMessageBox.Show(e.ErrorText, "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void gridViewChiTietBangGia_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.ClearColumnErrors();
            foreach (GridColumn col in ((ColumnView)view).Columns)
            {
                if (col.FieldName != "MaChiTietBangGia")
                {
                    if (view.GetRowCellValue(e.RowHandle, col) == null || string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, col).ToString()))
                    {
                        e.Valid = false;
                        e.ErrorText = "Giá trị không được để trống";
                    }
                }
            }
        }
        #endregion
     
      
        private void gridViewChiTietBangGia_RowUpdated(object sender, RowObjectEventArgs e)
        {
            //// Bỏ Loại Giá đã chọn ra khỏi lkupLoaiGia
            //DataTable dt = loaiGiaBUS.LayDanhSachTenLoaiGia();
            //for(int i = 0; i < gridViewChiTietBangGia.RowCount; i++)
            //{
            //    for (int j = 0; j < dt.Rows.Count; j++)
            //    {
            //        if (dt.Rows[j].RowState != DataRowState.Deleted)
            //        { 
            //            if (int.Parse(dt.Rows[j]["MaLoaiGia"].ToString()) == int.Parse(gridViewChiTietBangGia.GetRowCellValue(i, colLoaiGia).ToString()))
            //            {
            //                dt.Rows[j].Delete();
            //            }
            //        }
            //    }
            //}
            //LoadData_lkupLoaiGia(dt);

            ////Them Dong Moi Vao DataTable
            //int rowHandle;
            //if (e.RowHandle == GridControl.NewItemRowHandle)
            //{
            //    rowHandle = gridViewChiTietBangGia.DataRowCount - 1;
            //}
            //else
            //{
            //    rowHandle = e.RowHandle;
            //}
            //dtChiTietBangGia.ImportRow(gridViewChiTietBangGia.GetDataRow(rowHandle));
            //gridChiTietBangGia.DataSource = dtChiTietBangGia;
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            txtMaBangGia.Text = gridViewDanhSachBangGia.GetRowCellValue(rowHandleDS, colMaBangGia).ToString();
            txtTenBangGia.Text = gridViewDanhSachBangGia.GetRowCellValue(rowHandleDS, colTenBangGia).ToString();
            dtNgayApDung.EditValue = DateTime.Parse(gridViewDanhSachBangGia.GetRowCellValue(rowHandleDS, colNgayApDung).ToString());
            dtNgayKetThuc.EditValue = DateTime.Parse(gridViewDanhSachBangGia.GetRowCellValue(rowHandleDS, colNgayKetThuc).ToString());

            DataTable t = new DataTable();
            t = bangGiaBUS.LayDanhSachChiTietBangGia(int.Parse(txtMaBangGia.Text));
            gridChiTietBangGia.DataSource = t;
        }

        private void gridViewDanhSachBangGia_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            rowHandleDS = e.RowHandle;
        }      

        private void LayDanhSachBangGia()
        {
            gridDanhSachBangGia.DataSource = bangGiaBUS.LayDanhSachBangGia();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            RestoreDefaultValue();
        }
    }
}
