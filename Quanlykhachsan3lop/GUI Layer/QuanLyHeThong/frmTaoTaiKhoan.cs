using DevExpress.XtraEditors;
using Quanlykhachsan3lop.Business_Logic_Layer;
using Quanlykhachsan3lop.Màn_Hình;
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
    public partial class frmTaoTaiKhoan : Form
    {
        
        ErrorProvider er = new ErrorProvider();//Báo lỗi khi nhập dữ liệu không hợp lệ
        NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
        bool isValidate = true;

        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }
        
        private void checkHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            //Hiển thị mật khẩu cho người dùng xem khi người dùng chọn "Hiển thị mật khẩu" 
            if(checkHienThiMatKhau.Checked == true)
            {
                txtMatKhau.Properties.UseSystemPasswordChar = false;
                txtNhapLaiMatKhau.Properties.UseSystemPasswordChar = false;                
            }
            else
            {
                txtMatKhau.Properties.UseSystemPasswordChar = true;
                txtNhapLaiMatKhau.Properties.UseSystemPasswordChar = true;    
            }
        }
        
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
      
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            //Đăng ký tài khoản mới
            if(IsValidate() == true && isValidate == true)//Kiểm tra dữ liệu nhập vào hợp lệ
            {
                //Có 3 loại người dùng: QuanTriHeThong, NhanVienLeTan, NguoiDungMoi
                nguoiDungBUS.Insert(new Data_Transfer_Object.NguoiDungDTO(txtHoTen.Text, txtTenDangNhap.Text, txtMatKhau.Text, "NguoiDungMoi"));
                XtraMessageBox.Show("Đăng ký tài khoản thành công.", "Thông Báo");
                RestoreDefault();
            }

        }

        //Kiểm tra dữ liệu nhập có hợp lệ
        private bool IsValidate()
        {
            er.Clear();
            bool flag = true;
            if (txtHoTen.Text == string.Empty)//Họ tên rỗng
            {
                er.SetError(txtHoTen, "Bạn chưa nhập họ tên người dùng.");
                flag = false;
            }
            if (txtTenDangNhap.Text == string.Empty)//Tên đăng nhập rỗng
            {
                er.SetError(txtTenDangNhap, "Bạn chưa nhập tên đăng nhập.");
                flag = false;
            }
            if (txtMatKhau.Text == string.Empty)//Mật khẩu rỗng
            {
                er.SetError(txtMatKhau, "Bạn chưa nhập mật khẩu.");
                flag = false;
            }
            if (txtNhapLaiMatKhau.Text == string.Empty)//Nhập lại mật khẩu rỗng
            {
                er.SetError(txtNhapLaiMatKhau, "Bạn chưa nhập mật khẩu.");
                flag = false;
            }
            return flag;
        }

        //Làm mới các control về mặc định
        private void RestoreDefault()
        {
            txtHoTen.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            txtNhapLaiMatKhau.Text = string.Empty;
            txtTenDangNhap.Text = string.Empty;
            checkHienThiMatKhau.Checked = false;
            er.Clear();
        }    

        //Kiểm tra, thông báo lỗi nếu mật khẩu nhập lại không đúng
        private void txtNhapLaiMatKhau_EditValueChanged(object sender, EventArgs e)
        {
            er.Clear();
            isValidate = true;
            if (txtMatKhau.Text != txtNhapLaiMatKhau.Text)//Mật khẩu nhập lại không đúng
            {
                er.SetError(txtNhapLaiMatKhau, "Nhập lại mật khẩu không đúng.");
                isValidate = false;
            }
        }


        //Kiểm tra, thông báo lỗi nếu tên đăng nhập tồn tại
        private void txtTenDangNhap_EditValueChanged(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            er.Clear();
            isValidate = true;
            if (nguoiDungBUS.TonTaiTenNguoiDung(txtTenDangNhap.Text) || txtTenDangNhap.Text ==  "admin")//Tên đăng nhập đã tồn tại
            {
                er.SetError(txtTenDangNhap, "Tên đăng nhập đã tồn tại.");
                isValidate = false;
            }
        }

        //Đăng ký khi nhấn Enter
        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangKy_Click(sender, e);
                e.Handled = true;
            }
        }

        //Chỉ cho nhập chữ ở họ tên
        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;  
        }
    }
}
