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
    public class KhachHangBUS
    {
        private KhachHangDAL khachHangDAL;       

        public KhachHangBUS()
        {
            khachHangDAL = new KhachHangDAL();
        }

        // Lấy danh sách khách hàng phụ thu.
        public DataTable LayDanhSachKhachHang()
        {
            return khachHangDAL.LayDanhSachKhachHang();
        }

        //Thêm một khách hàng vào cơ sở dữ liệu.
        public bool Insert(KhachHangDTO khachHangDTO)
        {
            if (khachHangDTO == null)
                return false;
            khachHangDAL.Insert(khachHangDTO);
            return true;
        }

        // Xóa một khách hàng khỏi cơ sở dữ liệu.
        public void Delete(int maKhachHang)
        {
            khachHangDAL.Delete(maKhachHang);
        }

        // Sửa thông tin một khách hàng.
        public bool Update(KhachHangDTO khachHangDTO)
        {
            if (khachHangDTO == null)
                return false;
            khachHangDAL.Update(khachHangDTO);
            return true;
        }

    }
}
