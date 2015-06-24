using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
using Quanlykhachsan3lop.Data_Transfer_Object;
using Quanlykhachsan3lop.GUI_Layer;
using Quanlykhachsan3lop.GUI_Layer.QuanLyDatPhong;
using Quanlykhachsan3lop.GUI_Layer.QuanLyHeThong;
using Quanlykhachsan3lop.GUI_Layer.QuanLyKhachHang;
using Quanlykhachsan3lop.GUI_Layer.QuanLyKhachSan;
using Quanlykhachsan3lop.GUI_Layer.ThongKe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Quanlykhachsan3lop.Màn_Hình
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static NguoiDungDTO user;//Lưu thông tin tài khoản đăng nhập


        public frmMain()
        {
            InitializeComponent();
        }

        Form GetMdiFormByName(string name)
        {
            return this.MdiChildren.FirstOrDefault(f => f.Name == name);
        }

        private void ShowWaitForm()
        {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            Thread.Sleep(1600);
            SplashScreenManager.CloseForm();
        }

        #region "Quản Lý Khách Sạn"
        private void btnPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmQuanLyPhong();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
            }
        }
        private void btnTangLau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmQuanLyTangLau();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        private void btnVatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmQuanLyVatTu();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        private void btnDichVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmQuanLyDichVu();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        private void btnBangGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmQuanLyBangGia();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        private void btnLoaiGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmQuanLyLoaiGia();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }

        }
        private void btnNhomDichVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmNhomDichVu();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        private void btnTinhTrangDatPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmTinhTrangDatPhong();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        private void btnTinhTrangPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmTinhTrangPhong();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        private void btnKhuyenMai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmKhuyenMai();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        private void btnDonViTinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmDonViTinh();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        private void btnChinhSachTraPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmChinhSachTraPhong();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        private void btnLoaiPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmQuanLyLoaiPhong();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        private void btnQuanLyVatTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmQuanLySuDungVatTu();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        #endregion

        #region "Quản Lý Đặt Phòng"
        private void btnDatPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmDatPhong();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong" && user.LoaiNguoiDung != "NhanVienLeTan")
                {
                    DisableControls(f);
                }
                f.Show();
            }
        }

        #endregion

        #region "Quản Lý Khách Hàng"
        private void btnDanhSachKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmQuanLyKhachHang();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong" && user.LoaiNguoiDung != "NhanVienLeTan")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
            }
        }
        #endregion

        #region "Thống Kê"
        private void btnDoanhThuThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmThongKeDoanhThuThang();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }

        private void btnDichVuAnKhach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmThongKe();
                f.Text = "Thống Kê Dịch Vụ Ăn Khách";
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }

        private void btnThongKeTinhTrangPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmThongKe();
                f.Text = "Thống Kê Tình Trạng Phòng";
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
                f.Show();
            }
        }
        #endregion


        #region "Quản Lý Hệ Thống"
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDanhSachNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string typeName = e.Item.Tag == null ? string.Empty : e.Item.Tag.ToString();
            Form f = GetMdiFormByName(typeName);
            if (f != null)
                f.BringToFront();
            else
            {
                ShowWaitForm();
                f = new frmDanhSachNguoiDung();
                f.Name = f.GetType().ToString();
                e.Item.Tag = f.Name;
                f.MdiParent = this;
                if (user.LoaiNguoiDung != "QuanTriHeThong")//Phân quyền
                {
                    DisableControls(f);
                }
                f.Show();
            }
        }

        private void btnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form f = new frmDoiMatKhau(user);
            f.ShowDialog();
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            Form f = new frmLogIn();
            f.ShowDialog();
        }

        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            item.Caption = string.Empty;
            if (user != null)
            {
                if (!string.IsNullOrEmpty(user.HoVaTen))
                    item.Caption = "Current User: " + user.HoVaTen;
                else
                    item.Caption = "Current User: Administrator";
            }
        }

        #region "Phân quyền người dùng"
        //Chức năng phần quyền ở mức độ cơ bản, cần cải thiện, nâng cấp lên có nhiều loại người dùng, phân
        //loại theo luật do người dùng đề ra
        //Phần mềm gồm 3 loại người dùng(cố định): Quản Trị Hệ Thống, Nhân Viên Lễ Tân, Người Dùng Mới
        //Quản Trị Hệ Thống : Xem, xóa, thêm mới và chỉnh sửa tất cả các chức năng.  
        //Nhân Viên Lễ Tân  : Thêm mới, xóa, chỉnh sửa các chức năng Quản Lý Đặt Phòng, Quản Lý Khách Hàng. Không được sử dụng chức năng Thống Kê
        //Người Dùng Mới    : Chỉ được xem. Không được sử dụng chức năng Thống Kê
               

        private void DisableControls(Form f)
        {
            foreach (Control c in f.Controls)
            {
                DisableChildControls(false, c);
            }
        }

        private void DisableChildControls(bool val, Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c is GridControl || c is UserControl || c is SimpleButton || c is TextEdit
                    || c is ComboBoxEdit || c is LookUpEdit || c is DateEdit)
                {
                    DisableChildControls(val, c);
                }
                else
                {
                    c.Enabled = val;
                }
            }
        }
        #endregion
    }
}
