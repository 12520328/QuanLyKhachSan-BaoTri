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
    class NhomDichVuBUS
    {
        private NhomDichVuDAL ndvDAL;

        public NhomDichVuBUS()
        {
            ndvDAL = new NhomDichVuDAL();
        }

        // Lấy danh sách nhóm dịch vụ.
        public DataTable LayDanhSachNhomDichVu()
        {
            return ndvDAL.LayDanhSachNhomDichvu();
        }

        //Thêm một nhóm dịch vụ vào cơ sở dữ liệu.
        public void ThemNhomDichVu(NhomDichVuDTO ndvDTO)
        {
            ndvDAL.ThemNhomDichvu(ndvDTO);
        }

        // Xóa một nhóm dịch vụ khỏi cơ sở dữ liệu.
        public void XoaNhomDichvu(NhomDichVuDTO ndvDTO)
        {
            ndvDAL.XoaNhomDichVu(ndvDTO);
        }

        // Sửa thông tin một vật tư.
        public void SuaNhomDichVu(NhomDichVuDTO ndvDTO)
        {
            ndvDAL.SuaNhomDichVu(ndvDTO);
        }
    }
}
