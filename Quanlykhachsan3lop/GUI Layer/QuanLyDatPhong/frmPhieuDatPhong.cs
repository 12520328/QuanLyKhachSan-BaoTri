using DevExpress.XtraEditors;
using Quanlykhachsan3lop.Business_Logic_Layer;
using Quanlykhachsan3lop.Data_Transfer_Object;
using Quanlykhachsan3lop.GUI_Layer.QuanLyKhachHang;
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
    public partial class frmPhieuDatPhong : Form
    {

        private int MaPhong;
        public frmPhieuDatPhong()
        {
            InitializeComponent();        
           
        }

        public frmPhieuDatPhong(string tileName, bool isDatPhong, int MaPhong)
        {
            InitializeComponent();

            this.MaPhong = MaPhong;
            lblTile.Text = tileName;
            checkVND.Checked = true;

            if (isDatPhong)
            {
                radioDatPhong.Checked = true;
                LayDanhSachPhongTrong();
                lkupSoPhong.EditValue = MaPhong;                
            }
            else
            {

                LayDanhSachPhongDaDat();
                ShowThongTin(MaPhong);
            }
        }


        #region Button Click
        private void btnCalcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isValidate())
            {
                DatPhongBUS dpBUS = new DatPhongBUS();
                PhongBUS pBUS = new PhongBUS();
                int MaDatPhong = pBUS.LayMaThamChieu(MaPhong);
                if (radioNhanPhong.Checked == true)
                {
                    ThuePhongBUS tpBUS = new ThuePhongBUS();
                    tpBUS.Insert(GetThuePhong(MaDatPhong));
                    dpBUS.Update(GetDatPhong(MaDatPhong));
                    XtraMessageBox.Show("Nhận phòng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {                    
                    dpBUS.Insert(GetDatPhong());  
                    XtraMessageBox.Show("Đặt phòng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                frmPhieuDatPhong_Load(sender, e);              

            }
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            Form f = new frmThemKhachHang();
            this.Hide();
            if (f.ShowDialog() == DialogResult.Cancel)
            {
                LayDanhSachKhachHang();
                this.Show();
            }
        }
        #endregion

        private DatPhongDTO GetDatPhong(int MaDatPhong = 0)
        {
            DatPhongDTO dp = new DatPhongDTO();
            dp.MaDatPhong = MaDatPhong;
            dp.MaKhachHang = int.Parse(lkupKhachHang.EditValue.ToString());
            dp.NgayDat = DateTime.Now;
            dp.NgayDen = DateTime.Parse(dtNgayDen.EditValue.ToString());
            dp.NgayDi = DateTime.Parse(dtNgayDi.EditValue.ToString());
            dp.DatCoc = (calTraTruoc.EditValue == null ? 0 : decimal.Parse(calTraTruoc.EditValue.ToString()));
            dp.KhuyenMai = (calKhuyenMai.EditValue == null ? 0 : decimal.Parse(calKhuyenMai.EditValue.ToString()));
            dp.VND = checkVND.Checked == true ? 1 : 0;
            dp.TrangThai = "Chờ";

            ChiTietDatPhongDTO ct = new ChiTietDatPhongDTO();
            ct.MaPhong = int.Parse(lkupSoPhong.EditValue.ToString());
            dp.ChiTietDatPhong.Add(ct);

            return dp;
        }

        private ThuePhongDTO GetThuePhong(int MaDatPhong)
        {
            ThuePhongDTO tp = new ThuePhongDTO();
            tp.MaDatPhong = MaDatPhong;
            tp.NgayThuePhong =DateTime.Parse(dtNgayDen.EditValue.ToString());
            tp.GioThuePhong = DateTime.Parse(timeGioVao.EditValue.ToString());

            ChiTietThuePhongDTO ct = new ChiTietThuePhongDTO();
            ct.MaKhachHang = int.Parse(lkupKhachHang.EditValue.ToString());
            ct.MaPhong = int.Parse(lkupSoPhong.EditValue.ToString());
            tp.CTThuePhong.Add(ct);
           
            return tp;
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

        #region Hiển Thị Danh Sách Phòng
        private void LayDanhSachPhongTrong()
        {
            PhongBUS p = new PhongBUS();

            lkupSoPhong.Properties.DataSource = p.LayDanhSachPhong(0);
            lkupSoPhong.Properties.ValueMember = "MaPhong";
            lkupSoPhong.Properties.DisplayMember = "SoPhong";
        }
        private void LayDanhSachPhongDaDat()
        {
            PhongBUS p = new PhongBUS();

            lkupSoPhong.Properties.DataSource = p.LayDanhSachPhong(1);
            lkupSoPhong.Properties.ValueMember = "MaPhong";
            lkupSoPhong.Properties.DisplayMember = "SoPhong";
        }
        #endregion

        private void lkupSoPhong_EditValueChanged(object sender, EventArgs e)
        {            
            if(lkupSoPhong.EditValue != null)
            {
                PhongBUS p = new PhongBUS();
                DataTable dt = p.LayDanhSach(int.Parse(lkupSoPhong.EditValue.ToString()));
                if (dt.Rows.Count > 0)
                    txtGiaTien.Text = dt.Rows[0]["GiaTheoNgay"].ToString();
                if (radioNhanPhong.Checked == true)
                    ShowThongTin(int.Parse(lkupSoPhong.EditValue.ToString()));
                
            }
        }

        private void frmPhieuDatPhong_Load(object sender, EventArgs e)
        {
            LayDanhSachKhachHang();
        }

        private void radioNhanPhong_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNhanPhong.Checked == true)
            {
                radioDatPhong.Checked = false;
                timeGioVao.EditValue = DateTime.Now;
                lblTile.Text = "Nhận Phòng";
                LayDanhSachPhongDaDat();
            }
            else
            {
                radioDatPhong.Checked = true;
                lblTile.Text = "Đặt Phòng";
                LayDanhSachPhongTrong();
                Clear();
            }
        }

        private void radioDatPhong_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDatPhong.Checked == true)
            {
                radioNhanPhong.Checked = false;
                lblTile.Text = "Đặt Phòng";
                LayDanhSachPhongTrong();
                Clear();
            }
            else
            {
                radioNhanPhong.Checked = true;
                timeGioVao.EditValue = DateTime.Now;
                lblTile.Text = "Nhận Phòng";
                LayDanhSachPhongDaDat();
            }
        }

        private void checkVND_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVND.Checked == true)
                checkPhanTram.Checked = false;
            else
                checkPhanTram.Checked = true;
        }

        private void checkPhanTram_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPhanTram.Checked == true)
                checkVND.Checked = false;
            else
                checkVND.Checked = true;
        }

        #region Kiểm tra dữ liệu
        ErrorProvider er = new ErrorProvider();
        private void dtNgayDen_EditValueChanged(object sender, EventArgs e)
        {
            dtNgayDi.EditValue = dtNgayDen.EditValue;
        }

        private void dtNgayDi_EditValueChanged(object sender, EventArgs e)
        {
            er.Clear();
            if (dtNgayDen.EditValue == null)
            {
                er.SetError(dtNgayDen, "Chưa nhập ngày nhận phòng.");
                return;
            }
            else
            {
                if (DateTime.Compare(DateTime.Parse(dtNgayDen.EditValue.ToString()),
                    DateTime.Parse(dtNgayDi.EditValue.ToString())) == 1)
                {
                    XtraMessageBox.Show("Ngày nhận phòng phải nhỏ hơn ngày trả phòng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtNgayDi.EditValue = dtNgayDen.EditValue;
                }
            }
        }
        private bool isValidate()
        {
            er.Clear();
            bool f = true;
            if (lkupKhachHang.EditValue == null)
            {
                er.SetError(lkupKhachHang, "Chưa chọn khách hàng");
                f = false;
            }
            else
            {
                if (lkupSoPhong.EditValue == null)
                {
                    er.SetError(lkupSoPhong, "Chưa chọn phòng.");
                    f = false;
                }
                else
                {
                    if (dtNgayDen.EditValue == null)
                    {
                        er.SetError(dtNgayDen, "Chưa chọn ngày nhận phòng.");
                        f = false;
                    }
                    else
                    {
                        if (dtNgayDi.EditValue == null)
                        {
                            er.SetError(dtNgayDi, "Chưa chọn ngày trả phòng.");
                            f = false;
                        }
                    }
                }
            }
            return f;
        }
        #endregion

        private void timeGioVao_EditValueChanged(object sender, EventArgs e)
        {
            timeGioRa.EditValue = timeGioVao.EditValue;
        }


        private void ShowThongTin(int _MaPhong)
        {
            //Khi phong da dat
            MaPhong = _MaPhong;
            PhongBUS pBUS = new PhongBUS();
            DatPhongBUS dpBUS = new DatPhongBUS();
            int MaDatPhong = pBUS.LayMaThamChieu(MaPhong);
            radioNhanPhong.Checked = true;
            lkupSoPhong.EditValue = MaPhong;
            lkupKhachHang.EditValue = dpBUS.LayMaKhachHang(MaDatPhong);
            DataTable dt = dpBUS.LayDanhSachPhieuDatPhong(MaDatPhong);
            if (dt.Rows.Count > 0)
            {
                dtNgayDen.EditValue = dt.Rows[0]["NgayDen"];
                dtNgayDi.EditValue = dt.Rows[0]["NgayDi"];
                calTraTruoc.EditValue = dt.Rows[0]["DatCoc"] == null ? 0 : dt.Rows[0]["DatCoc"];
                calKhuyenMai.EditValue = dt.Rows[0]["KhuyenMai"] == null ? 0 : dt.Rows[0]["KhuyenMai"];
                if (bool.Parse(dt.Rows[0]["VND"].ToString()))
                    checkVND.Checked = true;
                else
                    checkPhanTram.Checked = true;
            }
            timeGioVao.EditValue = timeGioRa.EditValue = DateTime.Now;
        }

        private void Clear()
        {
            lkupKhachHang.EditValue = null;
            lkupSoPhong.EditValue = null;
            txtGiaTien.Text = string.Empty;
            dtNgayDen.EditValue = DateTime.Now;
            dtNgayDi.EditValue = DateTime.Now;
            timeGioRa.EditValue = timeGioVao.EditValue = DateTime.Now;
            calTraTruoc.EditValue = calKhuyenMai.EditValue = 0;
            checkVND.Checked = true;
        }

    }
}
