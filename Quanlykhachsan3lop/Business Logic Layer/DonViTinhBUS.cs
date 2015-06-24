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
    public class DonViTinhBUS
    {
        private DonViTinhDAL donViTinhDAL;       

        public DonViTinhBUS()
        {
            donViTinhDAL = new DonViTinhDAL();
        }

        // Lấy danh sách đơn vị tính phụ thu.
        public DataTable LayDanhSachDonViTinh()
        {
            return donViTinhDAL.LayDanhSachDonViTinh();
        }

        //Thêm một đơn vị tính vào cơ sở dữ liệu.
        public bool Insert(DonViTinhDTO donViTinhDTO)
        {
            if (donViTinhDTO == null)
                return false;
            donViTinhDAL.Insert(donViTinhDTO);
            return true;
        }

        // Xóa một đơn vị tính khỏi cơ sở dữ liệu.
        public void Delete(int maDonViTinh)
        {
            donViTinhDAL.Delete(maDonViTinh);
        }

        // Sửa thông tin một đơn vị tính.
        public bool Update(DonViTinhDTO donViTinhDTO)
        {
            if (donViTinhDTO == null)
                return false;
            donViTinhDAL.Update(donViTinhDTO);
            return true;
        }
    }
}
