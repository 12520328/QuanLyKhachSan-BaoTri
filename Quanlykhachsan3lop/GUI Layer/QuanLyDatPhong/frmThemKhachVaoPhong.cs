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
    public partial class frmThemKhachVaoPhong : Form
    {
        public frmThemKhachVaoPhong()
        {
            InitializeComponent();
        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ErrorProvider er = new ErrorProvider();
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lkupKhachHang.EditValue == null)
            {
                er.SetError(lkupKhachHang, "Chưa chọn khách hàng");
                return;
            }
            if (lkupSoPhong.EditValue == null)
            {
                er.SetError(lkupSoPhong, "Chưa chọn phòng.");
                return;
            }
            ThuePhongBUS tpBUS = new ThuePhongBUS();
            PhongBUS pBUS = new PhongBUS();

            ChiTietThuePhongDTO cttpDTO = new ChiTietThuePhongDTO();

            cttpDTO.MaThuePhong = pBUS.LayMaThamChieu(int.Parse(lkupSoPhong.EditValue.ToString()));
            cttpDTO.MaPhong = int.Parse(lkupSoPhong.EditValue.ToString());
            cttpDTO.MaKhachHang = int.Parse(lkupKhachHang.EditValue.ToString());

            tpBUS.InsertCTThuePhong(cttpDTO);
            XtraMessageBox.Show("Thêm khách hàng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


      

        #region Danh Sách Khách Hàng
        private void LayDanhSachKhachHang()
        {
            KhachHangBUS kh = new KhachHangBUS();
            lkupKhachHang.Properties.DataSource = kh.LayDanhSachKhachHang();
            lkupKhachHang.Properties.DisplayMember = "TenKhachHang";
            lkupKhachHang.Properties.ValueMember = "MaKhachHang";
        }
        #endregion

        #region Hiển Thị Danh Sách Phòng Đang Được Thuê
        private void LayDanhSachPhong()
        {
            PhongBUS p = new PhongBUS();

            lkupSoPhong.Properties.DataSource = p.LayDanhSachPhong(2);
            lkupSoPhong.Properties.ValueMember = "MaPhong";
            lkupSoPhong.Properties.DisplayMember = "SoPhong";
        }
        #endregion

        private void frmThemKhachVaoPhong_Load(object sender, EventArgs e)
        {
            LayDanhSachKhachHang();
            LayDanhSachPhong();
        }
    }
}
