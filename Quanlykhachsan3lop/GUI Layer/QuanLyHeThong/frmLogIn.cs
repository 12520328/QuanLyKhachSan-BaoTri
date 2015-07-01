using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Quanlykhachsan3lop.Business_Logic_Layer;
using Quanlykhachsan3lop.Data_Transfer_Object;
using Quanlykhachsan3lop.GUI_Layer.QuanLyHeThong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quanlykhachsan3lop.Màn_Hình
{
    public partial class frmLogIn : Form
    {
        NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
        ErrorProvider er = new ErrorProvider();

        public frmLogIn()
        {
            InitializeComponent();            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Đăng nhập bằng tài khoản trong cơ sở dữ liệu hoặc tài khoản "admin" với mật khẩu "admin"
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {                
                if ((nguoiDungBUS.KiemTraDangNhap(txtTenTaiKhoan.Text, txtMatKhau.Text)) || (txtTenTaiKhoan.Text == "admin" && txtMatKhau.Text == "admin"))
                {
                    this.Hide();
                    //Send thông tin tài khoản đăng nhập qua form chính  
                    frmMain.user = new NguoiDungDTO();
                    if (txtTenTaiKhoan.Text == "admin")
                    {
                        frmMain.user.LoaiNguoiDung = "QuanTriHeThong";

                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(nguoiDungBUS.LayLoaiNguoiDung(txtTenTaiKhoan.Text))
                            && !string.IsNullOrEmpty(nguoiDungBUS.LayHoTenNguoiDung(txtTenTaiKhoan.Text)))
                        {
                            frmMain.user.MaNguoiDung = nguoiDungBUS.LayMaNguoiDung(txtTenTaiKhoan.Text);
                            frmMain.user.HoVaTen = nguoiDungBUS.LayHoTenNguoiDung(txtTenTaiKhoan.Text);
                            frmMain.user.LoaiNguoiDung = nguoiDungBUS.LayLoaiNguoiDung(txtTenTaiKhoan.Text);
                        }
                    }
                    frmMain.user.MatKhau = txtMatKhau.Text;
                    frmMain.user.TenNguoiDung = txtTenTaiKhoan.Text;                  


                    Form f = new frmMain();
                    SplashScreenManager.ShowForm(typeof(SplashScreen1));
                    Thread.Sleep(4000);
                    SplashScreenManager.CloseForm();
                    f.ShowDialog();
                    
                }
                else
                {
                    XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông Báo");                                                       
                }
            }
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            this.Hide();
            using(Form f = new frmTaoTaiKhoan())
            {
                f.ShowDialog();
            }
            this.Show();
        }

        private bool IsValidate()
        {
            er.Clear();
            bool flag = true;
            if(txtTenTaiKhoan.Text == string.Empty)
            {
                er.SetError(txtTenTaiKhoan, "Bạn chưa nhập tên đăng nhập.");
                flag = false;
            }
            if(txtMatKhau.Text == string.Empty)
            {
                er.SetError(txtMatKhau,"Bạn chưa nhập mật khẩu.");
                flag = false;
            }
            return flag;
        }

        private void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
