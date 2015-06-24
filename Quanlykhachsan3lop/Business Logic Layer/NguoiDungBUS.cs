using DevExpress.XtraEditors;
using Quanlykhachsan3lop.Data_Access_Layer;
using Quanlykhachsan3lop.Data_Transfer_Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykhachsan3lop.Business_Logic_Layer
{
    public class NguoiDungBUS
    {
         private NguoiDungDAL nguoiDungDAL;

        public NguoiDungBUS()
        {
            nguoiDungDAL = new NguoiDungDAL();
        }

        // Lấy danh sách người dùng.
        public DataTable LayDanhSachNguoiDung()
        {
            return nguoiDungDAL.LayDanhSachNguoiDung();
        }

        //Thêm một người dùng vào cơ sở dữ liệu.
        public bool Insert(NguoiDungDTO nguoiDungDTO)
        {
            if(nguoiDungDAL.TonTaiTenNguoiDung(nguoiDungDTO.TenNguoiDung))
            {
                XtraMessageBox.Show("Tên đăng nhập đã tồn tại.", "Thông Báo");
                return false;
            }
            return nguoiDungDAL.Insert(nguoiDungDTO);
        }

        // Xóa một người dùng khỏi cơ sở dữ liệu.
        public bool Delete(NguoiDungDTO nguoiDungDTO)
        {
            return nguoiDungDAL.Delete(nguoiDungDTO);
        }

        // Sửa thông tin một người dùng.
        public bool Update(NguoiDungDTO nguoiDungDTO)
        {
            return nguoiDungDAL.Update(nguoiDungDTO);
        }

        // Lấy MaNguoiDung cuối cùng trong bảng.
        public object LayMaNguoiDungCuoiBang()
        {
            return nguoiDungDAL.LayMaNguoiDungCuoiBang();
        }

        //Kiểm tra TenNguoiDung có tồn tại không?
        public bool TonTaiTenNguoiDung(string TenNguoiDung)
        {
            return nguoiDungDAL.TonTaiTenNguoiDung(TenNguoiDung);
        }

        //Kiểm tra đăng nhập
        public bool KiemTraDangNhap(string TenNguoiDung, string MatKhau)
        {
            return nguoiDungDAL.KiemTraDangNhap(TenNguoiDung, MatKhau);
        }

        //Lấy loại người dùng
        public string LayLoaiNguoiDung(string TenNguoiDung)
        {
            return nguoiDungDAL.LayLoaiNguoiDung(TenNguoiDung);
        }
        //Lấy Ho ten người dùng
        public string LayHoTenNguoiDung(string TenNguoiDung)
        {
            return nguoiDungDAL.LayHoTenNguoiDung(TenNguoiDung);
        }

        //Lấy Mã người dùng
        public int LayMaNguoiDung(string TenNguoiDung)
        {
            return nguoiDungDAL.LayMaNguoiDung(TenNguoiDung);
        }
      
    }
}
