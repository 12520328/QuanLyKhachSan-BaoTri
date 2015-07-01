using DevExpress.XtraEditors;
using Quanlykhachsan3lop.Business_Logic_Layer;
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
    public partial class frmThongTinPhong : Form
    {
        private int _maPhong;


        public frmThongTinPhong()
        {
            InitializeComponent();
        }
        public frmThongTinPhong(string TenPhong, int MaPhong)
        {
            InitializeComponent();
            lblTile.Text = "Thông tin phòng: " + TenPhong;
            _maPhong = MaPhong;
        }

        #region Thông tin phòng
        private string DanhSachTienNghiTrongPhong()
        {
            QuanLyVatTuBUS ql = new QuanLyVatTuBUS();
            PhongBUS p = new PhongBUS();
            string str = string.Empty;
            if (p.LayDanhSach(_maPhong).Rows.Count == 0)
                return str;
            int _maLoaiPhong = int.Parse(p.LayDanhSach(_maPhong).Rows[0]["MaLoaiPhong"].ToString());                  
            DataTable dt =  ql.LayDanhSachQuanLyVatTu(_maLoaiPhong);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if(string.IsNullOrEmpty(str))
                {
                    str += dt.Rows[i]["TenVatTu"].ToString();
                }
                else
                {
                    str += ", " + dt.Rows[i]["TenVatTu"].ToString();
                }
            }
            return str;
        }
        
        private void ThongTinPhong()
        {
            PhongBUS p = new PhongBUS();
            DataTable dt = p.LayDanhSach(_maPhong);
            if(dt.Rows.Count > 0)
            {
                lblSoGiuong.Text = dt.Rows[0]["SoGiuong"].ToString();
                lblGiaTheoNgay.Text = dt.Rows[0]["GiaTheoNgay"].ToString() + " VNĐ";
                lblSoNguoi.Text = dt.Rows[0]["SoNguoi"].ToString();
                txtThongTinPhong.Text = dt.Rows[0]["ThongTinPhong"].ToString();
            }
        }
        #endregion

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Cập Nhật Thông Tin Phòng
            PhongBUS p = new PhongBUS();
            p.UpdateThongTinPhong(string.IsNullOrEmpty(txtThongTinPhong.Text) ? "" : txtThongTinPhong.Text, _maPhong);
            XtraMessageBox.Show("Cập nhật thông tin thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmThongTinPhong_Load(object sender, EventArgs e)
        {
            lblTienNghi.Text = DanhSachTienNghiTrongPhong();
            ThongTinPhong();
        }
    }
}
