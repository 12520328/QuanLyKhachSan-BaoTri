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

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyKhachHang
{
    public partial class frmThemKhachHang : Form
    {
        public frmThemKhachHang()
        {
            InitializeComponent();
        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (isValidate())
            {
                KhachHangBUS khBUS = new KhachHangBUS();
                if (khBUS.Insert(GetKhachHang()))
                {
                    XtraMessageBox.Show("Thêm thông tin khách hàng thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
            }
        }

        private void Clear()
        {
            txtTenKhachHang.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtCMND.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            dtNgaySinh.EditValue = DateTime.Now;
        }
        private KhachHangDTO GetKhachHang()
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh.TenKhachHang = txtTenKhachHang.Text;
            kh.GioiTinh = cbbGioiTinh.EditValue == null ? "" : cbbGioiTinh.EditValue.ToString();
            kh.CMND = txtCMND.Text;
            if (dtNgaySinh.EditValue == System.DBNull.Value)
            {
                kh.NgaySinh = DateTime.Parse(dtNgaySinh.EditValue.ToString());
            }
            else
                kh.NgaySinh = (DateTime?) null;
        
            kh.SoDienThoai = string.IsNullOrEmpty(txtSDT.Text) ? "" : txtSDT.Text;
            kh.DiaChi = string.IsNullOrEmpty(txtDiaChi.Text) ? "" : txtDiaChi.Text;

            return kh;
        }


        #region Kiểm Tra Dữ Liệu
        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar <= 57 && (int)e.KeyChar >= 48 | (int)e.KeyChar == 8 | (int)e.KeyChar == 13)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Chỉ nhập số!!!", "Thông Báo Lỗi", MessageBoxButtons.OK);
                e.Handled = true;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar <= 57 && (int)e.KeyChar >= 48 | (int)e.KeyChar == 8 | (int)e.KeyChar == 13)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Chỉ nhập số!!!", "Thông Báo Lỗi", MessageBoxButtons.OK);
                e.Handled = true;
            }
        }

        ErrorProvider er = new ErrorProvider();
        private bool isValidate()
        {
            er.Clear();
            bool f = true;
            if(string.IsNullOrEmpty(txtTenKhachHang.Text))
            {
                er.SetError(txtTenKhachHang, "Chưa nhập tên khách hàng.");
                f = false;
            }
            else
            {
                if(string.IsNullOrEmpty(txtCMND.Text))
                {
                    er.SetError(txtCMND, "Chưa nhập số chứng minh nhân dân.");
                    f = false;
                }
            }
            return f;
        }

        #endregion
    }
}
