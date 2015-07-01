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
    class SuDungDichVuBUS
    {
        SuDungDichVuDAL sddvDAL = new SuDungDichVuDAL();
        public bool Insert(SuDungDichVuDTO sddvDTO)
        {
            sddvDAL.Insert(sddvDTO);
            return true;
        }

        // Xóa một dịch vụ khỏi cơ sở dữ liệu.
        public void Delete(int maSuDungDichVu)
        {
            sddvDAL.Delete(maSuDungDichVu);
        }

        // Sửa thông tin một dịch vụ.
        public bool Update(SuDungDichVuDTO sddvDTO)
        {
            sddvDAL.Update(sddvDTO);
            return true;
        }

        public DataTable DanhSachSuDungDichVu(int maPhong)
        {
            return sddvDAL.DSSuDungDichVu(maPhong);
        }

        public string LayTenKhachHang(int MaPhong)
        {
            return sddvDAL.LayTenKhachHang(MaPhong);
        }

        public DataTable LayDanhSachSuDungDichVu()
        {
            return sddvDAL.LayDanhSachSuDungDichVu();
        }
    }
}
