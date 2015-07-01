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
    public partial class frmThuePhong : Form
    {
        private int MaThuePhong;
        public frmThuePhong()
        {
            InitializeComponent();
        }

        public frmThuePhong(int MaThuePhong)
        {
            InitializeComponent();
            this.MaThuePhong = MaThuePhong;
        }

        private void frmThuePhong_Load(object sender, EventArgs e)
        {
            DanhSachPhieuThuePhong();
            DanhSachPhongTheoPhieuDat();
            DanhSachKhachHang();
            lkupMaThuePhong.EditValue = MaThuePhong;
        }

        #region Danh Sách Phiếu Thuê Phòng
        private void DanhSachPhieuThuePhong()
        {
            ThuePhongBUS dp = new ThuePhongBUS();
            lkupMaThuePhong.Properties.DataSource = dp.LayDanhSachPhieuThuePhong();
            lkupMaThuePhong.Properties.ValueMember = "MaThuePhong";
            lkupMaThuePhong.Properties.DisplayMember = "MaThuePhong";
        }
        #endregion

        #region Danh Sách Phòng Theo Phiếu Đặt Phòng
        private void DanhSachPhongTheoPhieuDat()
        {            
            if(lkupMaThuePhong.EditValue == null)
            {
                XtraMessageBox.Show("Bạn vui lòng chọn đơn đặt phòng trước.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DatPhongBUS dp = new DatPhongBUS();
            ThuePhongBUS tp = new ThuePhongBUS();
            lkupPhong.Properties.DataSource = dp.LayDanhSachPhongTheoMaDatPhong(
                tp.LayMaDatPhong(int.Parse(lkupMaThuePhong.EditValue.ToString())));
            lkupPhong.Properties.ValueMember = "MaPhong";
            lkupPhong.Properties.DisplayMember = "SoPhong";
        }
        #endregion

        #region Danh Sách Khách Hàng
        //Chưa lọc danh sách khách hàng đang thuê phòng
        private void DanhSachKhachHang()
        {
            KhachHangBUS kh = new KhachHangBUS();
            lkupKhachHang.Properties.DataSource = kh.LayDanhSachKhachHang();
            lkupKhachHang.Properties.ValueMember = "MaKhachHang";
            lkupKhachHang.Properties.DisplayMember = "TenKhachHang";
        }
        #endregion

        #region Danh Sách Khách Hàng Thuê Phong
        private void DanhSachKhachHangThuePhong()
        {
            ThuePhongBUS tp = new ThuePhongBUS();
            gridControl1.DataSource = tp.LayDanhSachKhachThuePhong();
        }

        #endregion
        private void lkupMaDatPhong_EditValueChanged(object sender, EventArgs e)
        {
            DanhSachPhongTheoPhieuDat();
        }

        #region Validation
        ErrorProvider er = new ErrorProvider();
        private bool isValidated()
        {
            er.Clear();
            bool f = true;
            if(lkupKhachHang.EditValue ==  null)
            {
                f = false;
                er.SetError(lkupKhachHang, "Chưa chọn khách hàng.");
            }
            if (lkupPhong.EditValue == null)
            {
                f = false;
                er.SetError(lkupPhong, "Chưa chọn phòng.");
            }
            return f;
        }
        #endregion

        #region Xử lý button
        //Button thêm khách hàng
        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
        ThuePhongBUS tp = new ThuePhongBUS();
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(isValidated())
            {
                tp.InsertCTThuePhong(GetChiTietThuePhong());

            }
        }

        private ChiTietThuePhongDTO GetChiTietThuePhong()
        {
            ChiTietThuePhongDTO ct = new ChiTietThuePhongDTO();
            ct.MaKhachHang = int.Parse(lkupKhachHang.EditValue.ToString());
            ct.MaPhong = int.Parse(lkupPhong.EditValue.ToString());
            ct.MaThuePhong = int.Parse(lkupMaThuePhong.EditValue.ToString());
            if (lkupMaThuePhong.EditValue != null)
                ct.MaChiTietThuePhong = int.Parse(lkupMaThuePhong.EditValue.ToString());
            return ct;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
