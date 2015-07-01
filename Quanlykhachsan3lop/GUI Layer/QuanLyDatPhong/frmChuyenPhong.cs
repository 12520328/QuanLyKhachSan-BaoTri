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
    public partial class frmChuyenPhong : Form
    {
        private int MaPhong;
        public frmChuyenPhong()
        {
            InitializeComponent();
        }
        public frmChuyenPhong(string _tenPhong, int _MaPhong)
        {
            InitializeComponent();
            this.MaPhong = _MaPhong;
            lblTile.Text = "Chuyển phòng: " + _tenPhong;
        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(lkupSoPhong.EditValue == null)
            {
                XtraMessageBox.Show("Chưa chọn phòng mới.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ThuePhongBUS tpBUS = new ThuePhongBUS();
            ChuyenPhongBUS cpBUS = new ChuyenPhongBUS();

            cpBUS.Insert(GetChuyenPhong());//Insert thông tin chuyển phòng

            PhongBUS p = new PhongBUS();//Cập nhật tình trạng phòng
            p.UpdateTinhTrangPhong(0, MaPhong);//Phòng cũ trống
            p.UpdateTinhTrangPhong(2, int.Parse(lkupSoPhong.EditValue.ToString()));//Phòng mới đang ở
            p.UpdateMaThamChieu(p.LayMaThamChieu(MaPhong), int.Parse(lkupSoPhong.EditValue.ToString()));

            tpBUS.ChuyenPhong(p.LayMaThamChieu(MaPhong), MaPhong, int.Parse(lkupSoPhong.EditValue.ToString()));
            XtraMessageBox.Show("Chuyển phòng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private ChuyenPhongDTO GetChuyenPhong()
        {
            ChuyenPhongDTO cp = new ChuyenPhongDTO();
            cp.NgayChuyenPhong = DateTime.Now;
            cp.MaPhongCu = MaPhong;
            cp.MaPhongMoi =int.Parse(lkupSoPhong.EditValue.ToString());
            return cp;
        }

        #region Hiển Thị Danh Sách Phòng
        private void LayDanhSachPhong()
        {
            PhongBUS p = new PhongBUS();

            lkupSoPhong.Properties.DataSource = p.LayDanhSachPhong(0);
            lkupSoPhong.Properties.ValueMember = "MaPhong";
            lkupSoPhong.Properties.DisplayMember = "SoPhong";
        }
        #endregion

        private void frmChuyenPhong_Load(object sender, EventArgs e)
        {
            LayDanhSachPhong();
        }

    }
}
