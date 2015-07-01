using DevExpress.XtraEditors;
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

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyDatPhong
{
    public partial class frmDatPhong : Form
    {
        ErrorProvider er = new ErrorProvider();
        DatPhongBUS datPhong = new DatPhongBUS();
        public frmDatPhong()
        {
            InitializeComponent();
        }

        //Form Load
        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            LayDanhSachKhachHang();
            LayDanhSachKhuyenMai();
            LayDanhSachPhong();
            DanhSachDonDatPhong();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }
        #region Tab - Đơn Đặt Phòng

        #region Khách Hàng
        //Load danh sách khách hàng lên lkupKhachHang
        private void LayDanhSachKhachHang()
        {
            KhachHangBUS kh = new KhachHangBUS();
            lkupKhachHang.Properties.DataSource = kh.LayDanhSachKhachHang();
            lkupKhachHang.Properties.DisplayMember = "TenKhachHang";
            lkupKhachHang.Properties.ValueMember = "MaKhachHang";
        }
        //Thêm khách hàng
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region Khuyến Mãi
        //Load danh sách khuyến mãi lên lkupKhuyenMAi
        private void LayDanhSachKhuyenMai()
        {
            KhuyenMaiBUS km = new KhuyenMaiBUS();
            lkupKhuyenMai.Properties.DataSource = km.LayDanhSach();
            lkupKhuyenMai.Properties.DisplayMember = "TenKhuyenMai";
            lkupKhuyenMai.Properties.ValueMember = "MaKhuyenMai";
        }

        //Thêm Khuyến Mãi
        private void btnThemKhuyenMai_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region Thiết lập quy định ngày nhận, ngày trả
        private void dtNgayNhanPhong_EditValueChanged(object sender, EventArgs e)
        {
            dtNgayTraPhong.EditValue = dtNgayNhanPhong.EditValue;
        }

        private void dtNgayTraPhong_EditValueChanged(object sender, EventArgs e)
        {
            er.Clear();
            if (dtNgayNhanPhong.EditValue == null)
            {
                er.SetError(dtNgayNhanPhong, "Chưa nhập ngày nhận phòng.");
                return;
            }
            else
            {
                if (DateTime.Compare(DateTime.Parse(dtNgayNhanPhong.EditValue.ToString()),
                    DateTime.Parse(dtNgayTraPhong.EditValue.ToString())) == 1)
                {
                    XtraMessageBox.Show("Ngày nhận phòng phải nhỏ hơn ngày trả phòng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtNgayTraPhong.EditValue = dtNgayNhanPhong.EditValue;
                }
            }
        }
        #endregion


        #region Hiển Thị Danh Sách Phòng
        private void LayDanhSachPhong()
        {
            PhongBUS p = new PhongBUS();
            p.LayDanhSachPhongChoThue();
            gridControl1.DataSource = p.LayDanhSachPhongChoThue();

            lkupSoPhong.DataSource = p.LayDanhSachPhongChoThue();
            lkupSoPhong.ValueMember = "MaPhong";
            lkupSoPhong.DisplayMember = "SoPhong";
        }
        #endregion


        #region Xử lý button
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Đặt phòng

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin hợp lệ
            if (isValidated())
            {
                if (datPhong.Insert(GetDatPhong()))
                {
                    XtraMessageBox.Show("Tạo thông tin đặt phòng thành công.", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDatPhong.Enabled = false;
                    txtTrangThai.Text = TrangThai.Waiting.ToString();
                    txtMaDonDatPhong.Text = datPhong.LayMaDatPhong().ToString();
                    btnCapNhat.Enabled = true;
                    DanhSachDonDatPhong();
                }
            }
        }

        //Refresh
        private void Refresh()
        {
            lkupKhachHang.EditValue = null;
            lkupKhuyenMai.EditValue = null;
            calTongSoKhach.EditValue = 0;
            calTienDatCoc.EditValue = 0;
            dtNgayNhanPhong.EditValue = dtNgayTraPhong.EditValue = DateTime.Now;
            LayDanhSachPhong();
        }

        //Enum trạng thái đặt phòng
        enum TrangThai
        {
            Waiting,
            Hiring,
            Canceled
        };
        //Lấy thông tin đặt phòng từ form
        private DatPhongDTO GetDatPhong()
        {
            DatPhongDTO d = new DatPhongDTO();
            d.MaKhachHang = int.Parse(lkupKhachHang.EditValue.ToString());
            d.NgayDat = DateTime.Now;
            d.NgayDen = DateTime.Parse(dtNgayNhanPhong.EditValue.ToString());
            d.NgayDi = DateTime.Parse(dtNgayTraPhong.EditValue.ToString());
            d.TrangThai = TrangThai.Waiting.ToString();
            if (lkupKhuyenMai.EditValue == System.DBNull.Value)
            {
                d.KhuyenMai = int.Parse(lkupKhuyenMai.EditValue.ToString());
            }
            d.DatCoc = (calTienDatCoc.EditValue == System.DBNull.Value) ? 0 : decimal.Parse(calTienDatCoc.EditValue.ToString());
            d.TongSoKhach = (calTongSoKhach.EditValue == System.DBNull.Value) ? 0 : int.Parse(calTongSoKhach.EditValue.ToString());

            int[] selectIndexs = gridView1.GetSelectedRows();
            for (int i = 0; i < selectIndexs.Length; i++)
            {
                ChiTietDatPhongDTO ct = new ChiTietDatPhongDTO();
                ct.MaPhong = int.Parse(gridView1.GetRowCellValue(i, colMaPhong).ToString());
                d.ChiTietDatPhong.Add(ct);
            }
            d.TongSoPhong = selectIndexs.Length;
            return d;
        }
        //Hủy đặt phòng
        private void btnHuyDatPhong_Click(object sender, EventArgs e)
        {
            if (!isValidated())
            {
                er.Clear();
                XtraMessageBox.Show("Không tìm thấy đơn đặt phòng được chọn.", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                HuyDatPhong(int.Parse(txtMaDonDatPhong.Text));
            }
        }

        private void HuyDatPhong(int MaDatPhong)
        {
            //Thêm thông tin phiểu hủy đặt phòng vào bảng đặt phòng
            HuyDatPhongBUS h = new HuyDatPhongBUS();
            HuyDatPhongDTO hDTO = new HuyDatPhongDTO();
            hDTO.MaDatPhong = MaDatPhong;
            hDTO.NgayHuy = DateTime.Now;
            h.Insert(hDTO);
            //Cập nhật trạng thái đơn đặt phòng
            datPhong.UpdateTrangThai(MaDatPhong, TrangThai.Canceled.ToString());
            txtTrangThai.Text = datPhong.LayTrangThai(MaDatPhong);
            
        }
        //Cập nhật thông tin
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin hợp lệ
            if (isValidated())
            {
                if (datPhong.Update(GetDatPhong()))
                {
                    XtraMessageBox.Show("Cập nhật thông tin đặt phòng thành công.", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDatPhong.Enabled = false;
                    txtMaDonDatPhong.Text = datPhong.LayMaDatPhong().ToString();
                    txtTrangThai.Text = datPhong.LayTrangThai(int.Parse(txtMaDonDatPhong.Text));
                }
            }
        }
        #endregion


        #region Validation
        private bool isValidated()
        {
            er.Clear();
            bool f = true;
            if (lkupKhachHang.EditValue == null)
            {
                er.SetError(lkupKhachHang, "Chưa chọn khách hàng.");
                f = false;
            }
            if (dtNgayNhanPhong.EditValue == null)
            {
                er.SetError(dtNgayNhanPhong, "Chưa nhập ngày nhận phòng.");
                f = false;
            }
            if (dtNgayTraPhong.EditValue == null)
            {
                er.SetError(dtNgayTraPhong, "Chưa nhập ngày trả phòng.");
                f = false;
            }
            int[] selectIndexs = gridView1.GetSelectedRows();
            if (selectIndexs.Length == 0)
            {
                er.SetError(gridControl1, "Chưa chọn phòng.");
                f = false;
                //XtraMessageBox.Show("Bạn chưa chọn thông tin phòng đặt. Vui lòng chọn lại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return f;
        }
        #endregion
        #endregion

        #region Tab - Danh Sách Đơn Đặt Phòng

        #region Danh sách đơn đặt phòng
        private void DanhSachDonDatPhong()
        {
            gridControl2.DataSource = datPhong.LayDanhSachPhieuDatPhong();
        }
        #endregion

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            int rowHandle = gridView2.FocusedRowHandle;
            if (rowHandle < 0)
                return;
            DataTable temp = datPhong.LayDanhSachPhieuDatPhong(int.Parse(gridView2.GetRowCellValue(rowHandle, colMaDonDatPhong).ToString()));

            txtMaDonDatPhong.Text = temp.Rows[0]["MaDatPhong"].ToString();
            lkupKhachHang.EditValue = temp.Rows[0]["MaKhachHang"];
            lkupKhuyenMai.EditValue = temp.Rows[0]["MaKhuyenMai"] == null ? null : temp.Rows[0]["MaKhuyenMai"];
            calTienDatCoc.EditValue = temp.Rows[0]["DatCoc"];
            calTongSoKhach.EditValue = temp.Rows[0]["TongSoKhach"];
            dtNgayNhanPhong.EditValue = temp.Rows[0]["NgayDen"];
            dtNgayTraPhong.EditValue = temp.Rows[0]["NgayDi"];

            //gridControl1.DataSource = datPhong.LayDanhSachChiTietDatPhong(int.Parse(gridView2.GetRowCellValue(rowHandle, colMaDonDatPhong).ToString()));
            xtraTabControl1.SelectedTabPage = tabDonDatPhong;

            btnThemPhong.Visible = true;
        }
        //Chua xoa dc
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, colMaDonDatPhong) == null)
                return;
            int maDatPhong = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, colMaDonDatPhong).ToString());
            datPhong.Delete(maDatPhong);
            XtraMessageBox.Show("Xóa đơn đặt phòng thành công.", "Thông Báo",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNhanP_Click(object sender, EventArgs e)
        {
            if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, colMaDonDatPhong) == null)
                return;
            datPhong.UpdateTrangThai(int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, colMaDonDatPhong).ToString()),
                TrangThai.Hiring.ToString());
            //Thêm dữ liệu vào bảng thuê phòng
            ThuePhongDTO thuePhong = new ThuePhongDTO();
            thuePhong.MaDatPhong = int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, colMaDonDatPhong).ToString());
            thuePhong.NgayThuePhong = DateTime.Now;
            thuePhong.GioThuePhong = DateTime.Now;
            ThuePhongBUS tpBUS = new ThuePhongBUS();
            tpBUS.Insert(thuePhong);
            //Gọi Form Thuê Phòng         

            Form f = new frmThuePhong(tpBUS.LayMaThuePhong());
            f.ShowDialog();
            
        }

        private void btnHuyDP_Click(object sender, EventArgs e)
        {
            if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, colMaDonDatPhong) == null)
                return;
            HuyDatPhong(int.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, colMaDonDatPhong).ToString()));
        }

        #endregion

        private void txtMaDonDatPhong_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDonDatPhong.Text))
            {
                txtTrangThai.Text = TrangThai.Waiting.ToString();
                return;
            }
            txtTrangThai.Text = datPhong.LayTrangThai(int.Parse(txtMaDonDatPhong.Text));
        }

        private void txtTrangThai_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTrangThai.Text.Trim() == TrangThai.Waiting.ToString())
            {
                btnCapNhat.Enabled = true;
                btnDatPhong.Enabled = false;
                btnHuyDatPhong.Enabled = true;
            }
            else
            {
                if (txtTrangThai.Text.Trim() == TrangThai.Canceled.ToString())
                {
                    btnCapNhat.Enabled = false;
                    btnDatPhong.Enabled = false;
                    btnHuyDatPhong.Enabled = false;
                }
                else
                {
                    btnCapNhat.Enabled = true;
                    btnDatPhong.Enabled = false;
                    btnHuyDatPhong.Enabled = false;
                }
            }
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.ReadOnly = false;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
        }

        private void lkupSoPhong_EditValueChanged(object sender, EventArgs e)
        {
            int rowHandle = gridView1.FocusedRowHandle;
            PhongBUS p = new PhongBUS();
            DataTable dt = p.LayDanhSachPhongChoThue(int.Parse(gridView1.GetRowCellValue(rowHandle,colSoPhong).ToString()));
            gridView1.SetRowCellValue(rowHandle, colLoaiPhong, dt.Rows[0]["TenLoaiPhong"].ToString());
            gridView1.SetRowCellValue(rowHandle, colGiaTien, dt.Rows[0]["GiaTheoNgay"].ToString());
            gridView1.SetRowCellValue(rowHandle, colSoNguoiToiDa, dt.Rows[0]["SoNguoiToiDa"].ToString());

        }
    }
    
    
}
