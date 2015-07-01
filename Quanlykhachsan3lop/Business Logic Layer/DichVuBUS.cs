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
    class DichVuBUS
    {
        private DichVuDAL dvDAL;

        public DichVuBUS()
        {
            dvDAL = new DichVuDAL();
        }

        // Lấy danh sách dịch vụ.
        public DataTable LayDanhSach()
        {
            return dvDAL.LayDanhSach();
        }
        public DataTable LayDanhSachTheoMaDichVu(int maDichVu)
        {
            return dvDAL.LayDanhSachTheoMaDichVu(maDichVu);
        }
        public DataTable LayDanhSachTheoNhomDichVu(int maNhomDichVu)
        {
            return dvDAL.LayDanhSachTheoNhomDichVu(maNhomDichVu);
        }

        //Thêm một dịch vụ vào cơ sở dữ liệu.
        public void insert(DichVuDTO dvDTO)
        {
            dvDAL.insert(dvDTO);
        }

        // Xóa một dịch vụ khỏi cơ sở dữ liệu.
        public void delete(DichVuDTO dvDTO)
        {
            dvDAL.delete(dvDTO);
        }

        // Sửa thông tin một dịch vụ.
        public void update(DichVuDTO dvDTO)
        {
            dvDAL.update(dvDTO);
        }
    }
}
