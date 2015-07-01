using Quanlykhachsan3lop.Business_Logic_Layer;
using Quanlykhachsan3lop.Data_Access_Layer;
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
    public partial class frmHoaDon : Form
    {
        private int _maThuePhong;
        private int _maPhong;
        private string _tenPhong;
        DataTable dtTienPhong = new DataTable();
        public frmHoaDon()
        {
            InitializeComponent();
        }

        public frmHoaDon(int MaPhong, string TenPhong)
        {
            InitializeComponent();
            PhongBUS p = new PhongBUS();
            _maThuePhong = p.LayMaThamChieu(MaPhong);
            _maPhong = MaPhong;
            _tenPhong = TenPhong;

            dtTienPhong.Columns.Add("TenPhong", typeof(string));
            dtTienPhong.Columns.Add("NgayNhanPhong", typeof(DateTime));
            dtTienPhong.Columns.Add("NgayDi", typeof(DateTime));
            dtTienPhong.Columns.Add("SoNgayO", typeof(int));
            dtTienPhong.Columns.Add("GiaTheoNgay", typeof(decimal));
            dtTienPhong.Columns.Add("ThanhTien", typeof(decimal));
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {            
            LayDanhSachKhachHang();
            txtMaPhieuThue.Text = _maThuePhong.ToString();
            ThuePhongBUS tp = new ThuePhongBUS();
            DataTable dt = tp.LayDanhSachChiTietThuePhong(_maThuePhong);
            if (dt.Rows.Count > 0)
                lkupKhachHang.EditValue =int.Parse(dt.Rows[0]["MaKhachHang"].ToString());
            dtNgayThanhToan.EditValue = DateTime.Now;
            DatPhongBUS dp = new DatPhongBUS();
            dt = dp.LayDanhSachPhieuDatPhong(tp.LayMaDatPhong(_maThuePhong));
            if(dt.Rows.Count > 0)
            {
                txtTienDatCoc.Text = dt.Rows[0]["DatCoc"].ToString();
                txtKhuyenMai.Text = dt.Rows[0]["KhuyenMai"].ToString();
                if (bool.Parse(dt.Rows[0]["VND"].ToString()))
                    checkEdit1.Checked = false;
                else
                    checkEdit1.Checked = true;
            }

            LoadDuLieu();
            HoaDonBUS hd = new HoaDonBUS();
            dtTienPhong = hd.LayThongTinThuePhong(_maThuePhong);
            gridControl1.DataSource = dtTienPhong;
            gridView1.SetRowCellValue(0, colNgayDi, DateTime.Now.ToShortDateString());
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            btnThongTinSuDungDichVu.Enabled = false;
        }

        private void btnThongTinSuDungDichVu_Click(object sender, EventArgs e)
        {
            Form f = new frmSuDungDichVu(_tenPhong, _maPhong);
            f.ShowDialog();
        }

        private void LoadDuLieu()
        {
            ChiTietSuDungDichVuBUS ctBUS = new ChiTietSuDungDichVuBUS();
            gridControl2.DataSource = ctBUS.LayDanhSachChiTietSuDungDichVu(_maThuePhong);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridView1.GetRowCellValue(e.RowHandle, colNgayDen) != null)
            {
                gridView1.SetRowCellValue(e.RowHandle, colNgayDi, DateTime.Now.ToShortDateString());
                if (gridView1.GetRowCellValue(e.RowHandle, colNgayDi) != null)
                {
                    DateTime ngayDen = DateTime.Parse(gridView1.GetRowCellValue(e.RowHandle, colNgayDen).ToString());
                    DateTime ngayDi = DateTime.Parse(gridView1.GetRowCellValue(e.RowHandle, colNgayDi).ToString());

                    TimeSpan soNgayO = ngayDi - ngayDen;
                    gridView1.SetRowCellValue(e.RowHandle, colSoNgayO, soNgayO.Days);
                }
                if(gridView1.GetRowCellValue(e.RowHandle, colSoNgayO) != null)
                {
                    decimal thanhtien = int.Parse(gridView1.GetRowCellValue(e.RowHandle, colSoNgayO).ToString()) * decimal.Parse(gridView1.GetRowCellValue(e.RowHandle, colGiaTheoNgay).ToString());
                    gridView1.SetRowCellValue(e.RowHandle,colThanhTien,thanhtien);
                }
            }
        }
    }
}
