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

namespace Quanlykhachsan3lop.GUI_Layer.QuanLyHeThong
{
    public partial class frmDoiMatKhau : Form
    {       
        NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
        NguoiDungDTO nguoiDungDTO = new NguoiDungDTO();
        ErrorProvider er = new ErrorProvider();
        bool isValidate = true;


        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        public frmDoiMatKhau(NguoiDungDTO _nguoiDungDTO)
        {
            InitializeComponent();
            this.nguoiDungDTO = _nguoiDungDTO;
        }

        private void checkHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            //Hiển thị mật khẩu cho người dùng xem khi người dùng chọn "Hiển thị mật khẩu" 
            if (checkHienThiMatKhau.Checked == true)
            {
                txtMatKhauMoi.Properties.UseSystemPasswordChar = false;
                txtNhapLaiMatKhau.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhauMoi.Properties.UseSystemPasswordChar = true;
                txtNhapLaiMatKhau.Properties.UseSystemPasswordChar = true;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if(IsValidate() && isValidate == true)
            {
                if (txtTenDangNhap.Text == "admin")
                {
                    XtraMessageBox.Show("Cập nhật mật khẩu không thành công.",
                        "Không Thể Cập Nhật Tài Khoản Hệ Thống");
                    return;
                }
                if(!nguoiDungBUS.KiemTraDangNhap(txtTenDangNhap.Text,txtMatKhauCu.Text))//Kiểm tra đúng tên đăng nhập và mật khẩu cũ không
                {
                    XtraMessageBox.Show("Mật khẩu cũ không đúng.", "Thông Báo");
                    return;
                }
                else
                {                    
                    nguoiDungDTO.MatKhau = txtMatKhauMoi.Text;
                    nguoiDungBUS.Update(nguoiDungDTO);
                    XtraMessageBox.Show("Cập nhật mật khẩu thành công.", "Thông Báo");
                    this.Close();
                }
            }
        }


        //Kiểm tra dữ liệu nhập có hợp lệ
        private bool IsValidate()
        {
            er.Clear();
            bool flag = true;
            if (txtMatKhauMoi.Text == string.Empty)//Mật khẩu rỗng
            {
                er.SetError(txtTenDangNhap, "Bạn chưa nhập mật khẩu.");
                flag = false;
            }
            if (txtMatKhauCu.Text == string.Empty)//Mật khẩu rỗng
            {
                er.SetError(txtMatKhauCu, "Bạn chưa nhập mật khẩu.");
                flag = false;
            }
            if (txtNhapLaiMatKhau.Text == string.Empty)//Nhập lại mật khẩu rỗng
            {
                er.SetError(txtNhapLaiMatKhau, "Bạn chưa nhập mật khẩu.");
                flag = false;
            }
            return flag;
        }

        //Kiểm tra, thông báo lỗi nếu mật khẩu nhập lại không đúng
        private void txtNhapLaiMatKhau_EditValueChanged(object sender, EventArgs e)
        {
            er.Clear();
            isValidate = true;
            if (txtMatKhauMoi.Text != txtNhapLaiMatKhau.Text)//Mật khẩu nhập lại không đúng
            {
                er.SetError(txtNhapLaiMatKhau, "Nhập lại mật khẩu không đúng.");
                isValidate = false;
            }
        }


        //Đổi mật khẩu khi nhấn enter
        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDoiMatKhau_Click(sender, e);
                e.Handled = true;
            }
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = nguoiDungDTO.TenNguoiDung;            
        }
    }
}
