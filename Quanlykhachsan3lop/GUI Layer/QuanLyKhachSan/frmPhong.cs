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

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyKhachSan
{
    public partial class frmPhong : Form
    {
        private bool isUpdate = false;//Kiểm tra hành động có phải là cập nhật
        private int _maPhong;//Lưu thông tin mã phòng được chọn
        PhongBUS p = new PhongBUS();

        public frmPhong()
        {
            InitializeComponent();
        }

        public frmPhong(PhongDTO p)
        {
            InitializeComponent();
            lkupLoaiPhong.EditValue = p.MaLoaiPhong;
            lkupSoTang.EditValue = p.MaTang;
            txtTenPhong.Text = p.SoPhong;
            txtThongTinPhong.Text = p.ThongTinPhong;
            calSoGiuong.EditValue = p.SoGiuong;
            calSoNguoi.EditValue = p.SoNguoi;

            _maPhong = p.MaPhong;

            isUpdate = true;
        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isValidate())
            {
                if (isUpdate == true)
                {
                    //Thực hiện update
                    p.Update(GetPhong(_maPhong));
                    XtraMessageBox.Show("Cập nhật thông tin thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Thực hiện insert
                    p.Insert(GetPhong());
                    XtraMessageBox.Show("Thêm mới thông tin thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private PhongDTO GetPhong(int MaPhong = 0)
        {
            PhongDTO p = new PhongDTO();
            p.MaPhong = MaPhong;
            p.SoPhong = txtTenPhong.Text;
            p.MaLoaiPhong = int.Parse(lkupLoaiPhong.EditValue.ToString());
            p.MaTang = int.Parse(lkupSoTang.EditValue.ToString());
            p.ThongTinPhong = string.IsNullOrEmpty(txtThongTinPhong.Text) ? "" : txtThongTinPhong.Text;
            if (!isUpdate)
                p.TinhTrangPhong = 0;
            p.SoGiuong = int.Parse(calSoGiuong.EditValue.ToString());
            p.SoNguoi = int.Parse(calSoNguoi.EditValue.ToString());
            return p;
        }

        #region Danh sách tầng lầu
        private void DanhSachTangLau()
        {
            TangLauBUS tl = new TangLauBUS();
            if (tl.LayDanhSachTangLau() == null)
            {
                XtraMessageBox.Show("Chưa có danh sách tầng lầu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lkupSoTang.Properties.DataSource = tl.LayDanhSachTangLau();
            lkupSoTang.Properties.ValueMember = "MaTangLau";
            lkupSoTang.Properties.DisplayMember = "TenTangLau";
        }
        #endregion


        #region Danh sách loại phòng
        private void DanhSachLoaiPhong()
        {
            LoaiPhongBUS tl = new LoaiPhongBUS();
            if (tl.LayDanhSachLoaiPhong() == null)
            {
                XtraMessageBox.Show("Chưa có danh sách loại phòng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lkupLoaiPhong.Properties.DataSource = tl.LayDanhSachLoaiPhong();
            lkupLoaiPhong.Properties.ValueMember = "MaLoaiPhong";
            lkupLoaiPhong.Properties.DisplayMember = "TenLoaiPhong";
        }
        #endregion


        private void frmPhong_Load(object sender, EventArgs e)
        {
            DanhSachLoaiPhong();
            DanhSachTangLau();
        }

        #region Kiểm tra hợp lệ dữ liệu
        ErrorProvider er = new ErrorProvider();
        private bool isValidate()
        {
            er.Clear();
            bool f = true;
            if (lkupLoaiPhong.EditValue == null)
            {
                er.SetError(lkupLoaiPhong, "Chưa chọn loại phòng.");
                f = false;
            }
            if (lkupSoTang.EditValue == null)
            {
                er.SetError(lkupSoTang, "Chưa chọn số tầng.");
                f = false;
            }
            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                er.SetError(txtTenPhong, "Chưa nhập tên phòng.");
                f = false;
            }
            if(calSoGiuong.EditValue == null)
            {
                er.SetError(calSoGiuong, "Chưa nhập số giường.");
                f = false;
            }
            if (calSoNguoi.EditValue == null)
            {
                er.SetError(calSoGiuong, "Chưa nhập số người.");
                f = false;
            }
            return f;
        }
        #endregion
    }
}
